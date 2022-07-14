namespace Domain.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
