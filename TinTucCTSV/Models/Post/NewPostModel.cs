using System.ComponentModel.DataAnnotations;

namespace TinTucCTSV.Models.Post
{
    public class NewPostModel
    {
        [Display(Name="Tiêu đề")]
        public string Title { get; set; }
        [Display(Name="Nội dung")]
        public string Content { get; set; }
        public string AuthorName { get; set; }     
        public string ForumImageUrl { get; set; }
        public string ForumName { get; set; }
        [Display(Name ="Tệp đính kèm")]
        public string FileUrl { get; set; }

        [Display(Name ="Chủ đề")]
        public int ForumId { get; set; }
    }
}
