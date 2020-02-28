using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.FM.DTOs
{
    public class Branch_Dto : AuditedEntityDto<Guid> 
    {
        public Branch_Dto()
        {

        }
        public Branch_Dto(Guid id)
        {
            Id = id;
        }
        public virtual Branch_Dto Company { get; set; }
        public Guid CompanyId { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public int BranchCode { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
