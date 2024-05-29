using System;
using System.Collections.Generic;

namespace SSAip.Models
{
    public partial class OrdersCoupon
    {
        public int OrderCouponId { get; set; }
        public string? OrderId { get; set; }
        public string? CouponId { get; set; }

        public virtual Coupon? Coupon { get; set; }
        public virtual Order? Order { get; set; }
    }
}
