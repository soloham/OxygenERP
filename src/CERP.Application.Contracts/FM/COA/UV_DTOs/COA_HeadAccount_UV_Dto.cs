using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.FM.COA.UV_DTOs
{
    public class COA_HeadAccount_UV_Dto : FullAuditedEntityDto<Guid> 
    {
        public COA_HeadAccount_UV_Dto()
        {

        }
        public COA_HeadAccount_UV_Dto(Guid id)
        {
            Id = id;
        }

        [Required]
        public HeadAccountType HeadCode { get; set; }
        [Required]
        public string AccountName { get; set; }
        public string LocalizationKey { get; set; }
    }
}
