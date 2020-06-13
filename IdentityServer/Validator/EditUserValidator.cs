using FluentValidation;
using IdentityServer.ViewModel.Administration;
using Microsoft.AspNetCore.Identity;
using ModelesApi.POC;


namespace IdentityServer.Validator
{
    public class EditUserValidator : AbstractValidator<EditUserViewModel>
    {


        public EditUserValidator(UserManager<Utilisateur> userManager)
        {
            RuleFor(x => x.User)
                .SetValidator(new UtilisateurValidator(userManager.Users));

        }
    }
}
