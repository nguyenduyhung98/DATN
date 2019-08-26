using System;
using System.ComponentModel.DataAnnotations;

namespace TinTucCTSV.Models.Form
{
    public class FormViewModel
    {
        [Display(Name ="Mã số")]
        public int Id { get; set; }

        [Display(Name ="Tên biểu mẫu")]
        public string Title { get; set; }

        [Display(Name ="Ngày tạo")]
        public DateTime Created { get; set; }

        [Display(Name = "Liên kết")]
        public string LinkUrl { get; set; }
    }
}