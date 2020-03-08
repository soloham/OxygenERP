using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;
using CERP.Setup;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using System.Threading.Tasks;
using System.Linq;

namespace CERP.AppServices.Setup.DepartmentSetup
{
    public class DepartmentAppService : CrudAppService<Department, Department_Dto, Guid, PagedAndSortedResultRequestDto, Department_UV_Dto, Department_UV_Dto>
    {
        public DepartmentAppService(IRepository<Department, Guid> repository) : base(repository)
        {

        }

        public List<Department_Dto> GetDepartments()
        {
            return Repository.WithDetails().Select(MapToGetOutputDto).ToList();
        }
    }
}
