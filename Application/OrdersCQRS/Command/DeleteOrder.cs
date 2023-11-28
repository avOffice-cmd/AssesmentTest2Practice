using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrdersCQRS.Command
{
    public class DeleteOrder : IRequest<string>
    {
        public int OrderID { get; set; }
    }


    public class DeleteOrder_Handler : IRequestHandler<DeleteOrder, string>
    {
        private readonly IApplicationDBContext context;

        public DeleteOrder_Handler(IApplicationDBContext _applicationDBContext)
        {
            context = _applicationDBContext;
        }

        public async Task<string> Handle(DeleteOrder request, CancellationToken cancellationToken)
        {
            var gotOrderTable = await context.Orders.ToListAsync();

            var gotOrder = gotOrderTable
                            .FirstOrDefault(o => o.Id == request.OrderID);


            if (gotOrder != null)
            {
                if (gotOrder.IsActive == false) return "Order already deleted";

                gotOrder.IsActive = false;
                gotOrder.LastModifiedDate = DateTime.Now;
                gotOrder.LastModifiedBy = "Admin";
                await context.SaveChangesAsync(cancellationToken);
                return "Order Deleted";
            }

            return "Order with the given ID not found";
        }
    }
}
