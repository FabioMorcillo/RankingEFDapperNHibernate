using System;
using System.Collections.Generic;

namespace Models
{
    public interface IRepository : IDisposable
    {
        string Name();

        void Add(Customer customer);

        void RemoveAll();

        IEnumerable<Customer> Query();

        void AddAll(IEnumerable<Customer> customerList);
    }
}
