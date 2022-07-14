namespace Application.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(validator => validator.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El nombre es requerido")
                .NotEmpty().WithMessage("El nombre no debe estár vacio")
                .MaximumLength(50).WithMessage("El nombre excede el límite de caracteres");

            RuleFor(validator => validator.FirstLastName)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El Apellido Paterno es requerido")
                .NotEmpty().WithMessage("El Apellido Paterno no debe estár vacio")
                .MaximumLength(50).WithMessage("El Apellido Paterno excede el límite de caracteres");

            RuleFor(validator => validator.SecondLastName)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage("El Apellido Materno es requerido")
               .NotEmpty().WithMessage("El Apellido Materno no debe estár vacio")
               .MaximumLength(50).WithMessage("El Apellido Materno excede el límite de caracteres");

            RuleFor(validator => validator.RFC)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage("El RFC es requerido")
              .NotEmpty().WithMessage("El RFC no debe estár vacio")
              .MaximumLength(20).WithMessage("El RFC excede el límite de caracteres");

            RuleFor(validator => validator.Email)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage("El correo es requerido")
              .NotEmpty().WithMessage("El correo no debe estár vacio")
              .EmailAddress().WithMessage("El correo es invalido")
              .MaximumLength(50).WithMessage("El correo excede el límite de caracteres");

            RuleFor(validator => validator.Address)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("El domicilio es requerido")
             .NotEmpty().WithMessage("El domicilio no debe estár vacio")
             .MaximumLength(150).WithMessage("El domicilio excede el límite de caracteres");
        }
    }
}
