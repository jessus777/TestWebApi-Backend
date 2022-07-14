using Application.Interfaces.Repositories;
using Application.Utils;
using Application.Wrappers;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.Queries.GetAllByOrderStatus
{
    public class GetAllOrdersByStatusQuery : IRequest<Response<IEnumerable<GetAllOrdersByStatusViewModel>>>
    {
        public int StatusType { get; set; }
    }

    public class GetAllOrdersByStatusQueryHandler : IRequestHandler<GetAllOrdersByStatusQuery, Response<IEnumerable<GetAllOrdersByStatusViewModel>>>
    {
        readonly IOrderRepositoryAsync _orderRepositoryAsync;

        public GetAllOrdersByStatusQueryHandler(IOrderRepositoryAsync orderRepositoryAsync)
        {
            _orderRepositoryAsync = orderRepositoryAsync;
        }
        public async Task<Response<IEnumerable<GetAllOrdersByStatusViewModel>>> Handle(GetAllOrdersByStatusQuery query, CancellationToken cancellationToken)
        {
            var getAllOrdersByStatus = await _orderRepositoryAsync.GetAllOrderByStatusAsync(query.StatusType);
            var orders = new List<GetAllOrdersByStatusViewModel>();
            if (getAllOrdersByStatus.Count <= 0)
            {
                return new Response<IEnumerable<GetAllOrdersByStatusViewModel>>(null) { Succeeded = false, Message = $"No hay Ordenes con el status {GetStatusOrder(query.StatusType)}" };
            }
            foreach (var getOrder in getAllOrdersByStatus)
            {
                foreach (var item in getOrder.OrderDetails)
                {
                    item.Order = null;
                }
                orders.Add((GetAllOrdersByStatusViewModel)DataMapper.Parse(getOrder, new GetAllOrdersByStatusViewModel()));
            }

            return new Response<IEnumerable<GetAllOrdersByStatusViewModel>>(orders);
        }

        public static string GetStatusOrder(int statusOrder)
        {
            string statusName = statusOrder switch
            {
                0 => Enum.GetName(OrderStatusType.Pending),
                1 => Enum.GetName(OrderStatusType.InProcess),
                2 => Enum.GetName(OrderStatusType.Completed),
                3 => Enum.GetName(OrderStatusType.Delivered),
                4 => Enum.GetName(OrderStatusType.Canceled),
                _ => Enum.GetName(OrderStatusType.Pending),
            };
            return statusName;
        }
    }

}
