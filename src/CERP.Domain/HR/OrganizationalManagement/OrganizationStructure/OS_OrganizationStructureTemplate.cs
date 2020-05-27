using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using CERP.Setup;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CERP.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_OrganizationStructureTemplate : AuditedAggregateTenantRoot<int>
    {
        public OS_OrganizationStructureTemplate()
        {
        }

        [CustomAudited]
        public string Code { get; set; }

        [CustomAudited]
        public string Name { get; set; }
        [CustomAudited]
        public string NameLocalized { get; set; }

        [CustomAudited]
        public string Description { get; set; }

        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }

        [CustomAudited]
        public OS_StructureStatus StructureStatus { get; set; }

        [CustomAudited]
        public OS_ReviewPeriod ReviewPeriod { get; set; }
        [CustomAudited]
        public int? ReviewPeriodDays { get; set; }

        public Company LegalEntity { get; set; }
        [CustomAudited]
        public Guid LegalEntityId { get; set; }


        public virtual ICollection<OS_OrganizationStructureTemplateBusinessUnits> OrganizationStructureTemplateBusinessUnits { get; set; }
        public virtual ICollection<OS_OrganizationStructureTemplateDivisions> OrganizationStructureTemplateDivisions { get; set; }
        public virtual ICollection<OS_OrganizationStructureTemplateDepartments> OrganizationStructureTemplateDepartments { get; set; }
    }

    public class OS_OrganizationStructureTemplateBusinessUnits : AuditedAggregateTenantRoot<int>
    {
        public OS_BusinessUnitTemplate BusinessUnitTemplate { get; set; }
        public int BusinessUnitTemplateId { get; set; }

        public OS_OrganizationStructureTemplate OrganizationStructureTemplate { get; set; }
        public int OrganizationStructureTemplateId { get; set; }

        public LocationTemplate Location { get; set; }
        public int LocationId { get; set; }

        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }

        public virtual ICollection<OS_OrganizationStructureTemplateBusinessUnitPosition> OrganizationStructureTemplateBusinessUnitPositions { get; set; }
    }
    public class OS_OrganizationStructureTemplateBusinessUnitPosition : AuditedAggregateTenantRoot<int>
    {
        public OS_PositionTemplate PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }

        public OS_OrganizationStructureTemplateBusinessUnits OrganizationStructureTemplateBusinessUnit { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }

        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }
    }


    public class OS_OrganizationStructureTemplateDivisions : AuditedAggregateTenantRoot<int>
    {
        public OS_DivisionTemplate DivisionTemplate { get; set; }
        public int DivisionTemplateId { get; set; }

        public OS_OrganizationStructureTemplate OrganizationStructureTemplate { get; set; }
        public int OrganizationStructureTemplateId { get; set; }

        public LocationTemplate Location { get; set; }
        public int LocationId { get; set; }

        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }

        public virtual ICollection<OS_OrganizationStructureTemplateDivisionPosition> OrganizationStructureTemplateDivisionPositions { get; set; }
    }
    public class OS_OrganizationStructureTemplateDivisionPosition : AuditedAggregateTenantRoot<int>
    {
        public OS_PositionTemplate PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }

        public OS_OrganizationStructureTemplateDivisions OrganizationStructureTemplateDivision { get; set; }
        public int OrganizationStructureTemplateDivisionId { get; set; }

        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }
    }


    public class OS_OrganizationStructureTemplateDepartments : AuditedAggregateTenantRoot<int>
    {
        public OS_DepartmentTemplate DepartmentTemplate { get; set; }
        public int DepartmentTemplateId { get; set; }

        public OS_OrganizationStructureTemplate OrganizationStructureTemplate { get; set; }
        public int OrganizationStructureTemplateId { get; set; }

        public LocationTemplate Location { get; set; }
        public int LocationId { get; set; }

        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }

        public virtual ICollection<OS_OrganizationStructureTemplateDepartmentPosition> OrganizationStructureTemplateDepartmentPositions { get; set; }
    }
    public class OS_OrganizationStructureTemplateDepartmentPosition : AuditedAggregateTenantRoot<int>
    {
        public OS_PositionTemplate PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }

        public OS_OrganizationStructureTemplateDepartments OrganizationStructureTemplateDepartment { get; set; }
        public int OrganizationStructureTemplateDepartmentId { get; set; }

        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }
    }
}
