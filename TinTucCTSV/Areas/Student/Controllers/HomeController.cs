using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using SmartBreadcrumbs.Attributes;
using TinTucCTSV.Data.Extends;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Data.Models;
using TinTucCTSV.Models.Form;
using TinTucCTSV.Models.Forum;
using TinTucCTSV.Models.Home;
using TinTucCTSV.Models.Post;

namespace TinTucCTSV.Areas.Student.Controllers
{
    [Area("Student")]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IForum _forumService;
        private readonly IPost _postService;
        private readonly IEmail _emailService;
        private readonly IForm _formService;
        public HomeController(IForum forumService,
            IPost postService, UserManager<ApplicationUser> userManager, IEmail emailService,
            IForm formService)
        {
            _forumService = forumService;
            _postService = postService;
            _userManager = userManager;
            _emailService = emailService;
            _formService = formService;
        }
        //Home Forum News
        public IActionResult Index()
        {
            var forumGroups = _forumService.GetAll().GroupBy(f => f.Id);

            List<ForumViewModel> forumList = new List<ForumViewModel>();
            List <PostViewModel> postsForum = new List<PostViewModel>();

            foreach (var forumGroup in forumGroups)
            {
                postsForum = new List<PostViewModel>();

                //Lặp qua tất cả các bài post rồi add vào IEnum ForumList
                foreach (var post in forumGroup.FirstOrDefault().Posts)
                {
                    postsForum.Add(new PostViewModel
                    {
                        Id = post.Id,
                        Title = post.Title,
                        Content = post.Content,
                        Created = post.Created,
                        NumberRead = post.NumberRead,
                        Status = post.Status,
                    });
                }

                //Nhận cái bài post sau khi lặp ở trên
                forumList.Add(new ForumViewModel
                {
                    Id = forumGroup.FirstOrDefault().Id,
                    Description = forumGroup.FirstOrDefault().Description,
                    ImageUrl = forumGroup.FirstOrDefault().ImageUrl,
                    Title = forumGroup.FirstOrDefault().Title,
                    //Chứa toàn bộ bài viết theo chủ đề
                    PostsForum = postsForum.OrderByDescending(post =>post.Created).Where(p =>p.Status == true).Take(5)
                });
            }
            var nPost = _postService.GetLastesPost(5);
            var postNews = nPost.Select(p =>new PostViewModel
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                Created = p.Created,
                AuthorName = p.User.UserName
            });
            var model = new ForumIndexModel
            {
                ForumList = forumList,
                NewsPostList = postNews
            };

            return View(model);
        }

        //Chủ đề tin tức
        [Route("Home/Topic/{id}")]
        public IActionResult Topic(int Id, int pageZ = 1)
        {
            var forum = _forumService.GetById(Id);
            var postList =  forum.Posts.OrderByDescending(post =>post.Created).Where(p =>p.Status == true)
                .Select(post => new PostViewModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    AuthorId = post.User.Id,
                    AuthorRating = post.User.Rating,
                    AuthorName = post.User.UserName,
                    ImageProfile = post.User.ProfileImageUrl,
                    Created = post.Created,
                    RepliesCount = post.Replies.Count(),
                    Forum = BuildForumListing(post)
                });

            var model = new ForumIndexTopicModel
            {
                Posts = postList,
                Forum = new ForumViewModel
                {
                    Id = forum.Id,
                    Title = forum.Title,
                    Description = forum.Description,
                    ImageUrl = forum.ImageUrl
                }
            };
            //var result = await PagingList.CreateAsync(IQueryable<model>, 10, pageZ);
            return View(model);
        }

        // public IActionResult Personnel(){
        //     var personnels = _userManager.Users
        //         .Include(p =>p.Department)
        //         .Where(u =>u.Department.Name == "Phòng công tác sinh viên").ToList()
        //         .Select(person => new PersonnelViewModel{
        //             Id = person.Id,
        //             Name = GetFullName.FullName(person.LastName,person.FirstName),
        //             Regency = person.Department.Name
        //         });
            
        //     return View(personnels);
        // }
        //-List Forum
        private ForumViewModel BuildForumListing(Post post)
        {
            var forum = post.Forum;
            var forumModel = new ForumViewModel
            {
                Id = forum.Id,
                Title = forum.Title,
                Description = forum.Description,
                ImageUrl = forum.ImageUrl
            };
            return forumModel;
        }

        //Biểu mẫu sinh viên
        [HttpGet]
        public IActionResult FormHome(){
            var forms = _formService.GetAll()
                .Select(f => new FormViewModel{
                    Id = f.Id,
                    Title = f.Title,
                    Created = f.Created,
                    LinkUrl = f.LinkUrl
                });
            var model = new FormIndexModel{
                listForms = forms
            };
            return PartialView(model);
        }
    }
}