using CERP.Setup;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP.AppServices.Setup.LocationSetup
{
    public class LocationTemplateAppService : CrudAppService<LocationTemplate, LocationTemplate_Dto, Guid, PagedAndSortedResultRequestDto, LocationTemplate_Dto, LocationTemplate_Dto>
    {
        public LocationTemplateAppService(IRepository<LocationTemplate, Guid> repository) : base(repository)
        {
            Repository = repository;
        }

        public List<LocationTemplate_Dto> GetAllLocations()
        {
            return Repository.WithDetails().Select(MapToGetListOutputDto).ToList();
        }

        public IRepository<LocationTemplate, Guid> Repository { get; }
    }
}
