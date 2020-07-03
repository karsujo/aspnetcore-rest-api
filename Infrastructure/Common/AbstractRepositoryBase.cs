using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Options;
using Application.Common;

namespace OdysseyPublishers.Infrastructure.Common
{
    public abstract class AbstractRepositoryBase : IRepository
    {
        private readonly PersistenceConfigurations _persistenceconfigurations;

        private readonly SqlConnection sqlConnection;
        public AbstractRepositoryBase(IOptions<PersistenceConfigurations> persistenceconfigurations)
        {
            _persistenceconfigurations = persistenceconfigurations.Value;
        }

        public DbConnection GetDbConnection()
        {

            return new SqlConnection(_persistenceconfigurations.ConnectionString);

        }


        public IEnumerable<T> QueryDatabase<T>(string commandQuery)
        {
            var connection = GetDbConnection();
            IEnumerable<T> result = null;
            using (connection)
            {
                result = connection.Query<T>(commandQuery);
            }

            return result.ToList();

        }

        public IEnumerable<dynamic> QueryDatabase(string command)
        {

            var connection = GetDbConnection();
            using (connection)
            {
                var sqlCommand = new SqlCommand(command, (SqlConnection)connection);
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    yield return reader;
                }
            }

        }

        public dynamic QueryDatabaseSingle(string command)
        {

            var connection = GetDbConnection();
            dynamic res = null;
            using (connection)
            {
                var sqlCommand = new SqlCommand(command, (SqlConnection)connection);
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    res = reader;
                }

            }
            return res;

        }

        public T QueryDatabaseSingle<T>(string commandQuery)
        {
            var connection = GetDbConnection();
            dynamic result = null;
            using (connection)
            {
                result = connection.Query<T>(commandQuery).FirstOrDefault();
            }

            return result;
        }

    }
}
