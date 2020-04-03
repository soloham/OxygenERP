using CERP.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CERP.Permissions
{
    public class CERPPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CERPPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(CERPPermissions.MyPermission1, L("Permission:MyPermission1"));
            myGroup.AddPermission(CERPPermissions.ESS_Timesheet, L("Permission:ESS_Timesheet"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CERPResource>(name);
        }
    }
}
