using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TinTucCTSV.Data.Enums;
using TinTucCTSV.Data.Extends;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Data.Models;
using TinTucCTSV.Data.Utility;
using TinTucCTSV.Models.Account;

namespace TinTucCTSV.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Administrator")]
    public class AccountController : Controller
    {
        [TempData]
        public string StatusMessage { get; set; }
        private readonly IHostingEnvironment _hostingEnviroment;
        private readonly IRegency _regencyService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
            IHostingEnvironment hostingEnviroment, IRegency regencyService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _hostingEnviroment = hostingEnviroment;
            _regencyService = regencyService;
        }
        public async Task<IActionResult> Index(int? pageIndex)
        {
            var accounts = _userManager.Users.Include(p => p.Regency).Select(user => new AccountViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FullName = GetFullName.FullName(user.LastName,user.FirstName),
                Created = user.MemberSince,
                ImageProfile = user.ProfileImageUrl,
                Regency = user.Regency.Name
            });
            int pageSize = 10;
            var result = await PaginatedList<AccountViewModel>.CreateAsync(accounts, pageIndex ?? 1, pageSize);
            var model = new AccountIndexModel()
            {
                Accounts = result.AsQueryable()
            };
           
            return View(model);
        }

        //Register Account
        public IActionResult Create()
        {
            ViewBag.listRoles = _roleManager.Roles.Where(r => r.Name != Roles.Administrator.ToString()).ToList();
            ViewBag.Regencies = _regencyService.GetAll().ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewAccountModel model)
        {
            ViewBag.listRoles = _roleManager.Roles.Where(r => r.Name != Roles.Administrator.ToString()).ToList();
            ViewBag.Regencies = _regencyService.GetAll().ToList();
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    DayOfBirth = model.DateOfBirth,
                    ProfileImageUrl = "default.jpg",
                    IsActive = true,
                    EmailConfirmed = false,
                    MemberSince = DateTime.Now.Date,
                    PhoneNumber = model.PhoneNumber,
                    RegencyId = model.RegencyId
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Student");
                    StatusMessage = "User Created Successfully. ";
                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        //Update Account
        public async Task<IActionResult> Update(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return NotFound();
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            ViewBag.DepartmentList = _regencyService.GetAll().ToList();
            var model = new ChangeInformation()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                IsActive = user.IsActive,
                Gender = user.Gender,
                IsLock = user.LockoutEnabled,
                DataOfBirth = user.DayOfBirth.ToDate(),
                ProfileImageUrl = user.ProfileImageUrl,
                Regency = user.RegencyId,
                RolesList = _roleManager.Roles.ToList().Select(x => new SelectListItem()
                {
                    Selected = userRoles.Contains(x.Name),
                    Text = x.Name,
                    Value = x.Name
                })
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeInformation(ChangeInformation changeInformation)
        {
            ViewBag.DepartmentList = _regencyService.GetAll().ToList();
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
                       StatusMessage = "Định dạng file không hợp lệ !"; 
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
                    user.RegencyId = changeInformation.Regency;
                    user.Gender = changeInformation.Gender;
                    // user.DayOfBirth = changeInformation.DataOfBirth.ConvertDateTime();
                        
                var userRoles = await _userManager.GetRolesAsync(user);
      
                var resultRemote = await _userManager.RemoveFromRolesAsync(user, userRoles);
                    if (!resultRemote.Succeeded)
                    {
                        ModelState.AddModelError("", resultRemote.Errors.ToString());
                    }
                var result = await _userManager.AddToRoleAsync(user, changeInformation.Role);

                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", result.Errors.ToString());
                    }
                    StatusMessage = "User Updated Successfully. ";

                return RedirectToAction("Index");
            }
            return View(nameof(Update));
        }

        //Delete Account
        public async Task<IActionResult> Delete(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            //Gets list of Roles associated with current user
            var rolesForUser = await _userManager.GetRolesAsync(user);

                if (rolesForUser.Count() > 0)
                {
                    foreach (var role in rolesForUser.ToList())
                    {
                        // item should be the name of the role
                        var result = await _userManager.RemoveFromRoleAsync(user, role);
                    }
                }   
                //Delete User
                await _userManager.DeleteAsync(user);

                StatusMessage = "User Deleted Successfully. ";
            return RedirectToAction(nameof(Index));
        }

        //ChangePassword

        public async Task<IActionResult> ChangePassword(string Id)
        {
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePassword model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (ModelState.IsValid)
            {
               user.PasswordHash = _userManager.PasswordHasher.HashPassword(user,model.NewPassword);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction("ChangePassword", "Account", new { Id = model.Id });
        }

        public async Task<IActionResult> SetLookoutEnable(string Id){
            var user = await _userManager.FindByIdAsync(Id);
            var dateLockEnbale = DateTime.Now.AddDays(1);
            await _userManager.SetLockoutEnabledAsync(user,true);
            await _userManager.SetLockoutEndDateAsync(user,dateLockEnbale);
            StatusMessage = "LookEnable sucesss";
            return RedirectToAction("Update","Account", new {Id = Id});
        }

        public async Task<IActionResult> UnlookUser(string Id){
            var user = await _userManager.FindByIdAsync(Id);
            var result = await _userManager.SetLockoutEnabledAsync(user, false);
            if (result.Succeeded)
            {
                await _userManager.SetLockoutEnabledAsync(user,false);
                await _userManager.ResetAccessFailedCountAsync(user);
            }
            return RedirectToAction("Update","Account", new {Id = Id});
        }
         public async Task<IActionResult> Profile(){
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = await _userManager.FindByIdAsync(userId);
            var model = new ProfileViewModel{
                Id = user.Id,
                Name = GetFullName.FullName(user.LastName,user.FirstName),
                ImageProfile = user.ProfileImageUrl,
                Created = user.MemberSince
            };
            return View(model);
        }
    }
}