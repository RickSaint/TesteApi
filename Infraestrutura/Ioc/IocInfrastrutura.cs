using Infraestrutura.Data.Contexts;
using Infraestrutura.Data.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestrutura.Ioc
{
    public static class IoCInfrastructure
    {
        private const string ConnectionStringKey = "CONNECTION_STRING";
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NewContext>(options =>
                        options.UseLazyLoadingProxies().UseSqlServer(configuration.GetValue<string>(ConnectionStringKey)));

            return services;
        }

        public static IServiceCollection AddRepositorios(this IServiceCollection services) =>
            services.AddScoped<IContatoRepository, ContatoRepository>();
    }
}
