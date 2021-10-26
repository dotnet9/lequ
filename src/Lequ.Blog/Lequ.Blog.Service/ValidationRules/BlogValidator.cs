using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lequ.Blog.Service.ValidationRules
{
    public class BlogValidator : AbstractValidator<Model.ViewModels.BlogDto>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title can't be empty.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content can't be empty.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Image can't be empty");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Title must bigger than 5");
            RuleFor(x => x.Title).MaximumLength(150).WithMessage("Title must small than 150");
            RuleFor(x => x.Content).MinimumLength(5).WithMessage("Content must bigger than 5");
            RuleFor(x => x.Content).MaximumLength(2048).WithMessage("Content must small than 2048");
        }
    }
}
