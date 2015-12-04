using Autofac;
using Procent.Demo.AutofacModules.Core.Execution;

namespace Procent.Demo.AutofacModules.Infrastructure.Composition
{
    public class ExecutorsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(typeof (IExecuteAction).Assembly)
                .Where(x => typeof (IExecuteAction).IsAssignableFrom(x))
                .AsImplementedInterfaces();
        }
    }
}