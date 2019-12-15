using System;
using System.Collections.Generic;

namespace vk20.Models
{
    public partial class BankMov
    {
        public int BankMoveId { get; set; }
        public int BankId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public string Concept { get; set; }
        public decimal Amount { get; set; }
        public string AccountNo { get; set; }
        public bool? IsRegistered { get; set; }

        public virtual Bank Bank { get; set; }
    }
}
