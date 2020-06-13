using FluentValidation;
using ModelesApi.POC;
using System.Collections.Generic;


namespace CoronaOutWeb.Validator
{
    public class HoraireValidator : AbstractValidator<Horaire>
    {
        private List<string> lJours;

        public HoraireValidator()
        {
            this.lJours = new JoursSemaine().lJours;

            
            RuleFor(x => x.HeureOuverture)
                .NotNull().WithMessage("L'heure d'ouverture doit être complétée")
                .LessThan(x => x.HeureFermeture).WithMessage("L'heure d'ouverture doit précéder l'heure de fermeture");

            RuleFor(x => x.HeureFermeture)
                .NotNull().WithMessage("L'heure de fermeture doit être complétée")
                .GreaterThan(x => x.HeureOuverture).WithMessage("L'heure de fermeture doit être postérieure à l'heure d'ouverture");

            RuleFor(x => x.Jour)
                .NotNull().WithMessage("Le jour doit être complété")
                .Must(JourValide).WithMessage("Le jour doit correspondre à un jour de la semaine");
                
        }

        public bool JourValide(string newValue)
        {
            if (lJours.Contains(newValue))
                return true;
            else
                return false;
        }


    }
}
