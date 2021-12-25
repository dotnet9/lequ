using FluentValidation;
using Lequ.ViewModels;

namespace Lequ.FluentValidation;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
	public LoginDtoValidator()
	{
		RuleFor(x => x.Account).NotEmpty().WithMessage("{0} can't be empty");
		RuleFor(x => x.Account).MinimumLength(3).WithMessage("Then lenth of the {0} must be bigger than {2}");
		RuleFor(x => x.Account).MaximumLength(50).WithMessage("Then lenth of the {0} must be bigger than {2}");
		RuleFor(x => x.Password).NotEmpty().WithMessage("{0} can't be empty");
		RuleFor(x => x.Password).MinimumLength(3).WithMessage("Then lenth of the {0} must be small than {2}");
		RuleFor(x => x.Password).MaximumLength(20).WithMessage("Then lenth of the {0} must be bigger than {2}");
	}
}