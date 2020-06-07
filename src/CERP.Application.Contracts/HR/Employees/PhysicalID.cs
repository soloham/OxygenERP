using CERP.App;
using CERP.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CERP.HR.EmployeeCentral.DTOs.Employee
{
    public class PhysicalID_Dto : AuditedEntityTenantDto<int>
    {
        public PhysicalID_Dto()
        {
        }

        [ForeignKey("IDTypeId")]
        public DictionaryValue_Dto IDType { get; set; }
        public Guid? IDTypeId { get; set; }
        public string IDNumber { get; set; }

        [ForeignKey("IssuedFromId")]
        public DictionaryValue_Dto IssuedFrom { get; set; }
        public Guid IssuedFromId { get; set; }
        public string JobTitle { get; set; }
        public string Sponsor { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime EndDate { get; set; }
        public string IDCopy { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee_Dto Employee { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
