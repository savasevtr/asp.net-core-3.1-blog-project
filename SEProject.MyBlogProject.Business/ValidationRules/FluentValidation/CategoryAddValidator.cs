using FluentValidation;
using SEProject.MyBlogProject.DTO.DTOs.CategoryDtos;

namespace SEProject.MyBlogProject.Business.ValidationRules.FluentValidation
{
    public class CategoryAddValidator : AbstractValidator<CategoryAddDto>
    {
        public CategoryAddValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
        }
    }
}