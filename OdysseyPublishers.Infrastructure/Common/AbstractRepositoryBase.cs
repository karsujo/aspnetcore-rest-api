using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
namespace OdysseyPublishers.Infrastructure.Common
{
    public abstract class AbstractRepositoryBase
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

        public DbCommand GetDbCommand(string commandQuery)
        {
            return new SqlCommand(commandQuery, (SqlConnection)GetDbConnection());
        }

        public IEnumerable<dynamic> QueryDatabase(string commandQuery)
        {
           var reader =  GetDbCommand(commandQuery).ExecuteReader();

            while(reader.Read())
            {
                yield return reader;
            }
        }

        public dynamic QueryDatabaseSingle(string commandQuery)
        {
            var reader = GetDbCommand(commandQuery).ExecuteReader();
            return reader[0];
        }

    }
}
