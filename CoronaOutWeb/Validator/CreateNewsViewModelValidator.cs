using CoronaOutWeb.ViewModel;
using FluentValidation;


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
