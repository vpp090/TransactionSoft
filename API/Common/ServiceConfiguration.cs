using System.Data;
using Core.Interfaces;
using Infrastructure.Data.Repositories;
using Services;
using Services.Interfaces;
using Services.Utilities;

namespace API.Common
{
    public static class ServiceConfiguration
    {
        public static void AddProjectServices(this IServiceCollection services)
        {
            services.AddScoped<IMerchantRepository, MerchantRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IMerchantService, MerchantService>();
            services.AddScoped<ICsvReader<DataTable>, CsvReader>();
            services.AddSingleton(sp => sp.GetRequiredService<ILoggerFactory>().CreateLogger("DefaultLogger"));

            var serviceProvider = services.BuildServiceProvider();
        }
    }
}