using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomersCQRS.Commands
{
    public class DeleteCustomer : IRequest<string>
    {
        public int CustomerID { get; set; }
    }

    public class DeleteCustomer_Handler : IRequestHandler<DeleteCustomer, string>
    {
        private readonly IApplicationDBContext context;

        public DeleteCustomer_Handler(IApplicationDBContext _applicationDBContext)
        {
            context = _applicationDBContext;
        }

        public async Task<string> Handle(DeleteCustomer request, CancellationToken cancellationToken)
        {
            var gotCustomerTable = await context.Customers.ToListAsync();

            var gotCustomer = gotCustomerTable
                            .FirstOrDefault(c => c.Id == request.CustomerID);


            if (gotCustomer != null)
            {
                if (gotCustomer.IsActive == false) return "Customer already deleted";

                gotCustomer.IsActive = false;
                gotCustomer.LastModifiedDate = DateTime.Now;
                gotCustomer.LastModifiedBy = "Admin";
                await context.SaveChangesAsync(cancellationToken);
                return "Customer Deleted";
            }

            return "Customer with the given ID not found";
        }
    }
}
