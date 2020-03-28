using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.TenantManagement;

namespace CERP.Web.Pages
{
    public class IndexModel : CERPPageModel
    {
        public IndexModel(IdentityUserManager userManager)
        {
            UserManager = userManager;
        }

        public IdentityUserManager UserManager { get; set; }
        private ITenantAppService TenantAppService { get; }

        public async void OnGet()
        {
            
        }

        //public async Task<IActionResult> OnGetUpdatePW()
        //{
        //    var user = await UserManager.FindByIdAsync("B2B95099-59AE-0E5F-85EF-39F411EAC38F");
        //    var result = await UserManager.ChangePasswordAsync(user, "AdminSuper55%", "YeeShallPa5$");

        //    if (result.Succeeded)
        //        return new ObjectResult(user.PasswordHash);
        //    else
        //        return StatusCode(500);
        //}
    }
}