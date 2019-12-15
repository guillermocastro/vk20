using System;
using System.Collections.Generic;

namespace vk20.Models
{
    public partial class Company
    {
        public Company()
        {
            Account = new HashSet<Account>();
            Bank = new HashSet<Bank>();
            Employee = new HashSet<Employee>();
            Partner = new HashSet<Partner>();
            Product = new HashSet<Product>();
            Tax = new HashSet<Tax>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
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
        public string Legal { get; set; }
        public string Owner { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<Bank> Bank { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Partner> Partner { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Tax> Tax { get; set; }
    }
}
