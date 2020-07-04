using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdysseyPublishers.Application.Common
{
    public interface IRepository
    {
        IEnumerable<T> QueryDatabase<T>( string query, DynamicParameters parameters);
        T QueryDatabaseSingle<T>( string query, DynamicParameters parameters);
        dynamic QueryDatabaseSingle(string query, DynamicParameters parameters);
        IEnumerable<dynamic> QueryDatabase(string query, DynamicParameters parameters);
    }
}
