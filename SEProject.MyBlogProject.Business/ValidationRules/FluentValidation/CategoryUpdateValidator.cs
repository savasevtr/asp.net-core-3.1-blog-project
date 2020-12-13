using FluentValidation;
using SEProject.MyBlogProject.DTO.DTOs.CategoryDtos;

namespace SEProject.MyBlogProject.Business.ValidationRules.FluentValidation
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(I => I.Id).InclusiveBetween(0, int.MaxValue).WithMessage("Id alanı boş geçilemez");
            RuleFor(I => I.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
        }
    }
}