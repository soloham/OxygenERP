using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.FM;
using CERP.HR.Employees;
using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.PayrollStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using CERP.App.Helpers;

namespace CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PayGrade_Dto : AuditedEntityTenantDto<int>
    {
        public PS_PayGrade_Dto()
        {
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameLocalized { get; set; }
        public string Description { get; set; }

        public string PayGradeStatusDescription { get => EnumExtensions.GetDescription(PayGradeStatus); set => PayGradeStatus = EnumExtensions.GetValueFromDescription<PS_PayGradeStatus>(value); }
        public PS_PayGradeStatus PayGradeStatus { get; set; }

        public string PayGradeLevelDescription { get => EnumExtensions.GetDescription(PayGradeLevel); set => PayGradeLevel = EnumExtensions.GetValueFromDescription<PS_PayGradeLevel>(value); }
        public PS_PayGradeLevel PayGradeLevel { get; set; }

        public PS_PayRange_Dto PayRange { get; set; }
        public int PayRangeId { get; set; }

        public List<PS_PayGradeComponent_Dto> PayGradeComponents { get; set; }
    }
    public class PS_PayGradeComponent_Dto : AuditedEntityTenantDto<int>
    {
        public PS_PayComponent_Dto PayComponent { get; set; }
        public int PayComponentId { get; set; }

        public PS_PayGrade_Dto PayGrade { get; set; }
        public int PayGradeId { get; set; }

        public int MaxAnnualLimit { get; set; }
    }
}
