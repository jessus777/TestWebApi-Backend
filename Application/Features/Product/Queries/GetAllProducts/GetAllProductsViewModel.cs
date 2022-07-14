namespace Application.Features.Product.Queries.GetAllProducts
{
    public class GetAllProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Quantity { get; set; }
        public decimal Iva { get; set; }
        public decimal Price { get; set; }
    }
}
