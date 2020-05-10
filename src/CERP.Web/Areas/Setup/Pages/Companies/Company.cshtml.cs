using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CERP.Web.Areas.Setup.Pages.CompanySetup
{
    public class CompanyModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Guid CompanyId { get; set; }
        public void OnGet()
        {
        }
    }
}
