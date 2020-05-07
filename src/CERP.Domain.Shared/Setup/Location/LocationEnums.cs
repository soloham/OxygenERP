using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CERP.Setup
{
    public enum LocationStatus
    {
        [Description("Active")]
        Active,
        [Description("Inactive")]
        Inactive,
        [Description("Closed")]
        Closed
    }
}
