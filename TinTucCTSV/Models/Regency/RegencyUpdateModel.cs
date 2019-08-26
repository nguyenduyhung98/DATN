using System.ComponentModel.DataAnnotations;
namespace TinTucCTSV.Models.Regency
{
    public class RegencyUpdateModel
    {
        public string Id { get; set; }
        [Display(Name="Tên chức vụ")]
        public string Name { get; set; }
    }
}