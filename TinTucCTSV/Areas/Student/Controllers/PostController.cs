using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TinTucCTSV.Data.Extends;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Data.Models;
using TinTucCTSV.Data.Utility;
using TinTucCTSV.Models.Post;
using TinTucCTSV.Models.Reply;
using Microsoft.AspNetCore.Hosting;

namespace TinTucCTSV.Areas.Student.Controllers
{
    [Area("Student")]
    public class PostController : Controller
    {
        private readonly IPost _postService;
        private readonly IForum _forumService;
        private readonly IComment _commentService;
        private readonly ILogger<PostViewModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _hostingEnviroment;
        public PostController(IPost postService,
                              IForum forumServie,
                              UserManager<ApplicationUser> userManager,
                              ILogger<PostViewModel> logger,
                              IComment commentService,
                              IHostingEnvironment hostingEnviroment)
        { 
            _postService = postService;
            _forumService = forumServie;
            _userManager = userManager;
            _logger = logger;
            _commentService = commentService;
            _hostingEnviroment = hostingEnviroment;
        }

        //Show Detail Post
        [Route("Topic/Post/{id}")]
        public IActionResult Index(int Id, int? pageIndex)
        {
            var post = _postService.GetById(Id);
            var replies = BuildPostReplies(post.Replies);
            var model = new PostViewModel{
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Created = post.Created,
                AuthorId = post.User.Id,
                NumberRead = post.NumberRead,
                AuthorName = GetFullName.FullName(post.User.LastName,post.User.FirstName),
                ImageProfile = post.User.ProfileImageUrl,
                FileUrl = post.FileUrl,
                AuthorRating = post.User.Rating,
                RepliesCount = post.Replies.Count(),
                UrlHttp = HttpContext.Request.PathBase,
                Replies = replies
            };
                _postService.ViewPost(Id);
            return View(model);
        }

        //Forum student
        public IActionResult Forum(){
            var posts = _postService.GetPostForumStudent()
            .Select(p => new PostViewModel{
                Id = p.Id,
                Title = p.Title,
                Content = p.Content
            });
            var model = new PostIndexModel{
                ListPosts = posts
            };
            return View(model);
        }
        //Create post
        [Route("Post/Create/{id}")]
        public IActionResult Create(int id)
        {
            var forumId = _forumService.GetById(id);
            var model = new NewPostModel{
                ForumName = forumId.Title,
                AuthorName = User.Identity.Name,
                ForumImageUrl = forumId.ImageUrl,
                ForumId = forumId.Id
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
                var userId = _userManager.GetUserId(User);
                var user = _userManager.FindByIdAsync(userId).Result;
                var post = BuildPost(model,user);

                await _postService.Add(post);
                return RedirectToAction("Forum","Post");
        }
        //Add Comments
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ReplyPost(PostViewModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = _userManager.FindByIdAsync(userId).Result;
            var post = _postService.GetById(model.Id);
            var reply = new PostReply
            {
                Content = model.NewReply.Content,
                Created = DateTime.Now,
                User = user,
                Post = post
            };
            await _commentService.AddReply(reply);
            return RedirectToAction("Index", "Post", new { Id = reply.Post.Id });
        }

        //End Comment
        public IActionResult Searching(string sortOrder, string searchQuery){
            ViewData["FilterFunction"] = searchQuery;
            var posts = _postService.GetFilteredPost(sortOrder, searchQuery)
                .Select(p => new PostViewModel{
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    Created = p.Created                    
                });
                var model = new PostIndexModel{
                    SearchQuery = posts
                };
            return View(model);
        }
        //Create post build
        private Post BuildPost(NewPostModel model, ApplicationUser user)
        {
            var forum = _forumService.GetById(model.ForumId);
            
            return new Post
            {
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now,
                Status = false,
                User = user,
                Forum = forum
            };
        }

        private IEnumerable<PostViewReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.OrderByDescending(r =>r.Created).Select(r => new PostViewReplyModel
            {
                AuthorId = r.User.Id,
                AuthorName = GetFullName.FullName(r.User.LastName,r.User.FirstName),
                AuthorRating = r.User.Rating,
                AuthorImageUrl = r.User.ProfileImageUrl,
                Created = r.Created,
                ReplyContent = r.Content
            }).ToList();
        }
    }
}