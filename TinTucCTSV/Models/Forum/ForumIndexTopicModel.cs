using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinTucCTSV.Models.Post;
using System.ComponentModel.DataAnnotations;

namespace TinTucCTSV.Models.Forum
{
    public class ForumIndexTopicModel
    {
        public ForumViewModel Forum { get; set; }
        public IEnumerable<PostViewModel> Posts { get; set; }
    }
}
