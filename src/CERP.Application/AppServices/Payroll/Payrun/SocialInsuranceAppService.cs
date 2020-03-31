using CERP.Payroll.DTOs;
using CERP.Payroll.Payrun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP.AppServices.Payroll.PayrunService
{
    public class SocialInsuranceAppService : CrudAppService<SISetup, SISetup_Dto, int, PagedAndSortedResultRequestDto, SISetup_Dto, SISetup_Dto>
    {
        public SocialInsuranceAppService(IRepository<SISetup, int> repository) : base(repository)
        {
            Repository = repository;
        }

        public IRepository<SISetup, int> Repository { get; }

        public SISetup GetEntitySetupWDAsync()
        {
            return Repository.WithDetails().First();
        }
        public SISetup_Dto GetSetupWDAsync()
        {
            return ObjectMapper.Map<SISetup, SISetup_Dto>(Repository.WithDetails().First());
        }

        public SISetup_Dto GetCurrentSetup()
        {
            return ObjectMapper.Map<SISetup, SISetup_Dto>(Repository.First());
        }
    }
}
