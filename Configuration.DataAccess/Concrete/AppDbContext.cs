using Microsoft.EntityFrameworkCore;
using Configuration.Data.Entities;

namespace Configuration.DataAccess.Concrete
{
    public class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CAN-TOKHAY-MASA\\CANTOKHAY ;Database=SecilCaseDB; User Id=sa;Password=230491Can.; TrustServerCertificate=True;");
        }

        public DbSet<ConfigurationEntity> Configurations { get; set; }

    }
}
