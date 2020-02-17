using FluentNHibernate.Mapping;

using Models;

namespace NHibernateFramework.Mappings
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id);

            Map(x => x.Name)
                .Length(100)
                .Nullable();

            Map(x => x.Email)
                .Length(100)
                .Nullable();

            Table("Customers");
        }
    }
}
