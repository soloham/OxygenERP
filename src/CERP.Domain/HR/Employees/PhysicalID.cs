using CERP.App;
using CERP.HR.Employee.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.HR.Employees
{
    public class PhysicalID : AuditedAggregateRoot<int>
    {
        public PhysicalID()
        {
        }

        [ForeignKey("IDTypeId")]
        public DictionaryValue IDType { get; set; }
        public Guid? IDTypeId { get; set; }
        public string IDNumber { get; set; }

        [ForeignKey("IssuedFromId")]
        public DictionaryValue IssuedFrom { get; set; }
        public Guid IssuedFromId { get; set; }
        public string JobTitle { get; set; }
        public string Sponsor { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime EndDate { get; set; }
        public string IDCopy { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
