using System;
using System.Collections.Generic;

namespace vk20.Models
{
    public partial class Location
    {
        public Location()
        {
            Doc = new HashSet<Doc>();
        }

        public int LocationId { get; set; }
        public int PartnerId { get; set; }
        public string LocationName { get; set; }
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

        public virtual Partner Partner { get; set; }
        public virtual ICollection<Doc> Doc { get; set; }
    }
}
