using SEProject.MyBlogProject.Entities.Concrete;

namespace SEProject.MyBlogProject.Business.Utilities.JwtTool
{
    public interface IJwtService
    {
        JwtToken GenerateJwt(AppUser appUser);
    }
}