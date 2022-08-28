using Mapster;
using TestMS.API.Controllers;

namespace TestMS
{
    public static class MapperConfig
    {
        public static readonly TypeAdapterConfig DefaultConfig = new();
        public static readonly TypeAdapterConfig UserConfig = new();

        // Needs to be changed while development progress
        static MapperConfig()
        {
            _ = DefaultConfig.Default
               .IgnoreNullValues(true)
               .NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);

            _ = UserConfig.ForType<UserDto, RefUser>()
              .IgnoreNullValues(true)
              .NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);
        }
    }
}