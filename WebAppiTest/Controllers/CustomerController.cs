using Application.Features.Customer.Commands.CreateCustomer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppiTest.Controllers
{
    public class CustomerController :  BaseApiController
    {
        // POST: CustomerController/Create
        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> Post(CreateCustomerCommand command)
        {         
            return Ok(await Mediator.Send(command));
        }

      
    }
}
