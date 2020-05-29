using CoronaOutWeb.ExternalApiCall.VAT;
using CoronaOutWeb.ViewModel;
using FluentValidation;
using System.Linq;

namespace CoronaOutWeb.Validator
{
    public class MonEtablissementViewValidator : AbstractValidator<MonEtablissementViewModel>
    {
        private int NOMBREPHOTOMAX = 5;

        public MonEtablissementViewValidator(IVATService vatValidator)
        {
            RuleFor(x => x.Etab)
                .SetValidator(new EtablissementValidator(vatValidator));

            RuleFor(x => x.Photos)
                .Must(coll => coll.Count() <= NOMBREPHOTOMAX);
        }

    }
}
