using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CERP.HR.Setup.OrganizationalManagement.OrganizationStructure
{
    public enum OS_DepartmentStatus
    {
        [Description("Active")]
        Active,
        [Description("Inactive")]
        Inactive,
        [Description("Closed")]
        Closed
    }
    public enum OS_PositionStatus
    {
        [Description("Active")]
        Active,
        [Description("Inactive")]
        Inactive
    }
    public enum OS_PositionLevel
    {
        [Description("1")]
        One,
        [Description("2")]
        Two,
        [Description("3")]
        Three,
        [Description("4")]
        Four
    }
    public enum OS_SubDepartmentRelationshipType
    {
        [Description("Reporting To")]
        ReportingTo,
        [Description("Isolated")]
        Isolated,
        [Description("Assistant")]
        Assistant
    }

    public enum OS_SkillAquisitionType
    {
        [Description("Reporting To")]
        ReportingTo,
        [Description("Isolated")]
        Isolated,
        [Description("Assistant")]
        Assistant
    }
    public enum OS_SkillType
    {
        [Description("Reporting To")]
        ReportingTo,
        [Description("Isolated")]
        Isolated,
        [Description("Assistant")]
        Assistant
    }
    public enum OS_SkillUpdatePeriod
    {
        [Description("Reporting To")]
        ReportingTo,
        [Description("Isolated")]
        Isolated,
        [Description("Assistant")]
        Assistant
    }

    public enum OS_AcademicType
    {
        [Description("Reporting To")]
        ReportingTo,
        [Description("Isolated")]
        Isolated,
        [Description("Assistant")]
        Assistant
    }
    public enum OS_AcademiaCertificateType
    {
        [Description("Reporting To")]
        ReportingTo,
        [Description("Isolated")]
        Isolated,
        [Description("Assistant")]
        Assistant
    }
}
