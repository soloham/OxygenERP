using CERP.FM;
using CERP.FM.COA;
using CERP.FM.DTOs;
using CERP.FM.UV_DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP
{
    public class companyAppService : CrudAppService<Company, Company_Dto, Guid, PagedAndSortedResultRequestDto, Company_UV_Dto, Company_UV_Dto>
    {
        public companyAppService(IRepository<Company, Guid> repository) : base(repository)
        {
        }
    }
}
