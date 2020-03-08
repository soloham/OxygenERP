using CERP.HR.Employees.DTOs;
using System;
using Volo.Abp.Application.Dtos;

namespace CERP.Setup.DTOs
{

    public class Position_Dto : AuditedEntityDto<Guid>
    {
        public Position_Dto()
        {

        }
        public Position_Dto(Guid id)
        {
            Id = id;
        }

        public Department_Dto Department { get; set; }
        public Guid DepartmentId { get; set; }

        public string Title { get; set; }

        public Employee_Dto? Employee { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}