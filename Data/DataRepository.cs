using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using AutoFixture;

using Models;

namespace Data
{
    public class DataRepository : IDisposable
    {
        private readonly IRepository _repository;
        private readonly IFixture _fixture;

        public DataRepository(IRepository repository)
        {
            _repository = repository;
            _fixture = new Fixture();

            _repository.RemoveAll();
        }

        public void AddCustomers()
        {
            Console.WriteLine($"Processing {nameof(AddCustomers)} in {_repository.Name()}...");

            var customerList = new List<Customer>();

            for (var c = 1; c <= 1_000; ++c)
            {
                var customer = _fixture
                    .Build<Customer>()
                    .Without(_ => _.Id)
                    .Create();

                customerList.Add(customer);
            }

            var start = DateTime.Now;

            customerList.ForEach(_ => _repository.Add(_));

            var end = DateTime.Now;

            var elapsed = end - start;

            Results.Add(nameof(AddCustomers), _repository.Name(), elapsed);
        }

        public void AddAllCustomers()
        {
            Console.WriteLine($"Processing {nameof(AddAllCustomers)} in {_repository.Name()}...");

            var customerList = new List<Customer>();

            for (var c = 1; c <= 1_000; ++c)
            {
                var customer = _fixture
                    .Build<Customer>()
                    .Without(_ => _.Id)
                    .Create();

                customerList.Add(customer);
            }

            var start = DateTime.Now;

            _repository.AddAll(customerList);

            var end = DateTime.Now;

            var elapsed = end - start;

            Results.Add(nameof(AddAllCustomers), _repository.Name(), elapsed);
        }

        public void QueryCustomers()
        {
            Console.WriteLine($"Processing {nameof(QueryCustomers)} in {_repository.Name()}...");

            var start = DateTime.Now;

            var list = _repository
                .Query()
                .ToList();

            var end = DateTime.Now;

            var elapsed = end - start;

            Console.WriteLine($"Count -> {list.Count}");

            Results.Add(nameof(QueryCustomers), _repository.Name(), elapsed);
        }


        public void Dispose()
        {
        }
    }
}
