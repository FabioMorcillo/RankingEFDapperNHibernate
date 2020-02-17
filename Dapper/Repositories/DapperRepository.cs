using System.Collections.Generic;
using System.Data.SqlClient;

using Dapper;

using Dommel;

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
            _sqlConnection.Insert(customer);
        }

        public void RemoveAll()
        {
            _sqlConnection.DeleteAll<Customer>();
        }

        public IEnumerable<Customer> Query()
        {
            return _sqlConnection
                .Query<Customer>("SELECT * FROM CUSTOMERS")
                .AsList();
            /*
            return _sqlConnection
                .GetAll<Customer>()
                .ToList();
                */
        }

        public void Dispose()
        {
            _sqlConnection.Close();
        }
    }
}
