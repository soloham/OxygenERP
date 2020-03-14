using CERP.App;
using CERP.HR.Employee.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CERP.HR.Employees.DTOs
{
    public class PhysicalID_Dto : AuditedEntityDto<int>
    {
        public PhysicalID_Dto()
        {
        }

        public DictionaryValue_Dto IDType { get; set; }
        public Guid IDTypeId { get; set; }
        public string IDNumber { get; set; }
        public DictionaryValue_Dto IssuedFrom { get; set; }
        public Guid IssuedFromId { get; set; }
        public string JobTitle { get; set; }
        public string Sponsor { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime EndDate { get; set; }
        public string IDCopy { get; set; }

        public Employee_Dto Employee { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
