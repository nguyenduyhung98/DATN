using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TinTucCTSV.Data.Extends;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Models.Comment;

namespace TinTucCTSV.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Administrator")]
    public class CommentController : Controller
    {
        private readonly IComment _commentService;
        private readonly IPost _postService;
        public CommentController(IComment commentService, IPost postService){
            _commentService = commentService;
            _postService = postService;
        }
        public IActionResult Index() {
            var comments = _commentService.GetAll()
            .Select(c => new CommentViewModel {
                Id = c.Id,
                ContentCmt = c.Content,
                Commented = c.Created
            });
            var model = new CommentIndexModel{
                listComment = comments
            };
            return View(model);
        }
    }
}