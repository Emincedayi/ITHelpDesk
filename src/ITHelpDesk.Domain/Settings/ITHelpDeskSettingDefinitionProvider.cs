﻿using Volo.Abp.Settings;

namespace ITHelpDesk.Settings;

public class ITHelpDeskSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ITHelpDeskSettings.MySetting1));
    }
}
