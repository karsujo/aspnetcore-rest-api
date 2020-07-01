using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace OdysseyPublishers.Infrastructure.Common
{
    public abstract class AbstractRepositoryBase<T> : IRepository<T>, IAbstractRepositoryBase
    {
        private readonly string connString;

        private readonly SqlConnection sqlConnection;
        public AbstractRepositoryBase(string connectionString)
        {
            connString = connectionString;
        }

        public DbConnection GetDbConnection()
        {

            return new SqlConnection(connString);

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
