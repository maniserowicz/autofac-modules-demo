using System;
using System.Configuration;
using Autofac;
using Procent.Demo.AutofacModules.Core.Execution;

namespace Procent.Demo.AutofacModules.Infrastructure.Composition
{
    public class DatabaseCommunicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var local_conn_string = ConfigurationManager.ConnectionStrings["local-db"].ConnectionString;
            var external_conn_string = ConfigurationManager.ConnectionStrings["external-db"].ConnectionString;

            builder.Register(ctx => local_conn_string).Keyed<string>(DatabaseType.Own);
            builder.Register(ctx => external_conn_string).Keyed<string>(DatabaseType.External);
            builder.Register<Func<DatabaseType, string>>(ctx =>
            {
                var cc = ctx.Resolve<IComponentContext>();
                return dbType => cc.ResolveKeyed<string>(dbType);
            });
        }
    }
}