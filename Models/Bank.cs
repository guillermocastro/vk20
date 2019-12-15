using System;
using System.Collections.Generic;

namespace vk20.Models
{
    public partial class Bank
    {
        public Bank()
        {
            BankMov = new HashSet<BankMov>();
        }

        public int BankId { get; set; }
        public int CompanyId { get; set; }
        public string BankName { get; set; }
        public string Swift { get; set; }
        public string Iban { get; set; }
        public string AccountNo { get; set; }
        public string CurrencyId { get; set; }
        public string CountryId { get; set; }
        public string Utr { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Url { get; set; }
        public string Email { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<BankMov> BankMov { get; set; }
    }
}
