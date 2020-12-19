using AutoMapper;
using SEProject.MyBlogProject.DTO.DTOs.BlogDtos;
using SEProject.MyBlogProject.DTO.DTOs.CategoryDtos;
using SEProject.MyBlogProject.DTO.DTOs.CommentDtos;
using SEProject.MyBlogProject.Entities.Concrete;
using SEProject.MyBlogProject.WebApi.Models;

namespace SEProject.MyBlogProject.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<BlogListDto, Blog>();
            CreateMap<Blog, BlogListDto>();

            CreateMap<BlogAddModel, Blog>();
            CreateMap<Blog, BlogAddModel>();

            CreateMap<BlogUpdateModel, Blog>();
            CreateMap<Blog, BlogUpdateModel>();

            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryListDto>();

            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();

            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();

            CreateMap<CommentListDto, Comment>();
            CreateMap<Comment, CommentListDto>();

            CreateMap<CommentAddDto, Comment>();
            CreateMap<Comment, CommentAddDto>();
        }
    }
}