using Application.Interfaces.Repositories;
using Application.Utils;
using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.Commands.CreateOrderAndDetail
{
    public class CreateOrderAndDetailCommand: IRequest<Response<int>>
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
        public CreateOrderAndDetailCommandHandler(IOrderRepositoryAsync orderRepositoryAsync, IOrderDetailRepositoryAsync orderDetailRepositoryAsync)
        {
            _orderRepositoryAsync = orderRepositoryAsync;
            _orderDetailRepositoryAsync = orderDetailRepositoryAsync;
        }

        public async Task<Response<int>> Handle(CreateOrderAndDetailCommand command, CancellationToken cancellationToken)
        {
            var orderExist = await _orderRepositoryAsync.GetByIdAsync(command.Id);
            if (orderExist != default)
            {
                orderExist.Total = command.Total;
                orderExist.SubTotal = command.Total;

                await _orderRepositoryAsync.UpdateAsync(orderExist);
            }
            else
            {
                orderExist.Id = 0;
            }

            if (command.OrderDetails.Count > 0)
            {
                foreach (var item in command.OrderDetails)
                {
                    _ = new Domain.Entities.OrderDetail();
                    Domain.Entities.OrderDetail orderDetail = (Domain.Entities.OrderDetail)DataMapper.Parse(item, new Domain.Entities.OrderDetail());
                    await _orderDetailRepositoryAsync.AddAsync(orderDetail);
                }
            }
            return new Response<int>(orderExist.Id) { Message = "Se creo correctamente", Succeeded = true };
        }
    }


}
