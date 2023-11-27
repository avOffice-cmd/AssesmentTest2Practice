using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order :Auditable
    {
        public int Id { get; set; }
        public string InvoiceId { get; set; }
        public float Total_Amt { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public string DeliveryCity { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
