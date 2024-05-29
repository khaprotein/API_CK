using System;
using System.Collections.Generic;

namespace SSAip.Models
{
    public partial class Coupon
    {
        public Coupon()
        {
            OrdersCoupons = new HashSet<OrdersCoupon>();
        }

        public string CouponId { get; set; } = null!;
        public string? CouponCode { get; set; }
        public decimal? DiscountAmount { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public decimal? MinimumOrderAmount { get; set; }
        public string? Description { get; set; }
        public int? Hide { get; set; }

        public virtual ICollection<OrdersCoupon> OrdersCoupons { get; set; }
    }
}
