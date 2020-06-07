using CoronaOutWeb.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaOutWeb.Validator
{
    public class CreateNewsViewModelValidator : AbstractValidator<CreateNewsViewModel>
    {
        public CreateNewsViewModelValidator()
        {
            RuleFor(x => x.news)
               .SetValidator(new NewsValidator());
        }
    }
}
