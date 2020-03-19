using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Volo.Abp.Account.Web.Areas.Account.Pages.Account
{
    public class AccessDeniedModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccessDeniedModel> _logger;

        [BindProperty(SupportsGet = true)]
        public string From { get; set; }

        public AccessDeniedModel(SignInManager<IdentityUser> signInManager,
            ILogger<AccessDeniedModel> logger,
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            if(!_signInManager.IsSignedIn(User))
            {
                return RedirectToPage("/Login");
            }

            return Page();
        }
    }
}

