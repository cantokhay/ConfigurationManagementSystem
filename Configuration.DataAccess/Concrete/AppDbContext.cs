using Microsoft.EntityFrameworkCore;
using Configuration.Data.Entities;

namespace Configuration.DataAccess.Concrete
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CAN-TOKHAY-MASA\\CANTOKHAY ;Database=SecilCaseDB; TrustServerCertificate=True;");
        }

        public DbSet<ConfigurationEntity> Configurations { get; set; }

    }
}
