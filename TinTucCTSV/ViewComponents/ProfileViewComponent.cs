using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TinTucCTSV.Data.Models;
using TinTucCTSV.Models.Account;

namespace TinTucCTSV.ViewComponents
{
    public class ProfileViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ProfileViewComponent(UserManager<ApplicationUser> userManager){
            _userManager = userManager;
        }
         public async Task<IViewComponentResult> InvokeAsync(){
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = await _userManager.FindByIdAsync(userId);
            var model = new ProfileViewModel{
                Id = user.Id,
                Name = user.FirstName,
                ImageProfile = user.ProfileImageUrl,
                Created = user.MemberSince
            };
            return View(model);
        }
    }
}