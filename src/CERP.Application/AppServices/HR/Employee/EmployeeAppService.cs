using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using CERP.HR.Employees;
using Volo.Abp.Application.Dtos;
using CERP.HR.Employees.DTOs;
using CERP.HR.Employees.UV_DTOs;
using System.Threading.Tasks;
using System.Linq;

namespace CERP.AppServices.HR.EmployeeService
{
    public class EmployeeAppService : CrudAppService<Employee, Employee_Dto, Guid, PagedAndSortedResultRequestDto, Employee_UV_Dto, Employee_UV_Dto>
    {
        public EmployeeAppService(IRepository<Employee, Guid> repository) : base(repository)
        {
            Repository = repository;
        }

        public IRepository<Employee, Guid> Repository { get; }

        public async Task<Employee_Dto> CreateEmployee(Employee_UV_Dto employeee)
        {
            try
            {
                Employee employee = MapToEntity(employeee);

                Employee_Dto dto = MapToGetOutputDto(await Repository.InsertAsync(employee));
                return dto;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public List<Employee_Dto> GetAllEmployees(Func<Employee, bool> Selector = null)
        {
            var result = Repository.WithDetails().Where(Selector ?? new Func<Employee, bool>(x => true));
            return result.Select(MapToGetListOutputDto).ToList();
        }
    }
}
