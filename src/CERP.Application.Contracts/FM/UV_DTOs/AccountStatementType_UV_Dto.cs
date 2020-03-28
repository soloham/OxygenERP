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
    public class AccountStatementType_UV_Dto : AuditedEntityTenantDto<Guid> 
    {
        public AccountStatementType_UV_Dto()
        {

        }
        public AccountStatementType_UV_Dto(Guid id)
        {
            Id = id;
        }

        [Required]
        public AccountStatementTypeEnum AccountStatementTypeId { get; set; }
        [Required]
        public AccountStatementDetailTypeEnum AccountStatementDetailTypeId { get; set; }
        [Required]
        public string Title { get; set; }
        public string TitleLocalizationKey { get; set; }
        public Guid? ParentId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
