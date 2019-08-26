using PagedList.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TinTucCTSV.Models.Reply;
namespace TinTucCTSV.Models.Post
{
    public class PostIndexModel
    {
        public IPagedList<PostViewModel> ListPostss { get; set; }
        public IEnumerable<PostViewModel> ListPosts { get; set; }
        public IEnumerable<PostViewModel> SearchQuery { get; set; }
    }
}
