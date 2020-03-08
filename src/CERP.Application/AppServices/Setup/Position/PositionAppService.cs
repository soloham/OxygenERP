using CERP.Setup;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP.AppServices.Setup.PositionSetup
{
    public class PositionAppService : CrudAppService<Position, Position_Dto, Guid, PagedAndSortedResultRequestDto, Position_UV_Dto, Position_UV_Dto>
    {
        public PositionAppService(IRepository<Position, Guid> repository) : base(repository)
        {

        }

        public List<Position_Dto> GetPositionByDepartmentId(Guid departmentId)
        {
            return Repository.Where(x => x.DepartmentId == departmentId).Select(MapToGetListOutputDto).ToList();
        }
    }
}
