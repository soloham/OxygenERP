using CERP.Setup;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using CERP.Payroll.DTOs;
using CERP.Payroll.Payrun;
using System.Dynamic;
using System.Text.Json;
using System.Threading.Tasks;

namespace CERP.AppServices.Payroll.PayrunService
{
    public class PayrunAppService : CrudAppService<Payrun, Payrun_Dto, int, PagedAndSortedResultRequestDto, Payrun_Dto, Payrun_Dto>
    {
        public IRepository<PayrunDetail, int> PayrunDetailsRepo { get; set; }
        public IRepository<PayrunAllowanceSummary, int> PayrunAllowanceSummaryRepo { get; set; }
        public PayrunAppService(IRepository<Payrun, int> repository, IRepository<PayrunDetail, int> payrunDetailsRepo, IRepository<PayrunAllowanceSummary, int> payrunAllowanceSummaryRepo) : base(repository)
        {
            Repository = repository;
            PayrunDetailsRepo = payrunDetailsRepo;
            PayrunAllowanceSummaryRepo = payrunAllowanceSummaryRepo;
        }

        public IRepository<Payrun, int> Repository { get; }

        public Payrun_Dto GetPayrun(int month, int year, Guid CompanyId)
        {
            return ObjectMapper.Map<Payrun, Payrun_Dto>(Repository.SingleOrDefault(x => x.Month == month && x.Year == year && x.CompanyId == CompanyId));
        }


        public async Task<List<PayrunDetail_Dto>> GetAllDetails()
        {
            List<PayrunDetail> list = (await PayrunDetailsRepo.GetListAsync(false));
            return ObjectMapper.Map<List<PayrunDetail>, List<PayrunDetail_Dto>>(list);
        }

    }
}
