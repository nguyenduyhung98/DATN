using System;
using System.Collections.Generic;
namespace TinTucCTSV.Data.Models
{
    public class Form
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Created { get; set; }

        public string LinkUrl { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}