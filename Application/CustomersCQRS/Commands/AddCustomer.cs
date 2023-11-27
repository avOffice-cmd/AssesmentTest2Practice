using Application.DTOs.CustomerDTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomersCQRS.Commands
{
    public  class AddCustomer : IRequest<Customer>
    {
        public AddCustomerDTO _addCustomerDTO { get; set; }
    }

    public class AddCustomer_Handler : IRequestHandler<AddCustomer, Customer>
    {
        private readonly IApplicationDBContext _context;
        public AddCustomer_Handler(IApplicationDBContext _applicationDBContext)
        {
            _context = _applicationDBContext;
        }

          async Task<Customer> IRequestHandler<AddCustomer, Customer>.Handle(AddCustomer request, CancellationToken cancellationToken)
        {
            Customer addCustomer = new Customer()
            {
                Name = request._addCustomerDTO.Name,
                Email = request._addCustomerDTO.Email,
                PhoneNumber = request._addCustomerDTO.PhoneNumber,
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                IsActive = true
               
            };

            _context.Customers.Add(addCustomer);

            await _context.SaveChangesAsync(cancellationToken);

            return addCustomer;
        }
    }
}
