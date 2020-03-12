using CERP.CERP.HR.Documents;
using CERP.FM;
using CERP.FM.COA;
using CERP.FM.DTOs;
using CERP.FM.UV_DTOs;
using CERP.HR.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP.AppServices.HR.DepartmentService
{
    public class documentAppService : CrudAppService<Document, Document_Dto, Guid, PagedAndSortedResultRequestDto, Document_Dto, Document_Dto>
    {
        public documentAppService(IRepository<Document, Guid> repository) : base(repository)
        {
            Repository = repository;
        }

        public IRepository<Document, Guid> Repository { get; }

        public List<Document_Dto> GetAllDocuments()
        {
            return Repository.WithDetails().Select(MapToGetListOutputDto).ToList();
        }
    }
}
