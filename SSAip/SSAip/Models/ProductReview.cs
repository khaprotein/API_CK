using System;
using System.Collections.Generic;

namespace SSAip.Models
{
    public partial class ProductReview
    {
        public string ProductReviewId { get; set; } = null!;
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime? ReviewDate { get; set; }
        public string? ProductId { get; set; }
        public string? UserId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual User? User { get; set; }
    }
}
