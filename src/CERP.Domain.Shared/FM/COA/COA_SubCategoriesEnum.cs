using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CERP.FM.COA
{
    public enum AccountCLI
    {
        [Description("Sub Header")]
        SubHeader = 2,
        [Description("Group")]
        Group = 3
    }
}
