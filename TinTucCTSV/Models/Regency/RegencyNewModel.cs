using System.ComponentModel.DataAnnotations;

namespace TinTucCTSV.Models.Regency
{
    public class RegencyNewModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; }
        
        [Required]
        [Display(Name = "Tên chức vụ")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }
}