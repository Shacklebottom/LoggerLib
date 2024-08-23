using LoggerModule.BaseClasses;
using LoggerModule.Interfaces;
using LoggerModule.Objects;
using Microsoft.Data.SqlClient;

namespace LoggerModule.DerivedClasses
{
    public class DatabaseLogger : Logger, ILogger
    {
        private readonly SqlConnection _sqlConnection;

        private readonly string _tableName = "TestLogs";

        private readonly List<string> _fields = ["Date", "Message"];

        public DatabaseLogger()
        {
            var targetCatalog = "LoggerData";

            var connectionString = $"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog={targetCatalog};Data Source=.;TrustServerCertificate=true";
            _sqlConnection = new SqlConnection(connectionString);
        }

        public override void Chat(string message)
        {
            throw new NotImplementedException();
        }

        public override void Log(string message)
        {
            var logMessage = new Log()
            {
                Date = DateTime.Parse(Date),
                Message = message
            };

            Insert(logMessage);
        }

        public override void Log(string[] messages)
        {
            foreach (var message in messages)
            {
                var logMessage = new Log()
                {
                    Date = DateTime.Parse(Date),
                    Message = message
                };

                Insert(logMessage);
            }
        }

        public override void Log(string message, Exception exception)
        {
            //I'll implement this later!
            throw new NotImplementedException();
        }

        public override void Log(string[] message, Exception exception)
        {
            //I'll implement this later!
            throw new NotImplementedException();
        }

        private void Insert(Log logMessage)
        {
            var command = _sqlConnection.CreateCommand();

            var fieldNames = string.Join(',', _fields.Select(f => $"[{f}]"));
            var parmNames = string.Join(',', _fields.Select(f => $"@{f}"));

            command.CommandText = $"INSERT INTO {_tableName}({fieldNames}) VALUES({parmNames})";
            command.Parameters.AddRange([.. SqlParameters(logMessage)]);

            _sqlConnection.Open();
            command.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        private static List<SqlParameter> SqlParameters(Log logMessage)
        {
            List<SqlParameter> parameters =
            [
                new("@Date", logMessage.Date == default ? DBNull.Value : logMessage.Date),
                new("@Message", string.IsNullOrEmpty(logMessage.Message) ? DBNull.Value : logMessage.Message)
            ];

            return parameters;
        }
    }
}
