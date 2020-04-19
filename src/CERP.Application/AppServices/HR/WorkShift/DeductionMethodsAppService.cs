using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.Workshift.DTOs;
using CERP.HR.Workshifts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP.AppServices.HR.WorkShiftService
{
    public class DeductionMethodsAppService : CrudAppService<DeductionMethod, DeductionMethod_Dto, int, PagedAndSortedResultRequestDto, DeductionMethod_Dto, DeductionMethod_Dto>
    {
        public DeductionMethodsAppService(IRepository<DeductionMethod, int> repository) : base(repository)
        {
            Repository = repository;
        }

        public IRepository<DeductionMethod, int> Repository { get; }

        [Route("/getAllDeductionMethods")]
        public List<DeductionMethod_Dto> GetAll()
        {
            return ObjectMapper.Map<List<DeductionMethod>, List<DeductionMethod_Dto>>(Repository.ToList());
        }
    }
}
