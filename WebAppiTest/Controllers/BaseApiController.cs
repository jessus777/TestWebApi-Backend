using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAppiTest.Controllers
{
    [ApiController]
    [Route("api/")]
    public abstract class BaseApiController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
