using System.Collections;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinTucCTSV.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DayOfBirth { get; set; }
        public string ProfileImageUrl { get; set; }
        public DateTime MemberSince { get; set; }
        public int Rating { get; set; }
        public bool IsActive { get; set; }

        public string RegencyId { get; set; }

        public virtual Regency Regency { get; set; }
        public virtual IEnumerable<Post> Posts { get; set; }
        public virtual IEnumerable<Form> Forms { get; set; }
    }
}
