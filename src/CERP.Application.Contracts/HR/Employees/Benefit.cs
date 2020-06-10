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
        public int PayComponentId { get; set; }
        //public PS_PayComponentType_Dto PayComponentType { get; set; }
        //public int PayComponentTypeId { get; set; }
        public string PayComponentComponentTypeAmount { get; set; }

        //public PS_PayFrequency_Dto PayFrequency { get; set; }
        //public int PayFrequencyId { get; set; }
        public string ValidityFromDate { get; set; }
        public string ValidityToDate { get; set; }
    }
}
