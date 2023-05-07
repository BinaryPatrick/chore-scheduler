using House.Chore.Data.Models;
using House.Chore.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace House.Chore.Data
{
    public static class DataExtensions
    {

        public static void AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            string? houseChoreContextConnectionString = configuration.GetConnectionString("HouseChoreContext");
            _ = services.AddDbContext<HouseChoreContext>(builder => builder.UseSqlServer(houseChoreContextConnectionString, SqlServerOptionsAction));

            _ = services.AddScoped<TaskTemplateService>();
        }

        private static void SqlServerOptionsAction(SqlServerDbContextOptionsBuilder options)
        {
            _ = options.CommandTimeout(3);
            _ = options.EnableRetryOnFailure();
        }
    }
}