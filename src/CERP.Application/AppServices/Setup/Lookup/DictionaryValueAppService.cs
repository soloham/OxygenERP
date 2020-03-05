using CERP.App;
using CERP.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Uow;

namespace CERP.AppServices.Setup.Lookup
{
    public class DictionaryValueAppService : CrudAppService<DictionaryValue, DictionaryValue_Dto, Guid, PagedAndSortedResultRequestDto, DictionaryValue_Dto, DictionaryValue_Dto>
    {
        
        public DictionaryValueAppService(IRepository<DictionaryValue, Guid> repository) : base(repository)
        {
            //ContextProvider = contextProvider;
            Repository = repository;
        }

        public IRepository<DictionaryValue, Guid> Repository { get; }
    }
}
