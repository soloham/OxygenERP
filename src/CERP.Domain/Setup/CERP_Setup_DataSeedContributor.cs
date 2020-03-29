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
using Volo.Abp.Uow;

namespace CERP.App
{
    public class CERP_Setup_DataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private IRepository<Department, Guid> _DepartmentsRepo;
        private IRepository<Company, Guid> _CompaniesRepo;
        private readonly IGuidGenerator _guidGenerator;

        public CERP_Setup_DataSeedContributor(IGuidGenerator guidGenerator, IRepository<Department, Guid> departmentsRepo, IRepository<Company, Guid> companiesRepo)
        {
            _guidGenerator = guidGenerator;
            _DepartmentsRepo = departmentsRepo;
            _CompaniesRepo = companiesRepo;
        }

        [UnitOfWork]
        public async Task SeedAsync(DataSeedContext context)
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
                            new Position(_guidGenerator.Create()){ Title = "Administrator", DepartmentId = departmentId, TenantId = context.TenantId },
                            new Position(_guidGenerator.Create()){ Title = "Manager", DepartmentId = departmentId, TenantId = context.TenantId },
                            new Position(_guidGenerator.Create()){ Title = "Assistant Manager", DepartmentId = departmentId, TenantId = context.TenantId },
                        };
                        Department adminDepartment = new Department(departmentId)
                        {
                            Name = "Admin",
                            Company = curCompanies.First(x => x.Name == "TestCorp"),
                            Positions = adminPositions,
                            TenantId = context.TenantId
                        };

                        await _DepartmentsRepo.InsertAsync(adminDepartment);
                    }
                    if (!curDepartments.Any(x => x.Name == "Audit and Advisory Services"))
                    {
                        Guid departmentId = _guidGenerator.Create();
                        List<Position> positions = new List<Position>() {
                            new Position(_guidGenerator.Create()){ Title = "Manager", DepartmentId = departmentId, TenantId = context.TenantId },
                            new Position(_guidGenerator.Create()){ Title = "Assistant Manager", DepartmentId = departmentId, TenantId = context.TenantId },
                        };
                        Department department = new Department(departmentId)
                        {
                            Name = "Audit and Advisory Services",
                            Company = curCompanies.First(x => x.Name == "TestCorp"),
                            Positions = positions,
                            TenantId = context.TenantId
                        };

                        await _DepartmentsRepo.InsertAsync(department);
                    }
                    if (!curDepartments.Any(x => x.Name == "IT"))
                    {
                        Guid departmentId = _guidGenerator.Create();
                        List<Position> positions = new List<Position>() {
                            new Position(_guidGenerator.Create()){ Title = "IT Manager", DepartmentId = departmentId, TenantId = context.TenantId },
                            new Position(_guidGenerator.Create()){ Title = "Manager", DepartmentId = departmentId, TenantId = context.TenantId },
                            new Position(_guidGenerator.Create()){ Title = "Assistant Manager", DepartmentId = departmentId, TenantId = context.TenantId },
                        };
                        Department department = new Department(departmentId)
                        {
                            Name = "IT",
                            Company = curCompanies.First(x => x.Name == "TestCorp"),
                            Positions = positions,
                            TenantId = context.TenantId
                        };

                        await _DepartmentsRepo.InsertAsync(department);
                    }
                    if (!curDepartments.Any(x => x.Name == "Corporate"))
                    {
                        Guid departmentId = _guidGenerator.Create();
                        List<Position> positions = new List<Position>() {
                            new Position(_guidGenerator.Create()){ Title = "CEO", DepartmentId = departmentId, TenantId = context.TenantId },
                            new Position(_guidGenerator.Create()){ Title = "CTO", DepartmentId = departmentId, TenantId = context.TenantId },
                            new Position(_guidGenerator.Create()){ Title = "CFO", DepartmentId = departmentId, TenantId = context.TenantId }
                        };
                        Department department = new Department(departmentId)
                        {
                            Name = "Corporate",
                            Company = curCompanies.First(x => x.Name == "TestCorp"),
                            Positions = positions,
                            TenantId = context.TenantId
                        };

                        await _DepartmentsRepo.InsertAsync(department);
                    }
                    if (!curDepartments.Any(x => x.Name == "Tax / Zakat Service"))
                    {
                        Guid departmentId = _guidGenerator.Create();
                        List<Position> positions = new List<Position>() {
                            new Position(_guidGenerator.Create()){ Title = "Manager", DepartmentId = departmentId, TenantId = context.TenantId },
                            new Position(_guidGenerator.Create()){ Title = "Assistant Manager", DepartmentId = departmentId, TenantId = context.TenantId },
                        };
                        Department department = new Department(departmentId)
                        {
                            Name = "Tax / Zakat Service",
                            Company = curCompanies.First(x => x.Name == "TestCorp"),
                            Positions = positions,
                            TenantId = context.TenantId,
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