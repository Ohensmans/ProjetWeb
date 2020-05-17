using CoronaOutWeb.ViewModel;
using FluentValidation;
using System.Data;

namespace CoronaOutWeb.Validator
{
    public class RegisterValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Password)
                .NotNull().WithMessage("Le mot de passe doit être rempli")
                .MinimumLength(6).WithMessage("Le mot de passe doit être composé de 6 caractères minimum")
                .Matches(@"([a-z])+([A-Z])+([0-9])+(\W)+$").WithMessage("Le mot de passe doit contenir au moins : une miniscule, une majuscule, un chiffre et un caractère spécial");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Les 2 champs mot de passes doivent être identiques");

        }
    }
}
