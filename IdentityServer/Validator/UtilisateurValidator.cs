using FluentValidation;
using ModelesApi.POC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace IdentityServer.Validator
{
    public class UtilisateurValidator : AbstractValidator<Utilisateur>
    {
        private readonly IEnumerable<Utilisateur> _Utilisateurs;

        public UtilisateurValidator(IEnumerable<Utilisateur> Utilisateurs)
        {
            _Utilisateurs = Utilisateurs;

            RuleFor(x => x.Nom)
                .NotNull().WithMessage("le champ 'Nom' est obligatoire")
                .MaximumLength(50).WithMessage("Maximum 50 caractères")
                .Matches(@"^[a-zA-Z""'\s]*$").WithMessage("Les caractères spéciaux et les chiffres ne sont pas acceptés");

            RuleFor(x => x.Prenom)
                .NotNull().WithMessage("Le champ 'Prénom'est obligatoire")
                .MaximumLength(50).WithMessage("Maximum 50 caractères")
                .Matches(@"^[a-zA-Z""'\s]*$").WithMessage("Les caractères spéciaux et les chiffres ne sont pas acceptés");

            RuleFor(x => x.UserName)
                .NotNull().WithMessage("Le champ 'Email' est obligatoire")
                .MaximumLength(255).WithMessage("Maximum 255 caractères")
                .Must(MailEstValide).WithMessage("L'adresse mail doit être valide")
                .Must(MailEstUnique).WithMessage("Cette adresse mail est déjà utilisée");

            RuleFor(x => x.PhoneNumber)
                .MaximumLength(25).WithMessage("Maximum 25 caractères")
                .Matches(@"^[0-9\.\\+]*$").WithMessage("Les caractères spéciaux ainsi que les lettres ne sont pas acceptés")
                .Must(NumTelEstValide).WithMessage("Le numéro de gsm doit être valide");

            RuleFor(x => x.Sexe)
                .NotNull().WithMessage("Le champ 'Genre' est obligatoire")
                .Must(GenreEstDansListe).WithMessage("Ce genre n'est pas dans la liste");

            RuleFor(x => x.DateNaissance)
                .NotNull().WithMessage("Le champ 'Date de Naissance' est obligatoire");

            RuleFor(x => x.estProfessionel)
                .NotNull().WithMessage("Le champ 'Professionel' est obligatoire");

        }

        public bool MailEstUnique(Utilisateur user, string newValue)
        {
            return _Utilisateurs.All(u => u.Equals(user) || u.Email != newValue);
        }

        public bool MailEstValide(string newValue)
        {
            try
            {
                MailAddress email = new MailAddress(newValue);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool GenreEstDansListe(string newValue)
        {
            return new GenreUtilisateur().genres.Any(x => x.Equals(newValue));
        }

        public bool NumTelEstValide(string newValue)
        {
            try
            {
                var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
                var phoneNumber = phoneNumberUtil.Parse(newValue,"BE");
                return phoneNumberUtil.IsValidNumber(phoneNumber);
            }
            catch (PhoneNumbers.NumberParseException)
            {
                return false;
            }
        }

        public bool DateBonFormat(string newValue)
        {
            return new GenreUtilisateur().genres.Any(x => x.Equals(newValue));
        }



    }
}