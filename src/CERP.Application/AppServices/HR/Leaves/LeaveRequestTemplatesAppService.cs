using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.Leaves;
using CERP.HR.Workshift.DTOs;
using CERP.HR.Workshifts;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP.AppServices.HR.LeaveRequestService
{
    public class LeaveRequestTemplatesAppService : CrudAppService<LeaveRequestTemplate, LeaveRequestTemplate_Dto, int, PagedAndSortedResultRequestDto, LeaveRequestTemplate_Dto, LeaveRequestTemplate_Dto>
    {
        public LeaveRequestTemplatesAppService(IRepository<LeaveRequestTemplate, int> repository) : base(repository)
        {
            Repository = repository;
        }

        public IRepository<LeaveRequestTemplate, int> Repository { get; }
    }
}
