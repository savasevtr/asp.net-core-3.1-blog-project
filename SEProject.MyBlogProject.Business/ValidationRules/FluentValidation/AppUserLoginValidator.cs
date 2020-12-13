using FluentValidation;
using SEProject.MyBlogProject.DTO.DTOs.AppUserDtos;

namespace SEProject.MyBlogProject.Business.ValidationRules.FluentValidation
{
    public class AppUserLoginValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginValidator()
        {
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Parola alanı boş geçilemez");
        }
    }
}