using Configuration.DataAccess.Concrete;
using Configuration.UserInterface.Hubs;
using Configuration.UserInterface.SeedData;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<AppDbContext>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

//builder.Services.AddTransient<IConfigurationService, ConfigurationReader>();
//builder.Services.AddTransient<IConfigurationEntityRepository, ConfigurationEntityRepository>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

SeedData.Seed(app); //seeddata ile baþlatýlsýn.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ConfigurationEntity}/{action=Index}/{id?}");

app.MapHub<SignalRHub>("/signalrhub");

app.Run();
