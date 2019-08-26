using System;
using System.ComponentModel.DataAnnotations;

namespace TinTucCTSV.Models.Reply
{
    public class NewReplyModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Ý kiến phản hồi")]
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public string AuthorName { get; set; }
        public int PostId { get; set; }
    }
}
