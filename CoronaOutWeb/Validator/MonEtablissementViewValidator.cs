﻿using CoronaOutWeb.ExternalApiCall.VAT;
using CoronaOutWeb.ViewModel;
using FluentValidation;
using System.Linq;

namespace CoronaOutWeb.Validator
{
    public class MonEtablissementViewValidator : AbstractValidator<CreateEtablissementViewModel>
    {

        public MonEtablissementViewValidator(IVATService vatValidator)
        {
            RuleFor(x => x.Etab)
                .SetValidator(new EtablissementValidator(vatValidator));

        }

    }



}
