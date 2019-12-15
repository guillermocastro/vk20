using System;
using System.Collections.Generic;

namespace vk20.Models
{
    public partial class LineType
    {
        public LineType()
        {
            Line = new HashSet<Line>();
        }

        public string LineTypeId { get; set; }
        public string LineTypeName { get; set; }
        public string DebitNo { get; set; }
        public string CreditNo { get; set; }
        public string LineStates { get; set; }

        public virtual ICollection<Line> Line { get; set; }
    }
}
