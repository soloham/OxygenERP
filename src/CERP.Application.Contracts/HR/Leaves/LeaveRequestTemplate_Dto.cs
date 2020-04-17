using CERP.App;
using CERP.Base;
using CERP.Setup.DTOs;
using System.Collections.Generic;

namespace CERP.HR.Leaves
{
    public class LeaveRequestTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public LeaveRequestTemplate_Dto()
        {

        }
        public LeaveRequestTemplate_Dto(int id)
        {
            Id = id;
        }

        public string Title { get; set; }
        public string TitleLocalized { get; set; }
        public string Prefix { get; set; }
        public int StartingNo { get; set; }
        public int EntitlementDays { get; set; }

        public List<Department_Dto> Departments { get; set; }
        public List<Position_Dto> Positions { get; set; }
        public List<DictionaryValue_Dto> EmploymentTypes { get; set; }
        public List<DictionaryValue_Dto> EmployeeStatuses { get; set; }

        public ApprovalRouteTemplate_Dto ApprovalRouteTemplate { get; set; }

        public bool HasAdvanceSalaryRequest { get; set; }
        public bool HasExitReentryRequest { get; set; }
        public bool HasAirTicketRequest { get; set; }

        public bool HasNotesRequirement { get; set; }
        public bool HasAttachmentRequirement { get; set; }
    }
    
}
