using FluentValidation;

namespace CleanCodeTemplate.Application;

public class CreateCustomerValidation : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerValidation()
    {
        RuleFor(x => x.Name)
                .NotNull().WithMessage("El nombre no puede ser nulo.")
                .NotEmpty().WithMessage("EL nombre no puede ser vacio");

        RuleFor(x => x.LastName)
                .NotNull().WithMessage("El Apellido no puede ser nulo.")
                .NotEmpty().WithMessage("EL Apellido no puede ser vacio");
    }
}
