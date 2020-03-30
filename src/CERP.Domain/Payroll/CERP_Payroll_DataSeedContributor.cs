using CERP.Payroll.Payrun;
using CERP.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Uow;

namespace CERP.App
{
    public class CERP_Payroll_DataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;

        public CERP_Payroll_DataSeedContributor(IGuidGenerator guidGenerator, IRepository<SIContributionCategory> sIContribCatRepo, IRepository<SIContribution> sIContribsRepo)
        {
            _guidGenerator = guidGenerator;
            SIContribCatRepo = sIContribCatRepo;
            SIContribsRepo = sIContribsRepo;
        }

        public IRepository<SIContributionCategory> SIContribCatRepo { get; set; }
        public IRepository<SIContribution> SIContribsRepo { get; set; }

        [UnitOfWork]
        public async Task SeedAsync(DataSeedContext context)
        {
            var curSIContribCats = await SIContribCatRepo.GetListAsync();
            if(!curSIContribCats.Any(x => x.Title == "Employee"))
            {
                SIContributionCategory category = new SIContributionCategory();
                category.Title = "Employee";
                category.IsExpense = false;
                category.TenantId = context.TenantId;
                category.SIContributions = new List<SIContribution>()
                {
                    new SIContribution(){ Title = "Annuity", Value = 9, IsPercentage = true, TenantId = context.TenantId },
                    new SIContribution(){ Title = "Unemployment Contribution", Value = 1, IsPercentage = true, TenantId = context.TenantId }
                };

                await SIContribCatRepo.InsertAsync(category);
            }
            if(!curSIContribCats.Any(x => x.Title == "Employer"))
            {
                SIContributionCategory category = new SIContributionCategory();
                category.Title = "Employer";
                category.IsExpense = true;
                category.TenantId = context.TenantId;
                category.SIContributions = new List<SIContribution>()
                {
                    new SIContribution(){ Title = "Annuity", Value = 9, IsPercentage = true, TenantId = context.TenantId },
                    new SIContribution(){ Title = "Unemployment Contribution", Value = 1, IsPercentage = true, TenantId = context.TenantId },
                    new SIContribution(){ Title = "Occupational Hazard", Value = 2, IsPercentage = true, TenantId = context.TenantId }
                };

                await SIContribCatRepo.InsertAsync(category);
            }
        }
    }
}