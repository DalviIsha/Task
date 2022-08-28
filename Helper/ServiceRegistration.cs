using TestMS.API.Interface;
using TestMS.API.Service;
using TestMS.Domain.Interface;
using TestMS.Infrastructure.Service;

namespace TestMS.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthentication, Authentication>();
            services.AddScoped<ICustomRepo, CustomRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IUserQueryRepo, UserQueryRepo>();
            return services;
        }
    }
}