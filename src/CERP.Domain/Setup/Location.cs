using CERP.Base;
using CERP.FM;
using CERP.HR.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.Setup
{
    public class LocationTemplate : AuditedAggregateTenantRoot<Guid>
    {
        public LocationTemplate()
        {
        }
        public LocationTemplate(Guid id)
        {
            Id = id;
        }

        public string LocationName { get; set; }
        public string LocationNameLocalized { get; set; }
        public string LocationAbbreviation { get; set; }
        public LocationStatus Status { get; set; }
    }

}
