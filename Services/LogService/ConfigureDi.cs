using LogService.Implements;
using LogService.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LogService
{
    public static class ConfigureDi
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddScoped<IDebugService, DebugService>();
        }
    }
}
