using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SEProject.MyBlogProject.Business.Concrete;
using SEProject.MyBlogProject.Business.Interfaces;
using SEProject.MyBlogProject.Business.Utilities.FacadeTools;
using SEProject.MyBlogProject.Business.Utilities.JwtTool;
using SEProject.MyBlogProject.Business.Utilities.LogTool;
using SEProject.MyBlogProject.Business.ValidationRules.FluentValidation;
using SEProject.MyBlogProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using SEProject.MyBlogProject.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using SEProject.MyBlogProject.DataAccess.Interfaces;
using SEProject.MyBlogProject.DTO.DTOs.AppUserDtos;
using SEProject.MyBlogProject.DTO.DTOs.CategoryBlogDtos;
using SEProject.MyBlogProject.DTO.DTOs.CategoryDtos;
using SEProject.MyBlogProject.DTO.DTOs.CommentDtos;

namespace SEProject.MyBlogProject.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<BlogContext>();

            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDal, EfBlogRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentRepository>();

            services.AddScoped<IJwtService, JwtManager>();

            services.AddScoped<ICustomLogger, NLogAdapter>();
            services.AddScoped<IFacade, Facade>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginValidator>();
            services.AddTransient<IValidator<CategoryAddDto>, CategoryAddValidator>();
            services.AddTransient<IValidator<CategoryBlogDto>, CategoryBlogValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();
            services.AddTransient<IValidator<CommentAddDto>, CommentAddValidator>();
        }
    }
}