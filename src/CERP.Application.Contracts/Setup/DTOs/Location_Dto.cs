using CERP.App.Helpers;
using CERP.Base;
using CERP.FM;
using CERP.FM.DTOs;
using CERP.HR.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.Setup.DTOs
{
    public class LocationTemplate_Dto : AuditedEntityTenantDto<Guid>
    {
        public LocationTemplate_Dto()
        {

        }
        public LocationTemplate_Dto(Guid id)
        {
            Id = id;
        }

        public string LocationName { get; set; }
        public string LocationNameLocalized { get; set; }
        public string LocationAbbreviation { get; set; }

        public string StatusDescription { get => EnumExtensions.GetDescription(Status); set => Status = EnumExtensions.GetValueFromDescription<LocationStatus>(value); }
        public LocationStatus Status { get; set; }
    }

}
