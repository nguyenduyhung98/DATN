using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Data.Models;
using TinTucCTSV.Data.Utility;
using TinTucCTSV.Models.Forum;
using TinTucCTSV.Models.Post;

namespace TinTucCTSV.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator,Manager")]

    public class PostController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IForum _forumService;
        private readonly IPost _postService;
        private readonly IComment _commentService;
        private readonly IHostingEnvironment _hostingEnviroment;
        public PostController(IPost postService, UserManager<ApplicationUser> userManager, IForum forumService, IComment commentService,
            IHostingEnvironment hostingEnviroment)
        {
            _postService = postService;
            _userManager = userManager;
            _forumService = forumService;
            _commentService = commentService;
            _hostingEnviroment = hostingEnviroment;
        }
        public IActionResult Index(string sortOrder, string searchString, int? pageIndex)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty (sortOrder) ? "Name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "Date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var posts = _postService.GetFilteredPost(sortOrder,searchString).Where(p =>p.Status == true)
                .Select(post => new PostViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    Created = post.Created,
                    AuthorId = post.User.Id,
                    AuthorName = post.User.UserName,
                    AuthorRating = post.User.Rating,
                    Status = post.Status,
                    ImageProfile = post.User.ProfileImageUrl,
                    FileUrl = post.FileUrl,
                    NumberRead = post.NumberRead,
                    RepliesCount = post.Replies.Count()
                });
            var model = new PostIndexModel
            {
                ListPosts = posts
            };        
            return View(model);
        }

        //---------

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
        public IActionResult Create()
        {
            ViewBag.dropListForums = _forumService.listForumKeyValue().ToList();
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
            ViewBag.dropListForums = _forumService.listForumKeyValue().ToList();
            var userId = _userManager.GetUserId(User);
            var user = _userManager.FindByIdAsync(userId).Result;

            if (ModelState.IsValid)
            {
                string urlImage = "";
                string roorPath = _hostingEnviroment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var supportedTypes = new[] { ".txt", ".doc", ".docx", ".pdf", ".xls", ".xlsx" }; 
                if (files.Count != 0)
                {
                    var uploads = Path.Combine(roorPath,SD.FolderDefault+ "/" + SD.pathFiles);
                    var extension = Path.GetExtension(files[0].FileName).ToLower();

                    using (var filestream = new FileStream(Path.Combine(uploads, model.Title + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    if (!supportedTypes.Contains(extension))  
                    {  
                       TempData["Message"] = "Định dạng file không hợp lệ !"; 
                       return RedirectToAction(nameof(Create));
                    }  
                    else  
                    {  
                        urlImage = model.Title + extension;
                    }
                }
                    var post = new Post
                    {
                        Title = model.Title,
                        Content = model.Content,
                        Created = DateTime.Now,
                        Status = false,
                        FileUrl = urlImage,
                        User = user,
                        ForumId = model.ForumId
                    };
                    await _postService.Add(post);
                    return RedirectToAction(nameof(Index));
                }
            return View(nameof(Create));
        }

        public IActionResult Update(int Id){
            var post = _postService.GetById(Id);
            var model = new UpdatePostModel{
                Id = post.Id,
                Title = post.Title,
                Content = post.Content
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePost(int Id, UpdatePostModel model){
            if (ModelState.IsValid)
            {
                await _postService.EditPost(Id,
                model.Title,
                model.Content
                );
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int Id){
            await _postService.Delete(Id);
            return RedirectToAction(nameof(Index));
        }

        //Post Detail
        public IActionResult Detail(int Id)
        {
            var post = _postService.GetById(Id);
            var model = new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Created = post.Created,
                AuthorName = post.User.UserName,
                Forum = BuildPostForum(post)
            };
            return View(model);
        }

        private ForumViewModel BuildPostForum(Post post)
        {
            var forum = post.Forum;
            return new ForumViewModel
            {
                Id = forum.Id,
                Title = forum.Title,
                Description = forum.Description
            };
        }
    }
}