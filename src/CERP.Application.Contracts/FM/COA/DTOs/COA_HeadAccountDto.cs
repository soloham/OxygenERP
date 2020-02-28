using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.FM.COA.DTOs
{
    public class COA_HeadAccount_Dto : FullAuditedEntityDto<Guid> 
    {
        public COA_HeadAccount_Dto()
        {

        }
        public COA_HeadAccount_Dto(Guid id)
        {
            Id = id;
        }
        public HeadAccountType HeadCode { get; set; }
        public string AccountName { get; set; }
        public string LocalizationKey { get; set; }
    }
}
