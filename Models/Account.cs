using System;
using System.Collections.Generic;

namespace vk20.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public int CompanyId { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
        public string Balance { get; set; }
        public string IncomeStatement { get; set; }
        public string Utr { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Company Company { get; set; }
    }
}
