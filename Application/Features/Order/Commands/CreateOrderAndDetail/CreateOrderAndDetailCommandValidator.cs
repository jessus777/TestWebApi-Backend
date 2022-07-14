namespace Application.Features.Order.Commands.CreateOrderAndDetail
{
    public class CreateOrderAndDetailCommandValidator : AbstractValidator<CreateOrderAndDetailCommand>
    {
        public CreateOrderAndDetailCommandValidator()
        {
            RuleFor(validator => validator.Id)
               .Must(IsGreatTo1).WithMessage("Error: el numero de order debe ser mayor a 1");
            RuleForEach(validator => validator.OrderDetails).ChildRules(orderDetails =>
            {
                orderDetails.RuleFor(validator => validator.OrderId)
                .Must(IsGreatTo1).WithMessage("Error: el numero de order debe ser mayor a 1");
                orderDetails.RuleFor(validator => validator.ProductId)
                    .Must(IsGreatTo1).WithMessage("Error: el numero del producto debe ser mayor a 1");
                orderDetails.RuleFor(validator => validator.Quantity)
                    .Must(IsGreatTo0Decimal).WithMessage("Error: la cantidad del producto debe ser mayor a 0");
                orderDetails.RuleFor(validator => validator.SubTotal)
                    .Must(IsGreatTo0Decimal).WithMessage("Error: el subtotal del detalle debe ser mayor a 0");
                orderDetails.RuleFor(validator => validator.Total)
                    .Must(IsGreatTo0Decimal).WithMessage("Error: el total del detalle debe ser mayor a 0");
            });
        }

        private bool IsGreatTo1(int orderNumber)
        {
            return orderNumber >= 1;
        }

        private bool IsGreatTo0Decimal(decimal value)
        {
            return value > 0m;
        }
    }
}
