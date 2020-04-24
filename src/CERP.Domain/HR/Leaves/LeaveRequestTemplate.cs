using CERP.App;
using CERP.Base;
using CERP.Setup;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERP.HR.Leaves
{
    public class LeaveRequestTemplate : AuditedAggregateTenantRoot<int>
    {
        public LeaveRequestTemplate()
        {

        }
        public LeaveRequestTemplate(int id)
        {
            Id = id;
        }

        public string Title { get; set; }
        public string TitleLocalized { get; set; }
        public string Prefix { get; set; }
        public int StartingNo { get; set; }
        public int EntitlementDays { get; set; }

        public DictionaryValue LeaveType { get; set; }
        public Guid LeaveTypeId { get; set; }

        public virtual ICollection<LeaveRequestTemplateDepartment> Departments { get; set; }
        public virtual ICollection<LeaveRequestTemplatePosition> Positions { get; set; }
        public virtual ICollection<LeaveRequestTemplateEmploymentType> EmploymentTypes { get; set; }
        public virtual ICollection<LeaveRequestTemplateEmployeeStatus> EmployeeStatuses { get; set; }
        public virtual ICollection<LeaveRequestTemplateHoliday> Holidays { get; set; }
        
        public virtual ApprovalRouteTemplate ApprovalRouteTemplate { get; set; }
        public int ApprovalRouteTemplateId { get; set; }

        public bool HasAdvanceSalaryRequest { get; set; }
        public bool HasExitReentryRequest { get; set; }
        public bool HasAirTicketRequest { get; set; }

        public bool HasNotesRequirement { get; set; }
        public bool HasAttachmentRequirement { get; set; }
    }
    
}
