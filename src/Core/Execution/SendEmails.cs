using System;

namespace Procent.Demo.AutofacModules.Core.Execution
{
    public class SendEmails : IExecuteAction
    {
        private readonly EmailConfiguration _configuration;

        public SendEmails(EmailConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Execute()
        {
            Console.WriteLine("Sending emails from {0}", _configuration.FromAddress);
        }
    }

    public class EmailConfiguration
    {
        public string FromAddress { get; private set; }

        public EmailConfiguration(string fromAddress)
        {
            FromAddress = fromAddress;
        }
    }
}