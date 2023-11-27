using Application.CustomersCQRS.Commands;
using Application.DTOs.CustomerDTO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CustomerController : ApiControllerBase
    {

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> AddStudent([FromBody] AddCustomerDTO _addCustomerDTO)
        {
            var response = await Mediator.Send(new AddCustomer { _addCustomerDTO = _addCustomerDTO });
            return Ok(response);
        }

    }
}
