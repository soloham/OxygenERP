using CERP.App;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.TenantManagement;

namespace CERP.Web.Pages
{
    public class IndexModel : CERPPageModel
    {
        private IRepository<DictionaryValue, Guid> DictionaryValuesRepo;
        private IRepository<DictionaryValueType, Guid> DictionaryValueTypesRepo;
        public IndexModel(IdentityUserManager userManager, IRepository<DictionaryValue, Guid> dictionaryValuesRepo, IRepository<DictionaryValueType, Guid> dictionaryValueTypesRepo)
        {
            UserManager = userManager;
            DictionaryValuesRepo = dictionaryValuesRepo;
            DictionaryValueTypesRepo = dictionaryValueTypesRepo;
        }

        public IdentityUserManager UserManager { get; set; }
        private ITenantAppService TenantAppService { get; }

        public async void OnGet()
        {
            var dicValues = DictionaryValuesRepo.WithDetails().Where(x => x.TenantId == CurrentTenant.Id).ToList();
            for (int i = 0; i < dicValues.Count; i++)
            {
                var counts = DictionaryValuesRepo.WithDetails().Where(x => x.TenantId == CurrentTenant.Id && x.Value == dicValues[i].Value && (dicValues[i].ValueType == null || x.ValueType.ValueTypeFor == dicValues[i].ValueType.ValueTypeFor)).ToList();
                if (counts.Count > 1)
                {
                    for (int j = 0; j < counts.Count; j++)
                    {
                        await DictionaryValuesRepo.DeleteAsync(counts[j].Id);
                    }
                }
            }
            var dicValueTypes = DictionaryValueTypesRepo.WithDetails().Where(x => x.TenantId == CurrentTenant.Id).ToList();
            for (int i = 0; i < dicValueTypes.Count; i++)
            {
                var counts = DictionaryValueTypesRepo.WithDetails().Where(x => x.TenantId == CurrentTenant.Id && x.ValueTypeFor == dicValueTypes[i].ValueTypeFor).ToList();
                if (counts.Count > 1)
                {
                    //for (int j = 0; j < counts.Count; j++)
                    //{
                    //    await DictionaryValueTypesRepo.DeleteAsync(counts[j].Id);
                    //}
                }
            }
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