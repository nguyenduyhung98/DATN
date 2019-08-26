using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Data.Models;
using TinTucCTSV.Models.Home;

namespace TinTucCTSV.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Administrator")]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPost _postService;
        private readonly IComment _commentService;
        private readonly IForum _forumService;
        public HomeController(UserManager<ApplicationUser> userManager, IPost postService, IComment commentService, IForum forumService)
        {
            _userManager = userManager;
            _postService = postService;
            _commentService = commentService;
            _forumService = forumService;
        }
        public IActionResult Index()
        {
            var numberUsers = _userManager.Users.Count();
            var numberPosts = _postService.GetAll().Where(post =>post.Status == false).Count();
            var numberReplies = _commentService.GetAll().Count();
            var numberForum = _forumService.GetAll().Count();
            var model = new HomeViewModel
            {
                CountUsers = numberUsers,
                CountPosts = numberPosts,
                CountReplies = numberReplies,
                CountForums = numberForum
            };    
            return View(model);
        }
    }
}