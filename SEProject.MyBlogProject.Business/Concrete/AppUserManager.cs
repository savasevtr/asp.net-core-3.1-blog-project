using SEProject.MyBlogProject.Business.Interfaces;
using SEProject.MyBlogProject.DataAccess.Interfaces;
using SEProject.MyBlogProject.DTO.DTOs.AppUserDtos;
using SEProject.MyBlogProject.Entities.Concrete;
using System.Threading.Tasks;

namespace SEProject.MyBlogProject.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IGenericDal<AppUser> _genericDal;
        
        public AppUserManager(IGenericDal<AppUser> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<AppUser> CheckUserAsync(AppUserLoginDto appUserLoginDto)
        {
            return await _genericDal.GetAsync(I => I.UserName == appUserLoginDto.UserName && I.Password == appUserLoginDto.Password);
        }

        public async Task<AppUser> FindByNameAsync(string userName)
        {
            return await _genericDal.GetAsync(I => I.UserName == userName);
        }
    }
}