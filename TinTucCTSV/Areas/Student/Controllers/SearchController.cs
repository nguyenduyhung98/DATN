using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TinTucCTSV.Data.Extends;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Data.Models;
using TinTucCTSV.Models.Forum;
using TinTucCTSV.Models.Post;
using TinTucCTSV.Models.Search;

namespace TinTucCTSV.Areas.Student.Controllers
{
    [Area("Student")]
    public class SearchController : Controller
    {
        private readonly IPost _postService;
        public SearchController(IPost postService)
        {
            _postService = postService;
        }
        public IActionResult Results(string stringQuery)
        {
            var posts = _postService.SeachPost(stringQuery);
            var noResult = (!String.IsNullOrEmpty(stringQuery) && !posts.Any());
            var result = posts 
                .Select(post => new PostViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    AuthorName = GetFullName.FullName(post.User.LastName, post.User.FirstName),
                    AuthorRating = post.User.Rating,
                    Created = post.Created,
                    RepliesCount = post.Replies.Count(),
                    Forum = BuildForum(post)
                });
            var model = new ResultViewModel
            {
                Posts = result,
                SearchQuery = stringQuery,
                EmptySearchQuery = noResult
            };
            return View(model);
        }


        public IActionResult Search(string stringQuery)
        {
            return RedirectToAction("Results", new { stringQuery });
        }

        private ForumViewModel BuildForum(Post post)
        {
            var forum = post.Forum;
            return new ForumViewModel
            {
                Id = forum.Id,
                Title = forum.Title,
                ImageUrl = forum.ImageUrl,
                Description = forum.Description
            };
        }
    }
}