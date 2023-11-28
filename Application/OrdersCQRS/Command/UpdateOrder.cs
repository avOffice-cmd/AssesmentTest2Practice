using Application.CustomersCQRS.Commands;
using Application.DTOs.OrderDTO;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrdersCQRS.Command
{
    public class UpdateOrder : IRequest<string>
    {
        public UpdateOrderDTO _updateOrderDTO {  get; set; }
    }

    public class UpdateOrder_Handler : IRequestHandler<UpdateOrder, string>
    {

        private readonly IApplicationDBContext context;

        public UpdateOrder_Handler(IApplicationDBContext _applicationDBContext)
        {
            context = _applicationDBContext;
        }

        public async Task<string> Handle(UpdateOrder request, CancellationToken cancellationToken)
        {
            var updateOrderDTO = request._updateOrderDTO;

            var gotOrderTable = await context.Orders.AsNoTracking().ToListAsync();

            var gotOrder = gotOrderTable
                           .FirstOrDefault(o => o.Id == updateOrderDTO.Id);

            if (gotOrder != null)
            {
                if (gotOrder.IsActive == false) return "Customer Not found";

                Order updatedOrderObject = new Order
                {
                    
                  Id = gotOrder.Id,
                  Quantity = gotOrder.Quantity,
                  Total_Amt = gotOrder.Total_Amt,
                  DeliveryCity = gotOrder.DeliveryCity,
                  OrderStatus = updateOrderDTO.OrderStatus,
                  CreatedDate = gotOrder.CreatedDate,
                  CreatedBy = gotOrder.CreatedBy,
                  LastModifiedDate = DateTime.Now,
                  LastModifiedBy = "Admin",
                  IsActive = gotOrder.IsActive

                };

                context.Orders.Update(updatedOrderObject);
                await context.SaveChangesAsync(cancellationToken);

                return "Order Updated";
            }

            return " Order with the given Id Not found";
        }
    }
}
