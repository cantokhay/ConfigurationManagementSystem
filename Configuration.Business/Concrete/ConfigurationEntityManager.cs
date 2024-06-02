using Configuration.Business.Abstract;
using Configuration.Data.Entities;
using Configuration.DataAccess.Abstract;
using System.Linq.Expressions;

namespace Configuration.Business.Concrete
{
    public class ConfigurationEntityManager : IConfigurationService
    {

        private IConfigurationEntityRepository _configurationEntityRepository;

        public ConfigurationEntityManager(IConfigurationEntityRepository configurationEntityRepository)
        {
            _configurationEntityRepository = configurationEntityRepository;
            LoadConfiguration();
        }

        private Dictionary<string, ConfigurationEntity> _configurationDictionary;

        public class ConfigurationReader
        {
            private readonly string _applicationName;
            private readonly int _refreshTimerInterval;
            private readonly string _connectionString;

            public ConfigurationReader(string applicationName, int refreshTimerInterval, string connectionString)
            {
                _applicationName = applicationName;
                _refreshTimerInterval = refreshTimerInterval;
                _connectionString = connectionString;
            }
        }

        ConfigurationReader reader = new ConfigurationReader("MyApplication", 60, "connectionString");

        private void LoadConfiguration()
        {
            _configurationDictionary = new Dictionary<string, ConfigurationEntity>();
            var configurations = _configurationEntityRepository.GetAll();
            foreach (var configuration in configurations)
            {
                _configurationDictionary.Add(configuration.Name, configuration);
            }
        }

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

        public IEnumerable<ConfigurationEntity> TSearch(string searchTerm)
        {
            return _configurationEntityRepository.GetAll()
                .Where(c => c.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            c.ApplicationName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            c.Type.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            c.Value.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public async Task TUpdateAsync(ConfigurationEntity entity)
        {
            entity.IsActive = true; //güncellenen entity'lerin default olarak aktif olmasını sağlıyorum.
            await _configurationEntityRepository.UpdateAsync(entity);
        }
    }
}
