using System;
using System.Collections.Generic;

namespace vk20.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public int CompanyId { get; set; }
        public string ProductName { get; set; }
        public string Sku { get; set; }
        public string Ean13 { get; set; }
        public string Description { get; set; }
        public decimal? StdCost { get; set; }
        public string Unit { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Company Company { get; set; }
    }
}
