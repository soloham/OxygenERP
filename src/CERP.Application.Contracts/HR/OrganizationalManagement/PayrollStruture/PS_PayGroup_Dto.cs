﻿using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.FM;
using CERP.HR.Employees;
using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure
{
    public class PS_PayGroup_Dto : AuditedEntityTenantDto<int>
    {
        public PS_PayGroup_Dto()
        {
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameLocalized { get; set; }
        public string Description { get; set; }

        public PS_PayFrequency_Dto Frequency { get; set; }
        public int FrequencyId { get; set; }
    }
}
