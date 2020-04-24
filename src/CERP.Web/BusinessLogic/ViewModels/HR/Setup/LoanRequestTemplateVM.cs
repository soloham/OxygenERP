using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CERP.Setup.DTOs;
using CERP.Web.BusinessLogic.Core;

namespace CERP.Web.BusinessLogic.ViewModels.HR.Setup
{
    public class LoanRequestTemplateViewModel : ApprovalRouteViewModelBase
    {
        public LoanRequestTemplateViewModel()
        {
            IsEditing = false;
        }

        public int Id { get; set; }

        public bool IsEditing { get; set; }
        public string LRTitle { get; set; }
        public string LRTitleLocalized { get; set; }
        public string LRPrefix { get; set; }
        public int LRStartingNo { get; set; }

        public Guid LRLoanTypeId { get; set; }
        
        public Guid[] LRDepartmentIds { get; set; }
        public Guid[] LRPositionsIds { get; set; }
        public Guid[] LREmploymentTypeIds { get; set; }
        public Guid[] LREmployeeStatusIds { get; set; }

        public int LRMinEmployeeDependants { get; set; }
        public double LRMaxIndemnityLimit { get; set; }

        public int LRMaxInstallmentsLimit { get; set; }
        public double LRMaxInstallmentAmount { get; set; }
    }

}
