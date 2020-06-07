using CERP.App;
using CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure;
using CERP.Attributes;
using CERP.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class Benefit_Dto : AuditedEntityTenantDto<int>
    {
        public Benefit_Dto()
        {

        }

        public PS_PayComponent_Dto PayComponent { get; set; }
        [CustomAudited]
        public int PayComponentId { get; set; }

        [CustomAudited]
        public string PayComponentComponentTypeAmount { get; set; }

        public PS_PayFrequency_Dto PayFrequency { get; set; }
        [CustomAudited]
        public int PayFrequencyId { get; set; }


        [CustomAudited]
        public string ValidityFromDate { get; set; }
        [CustomAudited]
        public string ValidityToDate { get; set; }
    }
}
