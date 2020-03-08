using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CERP
{
    public static class AppSettings
    {
        
    }
    public enum ValueTypeModules
    {
        [Description("Country")]
        Country,
        [Description("Gender")]
        Gender,
        [Description("Marital Status")]
        MaritalStatus,
        [Description("Blood Group")]
        BloodGroup,
        [Description("Religion")]
        Religion,
        [Description("ID Type")]
        IDType,
        [Description("Cashflow Statement Type")]
        CashflowStatementType,
        [Description("Contract Type")]
        ContractType,
        [Description("Contract Status")]
        ContractStatus,
        [Description("Employee Status")]
        EmployeeStatus,
        [Description("Bank")]
        Bank,
        [Description("Relationship")]
        Relationship,
        [Description("Degree / Certification")]
        Degree,
        [Description("Academic Institution")]
        AcademicInstitution,
        [Description("Allowance Type")]
        AllowanceType,
    }
}
