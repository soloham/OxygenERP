using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CERP.HR.EmployeeCentral.Employee
{
    public enum EC_LoanStatus
    {
        [Description("Active")]
        Active,
        [Description("Inactive")]
        Inactive
    }
    public enum EC_IqamaSponsorType
    {
        [Description("Group Legal Entity")]
        GroupLegalEntity,
        [Description("Other")]
        Other
    }
}
