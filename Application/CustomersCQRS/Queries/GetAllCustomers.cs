using Application.DTOs.CustomerDTO;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomersCQRS.Queries
{
    public class GetAllCustomers : IRequest<List<ViewCustomerDTO>>
    {
    }

    public class GetAllCustomers_Handler : IRequestHandler<GetAllCustomers, List<ViewCustomerDTO>>
    {
        private readonly IApplicationDBContext context;
        public GetAllCustomers_Handler(IApplicationDBContext _applicationDBContext)
        {
            context = _applicationDBContext;
        }

        public async Task<List<ViewCustomerDTO>> Handle(GetAllCustomers request, CancellationToken cancellationToken)
        {
            var gotAllCustomer = await context.Customers.ToListAsync();
            var allCustomersDTO = gotAllCustomer.Select(c => new ViewCustomerDTO
            {
                Id = c.Id,
                Email = c.Email,
                Name = c.Name,
                PhoneNumber = c.PhoneNumber

            }).ToList();

            return allCustomersDTO;
        }
    }
}

