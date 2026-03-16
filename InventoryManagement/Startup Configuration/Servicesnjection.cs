using Entitites;
using System.Runtime.CompilerServices;
using InventoryManagement.DatabaseActions;
using Microsoft.EntityFrameworkCore;
namespace InventoryManagement.Startup_Configuration
{
    public static class Servicesinjection
    {
        public static void AddDBservices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddDbContext<InventoryDbContext>(options => { options.UseNpgsql("Host=localhost;Port=5432;Database=Inventory;Username=postgres;Password=admin"); });

            services.AddScoped<ProductDB>();
            services.AddScoped<Categorydb>();
        }
    }
}
