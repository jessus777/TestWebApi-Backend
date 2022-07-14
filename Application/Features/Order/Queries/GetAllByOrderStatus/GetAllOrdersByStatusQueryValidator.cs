namespace Application.Features.Order.Queries.GetAllByOrderStatus
{
    public class GetAllOrdersByStatusQueryValidator : AbstractValidator<GetAllOrdersByStatusQuery>
    {
        public GetAllOrdersByStatusQueryValidator()
        {
            RuleFor(validator => validator.StatusType)
                .Must(IsGreatTo1Enum).WithMessage("Error: el tipo de status no existe");
        }

        private bool IsGreatTo1Enum(int statusType)
        {
            return statusType >= 0 && statusType <= 4;
        }
    }
}
