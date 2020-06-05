using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CERP.HR.Setup.OrganizationalManagement.OrganizationStructure
{
    public enum OS_StructureStatus
    {
        [Description("Active")]
        Active,
        [Description("Inactive")]
        Inactive
    }

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
    public enum OS_PositionHiringType
    {
        [Description("Immediate")]
        Immediate,
        [Description("Post Approval")]
        PostApproval
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
        [Description("Internal")]
        Internal,
        [Description("External")]
        External
    }
    public enum OS_SkillType
    {
        [Description("Type I")]
        TypeI,
        [Description("Type II")]
        TypeII
    }
    public enum OS_SkillUpdatePeriod
    {
        [Description("Quaterly")]
        Quaterly,
        [Description("Half Yearly")]
        HalfYearly,
        [Description("Yearly")]
        Yearly
    }

    public enum OS_ReviewPeriod
    {
        [Description("Quaterly")]
        Quaterly,
        [Description("Half Yearly")]
        HalfYearly,
        [Description("Yearly")]
        Yearly,
        [Description("Days")]
        Days
    }

    public enum OS_AcademicType
    {
        [Description("Internal")]
        Internal,
        [Description("External")]
        External
    }
    public enum OS_AcademiaCertificateType
    {
        [Description("Training")]
        Training,
        [Description("Education")]
        Education
    }
}
