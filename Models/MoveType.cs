using System;
using System.Collections.Generic;

namespace vk20.Models
{
    public partial class MoveType
    {
        public MoveType()
        {
            Mov = new HashSet<Mov>();
        }

        public string MoveTypeId { get; set; }
        public string MoveTypeName { get; set; }
        public string DebitNo { get; set; }
        public string CreditNo { get; set; }
        public string MovStates { get; set; }

        public virtual ICollection<Mov> Mov { get; set; }
    }
}
