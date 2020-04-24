using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CERP.Setup.DTOs;
using CERP.Web.BusinessLogic.Core;

namespace CERP.Web.BusinessLogic.ViewModels.HR.Setup
{
    public class LeaveRequestTemplateViewModel : ApprovalRouteViewModelBase
    {
        public LeaveRequestTemplateViewModel()
        {
            IsEditing = false;
        }

        public int Id { get; set; }

        public bool IsEditing { get; set; }
        public string LRTitle { get; set; }
        public string LRTitleLocalized { get; set; }
        public string LRPrefix { get; set; }
        public int LRStartingNo { get; set; }
        public Guid LRLeaveTypeId { get; set; }
        public int LREntitlementDays { get; set; }
        public Guid[] LRDepartmentIds { get; set; }
        public Guid[] LRPositionsIds { get; set; }
        public Guid[] LREmploymentTypeIds { get; set; }
        public Guid[] LREmployeeStatusIds { get; set; }

        public int[] LRDeductionHolidaysIds { get; set; }

        public bool LRAdvanceSalaryAD { get; set; }
        public bool LRExitReentryAD { get; set; }
        public bool LRAirTicketAD { get; set; }

        public bool LRNotesAR { get; set; }
        public bool LRAttachmentAR { get; set; }
        public bool LRAirTicketAR { get; set; }
        public bool LRExitReentryAR { get; set; }
        public bool LRAdvanceSalaryAR { get; set; }

    }

}
