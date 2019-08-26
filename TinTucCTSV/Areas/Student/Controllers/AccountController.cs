using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TinTucCTSV.Data.Extends;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Data.Models;
using TinTucCTSV.Data.Utility;
using TinTucCTSV.Models.Account;

namespace TinTucCTSV.Areas.Student.Controllers
{
    [Area("Student")]
    public class AccountController : Controller
    {
        private readonly IHostingEnvironment _hostingEnviroment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUser _userService;
        public AccountController(UserManager<ApplicationUser> userManager, IHostingEnvironment hostingEnviroment,
        IUser userService){
            _userManager = userManager;
            _hostingEnviroment = hostingEnviroment;
            _userService = userService;
        }

        public async Task<IActionResult> Update(string Id){
            if (Id == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return NotFound();
            }
            var model = new ChangeInformation()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                IsActive = user.IsActive,
                ProfileImageUrl = user.ProfileImageUrl
                //Department = user.DepartmentId,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeInformation(ChangeInformation changeInformation)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(changeInformation.Id);

                string roorPath = _hostingEnviroment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var supportedTypes = new[] { ".jpg", ".jpeg", ".png" };

                if (files.Count != 0)
                {
                    var uploads = Path.Combine(roorPath,SD.FolderDefault+"/"+ SD.FolderImages + "/" + SD.pathProfiles);
                    var extension = Path.GetExtension(files[0].FileName).ToLower();

                    using (var filestream = new FileStream(Path.Combine(uploads, changeInformation.Id + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    if (!supportedTypes.Contains(extension))  
                    {  
                       TempData["Message"] = "Định dạng file không hợp lệ !"; 
                       return RedirectToAction("Update","Account", new{Id = changeInformation.Id});
                    }  
                    else  
                    {  
                        user.ProfileImageUrl = changeInformation.Id + extension; 
                    }
                }
                    user.Email = changeInformation.Email;
                    user.IsActive = changeInformation.IsActive;
                    user.PhoneNumber = changeInformation.PhoneNumber;
                        
                    TempData["Message"] = "User Updated Successfully. ";

                return RedirectToAction("Index","Home");
            }
            return View(nameof(Update));
        }

        public async Task<IActionResult> ChangePassword(string Id){
             if (Id == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(Id);
            var result = new ChangePassword{
                Id = user.Id,
                UserName = user.UserName
            };
            return View(result);
        }
      
    }
    
}