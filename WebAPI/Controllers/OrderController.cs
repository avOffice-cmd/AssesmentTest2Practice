using Application.CustomersCQRS.Commands;
using Application.DTOs.CustomerDTO;
using Application.DTOs.OrderDTO;
using Application.OrdersCQRS.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class OrderController : ApiControllerBase
    {
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> AddCustomer([FromBody] AddOrderDTO _addOrderDTO)
        {
            var response = await Mediator.Send(new AddOrder { _addOrderDTO = _addOrderDTO });
            return Ok(response);
        }


        [HttpPut]
        [Route("updateOrder")]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderDTO _updateOrderDTO)
        {
            var gotMessage = await Mediator.Send(new UpdateOrder { _updateOrderDTO = _updateOrderDTO });
            return Ok(gotMessage);
        }



        [HttpDelete]
        [Route("delete/{orderID}")]
        public async Task<ActionResult> DeleteOrderByIDAsync(int orderID)
        {
            var gotMessage = await Mediator.Send(new DeleteOrder { OrderID = orderID });
            return Ok(gotMessage);
        }
    }
}
