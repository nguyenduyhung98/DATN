using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinTucCTSV.Models.Post;

namespace TinTucCTSV.Models.Search
{
    public class ResultViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
        public string SearchQuery { get; set; }
        public bool EmptySearchQuery { get; set; }
    }
}
