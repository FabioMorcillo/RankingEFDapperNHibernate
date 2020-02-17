using Dapper.FluentMap.Dommel.Mapping;

using Models;

namespace DapperFramework.Mappings
{
    public class CustomerMap : DommelEntityMap<Customer>
    {
        public CustomerMap()
        {
            Map(i => i.Id)
                .IsIdentity();

            Map(i => i.Name);
            Map(i => i.Email);

            ToTable("Customers");
        }
    }
}
