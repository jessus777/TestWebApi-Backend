namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public decimal Quantity { get; set; }
        public decimal Iva { get; set; } = 16;
        public decimal Price { get; set; }

    }
}
