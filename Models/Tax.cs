using System;
using System.Collections.Generic;

namespace vk20.Models
{
    public partial class Tax
    {
        public Tax()
        {
            Doc = new HashSet<Doc>();
            Line = new HashSet<Line>();
        }

        public int TaxId { get; set; }
        public int CompanyId { get; set; }
        public string TaxName { get; set; }
        public decimal Percentage { get; set; }
        public string DebitNo { get; set; }
        public string CreditNo { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Doc> Doc { get; set; }
        public virtual ICollection<Line> Line { get; set; }
    }
}
