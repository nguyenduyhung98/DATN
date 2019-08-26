using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace TinTucCTSV.Data.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
