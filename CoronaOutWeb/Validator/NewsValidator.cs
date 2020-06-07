using FluentValidation;
using ModelesApi.POC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaOutWeb.Validator
{
    public class NewsValidator : AbstractValidator<News>
    {
        public NewsValidator()
        {
            RuleFor(x => x.Titre)
                .NotNull().WithMessage("Le titre doit être complété");

            RuleFor(x => x.Message)
                .NotNull().WithMessage("Le corps de la news doit être complété");
        }
    }
}
