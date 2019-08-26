using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TinTucCTSV.Models.Account
{
    public class ChangeInformation
    {
        public string Id { get; set; }

        [Display(Name="Tên đăng nhập")]
        public string UserName { get; set; }

        [Display(Name="Email")]
        public string Email { get; set; }

        [Display(Name="Tên")]
        public string FirstName { get; set; }
        [Display(Name="Họ")]
        public string LastName { get; set; }

        [Display(Name="Giới tính")]
        public bool Gender { get; set; }

        [Display(Name="Ngày sinh")]
        public string DataOfBirth { get; set; }

        [Display(Name="Trạng thái")]
        public bool IsActive { get; set; }

        [Display(Name="Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name="Ảnh đại diện")]
        public string ProfileImageUrl { get; set; }
        
        [Display(Name="Quyền hạn")]
        public string Role { get; set; }

        [Display(Name="Chức vụ")]
        public string Regency { get; set; }
        public bool IsLock { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}
