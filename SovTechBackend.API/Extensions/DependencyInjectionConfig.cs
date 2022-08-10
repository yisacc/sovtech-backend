using SovTechBackend.Service.categories;
using SovTechBackend.Service.People;
using Microsoft.Extensions.DependencyInjection;

namespace SovTechBackend.API.Extensions
{
    public static class DependencyInjectionConfig
    {
        public static void AddScope(IServiceCollection services)
        {
            //Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<IJokeService, JokeService>();

        }
    }
}
