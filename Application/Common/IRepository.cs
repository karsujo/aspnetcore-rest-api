using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace OdysseyPublishers.Application.Common
{
    public interface IRepository
    {
        IEnumerable<T> QueryDatabase<T>( string query, DynamicParameters parameters);
        T QueryDatabaseSingle<T>( string query, DynamicParameters parameters);
        dynamic QueryDatabaseSingle(string query, DbParameterCollection parameters);
        IEnumerable<dynamic> QueryDatabase(string query, DbParameterCollection parameters);
    }
}
