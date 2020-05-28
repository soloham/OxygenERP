using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.Attributes;
using CERP.Base;
using CERP.FM.DTOs;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using CERP.Setup.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;

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
        public OS_StructureStatus StructureStatus { get; set; }
        public OS_ReviewPeriod ReviewPeriod { get; set; }
        public int? ReviewPeriodDays { get; set; }

        public Company_Dto LegalEntity { get; set; }
        public Guid LegalEntityId { get; set; }


        public virtual ICollection<OS_OrganizationStructureTemplateBusinessUnits_Dto> OrganizationStructureTemplateBusinessUnits { get; set; }
        public virtual ICollection<OS_OrganizationStructureTemplateDivisions_Dto> OrganizationStructureTemplateDivisions { get; set; }
        public virtual ICollection<OS_OrganizationStructureTemplateDepartments_Dto> OrganizationStructureTemplateDepartments { get; set; }
    }

    public class OS_OrganizationStructureTemplateBusinessUnits_Dto : AuditedEntityTenantDto<int>
    {
        public OS_BusinessUnitTemplate_Dto BusinessUnitTemplate { get; set; }
        public int BusinessUnitTemplateId { get; set; }

        public OS_OrganizationStructureTemplate_Dto OrganizationStructureTemplate { get; set; }
        public int OrganizationStructureTemplateId { get; set; }

        public LocationTemplate_Dto Location { get; set; }
        public int LocationId { get; set; }

        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }

        public virtual ICollection<OS_OrganizationStructureTemplateBusinessUnitPosition_Dto> OrganizationStructureTemplateBusinessUnitPositions { get; set; }

    }
    public class OS_OrganizationStructureTemplateBusinessUnitPosition_Dto : AuditedEntityTenantDto<int>
    {
        public OS_PositionTemplate_Dto PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }

        public OS_OrganizationStructureTemplateBusinessUnits_Dto OrganizationStructureTemplateBusinessUnit { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }
        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }
    }


    public class OS_OrganizationStructureTemplateDivisions_Dto : AuditedEntityTenantDto<int>
    {
        public OS_DivisionTemplate_Dto DivisionTemplate { get; set; }
        public int DivisionTemplateId { get; set; }

        public OS_OrganizationStructureTemplate_Dto OrganizationStructureTemplate { get; set; }
        public int OrganizationStructureTemplateId { get; set; }

        public LocationTemplate_Dto Location { get; set; }
        public int LocationId { get; set; }

        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }
        public virtual ICollection<OS_OrganizationStructureTemplateDivisionPosition_Dto> OrganizationStructureTemplateDivisionPositions { get; set; }
    }
    public class OS_OrganizationStructureTemplateDivisionPosition_Dto : AuditedEntityTenantDto<int>
    {
        public OS_PositionTemplate_Dto PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }

        public OS_OrganizationStructureTemplateDivisions_Dto OrganizationStructureTemplateDivision { get; set; }
        public int OrganizationStructureTemplateDivisionId { get; set; }
        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }
    }


    public class OS_OrganizationStructureTemplateDepartments_Dto : AuditedEntityTenantDto<int>
    {
        public OS_DepartmentTemplate_Dto DepartmentTemplate { get; set; }
        public int DepartmentTemplateId { get; set; }

        public OS_OrganizationStructureTemplate_Dto OrganizationStructureTemplate { get; set; }
        public int OrganizationStructureTemplateId { get; set; }

        public LocationTemplate_Dto Location { get; set; }
        public int LocationId { get; set; }

        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }
        public virtual ICollection<OS_OrganizationStructureTemplateDepartmentPosition_Dto> OrganizationStructureTemplateDepartmentPositions { get; set; }
    }
    public class OS_OrganizationStructureTemplateDepartmentPosition_Dto : AuditedEntityTenantDto<int>
    {
        public OS_PositionTemplate_Dto PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }

        public OS_OrganizationStructureTemplateDepartments_Dto OrganizationStructureTemplateDepartment { get; set; }
        public int OrganizationStructureTemplateDepartmentId { get; set; }
        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }
    }
}
