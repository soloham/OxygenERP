using CERP.App;
using CERP.App.Helpers;
using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure;
using CERP.Attributes;
using CERP.Base;
using CERP.FM.DTOs;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using CERP.Setup.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_OrganizationStructureTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_OrganizationStructureTemplate_Dto()
        {
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string NameLocalized { get; set; }
        public string Description { get; set; }
        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }
        public string StructureStatusDescription { get => EnumExtensions.GetDescription(StructureStatus); set => StructureStatus = EnumExtensions.GetValueFromDescription<OS_StructureStatus>(value); }
        public OS_StructureStatus StructureStatus { get; set; }
        public string ReviewPeriodDescription { get => EnumExtensions.GetDescription(ReviewPeriod); set => ReviewPeriod = EnumExtensions.GetValueFromDescription<OS_ReviewPeriod>(value); }
        public OS_ReviewPeriod ReviewPeriod { get; set; }
        public int? ReviewPeriodDays { get; set; }

        public Company_Dto LegalEntity { get; set; }
        public Guid LegalEntityId { get; set; }


        public List<OS_OrganizationStructureTemplateBusinessUnit_Dto> OrganizationStructureTemplateBusinessUnits { get; set; }
        public List<OS_OrganizationStructureTemplateDivision_Dto> OrganizationStructureTemplateDivisions { get; set; }
        public List<OS_OrganizationStructureTemplateDepartment_Dto> OrganizationStructureTemplateDepartments { get; set; }
        public List<OS_OrganizationStructureTemplatePosition_Dto> OrganizationStructureTemplatePositions { get; set; }
    }

    public class OS_OrganizationStructureTemplateBusinessUnit_Dto : AuditedEntityTenantDto<int>
    {
        public OS_BusinessUnitTemplate_Dto BusinessUnitTemplate { get; set; }
        public int BusinessUnitTemplateId { get; set; }

        public OS_OrganizationStructureTemplate_Dto OrganizationStructureTemplate { get; set; }
        public int OrganizationStructureTemplateId { get; set; }

        public LocationTemplate_Dto Location { get; set; }
        public Guid LocationId { get; set; }

        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }

        public List<OS_OrganizationStructureTemplateDivision_Dto> OrganizationStructureTemplateDivisions { get; set; }
        public List<OS_OrganizationStructureTemplateDepartment_Dto> OrganizationStructureTemplateDepartments { get; set; }
        //public List<OS_OrganizationStructureTemplatePosition_Dto> OrganizationStructureTemplatePositions { get; set; }

        public List<OS_OrganizationStructureTemplateBusinessUnitPosition_Dto> OrganizationStructureTemplateBusinessUnitAssociatedPositions { get; set; }
        public List<OS_OrganizationStructureTemplatePosition_Dto> OrganizationStructureTemplateBusinessUnitPositions { get; set; }
        public List<OS_OrganizationStructureTemplateBusinessUnitCostCenter_Dto> OrganizationStructureTemplateBusinessUnitCostCenters { get; set; }

        public OS_OrganizationStructureTemplateBusinessUnitPosition_Dto Head { get => OrganizationStructureTemplateBusinessUnitAssociatedPositions.FirstOrDefault(x => x.IsHead); }

        public PS_PayGroup_Dto PayGroup { get; set; }
        public int PayGroupId { get; set; }
    }
    public class OS_OrganizationStructureTemplateBusinessUnitPosition_Dto : AuditedEntityTenantDto<int>
    {
        public OS_PositionTemplate_Dto PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }

        public OS_OrganizationStructureTemplateBusinessUnit_Dto OrganizationStructureTemplateBusinessUnit { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }
        public int OrganizationStructureTemplateId { get; set; }

        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }
        public bool IsHead { get; set; }
    }
    public class OS_OrganizationStructureTemplateBusinessUnitCostCenter_Dto : AuditedEntityTenantDto<int>
    {
        public DictionaryValue_Dto CostCenter { get; set; }
        public Guid CostCenterId { get; set; }

        public OS_OrganizationStructureTemplateBusinessUnit_Dto OrganizationStructureTemplateBusinessUnit { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }
        public int OrganizationStructureTemplateId { get; set; }

        public int Percentage { get; set; }
    }


    public class OS_OrganizationStructureTemplateDivision_Dto : AuditedEntityTenantDto<int>
    {
        public OS_DivisionTemplate_Dto DivisionTemplate { get; set; }
        public int DivisionTemplateId { get; set; }

        public OS_OrganizationStructureTemplateBusinessUnit_Dto OrganizationStructureTemplateBusinessUnit { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }
        public int OrganizationStructureTemplateId { get; set; } 

        public LocationTemplate_Dto Location { get; set; }
        public int LocationId { get; set; }

        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }

        public List<OS_OrganizationStructureTemplateDepartment_Dto> OrganizationStructureTemplateDepartments { get; set; }
        //public List<OS_OrganizationStructureTemplatePosition_Dto> OrganizationStructureTemplatePositions { get; set; }

        public List<OS_OrganizationStructureTemplateDivisionPosition_Dto> OrganizationStructureTemplateDivisionAssociatedPositions { get; set; }
        public List<OS_OrganizationStructureTemplatePosition_Dto> OrganizationStructureTemplateDivisionPositions { get; set; }
        public List<OS_OrganizationStructureTemplateDivisionCostCenter_Dto> OrganizationStructureTemplateDivisionCostCenters { get; set; }

        public OS_OrganizationStructureTemplateDivisionPosition_Dto Head { get => OrganizationStructureTemplateDivisionAssociatedPositions.FirstOrDefault(x => x.IsHead); }

        //public OS_OrganizationStructureTemplateBusinessUnit_Dto Parent { get; set; }
        //public int ParentId { get; set; }
    }
    public class OS_OrganizationStructureTemplateDivisionPosition_Dto : AuditedEntityTenantDto<int>
    {
        public OS_PositionTemplate_Dto PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }

        public OS_OrganizationStructureTemplateDivision_Dto OrganizationStructureTemplateDivision { get; set; }
        public int OrganizationStructureTemplateId { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }
        public int OrganizationStructureTemplateDivisionId { get; set; }

        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }
        public bool IsHead { get; set; }
    }
    public class OS_OrganizationStructureTemplateDivisionCostCenter_Dto : AuditedEntityTenantDto<int>
    {
        public DictionaryValue_Dto CostCenter { get; set; }
        public Guid CostCenterId { get; set; }

        public OS_OrganizationStructureTemplateDivision_Dto OrganizationStructureTemplateDivision { get; set; }
        public int OrganizationStructureTemplateId { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }
        public int OrganizationStructureTemplateDivisionTemplateId { get; set; }

        public int Percentage { get; set; }
    }


    public class OS_OrganizationStructureTemplateDepartment_Dto : AuditedEntityTenantDto<int>
    {
        public OS_DepartmentTemplate_Dto DepartmentTemplate { get; set; }
        public int DepartmentTemplateId { get; set; }

        public OS_OrganizationStructureTemplateBusinessUnit_Dto OrganizationStructureTemplateBusinessUnit { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }
        public int OrganizationStructureTemplateId { get; set; }
        public OS_OrganizationStructureTemplateDivision_Dto? OrganizationStructureTemplateDivision { get; set; }
        public int OrganizationStructureTemplateDivisionId { get; set; }
        //public OS_OrganizationStructureTemplateDepartment_Dto? OrganizationStructureTemplateHeadDepartment { get; set; }
        //public int HeadDepartmentTemplateId { get; set; }

        public LocationTemplate_Dto Location { get; set; }
        public int LocationId { get; set; }

        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }

        public List<OS_OrganizationStructureTemplateDepartment_Dto> OrganizationStructureTemplateDepartments { get; set; }
        //public List<OS_OrganizationStructureTemplatePosition_Dto> OrganizationStructureTemplatePositions { get; set; }

        public List<OS_OrganizationStructureTemplateDepartmentPosition_Dto> OrganizationStructureTemplateDepartmentAssociatedPositions { get; set; }
        public List<OS_OrganizationStructureTemplatePosition_Dto> OrganizationStructureTemplateDepartmentPositions { get; set; }
        public List<OS_OrganizationStructureTemplateDepartmentCostCenter_Dto> OrganizationStructureTemplateDepartmentCostCenters { get; set; }

        public OS_OrganizationStructureTemplateDepartmentPosition_Dto Head { get => OrganizationStructureTemplateDepartmentAssociatedPositions.FirstOrDefault(x => x.IsHead); }
    }
    public class OS_OrganizationStructureTemplateDepartmentPosition_Dto : AuditedEntityTenantDto<int>
    {
        public OS_PositionTemplate_Dto PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }

        public OS_OrganizationStructureTemplateDepartment_Dto OrganizationStructureTemplateDepartment { get; set; }
        public int OrganizationStructureTemplateDepartmentId { get; set; }
        public int HeadDepartmentTemplateId { get; set; }
        public int OrganizationStructureTemplateDivisionId { get; set; }
        public int OrganizationStructureTemplateId { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }

        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }
        public bool IsHead { get; set; }
    }
    public class OS_OrganizationStructureTemplateDepartmentCostCenter_Dto : AuditedEntityTenantDto<int>
    {
        public DictionaryValue_Dto CostCenter { get; set; }
        public Guid CostCenterId { get; set; }

        public OS_OrganizationStructureTemplateDepartment_Dto OrganizationStructureTemplateDepartment { get; set; }
        public int OrganizationStructureTemplateDepartmentId { get; set; }
        public int HeadDepartmentTemplateId { get; set; }
        public int OrganizationStructureTemplateDivisionId { get; set; }
        public int OrganizationStructureTemplateId { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }

        public int Percentage { get; set; }
    }


    public class OS_OrganizationStructureTemplatePosition_Dto : AuditedEntityTenantDto<int>
    {
        public OS_PositionTemplate_Dto PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }

        public OS_OrganizationStructureTemplateBusinessUnit_Dto OrganizationStructureTemplateBusinessUnit { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }
        public int OrganizationStructureTemplateId { get; set; }
        public OS_OrganizationStructureTemplateDivision_Dto? OrganizationStructureTemplateDivision { get; set; }
        public int OrganizationStructureTemplateDivisionId { get; set; }
        public OS_OrganizationStructureTemplateDepartment_Dto? OrganizationStructureTemplateDepartment { get; set; }
        public int OrganizationStructureTemplateDepartmentId { get; set; }
        //public OS_OrganizationStructureTemplatePosition_Dto? OrganizationStructureTemplateHeadPosition { get; set; }
        //public int HeadPositionTemplateId { get; set; }

        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }
        public List<OS_OrganizationStructureTemplatePosition_Dto> OrganizationStructureTemplatePositions { get; set; }
        public List<OS_OrganizationStructureTemplatePositionJob_Dto> OrganizationStructureTemplatePositionJobs { get; set; }
    }
    public class OS_OrganizationStructureTemplatePositionJob_Dto : AuditedEntityTenantDto<int>
    {
        public OS_JobTemplate_Dto JobTemplate { get; set; }
        public int JobTemplateId { get; set; }

        public OS_OrganizationStructureTemplatePosition_Dto OrganizationStructureTemplatePosition { get; set; }
        public int OrganizationStructureTemplatePositionId { get; set; }
        public int HeadPositionTemplateId { get; set; }
        public int OrganizationStructureTemplateDepartmenteId { get; set; }
        public int HeadDepartmentTemplateId { get; set; }
        public int OrganizationStructureTemplateDivisioneId { get; set; }
        public int OrganizationStructureTemplateId { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }

        public DictionaryValue_Dto Level { get; set; }
        public Guid LevelId { get; set; }

        public DictionaryValue_Dto EmployeeClass { get; set; }
        public Guid EmployeeClassId { get; set; }

        public DictionaryValue_Dto ContractType { get; set; }
        public Guid ContractTypeId { get; set; }
        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }
    }
}
