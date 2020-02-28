using Volo.Abp.Settings;

namespace CERP.Settings
{
    public class CERPSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(CERPSettings.MySetting1));
        }
    }
}
