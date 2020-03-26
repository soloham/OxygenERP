using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp.Account.Web.Pages.Account;

namespace CERP.Web.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : AccountPageModel
    {
        private readonly ILogger<LogoutModel> _logger;

        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public string ReturnUrlHash { get; set; }
        public LogoutModel(ILogger<LogoutModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            await SignInManager.SignOutAsync();
            if (ReturnUrl != null)
            {
                return RedirectSafely(ReturnUrl, ReturnUrlHash);
            }

            return RedirectToPage("/Login");
        }
    }
}
