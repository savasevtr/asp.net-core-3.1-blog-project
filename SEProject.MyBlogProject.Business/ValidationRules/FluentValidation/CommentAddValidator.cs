using FluentValidation;
using SEProject.MyBlogProject.DTO.DTOs.CommentDtos;

namespace SEProject.MyBlogProject.Business.ValidationRules.FluentValidation
{
    public class CommentAddValidator : AbstractValidator<CommentAddDto>
    {
        public CommentAddValidator()
        {
            RuleFor(I => I.AuthorName).NotEmpty().WithMessage("Ad alanı boş bırakılamaz");
            RuleFor(I => I.AuthorEmail).NotEmpty().WithMessage("Email alanı boş bırakılamaz");
            RuleFor(I => I.Description).NotEmpty().WithMessage("Açıklama alanı boş bırakılamaz");
        }
    }
}