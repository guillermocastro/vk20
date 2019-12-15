using System;
using System.Collections.Generic;

namespace vk20.Models
{
    public partial class Doc
    {
        public Doc()
        {
            Line = new HashSet<Line>();
        }

        public int DocId { get; set; }
        public int LocationId { get; set; }
        public string DocTypeId { get; set; }
        public string DocNo { get; set; }
        public string AncestorNo { get; set; }
        public string DebitNo { get; set; }
        public string CreditNo { get; set; }
        public int TaxId { get; set; }
        public string DocStatus { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? Freight { get; set; }
        public decimal? Total { get; set; }
        public DateTime? DocDate { get; set; }
        public string Comment { get; set; }
        public string Author { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsRegistered { get; set; }
        public bool? IsPaid { get; set; }
        public bool? IsDelivered { get; set; }

        public virtual DocType DocType { get; set; }
        public virtual Location Location { get; set; }
        public virtual Tax Tax { get; set; }
        public virtual ICollection<Line> Line { get; set; }
    }
}
