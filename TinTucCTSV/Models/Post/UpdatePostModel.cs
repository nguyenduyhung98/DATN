using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TinTucCTSV.Models.Post
{
    public class UpdatePostModel
    {
        public int Id { get; set; }
        [Display(Name ="Tiêu đề")]
        public string Title { get; set; }
        [Display(Name ="Nội dung")]
        public string Content { get; set; }
    }
}
