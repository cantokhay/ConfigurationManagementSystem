using Configuration.Business.Abstract;
using Configuration.Data.Entities;
using Configuration.DataAccess.Abstract;
using System.Linq.Expressions;

namespace Configuration.Business.Concrete
{
    public class ConfigurationReader : IConfigurationService
    {
        private readonly string _applicationName;
        private readonly int _refreshTimerInterval;
        private readonly string _connectionString;
        private IConfigurationEntityRepository _configurationEntityRepository;
        private Dictionary<string, ConfigurationEntity> _configurationDictionary;

        public ConfigurationReader(string applicationName, int refreshTimerInterval, string connectionString)
        {
            _applicationName = applicationName;
            _refreshTimerInterval = refreshTimerInterval;
            _connectionString = connectionString;
        }

        public IConfigurationEntityRepository configurationEntityRepository => _configurationEntityRepository;
        public async Task TAddAsync(ConfigurationEntity entity)
        {
            entity.IsActive = true; //yeni oluşturulan entity'lerin default olarak aktif olmasını sağlıyorum.
            await _configurationEntityRepository.AddAsync(entity);
        }

        public IEnumerable<ConfigurationEntity> TFindPredicate(Expression<Func<ConfigurationEntity, bool>> predicate)
        {
            return _configurationEntityRepository.FindPredicate(predicate);
        }

        public IEnumerable<ConfigurationEntity> TGetAll()
        {
            return _configurationEntityRepository.GetAll().Where(c => c.IsActive != false).ToList(); //aktif olanları getiriyorum.
        }

        public ConfigurationEntity TGetById(int id)
        {
            return _configurationEntityRepository.GetById(id);
        }

        public T TGetValue<T>(string key)
        {
            return _configurationEntityRepository.GetValue<T>(key);
        }

        public async Task TUpdateAsync(ConfigurationEntity entity)
        {
            entity.IsActive = true; //güncellenen entity'lerin default olarak aktif olmasını sağlıyorum.
            await _configurationEntityRepository.UpdateAsync(entity);
        }
    }
}
