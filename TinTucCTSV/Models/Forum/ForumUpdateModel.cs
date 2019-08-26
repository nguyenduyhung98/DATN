using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TinTucCTSV.Models.Forum
{
    public class ForumUpdateModel
    {
        [Display(Name ="ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Upload hình ảnh")]
        public string ImageForum { get; set; }
    }
}