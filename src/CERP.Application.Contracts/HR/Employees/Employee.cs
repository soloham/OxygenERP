using CERP.App;
using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure;
using CERP.Attributes;
using CERP.Base;
using CERP.HR.Documents;
using CERP.Setup;
using CERP.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Auditing;

namespace CERP.HR.EmployeeCentral.DTOs.Employee
{
    [DisableAuditing]
    public class Employee_Dto : FullAuditedEntityTenantDto<Guid>
    {
        public Employee_Dto()
        {

        }
        public Employee_Dto(Guid guid)
        {
            Id = guid;
        }
        [NotMapped]
        public string GetReferenceId { get => Id.ToString().Substring(0, 4); }

        #region Personal Information

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
        public string Initials { get; set; }
        [CustomAudited]
        public string PreferredName { get; set; }
        [CustomAudited]
        public string DisplayName { get; set; }

        public DictionaryValue_Dto Gender { get; set; }
        [CustomAudited]
        public Guid GenderId { get; set; }
        public DictionaryValue_Dto MaritalStatus { get; set; }
        [CustomAudited]
        public Guid MaritalStatusId { get; set; }
        [CustomAudited]
        public string MarriedSince { get; set; }
        public DictionaryValue_Dto PreferredLanguage { get; set; }
        [CustomAudited]
        public Guid PreferredLanguageId { get; set; }
        public DictionaryValue_Dto Nationality { get; set; }
        [CustomAudited]
        public Guid NationalityId { get; set; }
        #endregion

        #region Bio Info
        [CustomAudited]
        public string DateOfBirth { get; set; }

        public DictionaryValue_Dto BirthCountry { get; set; }
        [CustomAudited]
        public Guid BirthCountryId { get; set; }
        [CustomAudited]
        public string PlaceOfBirth { get; set; }
        [CustomAudited]
        public string BioAttachment { get; set; }
        #endregion

        #region Identity Info
        public virtual ICollection<EmployeeNationalIdentity_Dto> NationalIdentities { get; set; }
        public virtual ICollection<EmployeePassportTravelDocument_Dto> PassportTravelDocuments { get; set; }
        #endregion

        #region Contact Info
        public virtual ICollection<EmployeeEmailAddress_Dto> EmailAddresses { get; set; }
        public virtual ICollection<EmployeePhoneAddress_Dto> PhoneAddresses { get; set; }
        public virtual ICollection<EmployeeHomeAddress_Dto> HomeAddresses { get; set; }
        public virtual ICollection<EmployeeContact_Dto> Contacts { get; set; }
        #endregion

        #region Dependants Info
        public virtual ICollection<Dependant_Dto> Dependants { get; set; }
        #endregion

        #endregion

        #region Employment Info

        #region Organization Info
        public OS_OrganizationStructureTemplateDepartment_Dto Department { get; set; }
        [CustomAudited]
        public int DeparmentId { get; set; }

        //public DictionaryValue_Dto Timezone { get; set; }
        //[CustomAudited]
        //public Guid TimezoneId { get; set; }

        public DictionaryValue_Dto CostCenter { get; set; }
        [CustomAudited]
        public Guid CostCenterId { get; set; }
        #endregion

        #endregion

        #region Compensation Info

        #region Basic Salary Info
        public PS_PayGroup_Dto PayGroup { get; set; }
        [CustomAudited]
        public int PayGroupId { get; set; }
        public PS_PayGrade_Dto PayGrade { get; set; }
        [CustomAudited]
        public int PayGradeId { get; set; }
        #endregion

        #region Benefits Info
        public virtual ICollection<Benefit_Dto> EmployeeBenefits { get; set; }
        #endregion
        #region Payment Details
        public virtual ICollection<CashPaymentType_Dto> CashPaymentTypes { get; set; }
        public virtual ICollection<ChequePaymentType_Dto> ChequePaymentTypes { get; set; }
        public virtual ICollection<BankPaymentType_Dto> BankPaymentTypes { get; set; }
        #endregion

        #endregion

        #region Time Details

        #region General Details
        public DictionaryValue_Dto Timezone { get; set; }
        [CustomAudited]
        public Guid TimezoneId { get; set; }
        #endregion
        #region Time Offs Info
        [CustomAudited]
        public string HiringDate { get; set; }
        [CustomAudited]
        public int YearlyTimeOffAllowance { get; set; }
        #endregion

        #endregion


        #region Academia & Skills Profile

        #region Academia Profile
        public virtual ICollection<OS_AcademiaTemplate_Dto> AcademiaProfile { get; set; }
        #endregion
        #region Skills Profile
        public virtual ICollection<OS_SkillTemplate_Dto> SkillsProfile { get; set; }
        #endregion

        #endregion

        #region Loans Information

        #region Loans List
        public virtual ICollection<EmployeeLoan_Dto> EmployeeLoans { get; set; }
        #endregion

        #endregion


        [CustomAudited]
        public string ProfilePic { get; set; }

        [ForeignKey("PortalId")]
        public virtual AppUser_Dto Portal { get; set; }
        [CustomAudited]
        public Guid? PortalId { get; set; }
    }

    public class EmployeeNationalIdentity_Dto : AuditedEntityTenantDto<int>
    {
        public Employee_Dto Employee { get; set; }
        public int EmployeeId { get; set; }
        public NationalIdentity_Dto NationalIdentity { get; set; }
        public int NationalIdentityId { get; set; }
    }
    public class EmployeePassportTravelDocument_Dto : AuditedEntityTenantDto<int>
    {
        public Employee_Dto Employee { get; set; }
        public int EmployeeId { get; set; }
        public PassportTravelDocument_Dto PassportTravelDocument { get; set; }
        public int PassportTravelDocumentId { get; set; }
    }
    public class EmployeeEmailAddress_Dto : AuditedEntityTenantDto<int>
    {
        public Employee_Dto Employee { get; set; }
        public int EmployeeId { get; set; }
        public EmailAddress_Dto EmailAddress { get; set; }
        public int EmailAddressId { get; set; }
    }
    public class EmployeePhoneAddress_Dto : AuditedEntityTenantDto<int>
    {
        public Employee_Dto Employee { get; set; }
        public int EmployeeId { get; set; }
        public PhoneAddress_Dto PhoneAddress { get; set; }
        public int PhoneAddressId { get; set; }
    }
    public class EmployeeHomeAddress_Dto : AuditedEntityTenantDto<int>
    {
        public Employee_Dto Employee { get; set; }
        public int EmployeeId { get; set; }
        public HomeAddress_Dto HomeAddress { get; set; }
        public int HomeAddressId { get; set; }
    }
    public class EmployeeContact_Dto : AuditedEntityTenantDto<int>
    {
        public Employee_Dto Employee { get; set; }
        public int EmployeeId { get; set; }
        public Contact_Dto Contact { get; set; }
        public int ContactId { get; set; }
    }
}
