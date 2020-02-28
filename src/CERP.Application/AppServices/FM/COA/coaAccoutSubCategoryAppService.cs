using CERP.FM;
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
    public class coaAccountSubCategoryAppService : CrudAppService<COA_AccountSubCategory, COA_AccountSubCategory_Dto, Guid, PagedAndSortedResultRequestDto, COA_AccountSubCategory_UV_Dto, COA_AccountSubCategory_UV_Dto>
    {
        public coaAccountSubCategoryAppService(IRepository<COA_AccountSubCategory, Guid> repository) : base(repository)
        {
            Repository = repository;
        }

        public IRepository<COA_AccountSubCategory, Guid> Repository { get; }
    }
}
