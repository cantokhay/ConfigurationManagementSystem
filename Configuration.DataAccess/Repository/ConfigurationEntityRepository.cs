using Configuration.Data.Entities;
using Configuration.DataAccess.Abstract;
using Configuration.DataAccess.Concrete;

namespace Configuration.DataAccess.Repository
{
    public class ConfigurationEntityRepository : GenericRepository<ConfigurationEntity>, IConfigurationEntityRepository
    {
        private readonly AppDbContext _context;

        public ConfigurationEntityRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public T GetValue<T>(string key)
        {
            var entity = _context.Configurations.FirstOrDefault(c => c.IsActive && c.Name == key);
            return (T)Convert.ChangeType(entity.Value, typeof(T));
        }
    }

}