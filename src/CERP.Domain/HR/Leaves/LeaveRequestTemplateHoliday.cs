using CERP.Base;
using CERP.HR.Holidays;
using CERP.Setup;
using CERP.Setup.DTOs;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CERP.HR.Leaves
{
    public class LeaveRequestTemplateHoliday : AuditedAggregateTenantRoot<int>
    {
        public LeaveRequestTemplateHoliday()
        {

        }

        public virtual LeaveRequestTemplate LeaveRequestTemplate { get; set; }
        public int LeaveRequestTemplateId;

        public virtual Holiday Holiday { get; set; }
        public int HolidayId;
    }
}
