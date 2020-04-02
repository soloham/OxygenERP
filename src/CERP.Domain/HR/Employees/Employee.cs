using CERP.App;
using CERP.Base;
using CERP.FM;
using CERP.HR.Workshifts;
using CERP.Setup;
using CERP.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace CERP.HR.Employees
{
    public class Employee : FullAuditedAggregateTenantRoot<Guid>
    {
        public Employee()
        {

        }
        public Employee(Guid guid)
        {
            Id = guid;
        }
        [NotMapped]
        public string GetReferenceId { get => Id.ToString().Substring(0, 4); }

        #region General Info
        [NotMapped]
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


        [ForeignKey("POB_ID")]
        public DictionaryValue POB { get; set; }
        public Guid POB_ID { get; set; }

        [ForeignKey("NationalityId")]
        public DictionaryValue Nationality { get; set; }
        public Guid NationalityId { get; set; }

        [ForeignKey("GenderId")]
        public DictionaryValue Gender { get; set; }
        public Guid GenderId { get; set; }

        [ForeignKey("MaritalStatusId")]
        public DictionaryValue MaritalStatus { get; set; }
        public Guid MaritalStatusId { get; set; }

        public int NoOfDependents { get; set; }

        [ForeignKey("BloodGroupId")]
        public DictionaryValue? BloodGroup { get; set; }
        public Guid? BloodGroupId { get; set; }

        [ForeignKey("ReligionId")]
        public DictionaryValue Religion { get; set; }
        public Guid ReligionId { get; set; }

        [ForeignKey("EmployeeTypeId")]
        public DictionaryValue EmployeeType { get; set; }
        public Guid EmployeeTypeId { get; set; }
        #endregion

        #region ID & Residence
        public string SocialInsuranceId { get; set; }

        [ForeignKey("SITypeId")]
        public DictionaryValue SIType { get; set; }
        public Guid? SITypeId { get; set; }

        [ForeignKey("IndemnityTypeId")]
        public DictionaryValue IndemnityType { get; set; }
        public Guid? IndemnityTypeId { get; set; }
        #endregion

        #region Contract Details
        public string JoiningDate { get; set; }
        public string JoiningHDate { get; set; }
        public string ContractStartDate { get; set; }
        public string ContractStartHDate { get; set; }
        public string ContractEndDate { get; set; }
        public string ContractEndHDate { get; set; }
        public int VacationDays { get; set; }
        [ForeignKey("ContractStatusId")]
        public DictionaryValue ContractStatus { get; set; }
        public Guid ContractStatusId { get; set; }
        [ForeignKey("ContractTypeId")]
        public DictionaryValue ContractType { get; set; }
        public Guid ContractTypeId { get; set; }
        [ForeignKey("EmployeeStatusId")]
        public DictionaryValue EmployeeStatus { get; set; }
        public Guid EmployeeStatusId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public Guid DepartmentId { get; set; }
        [ForeignKey("PositionId")]
        public Position Position { get; set; }
        public Guid PositionId { get; set; }
        [ForeignKey("ReportingToId")]
        public Employee? ReportingTo { get; set; }
        public Guid? ReportingToId { get; set; }
        #endregion

        #region Workshifts
        [ForeignKey("WorkShiftId")]
        public WorkShift WorkShift { get; set; }
        public int WorkShiftId { get; set; }

        #endregion

        public string ProfilePic { get; set; }

        [ForeignKey("PortalId")]
        public AppUser Portal { get; set; }
        public Guid? PortalId { get; set; }

        public void UpdateExtraProperties(IDictionary<string, object> extraProperties)
        {
            ExtraProperties = (Dictionary<string, object>)extraProperties;
        }
    }
}
