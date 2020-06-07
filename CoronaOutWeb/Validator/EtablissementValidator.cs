﻿using CoronaOutWeb.ExternalApiCall.VAT;
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
                .NotNull().WithMessage("Ce champ est obligatoire")
                .Must(TypeEstDansListe).WithMessage("Il n'y a que 4 valeurs possibles pour ce champ : Bar, Boite de Nuit, Salle de Concert, Cercle Etudiant");

            RuleFor(x => x.Nom)
                .NotNull().WithMessage("Ce champ est obligatoire")
                .MaximumLength(50).WithMessage("Maximum 50 caractères");

            RuleFor(x => x.NumeroTva)
                .NotNull().WithMessage("Ce champ est obligatoire");
                //.MustAsync(NumTvaValide).WithMessage("Le numéro de TVA doit être valide");

            RuleFor(x => x.AdresseEmailPro)
                .NotNull().WithMessage("Ce champ est obligatoire")
                .Must(MailEstValide).WithMessage("L'adresse mail doit être valide")
                .MaximumLength(255).WithMessage("Maximum 255 charactères");

            RuleFor(x => x.ZoneTexteLibre)
                .MaximumLength(2000).WithMessage("Maximum 2000 charactères");

            RuleFor(x => x.CodePostal)
                .NotNull().WithMessage("Ce champ est obligatoire")
                .MaximumLength(20).WithMessage("Maximum 20 caractères");

            RuleFor(x => x.Ville)
                .NotNull().WithMessage("Ce champ est obligatoire")
                .MaximumLength(100).WithMessage("Maximum 100 caractères");

            RuleFor(x => x.Pays)
                .NotNull().WithMessage("Ce champ est obligatoire")
                .Must(PaysEstDansListe).WithMessage("Le Pays doit exister");

            RuleFor(x => x.Rue)
                .NotNull().WithMessage("Ce champ est obligatoire")
                .MaximumLength(100).WithMessage("Maximum 100 caractères");

            RuleFor(x => x.NumeroBoite)
                .NotNull().WithMessage("Ce champ est obligatoire")
                .MaximumLength(20).WithMessage("Maximum 20 caractères");

            RuleFor(x => x.NumeroTelephone)
                .MaximumLength(25).WithMessage("Maximum 25 caractères")
                .Must(NumTelEstValide).WithMessage("Le numéro de téléphone doit être valide");

            RuleFor(x => x.AdresseEmailEtablissement)
                .Must(MailEstValide).WithMessage("L'adresse mail doit être valide")
                .MaximumLength(255).WithMessage("Maximum 255 caractères");

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
