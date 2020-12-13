using SEProject.MyBlogProject.Entities.Concrete;

namespace SEProject.MyBlogProject.DTO.DTOs.CategoryDtos
{
    public class CategoryWithBlogsCountDto
    {
        public int BlogsCount { get; set; }
        public Category Category { get; set; }
    }
}