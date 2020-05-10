using CoronaOutWeb.ViewModel;
using FluentValidation;


namespace CoronaOutWeb.Validator
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleViewModel>
    {
        public CreateRoleValidator()
        {
            RuleFor(x => x.RoleName)
                .NotNull().WithMessage("Ce champ est obligatoire");
        }
    }
}
