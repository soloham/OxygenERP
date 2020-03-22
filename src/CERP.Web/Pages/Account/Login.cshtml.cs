using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Account.Settings;
using Volo.Abp.Account.Web;
using Volo.Abp.Account.Web.Pages.Account;
using Volo.Abp.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.Security.Claims;
using Volo.Abp.Settings;
using Volo.Abp.Uow;
using Volo.Abp.Validation;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace CERP.Web.Pages.Account
{
    [AllowAnonymous]
    public class CustomLoginModel : LoginModel
    {

        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public new string ReturnUrl { get; set; }

        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public new string ReturnUrlHash { get; set; }
        public new bool EnableLocalLogin { get; set; }

        //TODO: Why there is an ExternalProviders if only the VisibleExternalProviders is used.
        public new IEnumerable<ExternalProviderModel> ExternalProviders { get; set; }
        public new IEnumerable<ExternalProviderModel> VisibleExternalProviders => ExternalProviders.Where(x => !String.IsNullOrWhiteSpace(x.DisplayName));

        public new bool IsExternalLoginOnly => EnableLocalLogin == false && ExternalProviders?.Count() == 1;
        public new string ExternalLoginScheme => IsExternalLoginOnly ? ExternalProviders?.SingleOrDefault()?.AuthenticationScheme : null;


        public CustomLoginModel(
            IAuthenticationSchemeProvider schemeProvider,
            IOptions<AbpAccountOptions> accountOptions) : base(
        schemeProvider,
        accountOptions)
        {
        }

        [BindProperty]
        public LoginInputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        [UnitOfWork]
        public async override Task<IActionResult> OnPostExternalLogin(string provider)
        {
            var redirectUrl = Url.Page("./Login", pageHandler: "ExternalLoginCallback", values: new { ReturnUrl, ReturnUrlHash });
            var properties = SignInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            properties.Items["scheme"] = provider;

            return Challenge(properties, provider);
        }

        [UnitOfWork]
        public override async Task<IActionResult> OnGetExternalLoginCallbackAsync(string returnUrl = "", string returnUrlHash = "", string remoteError = null)
        {
            //TODO: Did not implemented Identity Server 4 sample for this method (see ExternalLoginCallback in Quickstart of IDS4 sample)
            /* Also did not implement these:
             * - Logout(string logoutId)
             */

            if (remoteError != null)
            {
                Logger.LogWarning($"External login callback error: {remoteError}");
                return RedirectToPage("./Login");
            }

            var loginInfo = await SignInManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                Logger.LogWarning("External login info is not available");
                return RedirectToPage("./Login");
            }

            var result = await SignInManager.ExternalLoginSignInAsync(
                loginInfo.LoginProvider,
                loginInfo.ProviderKey,
                isPersistent: false,
                bypassTwoFactor: true
            );

            if (result.IsLockedOut)
            {
                throw new UserFriendlyException("Cannot proceed because user is locked out!");
            }

            if (result.Succeeded)
            {
                return RedirectSafely(returnUrl, returnUrlHash);
            }

            //TODO: Handle other cases for result!

            // Get the information about the user from the external login provider
            var info = await SignInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                throw new ApplicationException("Error loading external login information during confirmation.");
            }

            var user = await CreateExternalUserAsync(info);

            await SignInManager.SignInAsync(user, false);
            return RedirectSafely(returnUrl, returnUrlHash);
        }

        protected override async Task<IdentityUser> CreateExternalUserAsync(ExternalLoginInfo info)
        {
            var emailAddress = info.Principal.FindFirstValue(AbpClaimTypes.Email);

            var user = new IdentityUser(GuidGenerator.Create(), emailAddress, emailAddress, CurrentTenant.Id);

            CheckIdentityErrors(await UserManager.CreateAsync(user));
            CheckIdentityErrors(await UserManager.SetEmailAsync(user, emailAddress));
            CheckIdentityErrors(await UserManager.AddLoginAsync(user, info));

            return user;
        }

        protected override async Task ReplaceEmailToUsernameOfInputIfNeeds()
        {
            if (!ValidationHelper.IsValidEmailAddress(Input.UserNameOrEmailAddress))
            {
                return;
            }

            var userByUsername = await UserManager.FindByNameAsync(Input.UserNameOrEmailAddress);
            if (userByUsername != null)
            {
                return;
            }

            var userByEmail = await UserManager.FindByEmailAsync(Input.UserNameOrEmailAddress);
            if (userByEmail == null)
            {
                return;
            }

            Input.UserNameOrEmailAddress = userByEmail.UserName;
        }

        protected override async Task CheckLocalLoginAsync()
        {
            if (!await SettingProvider.IsTrueAsync(AccountSettingNames.EnableLocalLogin).ConfigureAwait(false))
            {
                throw new UserFriendlyException(L["LocalLoginDisabledMessage"]);
            }
        }

        public new class LoginInputModel
        {
            [Required]
            [Display(Name = "Username or Email")]
            [StringLength(IdentityUserConsts.MaxEmailLength)]
            public string UserNameOrEmailAddress { get; set; }

            [Required]
            [StringLength(IdentityUserConsts.MaxPasswordLength)]
            [DataType(DataType.Password)]
            [DisableAuditing]
            public string Password { get; set; }

            public bool RememberMe { get; set; }
        }

        public new class ExternalProviderModel
        {
            public string DisplayName { get; set; }
            public string AuthenticationScheme { get; set; }
        }
    }
}
