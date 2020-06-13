using FluentValidation;
using ModelesApi.POC;

namespace CoronaOutWeb.Validator
{
    public class NewsValidator : AbstractValidator<News>
    {
        public NewsValidator()
        {
            RuleFor(x => x.Titre)
                .NotNull().WithMessage("Le titre doit être complété");

            RuleFor(x => x.Message)
                .NotNull().WithMessage("Le corps de la news doit être complété");
        }
    }
}
