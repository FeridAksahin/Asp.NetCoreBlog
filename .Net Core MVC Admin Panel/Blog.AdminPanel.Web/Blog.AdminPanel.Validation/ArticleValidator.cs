using Blog.AdminPanel.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.AdminPanel.Validation
{
    public class ArticleValidator : AbstractValidator<ArticleViewModel>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty()
               .WithMessage("Category must not be empty.");


            RuleFor(x => x.Text).NotEmpty()
                .WithMessage("Password must not be empty.")
                .MinimumLength(30)
                .WithMessage("The article minumum length 30 character.");

            RuleFor(r => r.Header).NotEmpty().WithMessage("Header must not be empty.")
                .MaximumLength(60)
                .WithMessage("The article header minumum length 60 character."); ;
        }
    }
}
