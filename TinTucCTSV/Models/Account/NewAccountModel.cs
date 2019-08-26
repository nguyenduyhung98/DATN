using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TinTucCTSV.Data.Utility.DateTimeExtends;

namespace TinTucCTSV.Models.Account
{
    public class NewAccountModel
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name ="Tên")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name ="Họ")]
        public string LastName { get; set; }

        [Phone]
        [Display(Name="Số điện thoại")]
        public string PhoneNumber { get; internal set; }
        [Required]
        [Display(Name="Giới tính")]
        public bool Gender { get; set; }

        [Required]
        [Display(Name = "Ngày sinh")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name="Avatar")]
        public IFormFile ProfileImageUrl { get; set; }

        public List<SelectListItem> ListRoles { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác thực mật khẩu")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name="Chức vụ")]
        public string RegencyId { get; set; }
        public IEnumerable<SelectListItem> RegenciesList { get; set; }
        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}
