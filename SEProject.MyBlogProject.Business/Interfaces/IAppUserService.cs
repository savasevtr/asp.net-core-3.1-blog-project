using SEProject.MyBlogProject.DTO.DTOs.AppUserDtos;
using SEProject.MyBlogProject.Entities.Concrete;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<AppUser> CheckUserAsync(AppUserLoginDto appUserLoginDto);
        Task<AppUser> FindByNameAsync(string userName);
    }
}