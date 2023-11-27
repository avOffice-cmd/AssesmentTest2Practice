using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.OrderDTO
{
    public class AddOrderDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float Total_Amt { get; set; }
        public string DeliveryCity { get; set; }
        public string OrderStatus { get; set; }
        public int? CustomerId { get; set; }
    }
}
