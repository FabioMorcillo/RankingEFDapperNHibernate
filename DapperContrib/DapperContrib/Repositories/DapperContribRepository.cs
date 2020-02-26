using Dapper.Contrib.Extensions;
using Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DapperFramework.Repositories
{
    public class DapperContribRepository : IRepository
    {
        public string Name() => "Dapper Contrib";

        private readonly SqlConnection _sqlConnection;

        public DapperContribRepository()
        {
            _sqlConnection = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = EF5; Integrated Security = True");
            _sqlConnection.Open();
        }

        public void Add(Customer customer)
        {
            _sqlConnection.Insert(customer);
        }

        public void RemoveAll()
        {
            _sqlConnection.DeleteAll<Customer>();
        }

        public IEnumerable<Customer> Query()
        {
            return _sqlConnection.GetAll<Customer>();
        }

        public void AddAll(IEnumerable<Customer> customerList)
        {
            _sqlConnection.Insert(customerList);
        }

        public void Dispose()
        {
            _sqlConnection.Close();
            _sqlConnection.Dispose();
        }
    }
}