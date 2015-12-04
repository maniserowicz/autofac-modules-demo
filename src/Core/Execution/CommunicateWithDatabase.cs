using System;

namespace Procent.Demo.AutofacModules.Core.Execution
{
    public class CommunicateWithDatabase : IExecuteAction
    {
        private readonly Func<DatabaseType, string> _connectionStringFactory;

        public CommunicateWithDatabase(Func<DatabaseType, string> connectionStringFactory)
        {
            _connectionStringFactory = connectionStringFactory;
        }

        public void Execute()
        {
            communicate(DatabaseType.Own);
            communicate(DatabaseType.External);
        }

        void communicate(DatabaseType databaseType)
        {
            string connection_string = _connectionStringFactory(databaseType);
            Console.WriteLine("communicating with DB {0}: {1}", databaseType, connection_string);
        }
    }

    public enum DatabaseType
    {
        Own,
        External
    }
}