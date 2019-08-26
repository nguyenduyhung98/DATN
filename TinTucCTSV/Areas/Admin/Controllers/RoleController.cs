using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TinTucCTSV.Data.Models;
using TinTucCTSV.Models.Role;

namespace TinTucCTSV.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class RoleController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles
                .Select(role => new RoleViewModel
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description
                });
            var model = new RoleIndexModel
            {
                RolesList = roles
            };
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(NewRoleModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new ApplicationRole
                {
                    Name = model.Name,
                    Description = model.Description
                };
                await _roleManager.CreateAsync(role);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Update(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            if (Id == null)
            {
                return NotFound();
            }
            var model = new UpdateRoleModel
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateRoleModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(model.Id);

                role.Name = model.Name;
                role.Description = model.Description;
                await _roleManager.UpdateAsync(role);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var role = await _roleManager.FindByIdAsync(Id);
            await _roleManager.DeleteAsync(role);
            return RedirectToAction(nameof(Index));
        }
    }
}