using System.Collections.Generic;
using System.Data.Common;

namespace OdysseyPublishers.Infrastructure.Common
{
    public interface IAbstractRepositoryBase
    {
        DbConnection GetDbConnection();
        IEnumerable<dynamic> QueryDatabase(string command);
        IEnumerable<T> QueryDatabase<T>(string commandQuery);
        dynamic QueryDatabaseSingle(string command);
        T QueryDatabaseSingle<T>(string commandQuery);
    }
}