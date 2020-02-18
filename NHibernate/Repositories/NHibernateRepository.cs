using System.Collections.Generic;
using System.Linq;
using Models;

using NHibernate;
using NHibernate.Linq;

using NHibernateFramework.Helpers;

namespace NHibernateFramework.Repositories
{
    public class NHibernateRepository : IRepository
    {
        private readonly ISession _session = FluentNHibernateHelper.OpenSession();

        public string Name() => "Fluent NHibernate";

        public void Add(Customer customer)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(customer);

                transaction.Commit();
            }
        }

        public void RemoveAll()
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Query<Customer>().Delete();

                transaction.Commit();
            }
        }

        public IEnumerable<Customer> Query()
        {
            return _session
                .Query<Customer>()
                .ToList();
        }

        public void AddAll(IEnumerable<Customer> customerList)
        {
            using (var transaction = _session.BeginTransaction())
            {
                foreach (var c in customerList)
                {
                    _session.Save(c);
                }

                transaction.Commit();
            }
        }

        public void Dispose()
        {
            _session.Dispose();
        }
    }
}
