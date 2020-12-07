using Microsoft.Extensions.DependencyInjection;
using SEProject.MyBlogProject.Business.Concrete;
using SEProject.MyBlogProject.Business.Interfaces;
using SEProject.MyBlogProject.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using SEProject.MyBlogProject.DataAccess.Interfaces;

namespace SEProject.MyBlogProject.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
        }
    }
}