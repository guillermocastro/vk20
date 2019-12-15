using System;
using System.Collections.Generic;

namespace vk20.Models
{
    public partial class Line
    {
        public Line()
        {
            Mov = new HashSet<Mov>();
        }

        public int LineId { get; set; }
        public int DocId { get; set; }
        public string LineTypeId { get; set; }
        public string Sku { get; set; }
        public int TaxId { get; set; }
        public string Description { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string DebitNo { get; set; }
        public string CreditNo { get; set; }
        public string Author { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsRegistered { get; set; }
        public DateTime? RegisteredOn { get; set; }

        public virtual Doc Doc { get; set; }
        public virtual LineType LineType { get; set; }
        public virtual Tax Tax { get; set; }
        public virtual ICollection<Mov> Mov { get; set; }
    }
}
