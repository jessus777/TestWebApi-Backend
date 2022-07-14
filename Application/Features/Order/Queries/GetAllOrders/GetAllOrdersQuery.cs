using Application.Interfaces.Repositories;
using Application.Utils;
using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<Response<IEnumerable<GetAllOrderViewModel>>>
    {

    }

    public class GetAllOrdersQueriesHandler : IRequestHandler<GetAllOrdersQuery, Response<IEnumerable<GetAllOrderViewModel>>>
    {
        readonly IOrderRepositoryAsync _orderRepositoryAsync;

        public GetAllOrdersQueriesHandler(IOrderRepositoryAsync orderRepositoryAsync)
        {
            _orderRepositoryAsync = orderRepositoryAsync;
        }
        public async Task<Response<IEnumerable<GetAllOrderViewModel>>> Handle(GetAllOrdersQuery command, CancellationToken cancellationToken)
        {
            var getAllOrders = await _orderRepositoryAsync.GetAllOrdersAsync();
            var orders = new List<GetAllOrderViewModel>();
            if (getAllOrders.Count <= 0)
            {
                return new Response<IEnumerable<GetAllOrderViewModel>>(null) { Succeeded = false, Message = "No hay Ordenes" };
            }

            foreach (var getOrder in getAllOrders)
            {
                foreach (var item in getOrder.OrderDetails)
                {
                    item.Order = null;   
                }
                orders.Add((GetAllOrderViewModel)DataMapper.Parse(getOrder, new GetAllOrderViewModel()));
            }
            return new Response<IEnumerable<GetAllOrderViewModel>>(orders); 
        }
    }
}
