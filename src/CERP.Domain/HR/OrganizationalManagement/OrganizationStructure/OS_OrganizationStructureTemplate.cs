using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.HR.OrganizationalManagement.PayrollStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using CERP.Setup;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        public virtual ICollection<OS_OrganizationStructureTemplateBusinessUnit> OrganizationStructureTemplateBusinessUnits { get; set; }
        public virtual ICollection<OS_OrganizationStructureTemplateDivision> OrganizationStructureTemplateDivisions { get; set; }
        public virtual ICollection<OS_OrganizationStructureTemplateDepartment> OrganizationStructureTemplateDepartments { get; set; }
        public virtual ICollection<OS_OrganizationStructureTemplatePosition> OrganizationStructureTemplatePositions { get; set; }
    }

    public class OS_OrganizationStructureTemplateBusinessUnit : AuditedAggregateTenantRoot<int>
    {
        public OS_BusinessUnitTemplate BusinessUnitTemplate { get; set; }
        public int BusinessUnitTemplateId { get; set; }

        public OS_OrganizationStructureTemplate OrganizationStructureTemplate { get; set; }
        public int OrganizationStructureTemplateId { get; set; }

        public LocationTemplate Location { get; set; }
        public Guid LocationId { get; set; }

        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }

        public virtual ICollection<OS_OrganizationStructureTemplateDivision> OrganizationStructureTemplateDivisions { get; set; }
        public virtual ICollection<OS_OrganizationStructureTemplateDepartment> OrganizationStructureTemplateDepartments { get; set; }
        //public virtual ICollection<OS_OrganizationStructureTemplatePosition> OrganizationStructureTemplatePositions { get; set; }

        public virtual ICollection<OS_OrganizationStructureTemplateBusinessUnitPosition> OrganizationStructureTemplateBusinessUnitAssociatedPositions { get; set; }
        public virtual ICollection<OS_OrganizationStructureTemplatePosition> OrganizationStructureTemplateBusinessUnitPositions { get; set; }
        public virtual ICollection<OS_OrganizationStructureTemplateBusinessUnitCostCenter> OrganizationStructureTemplateBusinessUnitCostCenters { get; set; }

        public PS_PayGroup PayGroup { get; set; }
        public int PayGroupId { get; set; }
    }
    public class OS_OrganizationStructureTemplateBusinessUnitPosition : AuditedAggregateTenantRoot<int>
    {
        public OS_PositionTemplate PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }

        [ForeignKey("OrganizationStructureTemplateId, OrganizationStructureTemplateBusinessUnitId")]
        public OS_OrganizationStructureTemplateBusinessUnit OrganizationStructureTemplateBusinessUnit { get; set; }
        public int OrganizationStructureTemplateId { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }

        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }

        [CustomAudited]
        public bool IsHead { get; set; }
    }
    public class OS_OrganizationStructureTemplateBusinessUnitCostCenter : AuditedAggregateTenantRoot<int>
    {
        public DictionaryValue CostCenter { get; set; }
        public Guid CostCenterId { get; set; }

        [ForeignKey("OrganizationStructureTemplateId, OrganizationStructureTemplateBusinessUnitId")]
        public OS_OrganizationStructureTemplateBusinessUnit OrganizationStructureTemplateBusinessUnit { get; set; }
        public int OrganizationStructureTemplateId { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }

        [CustomAudited]
        public int Percentage { get; set; }
    }

    public class OS_OrganizationStructureTemplateDivision : AuditedAggregateTenantRoot<int>
    {
        public OS_DivisionTemplate DivisionTemplate { get; set; }
        public int DivisionTemplateId { get; set; }

        [ForeignKey("OrganizationStructureTemplateId, OrganizationStructureTemplateBusinessUnitId")]
        public OS_OrganizationStructureTemplateBusinessUnit OrganizationStructureTemplateBusinessUnit { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }
        public int OrganizationStructureTemplateId { get; set; }

        //public LocationTemplate Location { get; set; }
        //public int LocationId { get; set; }

        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }

        public virtual ICollection<OS_OrganizationStructureTemplateDepartment> OrganizationStructureTemplateDepartments { get; set; }

        public virtual ICollection<OS_OrganizationStructureTemplateDivisionPosition> OrganizationStructureTemplateDivisionAssociatedPositions { get; set; }
        public virtual ICollection<OS_OrganizationStructureTemplatePosition> OrganizationStructureTemplateDivisionPositions { get; set; }
        public virtual ICollection<OS_OrganizationStructureTemplateDivisionCostCenter> OrganizationStructureTemplateDivisionCostCenters { get; set; }

        //public OS_OrganizationStructureTemplateBusinessUnit Parent { get; set; }
        //public int ParentId { get; set; }
    }
    public class OS_OrganizationStructureTemplateDivisionPosition : AuditedAggregateTenantRoot<int>
    {
        public OS_PositionTemplate PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }

        [ForeignKey("OrganizationStructureTemplateId, OrganizationStructureTemplateBusinessUnitId, OrganizationStructureTemplateDivisionId")]
        public OS_OrganizationStructureTemplateDivision OrganizationStructureTemplateDivision { get; set; }
        public int OrganizationStructureTemplateId { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }
        public int OrganizationStructureTemplateDivisionId { get; set; }


        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }

        [CustomAudited]
        public bool IsHead { get; set; }
    }
    public class OS_OrganizationStructureTemplateDivisionCostCenter : AuditedAggregateTenantRoot<int>
    {
        public DictionaryValue CostCenter { get; set; }
        public Guid CostCenterId { get; set; }


        [ForeignKey("OrganizationStructureTemplateId, OrganizationStructureTemplateBusinessUnitId, OrganizationStructureTemplateDivisionId")]
        public OS_OrganizationStructureTemplateDivision OrganizationStructureTemplateDivision { get; set; }
        public int OrganizationStructureTemplateId { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }
        public int OrganizationStructureTemplateDivisionId { get; set; }


        [CustomAudited]
        public int Percentage { get; set; }
    }

    public class OS_OrganizationStructureTemplateDepartment : AuditedAggregateTenantRoot<int>
    {
        public OS_DepartmentTemplate DepartmentTemplate { get; set; }
        public int DepartmentTemplateId { get; set; }


        [ForeignKey("OrganizationStructureTemplateId, OrganizationStructureTemplateBusinessUnitId")]
        public OS_OrganizationStructureTemplateBusinessUnit OrganizationStructureTemplateBusinessUnit { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }
        public int OrganizationStructureTemplateId { get; set; }

        [ForeignKey("OrganizationStructureTemplateId, OrganizationStructureTemplateBusinessUnitId, OrganizationStructureTemplateDivisionId")]
        public OS_OrganizationStructureTemplateDivision? OrganizationStructureTemplateDivision { get; set; }
        public int OrganizationStructureTemplateDivisionId { get; set; }

        //[ForeignKey("OrganizationStructureTemplateId, BusinessUnitTemplateId, DivisionTemplateId, DepartmentTemplateId, HeadDepartmentTemplateId")]
        //public OS_OrganizationStructureTemplateDepartment? OrganizationStructureTemplateHeadDepartment { get; set; }
        //public int HeadDepartmentTemplateId { get; set; }

        //public LocationTemplate Location { get; set; }
        //public int LocationId { get; set; }

        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }

        public virtual ICollection<OS_OrganizationStructureTemplateDepartment> OrganizationStructureTemplateDepartments { get; set; }

        public virtual ICollection<OS_OrganizationStructureTemplateDepartmentPosition> OrganizationStructureTemplateDepartmentAssociatedPositions { get; set; }
        public virtual ICollection<OS_OrganizationStructureTemplatePosition> OrganizationStructureTemplateDepartmentPositions { get; set; }
        public virtual ICollection<OS_OrganizationStructureTemplateDepartmentCostCenter> OrganizationStructureTemplateDepartmentCostCenters { get; set; }
    }
    public class OS_OrganizationStructureTemplateDepartmentPosition : AuditedAggregateTenantRoot<int>
    {
        public OS_PositionTemplate PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }

        [ForeignKey("OrganizationStructureTemplateId, OrganizationStructureTemplateBusinessUnitId, OrganizationStructureTemplateDivisionId, OrganizationStructureTemplateDepartmentId")]
        public OS_OrganizationStructureTemplateDepartment OrganizationStructureTemplateDepartment { get; set; }
        public int OrganizationStructureTemplateDepartmentId { get; set; }
        public int HeadDepartmentTemplateId { get; set; }
        public int OrganizationStructureTemplateDivisionId { get; set; }
        public int OrganizationStructureTemplateId { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }



        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }

        [CustomAudited]
        public bool IsHead { get; set; }
    }
    public class OS_OrganizationStructureTemplateDepartmentCostCenter : AuditedAggregateTenantRoot<int>
    {
        public DictionaryValue CostCenter { get; set; }
        public Guid CostCenterId { get; set; }


        [ForeignKey("OrganizationStructureTemplateId, OrganizationStructureTemplateBusinessUnitId, OrganizationStructureTemplateDivisionId, OrganizationStructureTemplateDepartmentId")]
        public OS_OrganizationStructureTemplateDepartment OrganizationStructureTemplateDepartment { get; set; }
        public int OrganizationStructureTemplateDepartmentId { get; set; }
        public int HeadDepartmentTemplateId { get; set; }
        public int OrganizationStructureTemplateDivisionId { get; set; }
        public int OrganizationStructureTemplateId { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }


        [CustomAudited]
        public int Percentage { get; set; }
    }

    public class OS_OrganizationStructureTemplatePosition : AuditedAggregateTenantRoot<int>
    {
        public OS_PositionTemplate PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }

        [ForeignKey("OrganizationStructureTemplateId, OrganizationStructureTemplateBusinessUnitId")]
        public OS_OrganizationStructureTemplateBusinessUnit OrganizationStructureTemplateBusinessUnit { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }
        public int OrganizationStructureTemplateId { get; set; }

        [ForeignKey("OrganizationStructureTemplateId, OrganizationStructureTemplateBusinessUnitId, OrganizationStructureTemplateDivisionId")]
        public OS_OrganizationStructureTemplateDivision? OrganizationStructureTemplateDivision { get; set; }
        public int OrganizationStructureTemplateDivisionId { get; set; }

        [ForeignKey("OrganizationStructureTemplateId, OrganizationStructureTemplateBusinessUnitId, OrganizationStructureTemplateDivisionId,  OrganizationStructureTemplateDepartmentId")]
        public OS_OrganizationStructureTemplateDepartment? OrganizationStructureTemplateDepartment { get; set; }
        public int HeadDepartmentTemplateId { get; set; }
        public int OrganizationStructureTemplateDepartmentId { get; set; }

        //[ForeignKey("OrganizationStructureTemplateId, OrganizationStructureTemplateBusinessUnitId, OrganizationStructureTemplateDivisionId,  OrganizationStructureTemplateDepartmentId, PositionTemplateId, HeadPositionTemplateId")]
        //public OS_OrganizationStructureTemplatePosition? OrganizationStructureTemplateHeadPosition { get; set; }
        //public int HeadPositionTemplateId { get; set; }


        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }

        public virtual ICollection<OS_OrganizationStructureTemplatePosition> OrganizationStructureTemplatePositions { get; set; }

        public virtual ICollection<OS_OrganizationStructureTemplatePositionJob> OrganizationStructureTemplatePositionJobs { get; set; }
    }
    public class OS_OrganizationStructureTemplatePositionJob : AuditedAggregateTenantRoot<int>
    {
        public OS_JobTemplate JobTemplate { get; set; }
        public int JobTemplateId { get; set; }


        [ForeignKey("OrganizationStructureTemplateId, OrganizationStructureTemplateBusinessUnitId, OrganizationStructureTemplateDivisionId,  OrganizationStructureTemplateDepartmentId, OrganizationStructureTemplatePositionId")]
        public OS_OrganizationStructureTemplatePosition OrganizationStructureTemplatePosition { get; set; }
        public int OrganizationStructureTemplatePositionId { get; set; }
        public int HeadPositionTemplateId { get; set; }
        public int OrganizationStructureTemplateDepartmentId { get; set; }
        public int HeadDepartmentTemplateId { get; set; }
        public int OrganizationStructureTemplateDivisionId { get; set; }
        public int OrganizationStructureTemplateId { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }

        public DictionaryValue Level { get; set; }
        [CustomAudited]
        public Guid LevelId { get; set; }

        public DictionaryValue EmployeeClass { get; set; }
        [CustomAudited]
        public Guid EmployeeClassId { get; set; }

        public DictionaryValue ContractType { get; set; }
        [CustomAudited]
        public Guid ContractTypeId { get; set; }

        [CustomAudited]
        public DateTime ValidityFromDate { get; set; }
        [CustomAudited]
        public DateTime ValidityToDate { get; set; }
    }
}
 