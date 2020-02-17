using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

using DapperFramework.Mappings;

namespace DapperFramework.Helpers
{
    public static class FluentDapperHelper
    {
        public static void Open()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new CustomerMap());
                config.ForDommel();
            });
        }
    }
}
