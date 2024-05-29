using System;
using System.Collections.Generic;

namespace SSAip.Models
{
    public partial class Cart
    {
        public string CartId { get; set; } = null!;
        public string? Size { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string? ProductId { get; set; }
        public string? UserId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual User? User { get; set; }
    }
}
