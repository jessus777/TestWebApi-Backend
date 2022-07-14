using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public decimal SubTotal { get; set; }  = 0m;
        public decimal Total { get; set; } = 0m;
        public DateTime DateCreate { get; set; } = DateTime.Now;
        public OrderStatusType OrderStatusType { get; set; } = OrderStatusType.Pending;
        public virtual IList<OrderDetail> OrderDetails { get; set; }
        public string OrderStatusTypeName { get; set; } = Enum.GetName(OrderStatusType.Pending);

    }
}
