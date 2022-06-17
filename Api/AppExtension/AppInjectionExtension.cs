using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.AppExtension
{
    public static class AppInjectionExtension
    {
        public static void InjectionServicesScoped(this IServiceCollection services)
        {
            services.AddScoped(typeof(Core.Interfaces.Data.IRepository<,>), typeof(Infra.Data.Repository.Repository<,>));
            services.AddScoped<Api.Middleware.ApplicationContext>();
        }
        public static void InjectionServicesTransient(this IServiceCollection services)
        {
            services.AddTransient<Core.Interfaces.Services.IUserService, Infra.Service.UserService>();
            services.AddTransient<Core.Interfaces.Services.IJwtService, Infra.Service.JwtService>();
            services.AddTransient<Core.Interfaces.Services.IClientService, Infra.Service.ClientService>();
            services.AddTransient<Api.Middleware.ApplicationContext>();
            services.AddTransient<Helpers.IUserInfo, Helpers.UserInfo>();
        }
        public static void InjectionServicesSingleton(this IServiceCollection services)
        {

        }
    }
}
