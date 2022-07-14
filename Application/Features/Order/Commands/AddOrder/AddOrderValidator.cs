namespace Application.Features.Order.Commands.AddOrder
{
    public class AddOrderValidator : AbstractValidator<AddOrderCommand>
    {
        public AddOrderValidator()
        {
            RuleFor(validator => validator.OrderNumber)
                .Must(IsGreatTo1).WithMessage("Error: el numero de order debe ser mayor a 1");
        }

        private bool IsGreatTo1(int orderNumber)
        {
            return orderNumber >= 1;
        }
    }
}
