using CERP.FM.COA;
using CERP.FM.COA.DTOs;
using CERP.FM.COA.UV_DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP
{
    public class coaHeadAccountAppService : CrudAppService<COA_HeadAccount, COA_HeadAccount_Dto, Guid, PagedAndSortedResultRequestDto, COA_HeadAccount_UV_Dto, COA_HeadAccount_UV_Dto>
    {
        public coaHeadAccountAppService(IRepository<COA_HeadAccount, Guid> repository) : base(repository)
        {

        }
    }
}
