using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using TinTucCTSV.Models.Forum;
using TinTucCTSV.Models.Reply;

namespace TinTucCTSV.Models.Post
{
    public class PostViewModel
    {
        [Display(Name ="ID")]
        public int Id { get; set; }
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Id Tác giả")]
        public string AuthorId { get; set; }
        [Display(Name = "Tác giả")]
        public string AuthorName { get; set; }
        [Display(Name = "Đánh giá")]
        public int AuthorRating { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime Created { get; set; }
        [Display(Name ="Trạng thái")]
        public bool Status { get; set; }
        [Display(Name = "Lượt xem")]
        public int NumberRead { get; set; }
        [Display(Name = "Hình ảnh")]
        public string ImageProfile { get; set; }
        [Display(Name = "Tệp đính kèm")]
        public string FileUrl { get; set; }
        [Display(Name = "Tổng bình luận")]
        public int RepliesCount { get; set; }
        public string UrlHttp { get; set; }
        public HostString IsActiveUser { get; set; }
        public ForumViewModel Forum { get; set; }

        public IEnumerable<PostViewReplyModel> Replies { get; set; }
        public NewReplyModel NewReply { get; set; }

    }
}
