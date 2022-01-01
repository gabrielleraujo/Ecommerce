using AutoMapper;
using Ecommerce.IoC.MapperProfiles;

namespace Ecommerce.Tests.Configurations
{
    public class AutoMapperConfiguration
    {
        static AutoMapperConfiguration()
        {
        }

        public static Profile[] Profiles { get; private set; }

        private static void SetProfiles()
        {
            Profiles = new Profile[]
            {
                new UserProfile(),
                new AddressProfile()
            };
        }

        public static MapperConfiguration Configure()
        {
            SetProfiles();
            return new MapperConfiguration(cfg => { cfg.AddProfiles(Profiles); });
        }
    }
}