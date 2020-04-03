using CERP.App;
using CERP.Base;
using CERP.FM.DTOs;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.HR.Employees.UV_DTOs
{
    public class Employee_UV_Dto : FullAuditedEntityTenantDto<Guid>
    {
        public Employee_UV_Dto()
        {

        }
        public Employee_UV_Dto(Guid guid)
        {
            Id = guid;
        }

        #region General Info
        [Required]
        public string FirstName { get; set; }
        public string FirstNameLocalized { get; set; }
        [Required]
        public string MiddleName { get; set; }
        public string MiddleNameLocalized { get; set; }
        [Required]
        public string LastName { get; set; }
        public string LastNameLocalized { get; set; }
        public string FamilyName { get; set; }
        public string FamilyNameLocalized { get; set; }

        [Required]
        public string DOB { get; set; }
        public string DOB_H { get; set; }

        public DictionaryValue_Dto POB { get; set; }
        [Required]
        public Guid POB_ID { get; set; }

        public DictionaryValue_Dto Nationality { get; set; }
        [Required]
        public Guid NationalityId { get; set; }

        public DictionaryValue_Dto Gender { get; set; }
        [Required]
        public Guid GenderId { get; set; }

        public DictionaryValue_Dto MaritalStatus { get; set; }
        [Required]
        public Guid MaritalStatusId { get; set; }

        [Required]
        public int NoOfDependents { get; set; }

        public DictionaryValue_Dto? BloodGroup { get; set; }
        public Guid? BloodGroupId { get; set; }

        public DictionaryValue_Dto Religion { get; set; }
        [Required]
        public Guid ReligionId { get; set; }

        public DictionaryValue_Dto EmployeeType { get; set; }
        [Required]
        public Guid EmployeeTypeId { get; set; }
        #endregion

        #region ID & Residence
        #endregion

        #region Contract Details
        [Required]
        public string JoiningDate { get; set; }
        public string JoiningHDate { get; set; }
        [Required]
        public string ContractStartDate { get; set; }
        public string ContractStartHDate { get; set; }
        [Required]
        public string ContractEndDate { get; set; }
        public string ContractEndHDate { get; set; }
        [Required]
        public int VacationDays { get; set; }
        public DictionaryValue_Dto ContractStatus { get; set; }
        [Required]
        public Guid ContractStatusId { get; set; }
        public DictionaryValue_Dto ContractType { get; set; }
        [Required]
        public Guid ContractTypeId { get; set; }
        public DictionaryValue_Dto EmployeeStatus { get; set; }
        [Required]
        public Guid EmployeeStatusId { get; set; }
        public Department_Dto Department { get; set; }
        [Required]
        public Guid DepartmentId { get; set; }
        public Position_Dto Position { get; set; }
        [Required]
        public Guid PositionId { get; set; }
        public Employee_UV_Dto? ReportingTo { get; set; }
        public Guid? ReportingToId { get; set; }
        #endregion

        #region Workshifts
        public WorkShift_Dto WorkShift { get; set; }
        [Required]
        public int WorkShiftId { get; set; }
        #endregion

        [Required]
        public string ProfilePic { get; set; }
        public Guid? PortalId { get; set; }

        public string GetReferenceId { get => Id.ToString().Substring(0, 4); }

        public IDictionary<string, object> ExtraProperties { get; set; } = new Dictionary<string, object>();
    }
}
