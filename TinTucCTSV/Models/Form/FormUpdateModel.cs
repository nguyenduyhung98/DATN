using System.ComponentModel.DataAnnotations;
namespace TinTucCTSV.Models.Form
{
    public class FormUpdateModel
    {
        public int Id { get; set; }
        
        [Display(Name="Tên biểu mẫu")]
        public string Title { get; set; }

        [Display(Name="Liên kết")]
        public string LinkUrl { get; set; }
    }
}