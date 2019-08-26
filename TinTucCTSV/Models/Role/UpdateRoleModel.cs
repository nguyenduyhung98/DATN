using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TinTucCTSV.Models.Role
{
    public class UpdateRoleModel
    {
        public string Id { get; set; }
        [Display(Name="Tên quyền")]
        public string Name { get; set; }
        [Display(Name="Mô tả chi tiết")]
        public string Description { get; set; }
    }
}
