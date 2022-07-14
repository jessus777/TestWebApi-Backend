namespace Application.Features.Order.Commands.AddOrder
{
    public class AddOrderCommand : IRequest<Response<int>>
    {
        public int OrderNumber { get; set; }
    }
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, Response<int>>
    {
        readonly IOrderRepositoryAsync _orderRepositoryAsync;
        public AddOrderCommandHandler(IOrderRepositoryAsync orderRepositoryAsync)
        {
            _orderRepositoryAsync = orderRepositoryAsync;
        }
        public async Task<Response<int>> Handle(AddOrderCommand command, CancellationToken cancellationToken)
        {
            var order = new Domain.Entities.Order();

            var validatorOrderNumber = new AddOrderValidator();
            var resultValidator = await validatorOrderNumber.ValidateAsync(command, cancellationToken);

            if (!resultValidator.IsValid)
            {
                List<string> errors = new();
                errors.AddRange(resultValidator.Errors.Select(error => error.ErrorMessage));
                return new Response<int>(null) { Message = "No se pudo crear la Order", Succeeded = false, Errors = errors };
            }

            var orderNumberExist = await _orderRepositoryAsync.IsUniqueOrderAsync(command.OrderNumber);
            if (!orderNumberExist)
            {
                order.OrderNumber = command.OrderNumber;
                order = (Domain.Entities.Order)DataMapper.Parse(command, new Domain.Entities.Order());
                await _orderRepositoryAsync.AddAsync(order);
            }
            else
            {
                return new Response<int>(null) { Message = "Ya existe esta Orden", Succeeded = false };
            }

            return new Response<int>(order.Id) { Message = "Order creada correctamente", Succeeded = true };
        }
    }
}
