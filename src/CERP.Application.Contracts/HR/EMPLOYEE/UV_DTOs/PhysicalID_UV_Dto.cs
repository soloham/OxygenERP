using CERP.App;
using CERP.HR.Employee.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.HR.Employees.UV_DTOs
{
    public class PhysicalID_UV_Dto : AuditedAggregateRoot<int>
    {
        public PhysicalID_UV_Dto()
        {
        }

        public DictionaryValue_Dto IDType { get; set; }
        [Required]
        public Guid IDTypeId { get; set; }
        [Required]
        public string IDNumber { get; set; }
        public DictionaryValue_Dto IssuedFrom { get; set; }
        [Required]
        public Guid IssuedFromId { get; set; }
        [Required]
        public string JobTitle { get; set; }
        public string Sponsor { get; set; }
        [Required]
        public DateTime IssuedDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        //[Required]
        public string IDCopy { get; set; }
    }
}
