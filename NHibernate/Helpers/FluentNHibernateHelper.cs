using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

using NHibernate;
using NHibernate.Tool.hbm2ddl;

using NHibernateFramework.Mappings;

namespace NHibernateFramework.Helpers
{
    public static class FluentNHibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                  .ConnectionString("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EF5;Integrated Security=True")
                )
               .Mappings(m =>
                          m.FluentMappings
                              .AddFromAssemblyOf<CustomerMap>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                .Create(false, false))
                .BuildSessionFactory();
            
            return sessionFactory.OpenSession();
        }
    }
}
