using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CERP.App
{
    public enum TaskModule
    {
        [Description("Leave Request")]
        LeaveRequest
    }
    public enum TaskStatus
    {
        [Description("Completed")]
        Completed,
        [Description("In Progress")]
        InProgress,
        [Description("Cancelled")]
        Cancelled,
    }
}
