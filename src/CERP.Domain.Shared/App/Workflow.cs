using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CERP.App
{
    public enum WorkflowModule
    {
        [Description("Leave Request")]
        LeaveRequest,
        [Description("Loans Request")]
        LoansRequest
    }
    public enum WorkflowNode
    {
        [Description("Approval")]
        Approval,
        [Description("Task")]
        Task,
        [Description("Delay")]
        Delay,
        [Description("Conditional")]
        Conditional
    }
    public enum ApprovalActions
    {
        [Description("Approved")]
        Approved,
        [Description("Rejected")]
        Rejected,
        [Description("Deligated")]
        Deligated
    }
    public enum TaskActions
    {
        [Description("Completed")]
        Completed,
        [Description("Failed")]
        Failed,
        [Description("Deligated")]
        Deligated
    }
}
