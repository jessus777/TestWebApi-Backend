namespace Application.Features.Order.Queries.GetAllOrders
{
    public class GetAllOrderViewModel
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public DateTime DateCreate { get; set; }
        public OrderStatusType OrderStatusType { get; set; }
        public virtual IList<Domain.Entities.OrderDetail> OrderDetails { get; set; }
        public string OrderStatusTypeName { get; set; }

    }
}
