using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Settings;
using Volo.Abp.Account.Web.Pages.Account;
using Volo.Abp.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.Settings;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace CERP.Web.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : AccountPageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IAccountAppService _accountAppService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        public string ReturnUrl { get; set; }

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger, IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Username")]
            [StringLength(IdentityUserConsts.MaxUserNameLength)]
            public string Username { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            [StringLength(IdentityUserConsts.MaxEmailLength)]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            [Required]
            [StringLength(IdentityUserConsts.MaxPasswordLength)]
            [DisableAuditing]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToPage("/index");
            }

            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            return Page();
        }


        public virtual async Task<IActionResult> OnPostAsync()
        {
            await CheckSelfRegistrationAsync();

            var registerDto = new RegisterDto
            {
                AppName = "MVC",
                EmailAddress = Input.Email,
                Password = Input.Password,
                UserName = Input.Username,
            };

            if (ModelState.IsValid)
            {
                var userDto = await _accountAppService.RegisterAsync(registerDto);
                var user = await UserManager.GetByIdAsync(userDto.Id);

                var result = await UserManager.SetEmailAsync(user, Input.Email);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = user.Id, code = code },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(ReturnUrl);
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(ReturnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }

        protected virtual async Task CheckSelfRegistrationAsync()
        {
            if (!await SettingProvider.IsTrueAsync(AccountSettingNames.IsSelfRegistrationEnabled) ||
                !await SettingProvider.IsTrueAsync(AccountSettingNames.EnableLocalLogin))
            {
                throw new UserFriendlyException(L["SelfRegistrationDisabledMessage"]);
            }
        }
        //    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        //    {
        //        returnUrl = returnUrl ?? Url.Content("~/");
        //        ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        //        if (ModelState.IsValid)
        //        {
        //            var user = new ApplicationUser { UserName = Input.Username, Email = Input.Email };
        //            var result = await _userManager.CreateAsync(user, Input.Password);
        //            if (result.Succeeded)
        //            {
        //                _logger.LogInformation("User created a new account with password.");

        //                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        //                var callbackUrl = Url.Page(
        //                    "/Account/ConfirmEmail",
        //                    pageHandler: null,
        //                    values: new { area = "Identity", userId = user.Id, code = code },
        //                    protocol: Request.Scheme);

        //                await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
        //                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        //                if (_userManager.Options.SignIn.RequireConfirmedAccount)
        //                {
        //                    return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
        //                }
        //                else
        //                {
        //                    await _signInManager.SignInAsync(user, isPersistent: false);
        //                    return LocalRedirect(returnUrl);
        //                }
        //            }
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, error.Description);
        //            }
        //        }

        //        // If we got this far, something failed, redisplay form
        //        return Page();
        //    //}
        //}
    }
}
