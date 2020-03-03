using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CERP.App;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.Domain.Repositories;

namespace CERP.Web.Areas.HR.Pages.Employees
{
    public class CreateModel : CERPPageModel
    {
        public IRepository<DictionaryValue, Guid> DictionaryValuesRepo;

        public CreateModel(IRepository<DictionaryValue, Guid> dictionaryValuesRepo)
        {
            DictionaryValuesRepo = dictionaryValuesRepo;
        }

        public void OnGet()
        {
        }
    }
}
