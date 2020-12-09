using SEProject.MyBlogProject.DTO.Interfaces;

namespace SEProject.MyBlogProject.DTO.DTOs.AppUserDtos
{
    public class AppUserLoginDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}