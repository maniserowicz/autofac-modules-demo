using System.Configuration;
using Autofac;
using Procent.Demo.AutofacModules.Core.Execution;

namespace Procent.Demo.AutofacModules.Infrastructure.Composition
{
    public class SendingEmailsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var email_config = new EmailConfiguration(ConfigurationManager.AppSettings["email-from"]);
            builder.RegisterInstance(email_config)
                .SingleInstance();
        }
    }
}