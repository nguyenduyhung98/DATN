using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TinTucCTSV.Models.Role
{
    public class RoleViewModel
    {
        [Display(Name="ID")]
        public string Id { get; set; }
        [Display(Name = "Tên quyền")]
        public string Name { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }
}
