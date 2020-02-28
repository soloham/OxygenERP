﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.FM.DTOs
{
    public class AccountStatementType_UV_Dto : AuditedEntityDto<Guid> 
    {
        public AccountStatementType_UV_Dto()
        {

        }
        public AccountStatementType_UV_Dto(Guid id)
        {
            Id = id;
        }

        public AccountStatementTypeEnum AccountStatementTypeId { get; set; }
        public AccountStatementDetailTypeEnum AccountStatementDetailTypeId { get; set; }
        public string Title { get; set; }
        public string TitleLocalizationKey { get; set; }
        public Guid? ParentId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
