using CoronaOutWeb.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaOutWeb.Validator
{
    public class EditRoleValidator : AbstractValidator<EditRoleViewModel>
    {
        public EditRoleValidator()
        {

            RuleFor(x => x.RoleName)
                .NotNull().WithMessage("Le champ RoleName est obligatoire");
        }
    }
}
