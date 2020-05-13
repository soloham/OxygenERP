using CERP.Base;
using CERP.HR.Holidays;

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
