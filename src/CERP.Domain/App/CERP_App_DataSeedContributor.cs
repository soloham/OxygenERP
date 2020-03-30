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

                

             //   if (!DictionaryValueTypesRepo.Any(x => x.ValueTypeName == "Cashflow Statement Types"))
             //   {
             //       Guid guid = _guidGenerator.Create();
             //       List<DictionaryValue> cashflowDicValues = new List<DictionaryValue>() {
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "01001",
             //               Value = "Cash Generated From Operations",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "01002",
             //               Value = "Cash Flow From Operating Activities",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "01003",
             //               Value = "Cash Generated From Financing Activities",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "01004",
             //               Value = "Net Profit Before Tax",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "01005",
             //               Value = "Operating Profit Before Working Capital",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "01006",
             //               Value = "Cash and Cash Equivalents",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           }
             //       };

             //       await DictionaryValueTypesRepo.InsertAsync(new DictionaryValueType(guid)
             //       {
             //           ValueTypeFor = ValueTypeModules.CashflowStatementType,
             //           ValueTypeCode = "01",
             //           ValueTypeName = "Cashflow Statement Types",
             //           ActiveStatus = true,
             //           Values = cashflowDicValues,
             //           Branch = null,
             //           Company = _CompaniesRepo.First(),
             //           TenantId = context.TenantId
             //       });
             //   }
             //   if (!DictionaryValueTypesRepo.Any(x => x.ValueTypeName == "Country"))
             //   {
             //       Guid guid = _guidGenerator.Create();
             //       List<DictionaryValue> locationsDicValues = new List<DictionaryValue>() {
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "02001",
             //               Value = "UAE",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "02002",
             //               Value = "Bahrain",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "02003",
             //               Value = "Qatar",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "02004",
             //               Value = "Saudi Arabia",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "02005",
             //               Value = "Yemen",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "02006",
             //               Value = "Syria",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "02007",
             //               Value = "Egypt",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "02008",
             //               Value = "Libya",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "020017",
             //               Value = "Sudan",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "02009",
             //               Value = "Palestine",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "02010",
             //               Value = "Pakistan",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "02011",
             //               Value = "India",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "02012",
             //               Value = "Lebanon",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "02013",
             //               Value = "Jordan",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "02014",
             //               Value = "Kuwait",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "02015",
             //               Value = "Bangladesh",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "02016",
             //               Value = "Philippines",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           }
             //       };

             //       await DictionaryValueTypesRepo.InsertAsync(new DictionaryValueType(guid)
             //       {
             //           ValueTypeFor = ValueTypeModules.Country,
             //           ValueTypeCode = "02",
             //           ValueTypeName = "Country",
             //           ActiveStatus = true,
             //           Values = locationsDicValues,
             //           Branch = null,
             //           Company = _CompaniesRepo.First()
             //       });
             //   }
             //   if (!DictionaryValueTypesRepo.Any(x => x.ValueTypeName == "Gender"))
             //   {
             //       Guid guid = _guidGenerator.Create();
             //       List<DictionaryValue> genderDicValues = new List<DictionaryValue>() {
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "03001",
             //               Value = "Male",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "03002",
             //               Value = "Female",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           }
             //       };

             //       await DictionaryValueTypesRepo.InsertAsync(new DictionaryValueType(guid)
             //       {
             //           ValueTypeFor = ValueTypeModules.Gender,
             //           ValueTypeCode = "03",
             //           ValueTypeName = "Gender",
             //           ActiveStatus = true,
             //           Values = genderDicValues,
             //           Branch = null,
             //           Company = _CompaniesRepo.First(),
             //           TenantId = context.TenantId
             //       });
             //   }
             //   if (!DictionaryValueTypesRepo.Any(x => x.ValueTypeName == "Marital Status"))
             //   {
             //       Guid guid = _guidGenerator.Create();
             //       List<DictionaryValue> maritalStatusDicValues = new List<DictionaryValue>() {
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "04001",
             //               Value = "Married",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "04002",
             //               Value = "Un-Married",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           }
             //       };

             //       await DictionaryValueTypesRepo.InsertAsync(new DictionaryValueType(guid)
             //       {
             //           ValueTypeFor = ValueTypeModules.MaritalStatus,
             //           ValueTypeCode = "04",
             //           ValueTypeName = "Marital Status",
             //           ActiveStatus = true,
             //           Values = maritalStatusDicValues,
             //           Branch = null,
             //           Company = _CompaniesRepo.First(),
             //           TenantId = context.TenantId
             //       });
             //   }
             //   if (!DictionaryValueTypesRepo.Any(x => x.ValueTypeName == "Blood Group"))
             //   {
             //       Guid guid = _guidGenerator.Create();
             //       List<DictionaryValue> bloodGroupsDicValues = new List<DictionaryValue>() {
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "05001",
             //               Value = "AB+",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "05002",
             //               Value = "A-",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "05003",
             //               Value = "B+",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "05004",
             //               Value = "A+",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "05005",
             //               Value = "O+",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "05006",
             //               Value = "O-",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "05007",
             //               Value = "AB-",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "05008",
             //               Value = "Unknown",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           }
             //       };

             //       await DictionaryValueTypesRepo.InsertAsync(new DictionaryValueType(guid)
             //       {
             //           ValueTypeFor = ValueTypeModules.BloodGroup,
             //           ValueTypeCode = "05",
             //           ValueTypeName = "Blood Group",
             //           ActiveStatus = true,
             //           Values = bloodGroupsDicValues,
             //           Branch = null,
             //           Company = _CompaniesRepo.First(),
             //           TenantId = context.TenantId
             //       });
             //   }
             //   if (!DictionaryValueTypesRepo.Any(x => x.ValueTypeName == "Religion"))
             //   {
             //       Guid guid = _guidGenerator.Create();
             //       List<DictionaryValue> religionDicValues = new List<DictionaryValue>() {
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "06001",
             //               Value = "Muslim",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "06002",
             //               Value = "Christian",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "06003",
             //               Value = "Jew",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "06004",
             //               Value = "Other",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           }
             //       };

             //       await DictionaryValueTypesRepo.InsertAsync(new DictionaryValueType(guid)
             //       {
             //           ValueTypeFor = ValueTypeModules.Religion,
             //           ValueTypeCode = "06",
             //           ValueTypeName = "Religion",
             //           ActiveStatus = true,
             //           Values = religionDicValues,
             //           Branch = null,
             //           Company = _CompaniesRepo.First(),
             //           TenantId = context.TenantId
             //       });
             //   }

             //   if (!DictionaryValueTypesRepo.Any(x => x.ValueTypeName == "ID Type"))
             //   {
             //       Guid guid = _guidGenerator.Create();

             //       List<DictionaryValue> idTypesDicValues = new List<DictionaryValue>() {
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "07001",
             //               Value = "Iqama",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "07002",
             //               Value = "Passport",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           },
             //           new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "07003",
             //               Value = "Ahwal",
             //               ActiveStatus = true,
             //               Branch = null,
             //               Company = _CompaniesRepo.First(),
             //               ValueTypeId = guid,
                //TenantId = context.TenantId
             //           }
             //       };

             //       await DictionaryValueTypesRepo.InsertAsync(new DictionaryValueType(guid)
             //       {
             //           ValueTypeFor = ValueTypeModules.IDType,
             //           ValueTypeCode = "07",
             //           ValueTypeName = "ID Type",
             //           ActiveStatus = true,
             //           Values = idTypesDicValues,
             //           Branch = null,
             //           Company = _CompaniesRepo.First(),
             //           TenantId = context.TenantId
             //       });
             //   }

             //   if (DictionaryValueTypesRepo.Count() == -1)
             //   {
             //       if (!DictionaryValuesRepo.Any(x => x.Value == "Cash Generated From Operations"))
             //       {
             //           await DictionaryValuesRepo.InsertAsync(new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "01",
             //               Value = "Cash Generated From Operations",
             //               ActiveStatus = true,
             //               ValueType = DictionaryValueTypesRepo.First(x => x.ValueTypeName == "Cashflow Statement Types"),
             //               TenantId = context.TenantId
             //           });
             //       }
             //       if (!DictionaryValuesRepo.Any(x => x.Value == "Cash Flow From Operating Activities"))
             //       {
             //           await DictionaryValuesRepo.InsertAsync(new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "01",
             //               Value = "Cash Flow From Operating Activities",
             //               ActiveStatus = true,
             //               ValueType = DictionaryValueTypesRepo.First(x => x.ValueTypeName == "Cashflow Statement Types"),
             //               TenantId = context.TenantId
             //           });
             //       }
             //       if (!DictionaryValuesRepo.Any(x => x.Value == "Cash Generated From Financing Activities"))
             //       {
             //           await DictionaryValuesRepo.InsertAsync(new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "01",
             //               Value = "Cash Generated From Financing Activities",
             //               ActiveStatus = true,
             //               ValueType = DictionaryValueTypesRepo.First(x => x.ValueTypeName == "Cashflow Statement Types"),
             //               TenantId = context.TenantId
             //           });
             //       }
             //       if (!DictionaryValuesRepo.Any(x => x.Value == "Net Profit Before Tax"))
             //       {
             //           await DictionaryValuesRepo.InsertAsync(new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "01",
             //               Value = "Net Profit Before Tax",
             //               ActiveStatus = true,
             //               ValueType = DictionaryValueTypesRepo.First(x => x.ValueTypeName == "Cashflow Statement Types"),
             //               TenantId = context.TenantId
             //           });
             //       }
             //       if (!DictionaryValuesRepo.Any(x => x.Value == "Operating Profit Before Working Capital"))
             //       {
             //           await DictionaryValuesRepo.InsertAsync(new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "01",
             //               Value = "Operating Profit Before Working Capital",
             //               ActiveStatus = true,
             //               ValueType = DictionaryValueTypesRepo.First(x => x.ValueTypeName == "Cashflow Statement Types"),
             //               TenantId = context.TenantId
             //           });
             //       }
             //       if (!DictionaryValuesRepo.Any(x => x.Value == "Cash and Cash Equivalents"))
             //       {
             //           await DictionaryValuesRepo.InsertAsync(new DictionaryValue(_guidGenerator.Create())
             //           {
             //               Key = "01",
             //               Value = "Cash and Cash Equivalents",
             //               ActiveStatus = true,
             //               ValueType = DictionaryValueTypesRepo.First(x => x.ValueTypeName == "Cashflow Statement Types"),
             //               TenantId = context.TenantId
             //           });
             //       }
             //   }
            }
        }
    }
}