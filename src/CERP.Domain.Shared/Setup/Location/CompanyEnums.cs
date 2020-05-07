using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CERP.Setup
{
    public enum CompanyStatus
    {
        [Description("Active")]
        Active,
        [Description("Inactive")]
        Inactive,
        [Description("Closed")]
        Closed
    }
    public enum CurrencyType
    {
        [Description("Base Currency")]
        Base,
        [Description("Exchange Currency")]
        Exchange,
    }
}
