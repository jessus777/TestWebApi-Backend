namespace Application.Features.Order.Commands.CreateOrderAndDetail
{
    public class CreateOrderAndDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public virtual IList<OrderDetail> OrderDetails { get; set; }

        public class OrderDetail
        {
            public int OrderId { get; set; }
            public int ProductId { get; set; }
            public decimal Quantity { get; set; }
            public decimal SubTotal { get; set; }
            public decimal Total { get; set; }
        }

    }

    public class CreateOrderAndDetailCommandHandler : IRequestHandler<CreateOrderAndDetailCommand, Response<int>>
    {
        readonly IOrderRepositoryAsync _orderRepositoryAsync;
        readonly IOrderDetailRepositoryAsync _orderDetailRepositoryAsync;
        readonly IProductRepositoryAsync _productRepositoryAsync;
        public CreateOrderAndDetailCommandHandler(IOrderRepositoryAsync orderRepositoryAsync, IOrderDetailRepositoryAsync orderDetailRepositoryAsync, IProductRepositoryAsync productRepositoryAsync)
        {
            _orderRepositoryAsync = orderRepositoryAsync;
            _orderDetailRepositoryAsync = orderDetailRepositoryAsync;
            _productRepositoryAsync = productRepositoryAsync;
        }

        public async Task<Response<int>> Handle(CreateOrderAndDetailCommand command, CancellationToken cancellationToken)
        {
            var validatorOrderNumber = new CreateOrderAndDetailCommandValidator();
            var resultValidator = await validatorOrderNumber.ValidateAsync(command, cancellationToken);

            if (!resultValidator.IsValid)
            {
                List<string> errors = new();
                errors.AddRange(resultValidator.Errors.Select(error => error.ErrorMessage));
                return new Response<int>(null) { Message = "No se pudo crear la Order", Succeeded = false, Errors = errors };
            }


            var orderExist = await _orderRepositoryAsync.GetByIdAsync(command.Id);
            if (orderExist != default)
            {
                orderExist.Total = command.Total;
                orderExist.SubTotal = command.SubTotal;

                await _orderRepositoryAsync.UpdateAsync(orderExist);
            }
            else
            {
                orderExist = new Domain.Entities.Order() { Id = 0 };
            }

            if (command.OrderDetails.Count > 0)
            {
                foreach (var item in command.OrderDetails)
                {
                    var productExist = await _productRepositoryAsync.GetByIdAsync(item.ProductId);
                    if (productExist != default)
                    {
                        _ = new Domain.Entities.OrderDetail();
                        Domain.Entities.OrderDetail orderDetail = (Domain.Entities.OrderDetail)DataMapper.Parse(item, new Domain.Entities.OrderDetail());
                        await _orderDetailRepositoryAsync.AddAsync(orderDetail);
                    }

                }
            }
            return new Response<int>(orderExist.Id) { Message = "Se creo correctamente", Succeeded = true };
        }
    }


}
