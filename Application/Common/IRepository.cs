using System;
using System.Collections.Generic;
using System.Text;

namespace OdysseyPublishers.Application.Common
{
    public interface IRepository
    {
        IEnumerable<T> QueryDatabase<T>( string query);
        T QueryDatabaseSingle<T>( string query);
        dynamic QueryDatabaseSingle(string query);
        IEnumerable<dynamic> QueryDatabase(string query);
    }
}
