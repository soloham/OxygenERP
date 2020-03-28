using CERP.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.FM.UV_DTOs
{
    public class Branch_UV_Dto : AuditedEntityTenantDto<Guid> 
    {
        public Branch_UV_Dto()
        {

        }
        public Branch_UV_Dto(Guid id)
        {
            Id = id;
        }

        [Required]
        public virtual Company_UV_Dto Company { get; set; }
        public Guid CompanyId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int BranchCode { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
