using System.ComponentModel.DataAnnotations;
namespace TinTucCTSV.Models.Form
{
    public class FormNewModel
    {
        [Display(Name="Tên biểu mẫu")]
        public string Title { get; set; }
        [Display(Name="Liên kết")]
        public string LinkUrl { get; set; }
        public string Created { get; set; }
    }
}