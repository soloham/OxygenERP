using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.HR.OrganizationalManagement.PayrollStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class Benefit : AuditedAggregateTenantRoot<int>
    {
        public Benefit()
        {

        }

        public PS_PayComponent PayComponent { get; set; }
        [CustomAudited]
        public int PayComponentId { get; set; }

        [CustomAudited]
        public string PayComponentComponentTypeAmount { get; set; }

        public PS_PayFrequency PayFrequency { get; set; }
        [CustomAudited]
        public int PayFrequencyId { get; set; }


        [CustomAudited]
        public string ValidityFromDate { get; set; }
        [CustomAudited]
        public string ValidityToDate { get; set; }
    }
}
