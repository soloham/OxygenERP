using CERP.App;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.HR.Leaves;
using CERP.HR.Workshift.DTOs;
using CERP.HR.Workshifts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CERP.AppServices.App.TaskService
{
    public class TaskTemplatesAppService : CrudAppService<TaskTemplate, TaskTemplate_Dto, int, PagedAndSortedResultRequestDto, TaskTemplate_Dto, TaskTemplate_Dto>
    {
        public TaskTemplatesAppService(IRepository<TaskTemplate, int> repository, IRepository<TaskTemplateItem, int> itemsRepository) : base(repository)
        {
            Repository = repository;
            ItemsRepository = itemsRepository;
        }

        public IRepository<TaskTemplate, int> Repository { get; }
        public IRepository<TaskTemplateItem, int> ItemsRepository { get; }
        public IRepository<TaskTemplateItemEmployee> EmployeesRepository { get; set; }

        public async Task<TaskTemplate_Dto> GetFull(int id)
        {
            return ObjectMapper.Map<TaskTemplate, TaskTemplate_Dto>(await Repository.GetAsync(id, true));
        }
    }
}
