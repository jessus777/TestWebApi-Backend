using Application.Features.Product.Queries.GetAllProducts;
using Application.Features.Product.Queries.GetAllProductsExistens;
using Microsoft.AspNetCore.Mvc;

namespace WebAppiTest.Controllers
{
    public class ProductController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery()));
        }

        [HttpGet("GetAllProductsExistents")]
        public async Task<IActionResult> GetAllProductsExistents()
        {
            return Ok(await Mediator.Send(new GetAllProductsExistenQuery()));
        }
    }
}
