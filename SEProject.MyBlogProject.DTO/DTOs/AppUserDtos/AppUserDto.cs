using SEProject.MyBlogProject.DTO.Interfaces;

namespace SEProject.MyBlogProject.DTO.DTOs.AppUserDtos
{
    public class AppUserDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}