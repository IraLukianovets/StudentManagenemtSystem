using Microsoft.Extensions.DependencyInjection;
using StudentSystem.API.Services;
using StudentSystem.API.Services.Absractions;

namespace StudentSystem.API.AppSettings
{
    public static class DiContainer
    {
        public static void RegisterDependecies(IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
        }
    }
}
