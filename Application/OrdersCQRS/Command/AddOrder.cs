using Application.CustomersCQRS.Commands;
using Application.DTOs.CustomerDTO;
using Application.DTOs.OrderDTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrdersCQRS.Command
{
    public  class AddOrder : IRequest<Order>
    {
        public AddOrderDTO _addOrderDTO { get; set; }
    }

    public class AddOrder_Handler : IRequestHandler<AddOrder, Order>
    {
        private readonly IApplicationDBContext _context;
        public AddOrder_Handler(IApplicationDBContext _applicationDBContext)
        {
            _context = _applicationDBContext;
        }

        async Task<Order> IRequestHandler<AddOrder, Order>.Handle(AddOrder request, CancellationToken cancellationToken)
        {
            Order addOrder = new Order()
            {
                  Id = request._addOrderDTO.Id,
                  Quantity = request._addOrderDTO.Quantity,
                  Total_Amt = request._addOrderDTO.Total_Amt,
                  DeliveryCity = request._addOrderDTO.DeliveryCity,
                  OrderStatus = request._addOrderDTO.OrderStatus,
                  CustomerId = (int)request._addOrderDTO.CustomerId,
                  InvoiceId = "44444",
                  CreatedBy = "Admin",
                  CreatedDate = DateTime.Now,
                  IsActive = true

            };

            _context.Orders.Add(addOrder);

            await _context.SaveChangesAsync(cancellationToken);

            return addOrder;
        }
    }
}
