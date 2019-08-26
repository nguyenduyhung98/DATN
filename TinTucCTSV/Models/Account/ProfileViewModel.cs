using System;
using System.ComponentModel.DataAnnotations;
namespace TinTucCTSV.Models.Account
{
    public class ProfileViewModel
    {
        public string Id { get; set; }
        [Display(Name="Họ tên")]
        public string Name { get; set; }
        [Display(Name="Ảnh đại diện")]
        public string ImageProfile { get; set; }
        public DateTime Created { get; set; }
    }
}