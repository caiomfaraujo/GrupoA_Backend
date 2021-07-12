using System;
using MySqlConnector;

namespace Domain
{
    public class MySqlSettings
    {
        public class MySqlDB : IDisposable
        {
            public MySqlConnection Connection { get; }

            public MySqlDB(string connectionString)
            {
                Connection = new MySqlConnection(connectionString);
            }

            public void Dispose() => Connection.Dispose();
        }
    }
}
