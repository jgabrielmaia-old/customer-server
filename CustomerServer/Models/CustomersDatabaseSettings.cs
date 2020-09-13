namespace CustomerServer.Models
{
    public class CustomersDatabaseSettings : ICustomersDatabaseSettings
    {
        public string CustomersCollectionName { get ; set ; }
        public string ConnectionString { get ; set ; }
        public string DatabaseName { get ; set ; }
    }
}