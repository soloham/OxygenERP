using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CERP.App
{
    public enum HolidayType
    {
        [Description("Public Holiday")]
        Public,
        [Description("Annual")]
        Annual
    }
}
