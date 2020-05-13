using CERP.App;
using CERP.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CERP.HR.Employees
{
    public class PhysicalID : AuditedAggregateTenantRoot<int>
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
