using CERP.Base;
using CERP.FM.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CERP.Setup.DTOs
{
    public class Department_Dto : AuditedEntityTenantDto<Guid>
    {
        public Department_Dto()
        {

        }
        public Department_Dto(Guid id)
        {
            Id = id;
        }

        public Company_Dto Company { get; set; }
        public Guid CompanyId { get; set; }

        public string Name { get; set; }
        public ICollection<Position_Dto> Positions { get; set; }
    }
}
