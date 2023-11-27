using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CustomerDTO
{
    public class AddCustomerDTO 
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }

   
}
