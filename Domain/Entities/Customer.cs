using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer :Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }


        public string PhoneNumber { get; set; }

        public List<Order> Orders { get; set; }
    }
}
