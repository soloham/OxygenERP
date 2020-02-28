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
    public class coaAppService : CrudAppService<COA_Account, COA_Account_Dto, Guid, PagedAndSortedResultRequestDto, COA_Account_UV_Dto, COA_Account_UV_Dto>
    {
        public readonly IRepository<COA_Account, Guid> repository;

        public coaAppService(IRepository<COA_Account, Guid> repository) : base(repository)
        {
            this.repository = repository;
        }

        public List<COA_Account_Dto> GetNonSubLedgerAccounts()
        {
            List<COA_Account_Dto> result = new List<COA_Account_Dto>();
            var acnts = Repository.Where(x => x.SubLedgerTypeId == 0).ToArray();
            for (int i = 0; i < acnts.Count(); i++)
            {
                result.Add(MapToGetOutputDto(acnts[i]));
            }
            return result;
        }

        //public async Task<COA_Account_Dto> CreateAccount(COA_Account_UV_Dto dto)
        //{
        //    //COA coa = new COA(dto.Id) {
        //    //    HeadAccountId = dto.HeadAccountId,
        //    //};
        //    COA_Account coa = MapToEntity(dto);
        //    await Repository.InsertAsync(coa);

        //    return MapToGetOutputDto(coa);
        //}

        //protected override IQueryable<COA> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        //{
        //    return repository.GetListAsync(input);
        //}

        //protected override ParentEntity GetEntityById(int id)
        //{
        //    var entity = repository.GetAllIncluding(p => p.ChildEntity).FirstOrDefault(p => p.Id == id);
        //    if (entity == null)
        //    {
        //        throw new EntityNotFoundException(typeof(ParentEntity), id);
        //    }

        //    return entity;
        //}
    }
}
