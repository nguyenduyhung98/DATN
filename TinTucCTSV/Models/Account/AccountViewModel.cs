
using System;
using System.ComponentModel.DataAnnotations;

namespace TinTucCTSV.Models.Account
{
    public class AccountViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }
        [Display(Name = "Địa chi email")]
        public string Email { get; set; }
        [Display(Name = "Chức vụ")]
        public string Position { get; set; }
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime Created { get; set; }
        [Display(Name = "Avatar")]
        public string ImageProfile { get; set; }

        [Display(Name = "Đơn vị công tác")]
        public string Regency { get; set; }

        [Display(Name = "Phòng ban")]
        public string Department { get; set; }
    }
}
