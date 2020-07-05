using Application.Common;
using Dapper;
using Microsoft.Extensions.Options;
using OdysseyPublishers.Application.Common;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace OdysseyPublishers.Infrastructure.Common
{

    //TODO: Does this need to inherit from IRepository?
    public class SqlRepositoryBase : IRepository
    {
        private readonly PersistenceConfigurations _persistenceConfigurations;

        public SqlRepositoryBase(IOptions<PersistenceConfigurations> persistenceconfigurations)
        {
            _persistenceConfigurations = persistenceconfigurations.Value;
        }

        public DbConnection GetDbConnection()
        {

            return new SqlConnection(_persistenceConfigurations.ConnectionString);

        }


        public IEnumerable<T> QueryDatabase<T>(string commandQuery, DynamicParameters parameters)
        {
            var connection = GetDbConnection();
            IEnumerable<T> result = null;
            using (connection)
            {
                result = connection.Query<T>(commandQuery, parameters);
            }

            return result;

        }

        public IEnumerable<dynamic> QueryDatabase(string command, DbParameterCollection parameters = null)
        {

            var connection = GetDbConnection();
            using (connection)
            {
                connection.Open();
                var sqlCommand = new SqlCommand(command, (SqlConnection)connection);
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        sqlCommand.Parameters.Add(parameter);
                    }
                }

                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    yield return reader;
                }
            }

        }

        public dynamic QueryDatabaseSingle(string command, DbParameterCollection parameters)
        {

            var connection = GetDbConnection();
            dynamic res = null;
            using (connection)
            {
                var sqlCommand = new SqlCommand(command, (SqlConnection)connection);

                foreach (var parameter in parameters)
                {
                    sqlCommand.Parameters.Add(parameter);
                }

                var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    res = reader;
                }

            }
            return res;

        }

        public T QueryDatabaseSingle<T>(string commandQuery, DynamicParameters parameters)
        {
            var connection = GetDbConnection();
            dynamic result = null;
            using (connection)
            {
                result = connection.Query<T>(commandQuery, parameters).FirstOrDefault();
            }

            return result;
        }


        //private T ExecuteGenericQuery<T>( string commandQuery, DynamicParameters parameters)
        //{
        //    var connection = GetDbConnection();
        //    dynamic result = null;

        //        if(typeof(T).Name == "Author")
        //        {
        //        using (connection)
        //        {
        //            result = connection.Query<AuthorEntity>(commandQuery, parameters).FirstOrDefault();
        //        }

        //        return _mapper.Map<Author>(result);
        //        }
        //        if(typeof(T).Name == "Book")
        //        {
        //        using (connection)
        //        {
        //            result = connection.Query<BookEntity>(commandQuery, parameters).FirstOrDefault();
        //        }
        //        return _mapper.Map<Book>(result);
        //        }

        //    return default(T);




        //}

    }
}
