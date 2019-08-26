using System.IO;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Data.Models;
using TinTucCTSV.Data.Utility;
using TinTucCTSV.Models.Forum;

namespace TinTucCTSV.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        private readonly IPost _postService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _hostingEnviroment;
        private string nameUpload = Guid.NewGuid().ToString();
        public ForumController(IForum forumService, IPost postService, UserManager<ApplicationUser> userManager,
            IHostingEnvironment hostingEnviroment)
        {
            _forumService = forumService;
            _postService = postService;
            _userManager = userManager;
            _hostingEnviroment = hostingEnviroment;
        }

        public IActionResult Index(){
            var forums = _forumService.GetAll()
            .Select(forum => new ForumViewModel{
                Id = forum.Id,
                Title = forum.Title,
                Description = forum.Description
            });
            var model = new ForumIndexModel{
                ForumList = forums
            };
            return View(model);
        }
        //Add Forum
        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ForumNewModel model){
            if (ModelState.IsValid)
            {
                string urlImage = "";
                string roorPath = _hostingEnviroment.WebRootPath;
                model.ImageForum = HttpContext.Request.Form.Files;

                var idNew = Guid.NewGuid();
                var supportedTypes = new[] { ".jpg", ".jpeg", ".png" };

                if (model.ImageForum.Count != 0)
                {
                    var uploads = Path.Combine(roorPath,SD.FolderDefault+"/"+ SD.FolderImages + "/" + SD.pathForum);
                    var extension = Path.GetExtension(model.ImageForum[0].FileName).ToLower();

                    using (var filestream = new FileStream(Path.Combine(uploads, idNew + extension), FileMode.Create))
                    {
                        model.ImageForum[0].CopyTo(filestream);
                    }
                    if (!supportedTypes.Contains(extension))  
                    {  
                       TempData["Message"] = "file fail!"; 
                       return RedirectToAction(nameof(Create));
                    }  
                    else  
                    {  
                        urlImage = idNew + extension; 
                    }
                }
                var forum = new Forum
                {
                    Title = model.Title,
                    Description = model.Description,
                    ImageUrl = urlImage
                };
                await _forumService.Create(forum);
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Create));
        }

        //Update  forum
        public IActionResult Update(int Id)
        {
            var forum = _forumService.GetById(Id);
            if (forum == null)
            {
                return NotFound();
            }
            var model = new ForumUpdateModel
            {
                Id = forum.Id,
                Title = forum.Title,
                Description = forum.Description,
                ImageForum = forum.ImageUrl
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ForumUpdateModel model)
        {
            var forum = _forumService.GetById(model.Id);
            string urlImage = forum.ImageUrl;
            if (ModelState.IsValid)
            {
                string roorPath = _hostingEnviroment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var supportedTypes = new[] { ".jpg", ".jpeg", ".png",".gif"};
                var idNew = Guid.NewGuid();
                if (files.Count != 0)
                {
                    var uploads = Path.Combine(roorPath,SD.FolderDefault+"/"+ SD.FolderImages + "/" + SD.pathForum);
                    var extension = Path.GetExtension(files[0].FileName).ToLower();

                    using (var filestream = new FileStream(Path.Combine(uploads, idNew + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    if (!supportedTypes.Contains(extension))  
                    {  
                       TempData["Message"] = "Định dạng file không hợp lệ !"; 
                       return RedirectToAction("Update","Forum", new{Id = model.Id});
                    }  
                    else  
                    {  
                        urlImage = idNew + extension; 
                    }
                }
                await _forumService.UpdateForum(model.Id,
                model.Title,
                model.Description, urlImage);

                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Update));
        }
        //Delete Forum
        public async Task<IActionResult> Delete(int Id)
        {
            await _forumService.Delete(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}