using CoronaOutWeb.ExternalApiCall.VAT;
using FluentValidation;
using ModelesApi.ExternalApi;
using ModelesApi.POC;
using System;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace CoronaOutWeb.Validator
{
    public class EtablissementValidator : AbstractValidator<Etablissement>
    {
        private readonly IVATService vatValidator;

        public EtablissementValidator(IVATService vatValidator)
        {
            RuleFor(x => x.Type)
                .NotNull().WithMessage("Le type est obligatoire")
                .Must(TypeEstDansListe).WithMessage("Il n'y a que 4 valeurs possibles pour ce champ : Bar, Boite de Nuit, Salle de Concert, Cercle Etudiant");

            RuleFor(x => x.Nom)
                .NotNull().WithMessage("Le nom est obligatoire")
                .MaximumLength(50).WithMessage("Maximum 50 caractères pour le nom");

            RuleFor(x => x.NumeroTva)
                .NotNull().WithMessage("Le numéro de TVA est obligatoire")
                .MustAsync(NumTvaValide).WithMessage("Le numéro de TVA doit être valide, n'oubliez pas le code pays par exemple : BE0409.458.972");

            RuleFor(x => x.AdresseEmailPro)
                .NotNull().WithMessage("L'adresse mail professionnelle est obligatoire")
                .Must(MailEstValide).WithMessage("L'adresse mail doit être valide")
                .MaximumLength(255).WithMessage("Maximum 255 charactères pour l'adresse mail");

            RuleFor(x => x.ZoneTexteLibre)
                .MaximumLength(2000).WithMessage("Maximum 2000 charactères pour la zone de texte libre");

            RuleFor(x => x.CodePostal)
                .NotNull().WithMessage("Le code postal est obligatoire")
                .MaximumLength(20).WithMessage("Maximum 20 caractères pour le code postal");

            RuleFor(x => x.Ville)
                .NotNull().WithMessage("La ville est obligatoire")
                .MaximumLength(100).WithMessage("Maximum 100 caractères pour la ville");

            RuleFor(x => x.Pays)
                .NotNull().WithMessage("Le pays est obligatoire")
                .Must(PaysEstDansListe).WithMessage("Le Pays doit exister");

            RuleFor(x => x.Rue)
                .NotNull().WithMessage("La rue est obligatoire")
                .MaximumLength(100).WithMessage("Maximum 100 caractères pour la rue");

            RuleFor(x => x.NumeroBoite)
                .NotNull().WithMessage("Le numéro de boîte est obligatoire")
                .MaximumLength(20).WithMessage("Maximum 20 caractères pour le numéro de boîte");

            RuleFor(x => x.NumeroTelephone)
                .MaximumLength(25).WithMessage("Maximum 25 caractères pour le numéro de téléphone")
                .Must(NumTelEstValide).WithMessage("Le numéro de téléphone doit être valide");

            RuleFor(x => x.AdresseEmailEtablissement)
                .Must(MailEstValide).WithMessage("L'adresse mail doit être valide")
                .MaximumLength(255).WithMessage("Maximum 255 caractères pour l'adresse mail");

            RuleFor(x => x.AdresseSiteWeb)
                .Matches(@"^(www).([\w]+).[\w\.//]*$").WithMessage("L'adresse url doit être valide par ex : www.youplaboom.be/index");

            RuleFor(x => x.AdresseInstagram)
                .Matches(@"^(www).([\w]+).[\w\.//]*$").WithMessage("L'adresse url doit être valide par ex : www.youplaboom.be/index");

            RuleFor(x => x.AdresseFacebook)
                .Matches(@"^(www).([\w]+).[\w\.//]*$").WithMessage("L'adresse url doit être valide par ex : www.youplaboom.be/index");

            RuleFor(x => x.AdresseLinkedin)
                .Matches(@"^(www).([\w]+).[\w\.//]*$").WithMessage("L'adresse url doit être valide par ex : www.youplaboom.be/index");

            this.vatValidator = vatValidator;
        }

        public bool TypeEstDansListe(string newValue)
        {
            return new TypeEtablissement().types.Any(x => x.Equals(newValue));
        }

        public bool NumTelEstValide(string newValue)
        {
            if (newValue != null)
            {
                var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
                var phoneNumber = phoneNumberUtil.Parse(newValue, "BE");
                return phoneNumberUtil.IsValidNumber(phoneNumber);
            }
            return true;
        }

        public async Task<bool> NumTvaValide(string newValue, CancellationToken token)
        {
            VATResponseModele response = await vatValidator.GetVATResponse(newValue);
            return response.Valid;
        }

        public bool PaysEstDansListe(string newValue)
        {
            return new Pays().lPays.Any(x => x.Equals(newValue));
        }

        public bool MailEstValide(string newValue)
        {
            try
            {
                if (newValue != null)
                {
                    MailAddress email = new MailAddress(newValue);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
