using FluentValidation;
using IdentityServer.ViewModel;
using Microsoft.AspNetCore.Identity;
using ModelesApi.POC;
using System.Data;

namespace IdentityServer.Validator
{
    public class ModifierValidator : AbstractValidator<ModifierViewModel>
    {
        private readonly UserManager<Utilisateur> userManager;

        public ModifierValidator(UserManager<Utilisateur> userManager)
        {
            this.userManager = userManager;

            RuleFor(x => x.Password)
                .Must(NulOuLongueurMin).WithMessage("Le mot de passe doit être composé de 6 caractères minimum")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$").WithMessage("Le mot de passe doit contenir au moins : une miniscule, une majuscule, un chiffre et un caractère spécial");

            RuleFor(x => x.NewPassword)
                .Must(NulOuLongueurMin).WithMessage("Le mot de passe doit être composé de 6 caractères minimum")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$").WithMessage("Le mot de passe doit contenir au moins : une miniscule, une majuscule, un chiffre et un caractère spécial");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.NewPassword).WithMessage("Les 2 champs mot de passes doivent être identiques");

            RuleFor(x => x.User)
                .SetValidator(new UtilisateurValidator(userManager.Users));

        }

        public bool NulOuLongueurMin(string newValue)
        {
            if (newValue == null || newValue.Length >= 6)
                return true;
            else
                return false;
        }
    }
}
