using CERP.Setup;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP.AppServices.Setup.CurrencySetup
{
    public class CurrencyAppService : CrudAppService<Currency, Currency_Dto, int, PagedAndSortedResultRequestDto, Currency_Dto, Currency_Dto>
    {
        public CurrencyAppService(IRepository<Currency, int> repository) : base(repository)
        {
            Repository = repository;
        }

        public IRepository<Currency, int> Repository { get; }
    }
}
