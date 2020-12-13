using SEProject.MyBlogProject.DTO.DTOs.CategoryBlogDtos;
using SEProject.MyBlogProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.Business.Interfaces
{
    public interface IBlogService : IGenericService<Blog>
    {
        Task<List<Blog>> GetAllSortedByPostedTimeAsync();
        Task AddToCategoryAsync(CategoryBlogDto categoryBlogDto);
        Task RemoveFromCategoryAsync(CategoryBlogDto categoryBlogDto);
    }
}