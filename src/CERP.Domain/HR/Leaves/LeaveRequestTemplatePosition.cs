using CERP.Base;
using CERP.Setup;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CERP.HR.Leaves
{
    public class LeaveRequestTemplatePosition : AuditedAggregateTenantRoot<int>
    {
        public LeaveRequestTemplatePosition()
        {

        }

        [ForeignKey("LeaveRequestTemplateId")]
        public virtual LeaveRequestTemplate LeaveRequestTemplate { get; set; }
        public int LeaveRequestTemplateId;

        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }
        public Guid PositionId;
    }
}
