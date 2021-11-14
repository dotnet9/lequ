using FluentValidation;
using Lequ.ViewModels;
using Microsoft.Extensions.Localization;

namespace Lequ.ValidationRules
{
    public class CreateLinkViewModelValidator : AbstractValidator<CreateLinkViewModel>
    {
        public CreateLinkViewModelValidator(IStringLocalizer<CreateLinkViewModel> localizer)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{0} can't be empty");
            RuleFor(x => x.Url).NotEmpty().WithMessage("{0} can't be empty");
            RuleFor(x => x.Description).NotEmpty().WithMessage("{0} can't be empty");
            RuleFor(x => x.Name).MinimumLength(1).WithMessage("Then lenth of the {0} must be bigger than {2}");
            RuleFor(x => x.Name).MinimumLength(50).WithMessage("Then lenth of the {0} must be small than {2}");
        }
    }
}
