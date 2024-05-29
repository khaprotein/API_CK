using System;
using System.Collections.Generic;

namespace SSAip.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int StatusId { get; set; }
        public string? Status { get; set; }
        public int? Hide { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
