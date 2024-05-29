using System;
using System.Collections.Generic;

namespace SSAip.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            Inventories = new HashSet<Inventory>();
            OrderDetails = new HashSet<OrderDetail>();
            ProductReviews = new HashSet<ProductReview>();
        }

        public string ProductId { get; set; } = null!;
        public string? ProductName { get; set; }
        public string? ProductimageUrl { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public int? Hide { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
    }
}
