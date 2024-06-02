using AutoMapper;
using Configuration.Data.Entities;
using Configuration.UserInterface.VMs;

namespace Configuration.UserInterface.Mapping
{
    public class ConfigurationEntityMapping : Profile
    {
        public ConfigurationEntityMapping()
        {
            CreateMap<ConfigurationEntity, CreateConfigurationEntityVM>().ReverseMap();
            CreateMap<ConfigurationEntity, UpdateConfigurationEntityVM>().ReverseMap();
        }
    }
}
