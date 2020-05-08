using FluentValidation;
using Modeles;
using Modeles.POC;
using System.Collections.Generic;
using System.Linq;


namespace CoronaOutWeb.Validator
{
    public class UtilisateurValidator : AbstractValidator<Utilisateur>
    {
        private readonly IEnumerable<Utilisateur> _Utilisateurs;

        public UtilisateurValidator(IEnumerable<Utilisateur> Utilisateurs)
        {
            _Utilisateurs = Utilisateurs;

            RuleFor(x => x.Nom)
                .NotNull().WithMessage("Ce champ est obligatoire")
                .MaximumLength(50).WithMessage("Maximum 50 caractères")
                .Matches(@"^[a-zA-Z""'\s]*$").WithMessage("Les caractères spéciaux et les chiffres ne sont pas acceptés");

            RuleFor(x => x.Prenom)
                .NotNull().WithMessage("Ce champ est obligatoire")
                .MaximumLength(50).WithMessage("Maximum 50 caractères")
                .Matches(@"^[a-zA-Z""'\s]*$").WithMessage("Les caractères spéciaux et les chiffres ne sont pas acceptés");

            RuleFor(x => x.AdresseEmail)
                .NotNull().WithMessage("Ce champ est obligatoire")
                .MaximumLength(255).WithMessage("Maximum 255 caractères")
                .EmailAddress().WithMessage("L'adresse mail doit être valide")
                .Must(MailEstUnique).WithMessage("Cette adresse mail est déjà utilisée");

            RuleFor(x => x.NumeroTelephone)
                .MaximumLength(25).WithMessage("Maximum 25 caractères")
                .Matches(@"[0-9]{4,6}+/+[0-9\.\s]{6,18}").WithMessage("Les caractères spéciaux et les chiffres ne sont pas acceptés");

            RuleFor(x => x.Sexe)
                .NotNull().WithMessage("Ce champ est obligatoire")
                .Must(GenreEstDansListe).WithMessage("Ce genre n'est pas dans la liste");

            //Attention à finir

        }

        public bool MailEstUnique(Utilisateur user, string newValue)
        {
            return _Utilisateurs.All(u => u.Equals(user) || u.AdresseEmail != newValue);
        }

        public bool GenreEstDansListe(string newValue)

        {
            return new GenreUtilisateur().genres.Any(x => x.Equals(newValue));
        }



    }
}
