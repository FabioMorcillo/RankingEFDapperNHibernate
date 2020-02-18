using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

using Models;

namespace DapperFramework.Repositories
{
    public class DapperRepository : IRepository
    {
        public string Name() => "Dapper";

        private readonly SqlConnection _sqlConnection;

        public DapperRepository()
        {
            _sqlConnection = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = EF5; Integrated Security = True");
            _sqlConnection.Open();
        }

        public void Add(Customer customer)
        { 
            _sqlConnection.Execute(@"insert into dbo.Customers (name, email) values (@Name, @Email)", customer);
        }

        public void RemoveAll()
        {
            _sqlConnection.Execute("delete from dbo.Customers");
        }

        public IEnumerable<Customer> Query()
        {
            return _sqlConnection
                .Query<Customer>("SELECT id, name, email FROM CUSTOMERS");
        }

        public void AddAll(IEnumerable<Customer> customerList)
        {
            _sqlConnection.Execute(@"insert into dbo.Customers (name, email) values (@Name, @Email)", customerList);
        }

        public void Dispose()
        {
            _sqlConnection.Close();
            _sqlConnection.Dispose();
        }
    }
}
