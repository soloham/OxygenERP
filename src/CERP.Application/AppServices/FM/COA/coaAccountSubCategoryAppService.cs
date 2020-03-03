using CERP.FM;
using CERP.FM.COA;
using CERP.FM.COA.DTOs;
using CERP.FM.COA.UV_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<COA_AccountSubCategory_Dto> GetSubCategories(Guid headAccount, int CLR, Guid empty)
        {
            var all = Repository.ToList();
            var result = all.Where(x => x.HeadAccountId == headAccount).ToList();
            var resultDtos = result.Select(MapToGetOutputDto).ToList();

            return resultDtos;
        }

        public List<COA_AccountSubCategory_Dto> GetDetailedList()
        {
            return Repository.WithDetails().Select(MapToGetListOutputDto).ToList();
        }

        public async Task<COA_AccountSubCategory_Dto> CreateCategory(COA_AccountSubCategory_UV_Dto dto)
        {
            COA_AccountSubCategory entity = MapToEntity(dto);
            return MapToGetOutputDto(await Repository.InsertAsync(entity));
        }
    }
}
