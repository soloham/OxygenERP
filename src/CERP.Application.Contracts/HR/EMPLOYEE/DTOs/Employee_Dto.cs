using CERP.App;
using CERP.Base;
using CERP.FM.DTOs;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace CERP.HR.Employees.DTOs
{
    public class Employee_Dto : FullAuditedEntityTenantDto<Guid>
    {
        public Employee_Dto()
        {

        }
        public Employee_Dto(Guid guid)
        {
            Id = guid;
        }

        public string GetReferenceId { get => Id.ToString().Substring(0, 4); }

        #region General Info
        public string Name { get => FirstName + " " + LastName; }
        public string FirstName { get; set; }
        public string FirstNameLocalized { get; set; }
        public string MiddleName { get; set; }
        public string MiddleNameLocalized { get; set; }
        public string LastName { get; set; }
        public string LastNameLocalized { get; set; }
        public string FamilyName { get; set; }
        public string FamilyNameLocalized { get; set; }

        public string DOB { get; set; }
        public string DOB_H { get; set; }

        public DictionaryValue_Dto POB { get; set; }
        public Guid POB_ID { get; set; }

        public DictionaryValue_Dto Nationality { get; set; }
        public Guid NationalityId { get; set; }

        public DictionaryValue_Dto Gender { get; set; }
        public Guid GenderId { get; set; }

        public DictionaryValue_Dto MaritalStatus { get; set; }
        public Guid MaritalStatusId { get; set; }

        public int NoOfDependents { get; set; }

        public DictionaryValue_Dto? BloodGroup { get; set; }
        public Guid? BloodGroupId { get; set; }

        public DictionaryValue_Dto Religion { get; set; }
        public Guid ReligionId { get; set; }

        public DictionaryValue_Dto EmployeeType { get; set; }
        public Guid EmployeeTypeId { get; set; }
        #endregion


        #region ID & Residence
        public string SocialInsuranceId { get; set; }

        #endregion

        #region Contract Details
        public string JoiningDate { get; set; }
        public string JoiningHDate { get; set; }
        public string ContractStartDate { get; set; }
        public string ContractStartHDate { get; set; }
        public string ContractEndDate { get; set; }
        public string ContractEndHDate { get; set; }
        public int VacationDays { get; set; }
        public DictionaryValue_Dto ContractStatus { get; set; }
        public Guid ContractStatusId { get; set; }
        public DictionaryValue_Dto ContractType { get; set; }
        public Guid ContractTypeId { get; set; }
        public DictionaryValue_Dto EmployeeStatus { get; set; }
        public Guid EmployeeStatusId { get; set; }
        public Department_Dto Department { get; set; }
        public Guid DepartmentId { get; set; }
        public Position_Dto Position { get; set; }
        public Guid PositionId { get; set; }
        public Employee_Dto? ReportingTo { get; set; }
        public Guid? ReportingToId { get; set; }
        #endregion

        #region Workshifts
        public WorkShift_Dto WorkShift { get; set; }
        public int WorkShiftId { get; set; }
        #endregion

        public string ProfilePic { get; set; }

        public IDictionary<string, object> ExtraProperties { get; set; }
    }
}
