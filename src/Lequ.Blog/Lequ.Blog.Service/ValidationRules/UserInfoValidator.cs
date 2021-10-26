using FluentValidation;
using Lequ.Blog.Model.Models;

namespace Lequ.Blog.Service.ValidationRules
{
    public class UserInfoValidator:AbstractValidator<UserInfo>
    {
        public UserInfoValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("User name can't be empty.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email can't be empty.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can't be empty");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("User name must bigger than 2");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Uer name must small than 50");
        }
    }
}
