using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace TinTucCTSV.Models.Role
{
    public class NewRoleModel
    {
        [Display(Name="Tên quyền")]
        public string Name { get; set; }
         [Display(Name="Mô tả chi tiết")]
        public string Description { get; set; }
    }
}
