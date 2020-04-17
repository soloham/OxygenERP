using CERP.Base;
using CERP.Setup;
using System;

namespace CERP.HR.Leaves
{
    public class LeaveRequestTemplatePosition : AuditedAggregateTenantRoot<int>
    {
        public LeaveRequestTemplatePosition()
        {

        }

        public virtual LeaveRequestTemplate LeaveRequestTemplate { get; set; }
        public int LeaveRequestTemplateId;

        public virtual Position Position { get; set; }
        public Guid PositionId;
    }
}
