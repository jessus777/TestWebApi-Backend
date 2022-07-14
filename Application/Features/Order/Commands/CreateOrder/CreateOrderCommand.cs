using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Response<int>>
    {

    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<int>>
    {
        readonly IOrderRepositoryAsync _orderRepositoryAsync;   
        public CreateOrderCommandHandler(IOrderRepositoryAsync orderRepositoryAsync)
        {
            _orderRepositoryAsync = orderRepositoryAsync;
        }

        public async Task<Response<int>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var orderNumber = await _orderRepositoryAsync.GetLastOrderNumber();
            if (orderNumber <= 0)
            {
                return new Response<int>(null) { Succeeded = false, Message = "Error al crear la orden" };
            }
            orderNumber++;
            return new Response<int>(orderNumber) { Succeeded = true, Message = "Se creo la order Correctamente" };
        }
    }
}
