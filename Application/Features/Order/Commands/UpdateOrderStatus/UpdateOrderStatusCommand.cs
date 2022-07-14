using Application.Interfaces.Repositories;
using Application.Wrappers;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.Commands.UpdateOrderStatus
{
    public class UpdateOrderStatusCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int StatusType { get; set; }
    }

    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand, Response<int>>
    {
        readonly IOrderRepositoryAsync _orderRepositoryAsync;
        readonly IProductRepositoryAsync _productRepositoryAsync;
        readonly IOrderDetailRepositoryAsync _orderDetailRepositoryAsync;
        public UpdateOrderStatusCommandHandler(IOrderRepositoryAsync orderRepositoryAsync, IProductRepositoryAsync productRepositoryAsync, IOrderDetailRepositoryAsync orderDetailRepositoryAsync)
        {
            _orderRepositoryAsync = orderRepositoryAsync;
            _productRepositoryAsync = productRepositoryAsync;
            _orderDetailRepositoryAsync = orderDetailRepositoryAsync;   
        }
        public async Task<Response<int>> Handle(UpdateOrderStatusCommand command, CancellationToken cancellationToken)
        {

            var order = await _orderRepositoryAsync.GetByIdAsync(command.Id);
            if (order == null)
            {
                return new Response<int>(null) { Succeeded = false, Message = "Orden no encontrada" };
            }

            var orderDetails = await _orderDetailRepositoryAsync.GetAllOrderDetailsByOrderIdAsync(command.Id);
            if (orderDetails.Count <= 0)
            {
                return new Response<int>(null) { Succeeded = false, Message = "No se puede actualizar el status, debe agregar productos" };
            }

            var statusIsDelivered = (OrderStatusType)command.StatusType == OrderStatusType.Delivered;
            if (statusIsDelivered)
            {
                var products = await _productRepositoryAsync.GetAllAsync();
                var listErrors = new  List<string>();
                foreach (var product in products)
                {

                    if (product.Quantity <= 0)
                    {
                        listErrors.Add($"El producto {product.Name} ya no se puede procesar. Ya no hay en stock");
                    }
                    else
                    {
                        var productDetail = orderDetails.Where(item => item.ProductId.Equals(product.Id)).Sum(q => q.Quantity);
                        if (productDetail > 0)
                        {
                            if (product.Quantity > productDetail)
                            {
                                product.Quantity -= productDetail;
                            }
                            else
                            {
                                listErrors.Add($"El producto {product.Name} ya no se puede procesar. Ya no hay en stock");
                            }
                            await _productRepositoryAsync.UpdateAsync(product);
                        }

                        
                        order.OrderStatusType = (OrderStatusType)command.StatusType;
                        order.OrderStatusTypeName = Enum.GetName(order.OrderStatusType);
                        await _orderRepositoryAsync.UpdateAsync(order);
                    }
                }

                return new Response<int>(order.Id) { Succeeded = true, Message = "Se actualizó correctamente el status de la orden", Errors= listErrors.ToList()};

            }
            else
            {
                order.OrderStatusType = (OrderStatusType)command.StatusType;
                order.OrderStatusTypeName = Enum.GetName(order.OrderStatusType);
                await _orderRepositoryAsync.UpdateAsync(order);
            }
            return new Response<int>(order.Id) { Succeeded = true, Message = "Se actualizó correctamente el status de la orden" };
        }

       
    }
   
}
