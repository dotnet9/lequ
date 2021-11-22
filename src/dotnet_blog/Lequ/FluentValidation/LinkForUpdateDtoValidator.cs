using FluentValidation;
using Lequ.ViewModels;
using Microsoft.Extensions.Localization;

namespace Lequ.FluentValidation;

public class LinkForUpdateDtoValidator : AbstractValidator<LinkForUpdateDto>
{
	public LinkForUpdateDtoValidator(IStringLocalizer<LinkForUpdateDtoValidator> localizer)
	{
		RuleFor(x => x.Name)
			.NotEmpty().WithMessage(localizer["NameNotEmpty"])
			.MaximumLength(20).WithMessage(localizer["NameMaximumLength"]);
		RuleFor(x => x.Url)
			.NotEmpty().WithMessage(localizer["UrlNotEmpty"])
			.MaximumLength(100).WithMessage(localizer["UrlMaximumLength"]);
		RuleFor(x => x.Description)
			.NotEmpty().WithMessage(localizer["DescriptionNotEmpty"])
			.MaximumLength(500).WithMessage(localizer["DescriptionMaximumLength"]);
	}
}