using CERP.Payroll.DTOs;
using CERP.Payroll.Payrun;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP.AppServices.Payroll.PayrunService
{
    public class SocialInsuranceAppService : CrudAppService<SIContributionCategory, SIContributionCategory_Dto, int, PagedAndSortedResultRequestDto, SIContributionCategory_Dto, SIContributionCategory_Dto>
    {
        public SocialInsuranceAppService(IRepository<SIContributionCategory, int> repository) : base(repository)
        {
            Repository = repository;
        }

        public IRepository<SIContributionCategory, int> Repository { get; }
    }
}
