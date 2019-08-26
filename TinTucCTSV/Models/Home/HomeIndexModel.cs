using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinTucCTSV.Models.Post;

namespace TinTucCTSV.Models.Home
{
    public class HomeIndexModel
    {
        public string SearchPosst { get; set; }
        public IEnumerable<PostViewModel> LasterPosts { get; set; }
    }
}
