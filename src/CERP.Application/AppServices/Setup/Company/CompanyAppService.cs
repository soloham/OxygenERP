using CERP.FM.DTOs;
using CERP.Setup;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP.AppServices.Setup.CompanySetup
{
    public class CompanyAppService : CrudAppService<Company, Company_Dto, Guid, PagedAndSortedResultRequestDto, Company_Dto, Company_Dto>
    {
        public CompanyAppService(IRepository<Company, Guid> repository, IRepository<CompanyLocation> locationsRepository, IRepository<CompanyCurrency> currenciesRepository, IRepository<CompanyPrintSize> printSizesRepository) : base(repository)
        {
            Repository = repository;
            LocationsRepository = locationsRepository;
            CurrenciesRepository = currenciesRepository;
            PrintSizesRepository = printSizesRepository;
        }

        public IRepository<Company, Guid> Repository { get; }
        public IRepository<CompanyLocation> LocationsRepository { get; }
        public IRepository<CompanyCurrency> CurrenciesRepository { get; }
        public IRepository<CompanyPrintSize> PrintSizesRepository { get; }

        public List<Company_Dto> GetAllCompanies()
        {
            return Repository.WithDetails().Select(MapToGetListOutputDto).ToList();
        }
    }
}
