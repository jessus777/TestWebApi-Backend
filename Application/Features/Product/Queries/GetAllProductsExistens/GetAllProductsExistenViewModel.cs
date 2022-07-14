using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Queries.GetAllProductsExistens
{
    public class GetAllProductsExistenViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Quantity { get; set; }
        public decimal Iva { get; set; }
        public decimal Price { get; set; }
    }
}
