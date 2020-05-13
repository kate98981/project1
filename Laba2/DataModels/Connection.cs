using LinqToDB.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Laba2.DataModels
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }
    public class Connection : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

        public string DefaultConfiguration => "PostgreSQL";
        public string DefaultDataProvider => "PostgreSQL";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "myservice",
                        ProviderName = "PostgreSQL",
                        ConnectionString = @"User ID=postgres;Password=12345;Host=localhost;Port=5433;Database=myservice"
                    };
            }
        }
    }    
}
