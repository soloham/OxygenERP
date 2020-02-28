using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CERP.FM.COA
{
    public enum HeadAccountType
    {
        Asset = 1,
        Liability = 2,
        Capital = 3,
        Equity = 4,
        Revenue = 5,
        [Description("Direct Cost")]
        DirectCost = 6,
        Expenses = 7,
        [Description("Other Income")]
        OtherIncome = 8,
    }
}
