using Domain.Bases;
using Infra;
using Infra.Bases;
using IobMovieUserAPI.Business;
using IobMovieUserAPI.Business.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Service;
using Service.Implementation;

namespace IobMovieUserAPI.Configurations
{
    public static class DependecyInjectionConfig
    {
        public static void ConfigDI(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IMovieBusiness, MovieBusinessImplementation>();
            services.AddScoped<ILoginBusiness, LoginBusinessImplementation>();

            services.AddTransient<ITokenService, TokenService>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }
    }
}
