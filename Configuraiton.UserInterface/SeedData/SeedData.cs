using Configuration.Data.Entities;
using Configuration.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Configuration.UserInterface.SeedData
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                AppDbContext context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.Migrate();

                if (!context.Configurations.Any())
                {
                    context.Configurations.AddRange(
                        new ConfigurationEntity()
                        {
                            ApplicationName = "SERVICE-A",
                            Name = "SiteName",
                            Type = "string",
                            Value = "soty.io",
                            IsActive = true
                        },
                        new ConfigurationEntity()
                        {
                            ApplicationName = "SERVICE-B",
                            Name = "IsBasketEnabled",
                            Type = "bool",
                            Value = "1",
                            IsActive = true
                        },
                        new ConfigurationEntity()
                        {
                            ApplicationName = "SERVICE-A",
                            Name = "MaxItemCount",
                            Type = "int",
                            Value = "50",
                            IsActive = false
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}
