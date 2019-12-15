using System;
using System.Collections.Generic;

namespace vk20.Models
{
    public partial class DocType
    {
        public DocType()
        {
            Doc = new HashSet<Doc>();
        }

        public string DocTypeId { get; set; }
        public string DocTypeName { get; set; }
        public string Prefix { get; set; }
        public int? LastNumber { get; set; }
        public string DebitNo { get; set; }
        public string CreditNo { get; set; }
        public string DocStates { get; set; }

        public virtual ICollection<Doc> Doc { get; set; }
    }
}
