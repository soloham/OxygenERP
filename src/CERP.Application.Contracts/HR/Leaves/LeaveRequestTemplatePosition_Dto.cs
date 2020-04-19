using CERP.Base;
using CERP.Setup;
using CERP.Setup.DTOs;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CERP.HR.Leaves
{
    public class LeaveRequestTemplatePosition_Dto : AuditedEntityTenantDto<int>
    {
        public LeaveRequestTemplatePosition_Dto()
        {

        }

        public virtual LeaveRequestTemplate_Dto LeaveRequestTemplate { get; set; }
        public int LeaveRequestTemplateId;

        public virtual Position_Dto Position { get; set; }
        public Guid PositionId;
    }
}
