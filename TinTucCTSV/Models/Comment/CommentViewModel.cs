using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TinTucCTSV.Models.Account;
using TinTucCTSV.Models.Post;

namespace TinTucCTSV.Models.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string ContentCmt { get; set; }

        public DateTime Commented { get; set; }

        public PostViewModel Posts { get; set; }
        public AccountViewModel Users { get; set; }
    }
}