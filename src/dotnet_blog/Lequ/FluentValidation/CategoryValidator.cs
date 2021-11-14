using FluentValidation;
using Lequ.Models;

namespace Lequ.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{0} can't be empty");
            RuleFor(x => x.Description).NotEmpty().WithMessage("{0} can't be empty");
            RuleFor(x => x.Name).MinimumLength(1).WithMessage("Then lenth of the {0} must be bigger than {2}");
            RuleFor(x => x.Name).MinimumLength(50).WithMessage("Then lenth of the {0} must be small than {2}");
        }
    }
}
