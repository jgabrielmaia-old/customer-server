namespace CustomerServer.Models
{
    public interface ICustomersDatabaseSettings {
        string CustomersCollectionName { get; set;}
        string ConnectionString { get; set;}
        string DatabaseName { get; set;}
    }
}