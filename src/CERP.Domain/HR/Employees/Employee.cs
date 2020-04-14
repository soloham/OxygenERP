using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.FM;
using CERP.HR.Workshifts;
using CERP.Setup;
using CERP.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace CERP.HR.Employees
{
    [DisableAuditing]
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
        [CustomAudited]
        public string FirstName { get; set; }
        [CustomAudited]
        public string FirstNameLocalized { get; set; }
        [CustomAudited]
        public string MiddleName { get; set; }
        [CustomAudited]
        public string MiddleNameLocalized { get; set; }
        [CustomAudited]
        public string LastName { get; set; }
        [CustomAudited]
        public string LastNameLocalized { get; set; }
        [CustomAudited]
        public string FamilyName { get; set; }
        [CustomAudited]
        public string FamilyNameLocalized { get; set; }
        [CustomAudited]
        public string DOB { get; set; }
        [CustomAudited]
        public string DOB_H { get; set; }


        [ForeignKey("POB_ID")]
        public DictionaryValue POB { get; set; }
        [CustomAudited]
        public Guid POB_ID { get; set; }

        [ForeignKey("NationalityId")]
        public DictionaryValue Nationality { get; set; }
        [CustomAudited]
        public Guid NationalityId { get; set; }

        [ForeignKey("GenderId")]
        public DictionaryValue Gender { get; set; }
        [CustomAudited]
        public Guid GenderId { get; set; }

        [ForeignKey("MaritalStatusId")]
        public DictionaryValue MaritalStatus { get; set; }
        [CustomAudited]
        public Guid MaritalStatusId { get; set; }
        [CustomAudited]
        public int NoOfDependents { get; set; }

        [ForeignKey("BloodGroupId")]
        public DictionaryValue? BloodGroup { get; set; }
        [CustomAudited]
        public Guid? BloodGroupId { get; set; }

        [ForeignKey("ReligionId")]
        public DictionaryValue Religion { get; set; }
        [CustomAudited]
        public Guid ReligionId { get; set; }

        [ForeignKey("EmployeeTypeId")]
        public DictionaryValue EmployeeType { get; set; }
        [CustomAudited]
        public Guid EmployeeTypeId { get; set; }
        #endregion

        #region ID & Residence
        [CustomAudited]
        public string SocialInsuranceId { get; set; }

        [ForeignKey("SITypeId")]
        public DictionaryValue SIType { get; set; }
        [CustomAudited]
        public Guid? SITypeId { get; set; }

        [ForeignKey("IndemnityTypeId")]
        public DictionaryValue IndemnityType { get; set; }
        [CustomAudited]
        public Guid? IndemnityTypeId { get; set; }
        #endregion

        #region Contract Details
        [CustomAudited]
        public string JoiningDate { get; set; }
        [CustomAudited]
        public string JoiningHDate { get; set; }
        [CustomAudited]
        public string ContractStartDate { get; set; }
        [CustomAudited]
        public string ContractStartHDate { get; set; }
        [CustomAudited]
        public string ContractEndDate { get; set; }
        [CustomAudited]
        public string ContractEndHDate { get; set; }
        [CustomAudited]
        public int VacationDays { get; set; }
        [ForeignKey("ContractStatusId")]
        public DictionaryValue ContractStatus { get; set; }
        [CustomAudited]
        public Guid ContractStatusId { get; set; }
        [ForeignKey("ContractTypeId")]
        public DictionaryValue ContractType { get; set; }
        [CustomAudited]
        public Guid ContractTypeId { get; set; }
        [ForeignKey("EmployeeStatusId")]
        public DictionaryValue EmployeeStatus { get; set; }
        [CustomAudited]
        public Guid EmployeeStatusId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        [CustomAudited]
        public Guid DepartmentId { get; set; }
        [ForeignKey("PositionId")]
        public Position Position { get; set; }
        [CustomAudited]
        public Guid PositionId { get; set; }
        [ForeignKey("ReportingToId")]
        public Employee? ReportingTo { get; set; }
        [CustomAudited]
        public Guid? ReportingToId { get; set; }
        #endregion

        #region Workshifts
        [ForeignKey("WorkShiftId")]
        public WorkShift WorkShift { get; set; }
        [CustomAudited]
        public int WorkShiftId { get; set; }

        #endregion
        [CustomAudited]
        public string ProfilePic { get; set; }

        [ForeignKey("PortalId")]
        public virtual AppUser Portal { get; set; }
        [CustomAudited]
        public Guid? PortalId { get; set; }

        public void UpdateExtraProperties(IDictionary<string, object> extraProperties)
        {
            ExtraProperties = (Dictionary<string, object>)extraProperties;
        }
    }
}
