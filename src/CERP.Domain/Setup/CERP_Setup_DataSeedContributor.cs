using CERP.FM;
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
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;
using Volo.Abp.Uow;

namespace CERP.App
{
    public class CERP_Setup_DataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private ITenantRepository TenantRepo;
        private ICurrentTenant CurrentTenant;
        private IRepository<Department, Guid> _DepartmentsRepo;
        private IRepository<Company, Guid> _CompaniesRepo;
        private readonly IGuidGenerator _guidGenerator;

        public CERP_Setup_DataSeedContributor(IGuidGenerator guidGenerator, IRepository<Department, Guid> departmentsRepo, IRepository<Company, Guid> companiesRepo, ITenantRepository tenantRepo, ICurrentTenant currentTenant)
        {
            _guidGenerator = guidGenerator;
            _DepartmentsRepo = departmentsRepo;
            _CompaniesRepo = companiesRepo;
            TenantRepo = tenantRepo;
            CurrentTenant = currentTenant;
        }

        [UnitOfWork]
        public async Task SeedAsync(DataSeedContext context)
        {
            var curTenants = await TenantRepo.GetListAsync();
            if (curTenants.Any(x => x.Name == "PIF"))
            {
                for (int i = 0; i < curTenants.Count; i++)
                {
                    using (CurrentTenant.Change(curTenants[i].Id, curTenants[i].Name))
                    {
                        var curCompanies = await _CompaniesRepo.GetListAsync();
                        var curDepartments = await _DepartmentsRepo.GetListAsync();
                        try
                        {
                            if (curCompanies.Any(x => x.Name == "TestCorp"))
                            {
                                if (!curDepartments.Any(x => x.Name == "Admin"))
                                {
                                    Guid departmentId = _guidGenerator.Create();
                                    List<Position> adminPositions = new List<Position>() {
                            new Position(_guidGenerator.Create()){ TenantId = CurrentTenant.Id, Title = "Administrator", DepartmentId = departmentId },
                            new Position(_guidGenerator.Create()){ TenantId = CurrentTenant.Id, Title = "Manager", DepartmentId = departmentId },
                            new Position(_guidGenerator.Create()){ TenantId = CurrentTenant.Id, Title = "Assistant Manager", DepartmentId = departmentId }
                        };
                                    Department adminDepartment = new Department(departmentId)
                                    {
		        TenantId = CurrentTenant.Id,
                                        Name = "Admin",
                                        Company = curCompanies.First(x => x.Name == "TestCorp"),
                                        Positions = adminPositions
                                    };

                                    await _DepartmentsRepo.InsertAsync(adminDepartment);
                                }
                                if (!curDepartments.Any(x => x.Name == "Audit and Advisory Services"))
                                {
                                    Guid departmentId = _guidGenerator.Create();
                                    List<Position> positions = new List<Position>() {
                            new Position(_guidGenerator.Create()){ TenantId = CurrentTenant.Id, Title = "Manager", DepartmentId = departmentId },
                            new Position(_guidGenerator.Create()){ TenantId = CurrentTenant.Id, Title = "Assistant Manager", DepartmentId = departmentId }
                        };
                                    Department department = new Department(departmentId)
                                    {
		        TenantId = CurrentTenant.Id,
                                        Name = "Audit and Advisory Services",
                                        Company = curCompanies.First(x => x.Name == "TestCorp"),
                                        Positions = positions
                                    };

                                    await _DepartmentsRepo.InsertAsync(department);
                                }
                                if (!curDepartments.Any(x => x.Name == "IT"))
                                {
                                    Guid departmentId = _guidGenerator.Create();
                                    List<Position> positions = new List<Position>() {
                            new Position(_guidGenerator.Create()){ TenantId = CurrentTenant.Id, Title = "IT Manager", DepartmentId = departmentId },
                            new Position(_guidGenerator.Create()){ TenantId = CurrentTenant.Id, Title = "Manager", DepartmentId = departmentId },
                            new Position(_guidGenerator.Create()){ TenantId = CurrentTenant.Id, Title = "Assistant Manager", DepartmentId = departmentId }
                        };
                                    Department department = new Department(departmentId)
                                    {
		        TenantId = CurrentTenant.Id,
                                        Name = "IT",
                                        Company = curCompanies.First(x => x.Name == "TestCorp"),
                                        Positions = positions
                                    };

                                    await _DepartmentsRepo.InsertAsync(department);
                                }
                                if (!curDepartments.Any(x => x.Name == "Corporate"))
                                {
                                    Guid departmentId = _guidGenerator.Create();
                                    List<Position> positions = new List<Position>() {
                            new Position(_guidGenerator.Create()){ TenantId = CurrentTenant.Id, Title = "CEO", DepartmentId = departmentId },
                            new Position(_guidGenerator.Create()){ TenantId = CurrentTenant.Id, Title = "CTO", DepartmentId = departmentId },
                            new Position(_guidGenerator.Create()){ TenantId = CurrentTenant.Id, Title = "CFO", DepartmentId = departmentId }
                        };
                                    Department department = new Department(departmentId)
                                    {
		        TenantId = CurrentTenant.Id,
                                        Name = "Corporate",
                                        Company = curCompanies.First(x => x.Name == "TestCorp"),
                                        Positions = positions
                                    };

                                    await _DepartmentsRepo.InsertAsync(department);
                                }
                                if (!curDepartments.Any(x => x.Name == "Tax / Zakat Service"))
                                {
                                    Guid departmentId = _guidGenerator.Create();
                                    List<Position> positions = new List<Position>() {
                            new Position(_guidGenerator.Create()){ TenantId = CurrentTenant.Id, Title = "Manager", DepartmentId = departmentId },
                            new Position(_guidGenerator.Create()){ TenantId = CurrentTenant.Id, Title = "Assistant Manager", DepartmentId = departmentId }
                        };
                                    Department department = new Department(departmentId)
                                    {
		        TenantId = CurrentTenant.Id,
                                        Name = "Tax / Zakat Service",
                                        Company = curCompanies.First(x => x.Name == "TestCorp"),
                                        Positions = positions
                                    };

                                    await _DepartmentsRepo.InsertAsync(department);
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
        }
    }
}
