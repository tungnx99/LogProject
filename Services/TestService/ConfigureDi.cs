using Microsoft.Extensions.DependencyInjection;
using NotificationService.Implements;
using NotificationService.Interfaces;

namespace NotificationService
{
    public static class ConfigureDi
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddTransient<ITestService, TestService>();
        }
    }
}
