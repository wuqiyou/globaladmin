using Framework.Core;
using Framework.Data;
using Framework.Sql;
using Framework.UoW;
using System.Configuration;

namespace Global.Registry
{
    public class DataStoreResolver : IDataStoreResolver
    {
        public const string CMSDataStoreKey = "CMSDataStore";

        public DataStoreResolver()
        { }

        public IDataStore Resolve(string dataStoreKey)
        {
            ArgumentValidator.IsNotNullOrEmpty("dataStoreKey", dataStoreKey);

            IConnectionString connectionString = GetConnectionString(dataStoreKey);

            switch (dataStoreKey)
            {
                case DataStoreResolver.CMSDataStoreKey:
                    return new CMSDataStore(connectionString, true);
                default:
                    return null;
            }
        }

        public static IConnectionString GetConnectionString(string dataStoreKey)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[dataStoreKey].ConnectionString;
            IConnectionString connection = ConnectionStringFactory.Build(connectionString);
            return connection;
        }
    }

}
