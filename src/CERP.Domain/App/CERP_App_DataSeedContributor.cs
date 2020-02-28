using CERP.FM;
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
    public class CERP_App_DataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private IRepository<DictionaryValue, Guid> DictionaryValuesRepo;
        private IRepository<DictionaryValueType, Guid> DictionaryValueTypesRepo;
        private IRepository<Company, Guid> _CompaniesRepo;
        private IRepository<Branch, Guid> _BranchesRepo;
        private readonly IGuidGenerator _guidGenerator;

        public CERP_App_DataSeedContributor(IGuidGenerator guidGenerator, IRepository<DictionaryValue, Guid> dictionaryValuesRepo, IRepository<DictionaryValueType, Guid> dictionaryValueTypesRepo, IRepository<Company, Guid> companiesRepo, IRepository<Branch, Guid> branchesRepo)
        {
            _guidGenerator = guidGenerator;
            DictionaryValuesRepo = dictionaryValuesRepo;
            DictionaryValueTypesRepo = dictionaryValueTypesRepo;
            _CompaniesRepo = companiesRepo;
            _BranchesRepo = branchesRepo;
        }

        [UnitOfWork]
        public async Task SeedAsync(DataSeedContext context)
        {
            var curCompanies = await _CompaniesRepo.GetListAsync();
            var curBranches = await _BranchesRepo.GetListAsync();
            if (curCompanies.Any(x => x.Name == "TestCorp" && curBranches.Any(x => x.Name == "Head")))
            {
                List<DictionaryValue> cashflowDicValues = new List<DictionaryValue>() {
                    new DictionaryValue(_guidGenerator.Create())
                    {
                        Key = AppSettings.CashflowStatementTypesKey,
                        Value = "Cash Generated From Operations",
                        ActiveStatus = true,
                        Branch = null,
                        Company = _CompaniesRepo.First()
                    },
                    new DictionaryValue(_guidGenerator.Create())
                    {
                        Key = AppSettings.CashflowStatementTypesKey,
                        Value = "Cash Flow From Operating Activities",
                        ActiveStatus = true,
                        Branch = null,
                        Company = _CompaniesRepo.First()
                    },
                    new DictionaryValue(_guidGenerator.Create())
                    {
                        Key = AppSettings.CashflowStatementTypesKey,
                        Value = "Cash Generated From Financing Activities",
                        ActiveStatus = true,
                        Branch = null,
                        Company = _CompaniesRepo.First()
                    },
                    new DictionaryValue(_guidGenerator.Create())
                    {
                        Key = AppSettings.CashflowStatementTypesKey,
                        Value = "Net Profit Before Tax",
                        ActiveStatus = true,
                        Branch = null,
                        Company = _CompaniesRepo.First()
                    },
                    new DictionaryValue(_guidGenerator.Create())
                    {
                        Key = AppSettings.CashflowStatementTypesKey,
                        Value = "Operating Profit Before Working Capital",
                        ActiveStatus = true,
                        Branch = null,
                        Company = _CompaniesRepo.First()
                    },
                    new DictionaryValue(_guidGenerator.Create())
                {
                    Key = AppSettings.CashflowStatementTypesKey,
                    Value = "Cash and Cash Equivalents",
                    ActiveStatus = true,
                    Branch = null,
                    Company = _CompaniesRepo.First()
                }
                };
                DictionaryValueType CashflowStatementTypeDicValueType = new DictionaryValueType(_guidGenerator.Create())
                {
                    ValueTypeName = "CashflowStatementTypes",
                    ActiveStatus = true,
                    Values = cashflowDicValues,
                    Branch = null,
                    Company = _CompaniesRepo.First()
                };
                if (!DictionaryValueTypesRepo.Any(x => x.ValueTypeName == "CashflowStatementTypes"))
                {
                    await DictionaryValueTypesRepo.InsertAsync(CashflowStatementTypeDicValueType);
                }

                if (DictionaryValueTypesRepo.Count() == -1)
                {
                    if (!DictionaryValuesRepo.Any(x => x.Value == "Cash Generated From Operations"))
                    {
                        await DictionaryValuesRepo.InsertAsync(new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.CashflowStatementTypesKey,
                            Value = "Cash Generated From Operations",
                            ActiveStatus = true,
                            ValueType = DictionaryValueTypesRepo.First(x => x.ValueTypeName == "CashflowStatementTypes")
                        });
                    }
                    if (!DictionaryValuesRepo.Any(x => x.Value == "Cash Flow From Operating Activities"))
                    {
                        await DictionaryValuesRepo.InsertAsync(new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.CashflowStatementTypesKey,
                            Value = "Cash Flow From Operating Activities",
                            ActiveStatus = true,
                            ValueType = DictionaryValueTypesRepo.First(x => x.ValueTypeName == "CashflowStatementTypes")
                        });
                    }
                    if (!DictionaryValuesRepo.Any(x => x.Value == "Cash Generated From Financing Activities"))
                    {
                        await DictionaryValuesRepo.InsertAsync(new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.CashflowStatementTypesKey,
                            Value = "Cash Generated From Financing Activities",
                            ActiveStatus = true,
                            ValueType = DictionaryValueTypesRepo.First(x => x.ValueTypeName == "CashflowStatementTypes")
                        });
                    }
                    if (!DictionaryValuesRepo.Any(x => x.Value == "Net Profit Before Tax"))
                    {
                        await DictionaryValuesRepo.InsertAsync(new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.CashflowStatementTypesKey,
                            Value = "Net Profit Before Tax",
                            ActiveStatus = true,
                            ValueType = DictionaryValueTypesRepo.First(x => x.ValueTypeName == "CashflowStatementTypes")
                        });
                    }
                    if (!DictionaryValuesRepo.Any(x => x.Value == "Operating Profit Before Working Capital"))
                    {
                        await DictionaryValuesRepo.InsertAsync(new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.CashflowStatementTypesKey,
                            Value = "Operating Profit Before Working Capital",
                            ActiveStatus = true,
                            ValueType = DictionaryValueTypesRepo.First(x => x.ValueTypeName == "CashflowStatementTypes")
                        });
                    }
                    if (!DictionaryValuesRepo.Any(x => x.Value == "Cash and Cash Equivalents"))
                    {
                        await DictionaryValuesRepo.InsertAsync(new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.CashflowStatementTypesKey,
                            Value = "Cash and Cash Equivalents",
                            ActiveStatus = true,
                            ValueType = DictionaryValueTypesRepo.First(x => x.ValueTypeName == "CashflowStatementTypes")
                        });
                    }
                } 
            }
        }
    }
}
