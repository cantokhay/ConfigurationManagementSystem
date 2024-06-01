using Configuration.Data.Entities;
using Configuration.DataAccess.Abstract;

namespace Configuration.Business.Abstract
{
    public interface IConfigurationService : IGenericService<ConfigurationEntity>
    {
        T TGetValue<T>(string key);
    }
}
