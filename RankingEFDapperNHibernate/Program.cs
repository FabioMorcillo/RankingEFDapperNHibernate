using System;

using DapperFramework.Repositories;

using Data;

using Models;

using NHibernateFramework.Repositories;

namespace RankingEFDapperNHibernate2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var efRepository = new EFRepository())
            using (var dataRepository = new DataRepository(efRepository))
            {
                dataRepository.AddCustomers();

                dataRepository.QueryCustomers();
            }

            Console.WriteLine();

            using (var nHibernateRepository = new NHibernateRepository())
            using (var dataRepository = new DataRepository(nHibernateRepository))
            {
                dataRepository.AddCustomers();

                dataRepository.QueryCustomers();
            }

            Console.WriteLine();

            using (var dapperRepository = new DapperRepository())
            using (var dataRepository = new DataRepository(dapperRepository))
            {
                dataRepository.AddCustomers();

                dataRepository.QueryCustomers();
            }

            Results.Show();
        }
    }
}
