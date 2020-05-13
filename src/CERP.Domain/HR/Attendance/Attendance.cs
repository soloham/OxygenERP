using CERP.Base;

namespace CERP.HR.Attendance
{
    public class Attendance : AuditedAggregateTenantRoot<int>
    {
        public bool UseAttendanceSystem { get; set; }

        public string EmployeeIDMap { get; set; }
        public string DateMap { get; set; }
        public string TimeInMap { get; set; }
        public string TimeOutMap { get; set; }
    }
}
