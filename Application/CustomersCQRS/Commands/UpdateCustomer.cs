using Application.DTOs.CustomerDTO;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomersCQRS.Commands
{
    public class UpdateCustomer : IRequest<string>
    {
       public UpdateCustomerDTO _updateCustomerDTO {  get; set; }    
    }

    public class UpdateCustomer_Handler : IRequestHandler<UpdateCustomer, string>
    {

        private readonly IApplicationDBContext context;

        public UpdateCustomer_Handler(IApplicationDBContext _applicationDBContext)
        {
            context = _applicationDBContext;
        }
        public async Task<string> Handle(UpdateCustomer request, CancellationToken cancellationToken)
        {
            var updateCustomerDTO = request._updateCustomerDTO;

            var gotCustomerTable = await context.Customers.AsNoTracking().ToListAsync();

            var gotCustomer = gotCustomerTable
                           .FirstOrDefault(c => c.Id == updateCustomerDTO.CustomerId);

            if (gotCustomer != null)
            {
                if (gotCustomer.IsActive == false) return "Customer Not found";

                Customer updatedCustomerObject = new Customer
                {
                    Id = gotCustomer.Id,
                    Name = updateCustomerDTO.Name,
                    Email = gotCustomer.Email,
                    PhoneNumber = gotCustomer.PhoneNumber,
                    CreatedDate = gotCustomer.CreatedDate,
                    CreatedBy = gotCustomer.CreatedBy,
                    LastModifiedDate = DateTime.Now,
                    LastModifiedBy = "Admin",
                    IsActive = gotCustomer.IsActive


                };

                context.Customers.Update(updatedCustomerObject);
                await context.SaveChangesAsync(cancellationToken);

                return "Customer Updated";
            }

            return " Customer with the given Id Not found";
        }
    }
}
