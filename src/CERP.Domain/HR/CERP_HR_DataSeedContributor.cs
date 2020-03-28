using CERP.FM;
using CERP.HR.Employees;
using CERP.HR.Workshifts;
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
    public class CERP_HR_DataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private ITenantRepository TenantRepo;
        private ICurrentTenant CurrentTenant;
        private IRepository<Department, Guid> _DepartmentsRepo;
        private IRepository<Company, Guid> _CompaniesRepo;
        private IRepository<WorkShift, int> _WorkShiftsRepo;
        private IRepository<Employee, Guid> _EmployeesRepo;
        private readonly IGuidGenerator _guidGenerator;

        public CERP_HR_DataSeedContributor(IGuidGenerator guidGenerator, IRepository<Department, Guid> departmentsRepo, IRepository<Company, Guid> companiesRepo, IRepository<WorkShift, int> workShiftsRepo, IRepository<Employee, Guid> employeesRepo, ITenantRepository tenantRepo, ICurrentTenant currentTenant)
        {
            _guidGenerator = guidGenerator;
            _DepartmentsRepo = departmentsRepo;
            _CompaniesRepo = companiesRepo;
            _WorkShiftsRepo = workShiftsRepo;
            _EmployeesRepo = employeesRepo;
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
                        var curEmployees = await _EmployeesRepo.GetListAsync();
                        try
                        {
                            if (curCompanies.Any(x => x.Name == "TestCorp"))
                            {
                                if (curDepartments.Any(x => x.Name == "Admin"))
                                {
                                    WorkShift workShift = new WorkShift()
                                    {
		        TenantId = CurrentTenant.Id,
                                        Title = "Morning",
                                        StartHour = 0900,
                                        EndHour = 1700,
                                        Department = curDepartments.First(x => x.Name == "Admin"),
                                        DepartmentId = curDepartments.First(x => x.Name == "Admin").Id
                                    };

                                    await _WorkShiftsRepo.InsertAsync(workShift);
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
