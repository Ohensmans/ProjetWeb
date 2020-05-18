using FluentValidation;
using IdentityServer.ViewModel;
using Microsoft.AspNetCore.Identity;
using ModelesApi.POC;

namespace IdentityServer.Validator
{
    public class RegisterValidator : AbstractValidator<RegisterViewModel>
    {
        private readonly UserManager<Utilisateur> userManager;

        public RegisterValidator(UserManager<Utilisateur> userManager)
        {
            this.userManager = userManager;

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Le mot de passe doit être rempli")
                .MinimumLength(6).WithMessage("Le mot de passe doit être composé de 6 caractères minimum")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$").WithMessage("Le mot de passe doit contenir au moins : une miniscule, une majuscule, un chiffre et un caractère spécial");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Les 2 champs mot de passes doivent être identiques");

            RuleFor(x => x.User)
                .SetValidator(new UtilisateurValidator(userManager.Users));
            
        }
    }
}