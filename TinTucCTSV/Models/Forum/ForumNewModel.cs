using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TinTucCTSV.Models.Forum
{
    public class ForumNewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage="Vui lòng nhập")]        
        [Display(Name ="Tiêu đề")]
        public string Title { get; set; }
        [Required]
        [Display(Name ="Mô tả")]
        public string Description { get; set; }
        
        [Required]
        [Display(Name ="Upload hình ảnh")]
        public IFormFileCollection ImageForum { get; set; }
    }
}