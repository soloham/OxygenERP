using CERP.Identity;
using CERP.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Account.Settings;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Settings;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace CERP.AppServices.Identity
{
    public class AccountAppService : ApplicationService
    {
        public IRepository<AppUser> AppUserRepo { get; set; }
        protected IIdentityRoleRepository RoleRepository { get; }
        protected IdentityUserManager UserManager { get; }

        public AccountAppService(
            IdentityUserManager userManager,
            IIdentityRoleRepository roleRepository, IRepository<AppUser> appUser)
        {
            RoleRepository = roleRepository;
            UserManager = userManager;
            AppUserRepo = appUser;
        }

        public virtual async Task<AppUser_Dto> RegisterAsync(RegisterDto input)
        {
            await CheckSelfRegistrationAsync();

            var user = new IdentityUser(GuidGenerator.Create(), input.UserName, input.EmailAddress, CurrentTenant.Id);
            
            (await UserManager.CreateAsync(user, input.Password)).CheckErrors();

            await UserManager.SetEmailAsync(user, input.EmailAddress);
            await UserManager.AddDefaultRolesAsync(user);

            var appUser = await AppUserRepo.GetAsync(x => x.Id == user.Id);
            appUser.EmployeeId = input.EmployeeId;

            var result = await AppUserRepo.UpdateAsync(appUser);

            return ObjectMapper.Map<AppUser, AppUser_Dto>(result);
        }

        protected virtual async Task CheckSelfRegistrationAsync()
        {
            if (!await SettingProvider.IsTrueAsync(AccountSettingNames.IsSelfRegistrationEnabled))
            {
                throw new UserFriendlyException(L["SelfRegistrationDisabledMessage"]);
            }
        }
    }
}
