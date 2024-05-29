using System;
using System.Collections.Generic;

namespace SSAip.Models
{
    public partial class OrderDetail
    {
        public string OrderDetailsId { get; set; } = null!;
        public decimal? PriceOder { get; set; }
        public int? Quantity { get; set; }
        public string? Size { get; set; }
        public string? ProductId { get; set; }
        public string? OrderId { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
