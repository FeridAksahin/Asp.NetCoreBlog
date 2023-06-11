using Blog.AdminPanel.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.AdminPanel.Validation
{
    internal class AboutValidator : AbstractValidator<AboutViewModel>
    {
        public AboutValidator()
        {
            RuleFor(x => x.AboutText).NotEmpty()
               .WithMessage("AboutText must not be empty.");
        }
    }
}
