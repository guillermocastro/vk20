using System;
using System.Collections.Generic;

namespace vk20.Models
{
    public partial class Partner
    {
        public Partner()
        {
            Location = new HashSet<Location>();
        }

        public int PartnerId { get; set; }
        public int CompanyId { get; set; }
        public string PartnerName { get; set; }
        public string CurrencyId { get; set; }
        public string CountryId { get; set; }
        public string Utr { get; set; }
        public string DebitNo { get; set; }
        public string CreditNo { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Location> Location { get; set; }
    }
}
