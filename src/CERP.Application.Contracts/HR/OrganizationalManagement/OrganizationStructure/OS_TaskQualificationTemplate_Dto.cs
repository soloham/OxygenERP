using CERP.App;
using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.Attributes;
using CERP.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CERP.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_TaskQualificationTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_TaskQualificationTemplate_Dto()
        {
        }

        public OS_TaskTemplate_Dto TaskTemplate { get; set; }
        public int TaskTemplateId { get; set; }

        public DictionaryValue_Dto Degree { get; set; }
        public Guid DegreeId { get; set; }

        public DictionaryValue_Dto Institute { get; set; }
        public Guid InstituteId { get; set; }

        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }
    }
}
