using System;
using System.Collections.Generic;

namespace SSAip.Models
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public string? Size { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public string? ProductId { get; set; }

        public virtual Product? Product { get; set; }
    }
}
