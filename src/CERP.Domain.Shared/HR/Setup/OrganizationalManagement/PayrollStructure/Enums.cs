using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CERP.HR.Setup.OrganizationalManagement.PayrollStructure
{
    public enum PS_ActiveStatus
    {
        [Description("Active")]
        Active,
        [Description("Inactive")]
        Inactive
    }
    public enum PS_PayGradeStatus
    {
        [Description("Active")]
        Active,
        [Description("Inactive")]
        Inactive
    }
    public enum PS_PayComponentStatus
    {
        [Description("Active")]
        Active,
        [Description("Inactive")]
        Inactive
    }
    public enum PS_PayGradeLevel
    {
        [Description("1")]
        One,
        [Description("2")]
        Two,
        [Description("3")]
        Three,
        [Description("4")]
        Four,
        [Description("5")]
        Five,
        [Description("6")]
        Six,
        [Description("7")]
        Seven,
        [Description("8")]
        Eight,
        [Description("9")]
        Nine,
        [Description("10")]
        Ten,
        [Description("11")]
        Eleven,
        [Description("12")]
        Twelve
    }
    public enum PS_PayComponentTypeValueType
    {
        [Description("Amount")]
        Amount,
        [Description("Percentage")]
        Percentage
    }
    public enum PS_PayGradeComponentAmountValueType
    {
        [Description("Amount")]
        Amount,
        [Description("Percentage")]
        Percentage
    }
    public enum PS_PayFrequencyAnnualizationFactor
    {
        [Description("Weekly")]
        WEEKLY,
        [Description("Bi-Weekly")]
        BI_WEEKLY,
        [Description("Monthly")]
        MONTHLY,
        [Description("Quaterly")]
        QUATERLY,
        [Description("Half Yearly")]
        HALF_YEARLY,
        [Description("Yearly")]
        YEARLY
    }

    public enum PS_PaymentFileEmployeeColumn
    {
        [Description("Weekly")]
        WEEKLY,
    }
    public enum PS_PaymentFilePayrollColumn
    {
        [Description("Weekly")]
        WEEKLY,
    }
    public enum PS_PaymentFileBankColumn
    {
        [Description("Weekly")]
        WEEKLY,
    }
}
