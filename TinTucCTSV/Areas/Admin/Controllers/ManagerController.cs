using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Models.Post;

namespace TinTucCTSV.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator,Manager")]
    public class ManagerController : Controller
    {
        private readonly IPost _postService;
        public ManagerController(IPost postService){
            _postService = postService;
        }
        public IActionResult ReviewPostStatus()
        {
            var posts = _postService.GetAll().Where(p => p.Status == false)
                .Select(post => new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorRating = post.User.Rating,
                Created = post.Created,
                Status = post.Status,
                NumberRead = post.NumberRead,
                ImageProfile = post.User.ProfileImageUrl,
                RepliesCount = post.Replies.Count()
            });
            var model = new PostIndexModel
            {
                ListPosts = posts
            };
            return View(model);
        }
        
        public async Task<IActionResult> CheckStatus(int Id)
        {
            await _postService.IsStatus(Id, true);
            return RedirectToAction(nameof(ReviewPostStatus));
        }
    }
}