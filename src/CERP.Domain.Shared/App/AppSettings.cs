using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CERP
{
    public static class AppSettings
    {
        public static int PermanantEmployeeTypeKey { get; set; } = 25001;
        public static int ContractBasedEmployeeTypeKey { get; set; } = 25002;
        public static string TerminatedEmployeeStatusKey { get; set; }
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
        [Description("Owner Type")]
        OwnerType,
        [Description("Document Type")]
        DocumentType,
        [Description("Service Category")]
        ServiceCategory,
        [Description("Service Line Chargeables")]
        ServiceLineChargeables,
        [Description("Service Line Non Chargeables")]
        ServiceLineNonChargeables,
        [Description("Service Line Admins")]
        ServiceLineAdmins,
        [Description("Clients")]
        Clients,
        [Description("Employee Type")]
        EmployeeType,
        [Description("Indemnity Type")]
        IndemnityType,
        [Description("Social Insurance Type")]
        SocialInsuranceType
    }
}
