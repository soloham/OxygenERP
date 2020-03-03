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
                if (!DictionaryValueTypesRepo.Any(x => x.ValueTypeName == "CashflowStatementTypes"))
                {
                    List<DictionaryValue> cashflowDicValues = new List<DictionaryValue>() {
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.CashflowStatementTypesKey,
                            Value = "Cash Generated From Operations",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.CashflowStatementTypesKey,
                            Value = "Cash Flow From Operating Activities",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.CashflowStatementTypesKey,
                            Value = "Cash Generated From Financing Activities",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.CashflowStatementTypesKey,
                            Value = "Net Profit Before Tax",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.CashflowStatementTypesKey,
                            Value = "Operating Profit Before Working Capital",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                    {
                        Key = AppSettings.DicValueTypeId.CashflowStatementTypesKey,
                        Value = "Cash and Cash Equivalents",
                        ActiveStatus = true,
                        Branch = null,
                        Company = _CompaniesRepo.First()
                    }
                    };

                    await DictionaryValueTypesRepo.InsertAsync(new DictionaryValueType(_guidGenerator.Create())
                    {
                        ValueTypeCode = AppSettings.DicValueTypeId.CashflowStatementTypesKey,
                        ValueTypeName = "CashflowStatementTypes",
                        ActiveStatus = true,
                        Values = cashflowDicValues,
                        Branch = null,
                        Company = _CompaniesRepo.First()
                    });
                }
                if (!DictionaryValueTypesRepo.Any(x => x.ValueTypeName == "Nationality"))
                {
                    List<DictionaryValue> nationalityDicValues = new List<DictionaryValue>() {
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Nationality,
                            Value = "UAE",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Nationality,
                            Value = "Bahrain",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Nationality,
                            Value = "Qatar",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Nationality,
                            Value = "Saudi Arabia",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Nationality,
                            Value = "Yemen",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Nationality,
                            Value = "Syria",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        }
                    };

                    await DictionaryValueTypesRepo.InsertAsync(new DictionaryValueType(_guidGenerator.Create())
                    {
                        ValueTypeCode = AppSettings.DicValueTypeId.Nationality,
                        ValueTypeName = "Nationality",
                        ActiveStatus = true,
                        Values = nationalityDicValues,
                        Branch = null,
                        Company = _CompaniesRepo.First()
                    });
                }
                if (!DictionaryValueTypesRepo.Any(x => x.ValueTypeName == "Location"))
                {
                    List<DictionaryValue> locationsDicValues = new List<DictionaryValue>() {
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Location,
                            Value = "UAE",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Location,
                            Value = "Bahrain",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Location,
                            Value = "Qatar",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Location,
                            Value = "Saudi Arabia",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Location,
                            Value = "Yemen",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Location,
                            Value = "Syria",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Location,
                            Value = "Egypt",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Location,
                            Value = "Libya",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Location,
                            Value = "Sudan",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Location,
                            Value = "Palestine",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Location,
                            Value = "Pakistan",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Location,
                            Value = "India",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Location,
                            Value = "Lebanon",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Location,
                            Value = "Jordan",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Location,
                            Value = "Kuwait",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Location,
                            Value = "Bangladesh",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Location,
                            Value = "Philippines",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        }
                    };

                    await DictionaryValueTypesRepo.InsertAsync(new DictionaryValueType(_guidGenerator.Create())
                    {
                        ValueTypeCode = AppSettings.DicValueTypeId.Location,
                        ValueTypeName = "Location",
                        ActiveStatus = true,
                        Values = locationsDicValues,
                        Branch = null,
                        Company = _CompaniesRepo.First()
                    });
                }
                if (!DictionaryValueTypesRepo.Any(x => x.ValueTypeName == "Gender"))
                {
                    List<DictionaryValue> genderDicValues = new List<DictionaryValue>() {
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Gender,
                            Value = "Male",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Gender,
                            Value = "Female",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        }
                    };

                    await DictionaryValueTypesRepo.InsertAsync(new DictionaryValueType(_guidGenerator.Create())
                    {
                        ValueTypeCode = AppSettings.DicValueTypeId.Gender,
                        ValueTypeName = "Gender",
                        ActiveStatus = true,
                        Values = genderDicValues,
                        Branch = null,
                        Company = _CompaniesRepo.First()
                    });
                }
                if (!DictionaryValueTypesRepo.Any(x => x.ValueTypeName == "MaritalStatus"))
                {
                    List<DictionaryValue> maritalStatusDicValues = new List<DictionaryValue>() {
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.MaritalStatus,
                            Value = "Married",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.MaritalStatus,
                            Value = "Un-Married",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        }
                    };

                    await DictionaryValueTypesRepo.InsertAsync(new DictionaryValueType(_guidGenerator.Create())
                    {
                        ValueTypeCode = AppSettings.DicValueTypeId.MaritalStatus,
                        ValueTypeName = "MaritalStatus",
                        ActiveStatus = true,
                        Values = maritalStatusDicValues,
                        Branch = null,
                        Company = _CompaniesRepo.First()
                    });
                }
                if (!DictionaryValueTypesRepo.Any(x => x.ValueTypeName == "BloodGroup"))
                {
                    List<DictionaryValue> bloodGroupsDicValues = new List<DictionaryValue>() {
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.BloodGroup,
                            Value = "AB+",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.BloodGroup,
                            Value = "A-",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.BloodGroup,
                            Value = "B+",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.BloodGroup,
                            Value = "A+",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.BloodGroup,
                            Value = "O+",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.BloodGroup,
                            Value = "O-",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.BloodGroup,
                            Value = "AB-",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.BloodGroup,
                            Value = "Unknown",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        }
                    };

                    await DictionaryValueTypesRepo.InsertAsync(new DictionaryValueType(_guidGenerator.Create())
                    {
                        ValueTypeCode = AppSettings.DicValueTypeId.BloodGroup,
                        ValueTypeName = "BloodGroup",
                        ActiveStatus = true,
                        Values = bloodGroupsDicValues,
                        Branch = null,
                        Company = _CompaniesRepo.First()
                    });
                }
                if (!DictionaryValueTypesRepo.Any(x => x.ValueTypeName == "Religion"))
                {
                    List<DictionaryValue> religionDicValues = new List<DictionaryValue>() {
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Religion,
                            Value = "Muslim",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Religion,
                            Value = "Christian",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Religion,
                            Value = "Jew",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.Religion,
                            Value = "Other",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        }
                    };

                    await DictionaryValueTypesRepo.InsertAsync(new DictionaryValueType(_guidGenerator.Create())
                    {
                        ValueTypeCode = AppSettings.DicValueTypeId.Religion,
                        ValueTypeName = "Religion",
                        ActiveStatus = true,
                        Values = religionDicValues,
                        Branch = null,
                        Company = _CompaniesRepo.First()
                    });
                }

                if (!DictionaryValueTypesRepo.Any(x => x.ValueTypeName == "IDType"))
                {
                    List<DictionaryValue> idTypesDicValues = new List<DictionaryValue>() {
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.IDType,
                            Value = "Iqama",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.IDType,
                            Value = "Passport",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        },
                        new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.IDType,
                            Value = "Ahwal",
                            ActiveStatus = true,
                            Branch = null,
                            Company = _CompaniesRepo.First()
                        }
                    };

                    await DictionaryValueTypesRepo.InsertAsync(new DictionaryValueType(_guidGenerator.Create())
                    {
                        ValueTypeCode = AppSettings.DicValueTypeId.IDType,
                        ValueTypeName = "IDType",
                        ActiveStatus = true,
                        Values = idTypesDicValues,
                        Branch = null,
                        Company = _CompaniesRepo.First()
                    });
                }

                if (DictionaryValueTypesRepo.Count() == -1)
                {
                    if (!DictionaryValuesRepo.Any(x => x.Value == "Cash Generated From Operations"))
                    {
                        await DictionaryValuesRepo.InsertAsync(new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.CashflowStatementTypesKey,
                            Value = "Cash Generated From Operations",
                            ActiveStatus = true,
                            ValueType = DictionaryValueTypesRepo.First(x => x.ValueTypeName == "CashflowStatementTypes")
                        });
                    }
                    if (!DictionaryValuesRepo.Any(x => x.Value == "Cash Flow From Operating Activities"))
                    {
                        await DictionaryValuesRepo.InsertAsync(new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.CashflowStatementTypesKey,
                            Value = "Cash Flow From Operating Activities",
                            ActiveStatus = true,
                            ValueType = DictionaryValueTypesRepo.First(x => x.ValueTypeName == "CashflowStatementTypes")
                        });
                    }
                    if (!DictionaryValuesRepo.Any(x => x.Value == "Cash Generated From Financing Activities"))
                    {
                        await DictionaryValuesRepo.InsertAsync(new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.CashflowStatementTypesKey,
                            Value = "Cash Generated From Financing Activities",
                            ActiveStatus = true,
                            ValueType = DictionaryValueTypesRepo.First(x => x.ValueTypeName == "CashflowStatementTypes")
                        });
                    }
                    if (!DictionaryValuesRepo.Any(x => x.Value == "Net Profit Before Tax"))
                    {
                        await DictionaryValuesRepo.InsertAsync(new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.CashflowStatementTypesKey,
                            Value = "Net Profit Before Tax",
                            ActiveStatus = true,
                            ValueType = DictionaryValueTypesRepo.First(x => x.ValueTypeName == "CashflowStatementTypes")
                        });
                    }
                    if (!DictionaryValuesRepo.Any(x => x.Value == "Operating Profit Before Working Capital"))
                    {
                        await DictionaryValuesRepo.InsertAsync(new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.CashflowStatementTypesKey,
                            Value = "Operating Profit Before Working Capital",
                            ActiveStatus = true,
                            ValueType = DictionaryValueTypesRepo.First(x => x.ValueTypeName == "CashflowStatementTypes")
                        });
                    }
                    if (!DictionaryValuesRepo.Any(x => x.Value == "Cash and Cash Equivalents"))
                    {
                        await DictionaryValuesRepo.InsertAsync(new DictionaryValue(_guidGenerator.Create())
                        {
                            Key = AppSettings.DicValueTypeId.CashflowStatementTypesKey,
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
