using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TinTucCTSV.Models.Post;

namespace TinTucCTSV.Models.Forum
{
    public class ForumViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Hình ảnh")]
        public string ImageUrl { get; set; }
        public IEnumerable<PostViewModel> PostsForum { get; set; }
    }
}
