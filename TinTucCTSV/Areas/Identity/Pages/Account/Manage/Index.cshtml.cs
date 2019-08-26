using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TinTucCTSV.Data.Extends;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Data.Models;

namespace TinTucCTSV.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmail _emailSender;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUser _userService;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmail emailSender,
            RoleManager<ApplicationRole> roleManager,
            IUser userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _userService = userService;
        }

        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }

        [Display(Name ="Email chưa xác thực")]
        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Số điện thoại")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Họ và tên")]
            public string FullName { get; set; }

            [Display(Name = "Ngày sinh")]
            public string DataOfBirth;
           
            [Display(Name = "Hình ảnh")]
            public string ImageProfile { get; set; }

            [Display(Name ="Giới tính")]
            public bool Gender { get; set; }

            [Display(Name ="Chức vụ")]
            public string Department { get; set; }

            [Display(Name = "Tổng bài viết: ")]
            public int PostCount { get; set; }
        }

        [Route("Home/Account/Information")]
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var userId = _userService.GetById(user.Id);

            Username = user.UserName;

            Input = new InputModel
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                FullName = GetFullName.FullName(user.LastName,user.FirstName),
                Department = user.Regency.Name,
                Gender = user.Gender,
                DataOfBirth = user.DayOfBirth.ToDate(),
                ImageProfile = user.ProfileImageUrl,
                PostCount = user.Posts.Count()
            };
            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
            return Page();
        }

        [Route("Home/Account/Information")]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            user.Gender = Input.Gender;
            // user.DayOfBirth = Input.DataOfBirth.ConvertDateTime();
            //user.ProfileImageUrl = Input.ImageProfile;
            await _userManager.UpdateAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Tài khoản  không tồn tại '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Xác thực email",
                $"Yêu cầu xác thực email cho tai khoản {User.Identity.Name} <a href='{callbackUrl}'>clicking here</a>");

            StatusMessage = "Gửi email thành công , vui lòng kiểm tra hộp thư !!";
            return RedirectToPage();
        }
    }
}
