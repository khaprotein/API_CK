using System;
using System.Collections.Generic;

namespace SSAip.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
            OrdersCoupons = new HashSet<OrdersCoupon>();
        }

        public string OrdersId { get; set; } = null!;
        public string? UserPhone { get; set; }
        public DateTime? OrdersDate { get; set; }
        public string? ShippingAddress { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? UserId { get; set; }
        public int? StatusId { get; set; }

        public virtual OrderStatus? Status { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<OrdersCoupon> OrdersCoupons { get; set; }
    }
}
