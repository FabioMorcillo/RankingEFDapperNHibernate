using System;
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
            Console.WriteLine($"Processing {MethodInfo.GetCurrentMethod().Name} in {_repository.Name()}...");

            var start = DateTime.Now;

            for (var c = 1; c <= 1000; ++c)
            {
                var customer = _fixture
                    .Build<Customer>()
                    .Without(c => c.Id)
                    .Create();

                _repository.Add(customer);
            }

            var end = DateTime.Now;

            var elapsed = end - start;

            Results.Add(MethodInfo.GetCurrentMethod().Name, _repository.Name(), elapsed);
        }

        public void QueryCustomers()
        {
            Console.WriteLine($"Processing {MethodInfo.GetCurrentMethod().Name} in {_repository.Name()}...");

            var start = DateTime.Now;

            var list = _repository
                .Query()
                .ToList();

            Console.WriteLine($"Count -> {list.Count}");

            var end = DateTime.Now;

            var elapsed = end - start;

            Results.Add(MethodInfo.GetCurrentMethod().Name, _repository.Name(), elapsed);
        }


        public void Dispose()
        {
        }
    }
}
