using System.ComponentModel.DataAnnotations;
namespace TinTucCTSV.Models.Regency
{
    public class RegencyViewModel
    {
        [Display(Name = "Mã Chức vụ")]
        public string Id { get; set; }

        [Display(Name = "Tên Chức vụ")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }
}