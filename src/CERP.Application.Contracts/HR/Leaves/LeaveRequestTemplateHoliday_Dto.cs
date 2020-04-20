using CERP.Base;
using CERP.HR.Holidays;
using CERP.Setup;
using CERP.Setup.DTOs;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CERP.HR.Leaves
{
    public class LeaveRequestTemplateHoliday_Dto : AuditedEntityTenantDto<int>
    {
        public LeaveRequestTemplateHoliday_Dto()
        {

        }

        public virtual LeaveRequestTemplate_Dto LeaveRequestTemplate { get; set; }
        public int LeaveRequestTemplateId;

        public virtual Holiday_Dto Holiday { get; set; }
        public int HolidayId;
    }
}
