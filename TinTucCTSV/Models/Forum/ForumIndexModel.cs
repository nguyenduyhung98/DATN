using System;
using System.Collections.Generic;
using TinTucCTSV.Models.Post;

namespace TinTucCTSV.Models.Forum
{
    public class ForumIndexModel
    {
        public IEnumerable<ForumViewModel> ForumList { get; set; }
        public IEnumerable<PostViewModel> NewsPostList { get; set; }
        public string SearchQuery { get; set; }
    }
}
