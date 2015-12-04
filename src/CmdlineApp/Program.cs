using System.Collections.Generic;
using Autofac;
using Procent.Demo.AutofacModules.Core.Execution;
using Procent.Demo.AutofacModules.Infrastructure;

namespace Procent.Demo.AutofacModules
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(typeof (IDetermineInfrastructureAssembly).Assembly);
            using (IContainer container = builder.Build())
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    var executors = scope.Resolve<IEnumerable<IExecuteAction>>();

                    foreach (var executor in executors)
                    {
                        executor.Execute();
                    }
                }
            }
        }
    }
}
