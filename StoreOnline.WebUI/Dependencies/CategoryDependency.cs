using Microsoft.Extensions.DependencyInjection;
using StoreOnline.DAL.Interface;
using StoreOnline.DAL.Repositories;
using StoreOnline.Service.Contracts;
using StoreOnline.Service.Services;

namespace StoreOnline.WebUI.Dependencies
{
    public static class CategoryDependency
    {
        /// <summary>
        /// Dependencias del módulo Category //
        /// </summary>
        /// <param name="services">Servicio donde se registra las dependencias</param>
        public static void AddStudentDependency(this IServiceCollection services) 
        {
            //Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            //Services(BL)//
            services.AddTransient<ICategoryService, CategoryService>();

        }
    }
}
