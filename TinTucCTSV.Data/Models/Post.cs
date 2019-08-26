using System;
using System.Collections.Generic;

namespace TinTucCTSV.Data.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public int NumberRead { get; set; }
        public bool Status { get; set; }
        public string FileUrl { get; set; }
        public int ForumId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Forum Forum { get; set; }
        public virtual IEnumerable<PostReply> Replies { get; set; }
    }
}