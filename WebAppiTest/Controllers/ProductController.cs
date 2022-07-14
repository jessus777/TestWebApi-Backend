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
