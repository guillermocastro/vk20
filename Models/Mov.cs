using System;
using System.Collections.Generic;

namespace vk20.Models
{
    public partial class Mov
    {
        public int MoveId { get; set; }
        public string MovetypeId { get; set; }
        public int LineId { get; set; }
        public decimal? Quantity { get; set; }
        public string BatchNo { get; set; }
        public string SerialNo { get; set; }
        public decimal? Price { get; set; }
        public string DebitNo { get; set; }
        public string CreditNo { get; set; }

        public virtual Line Line { get; set; }
        public virtual MoveType Movetype { get; set; }
    }
}
