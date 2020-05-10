using CERP.App.Helpers;
using CERP.Base;
using CERP.FM;
using CERP.FM.DTOs;
using CERP.HR.Employees;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.IO;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.Setup.DTOs
{
    public class Currency_Dto : AuditedEntityTenantDto<int>
    {
        public Currency_Dto()
        {

        }

        public string CurrencyName { get; set; }
        public string CurrencyNameLocal { get; set; }
        public string CurrencyCode { get; set; }

        public string StatusDescription { get => EnumExtensions.GetDescription(Status); set => Status = EnumExtensions.GetValueFromDescription<CurrencyStatus>(value); }
        public CurrencyStatus Status { get; set; }
    }

}
