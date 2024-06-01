using Configuration.Data.Entities;

namespace Configuration.DataAccess.Abstract
{
    public interface IConfigurationEntityRepository : IGenericRepository<ConfigurationEntity>
    {
        T GetValue<T>(string key);
    }
}
