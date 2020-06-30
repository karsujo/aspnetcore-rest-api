using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using System.Linq;

namespace OdysseyPublishers.Infrastructure.Common
{
    public abstract class AbstractRepositoryBase<T>
    {
        private readonly string connString;

        private readonly SqlConnection sqlConnection;

        private bool isOpen = false; 
        public AbstractRepositoryBase(string connectionString)
        {
            connString = connectionString;
        }

        public DbConnection GetDbConnection()
        {
            if (!isOpen)
            {
                return new SqlConnection();
            }
            else return sqlConnection; 
        }

        public IList<T> QueryDatabase<T>(string commandQuery)
        {
            var connection = GetDbConnection();
            IEnumerable<T> result = null;
            using (connection)
            {
               result =  connection.Query<T>(commandQuery);
            }

            return result.ToList();
         
        }

        public T QueryDatabaseSingle<T>(string commandQuery)
        {
            var connection = GetDbConnection();
            dynamic result = null;
            using (connection)
            {
                result =  connection.Query<T>(commandQuery).FirstOrDefault();
            }

            return result;
        }

        public bool Exists(string commandQuery)
        {
            var connection = GetDbConnection();
            dynamic result = null;
            using (connection)
            {
                result = connection.Query(commandQuery).FirstOrDefault();
            }

            return result==null?false:true;
        }

    }
}
