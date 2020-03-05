using CERP.App;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP.AppServices.Setup.Lookup
{
    public class DictionaryValueTypeAppService : CrudAppService<DictionaryValueType, DictionaryValueType_Dto, Guid, PagedAndSortedResultRequestDto, DictionaryValueType_Dto, DictionaryValueType_Dto>
    {
        public DictionaryValueTypeAppService(IRepository<DictionaryValueType, Guid> repository) : base(repository)
        {
            Repository = repository;
        }

        public IRepository<DictionaryValueType, Guid> Repository { get; }
    }
}
