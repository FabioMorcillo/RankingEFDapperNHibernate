using System.Collections.Generic;
using System.Linq;

using EntityFrameworkCoreFramework.Context;

using Models;

namespace EntityFrameworkCoreFramework.Repositories
{
    public class EFRepository : IRepository
    {
        public readonly EFDbContext Context = new EFDbContext();

        public string Name() => "Entity Framework Core";

        public void Add(Customer customer)
        {
            Context.Add(customer);

            Context.SaveChanges();
        }

        public void RemoveAll()
        {
            Context.Customers.RemoveRange(Context.Customers);

            Context.SaveChanges();
        }

        public IEnumerable<Customer> Query()
        {
            return Context
                .Customers
                .ToList();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
