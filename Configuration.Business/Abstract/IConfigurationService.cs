using Configuration.Data.Entities;

namespace Configuration.Business.Abstract
{
    public interface IConfigurationService : IGenericService<ConfigurationEntity>
    {
        T TGetValue<T>(string key);
        IEnumerable<ConfigurationEntity> TSearch(string searchTerm);
    }
}
