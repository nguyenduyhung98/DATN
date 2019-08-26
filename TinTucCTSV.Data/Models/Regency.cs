using System;
using System.Collections.Generic;
using System.Text;

namespace TinTucCTSV.Data.Models
{
    public class Regency
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<ApplicationUser> Users { get; set; }
    }
}
