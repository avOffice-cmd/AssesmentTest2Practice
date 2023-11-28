using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.OrderDTO
{
    public class UpdateOrderDTO
    {
        public int Id { get; set; }
      
     
        public string OrderStatus { get; set; }
    }
}
