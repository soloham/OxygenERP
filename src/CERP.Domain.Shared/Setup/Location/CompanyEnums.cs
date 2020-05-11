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
    public enum CurrencyStatus
    {
        [Description("Active")]
        Active,
        [Description("Inactive")]
        Inactive
    }
    public enum CurrencyType
    {
        [Description("Base Currency")]
        Base,
        [Description("Exchange Currency")]
        Exchange,
    }
    public enum LocationType
    {
        [Description("Head Office")]
        HeadOffice,
        [Description("Branch")]
        Branch,
    }
    public enum Language
    {
        [Description("Arabic")]
        Arabic,
        [Description("English")]
        English,
    }
    public enum PrintSize
    {
        [Description("A4")]
        A4,
        [Description("A5")]
        A5,
        [Description("B5")]
        B4,
    }
    public enum PrintSizeStatus
    {
        [Description("Active")]
        Active,
        [Description("Inactive")]
        Inactive
    }
}
