using Application.CustomersCQRS.Commands;
using Application.CustomersCQRS.Queries;
using Application.DTOs.CustomerDTO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CustomerController : ApiControllerBase
    {


        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult> GetAllCustomerAsync()
        {
            var gotAllCustomer = await Mediator.Send(new GetAllCustomers { });
            return Ok(gotAllCustomer);
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> AddStudent([FromBody] AddCustomerDTO _addCustomerDTO)
        {
            var response = await Mediator.Send(new AddCustomer { _addCustomerDTO = _addCustomerDTO });
            return Ok(response);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateCustomer([FromBody] UpdateCustomerDTO _updateCustomerDTO)
        {
            var gotMessage = await Mediator.Send(new UpdateCustomer { _updateCustomerDTO = _updateCustomerDTO });
            return Ok(gotMessage);
        }

        [HttpDelete]
        [Route("delete/{customerID}")]
        public async Task<ActionResult> DeleteCustomerByIDAsync(int customerID)
        {
            var gotMessage = await Mediator.Send(new DeleteCustomer { CustomerID = customerID });
            return Ok(gotMessage);
        }
    }
}
