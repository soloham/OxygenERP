using CERP.App;
using CERP.Base;
using CERP.Setup;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERP.HR.Loans
{
    public class LoanRequestTemplate : AuditedAggregateTenantRoot<int>
    {
        public LoanRequestTemplate()
        {

        }
        public LoanRequestTemplate(int id)
        {
            Id = id;
        }

        public string Title { get; set; }
        public string TitleLocalized { get; set; }
        public string Prefix { get; set; }
        public int StartingNo { get; set; }

        public DictionaryValue LoanType { get; set; }
        public Guid LoanTypeId { get; set; }

        public virtual ICollection<LoanRequestTemplateDepartment> Departments { get; set; }
        public virtual ICollection<LoanRequestTemplatePosition> Positions { get; set; }
        public virtual ICollection<LoanRequestTemplateEmploymentType> EmploymentTypes { get; set; }
        public virtual ICollection<LoanRequestTemplateEmployeeStatus> EmployeeStatuses { get; set; }

        public int MinEmployeeDependants { get; set; }
        public double MaxIndemnityLimit { get; set; }

        public int MaxInstallmentsLimit { get; set; }
        public double MaxInstallmentAmount { get; set; }

        public virtual ApprovalRouteTemplate ApprovalRouteTemplate { get; set; }
        public int ApprovalRouteTemplateId { get; set; }

    }
    
}
