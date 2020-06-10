using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.HR.Documents;
using CERP.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.OrganizationalManagement.PayrollStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Workshifts;
using CERP.Setup;
using CERP.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Auditing;

namespace CERP.HR.EmployeeCentral.Employee
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
        public DictionaryValue Title { get; set; }
        [CustomAudited]
        public Guid TitleId { get; set; }

        public DictionaryValue Gender { get; set; }
        [CustomAudited]
        public Guid GenderId { get; set; }
        public DictionaryValue MaritalStatus { get; set; }
        [CustomAudited]
        public Guid MaritalStatusId { get; set; }
        [CustomAudited]
        public string MarriedSince { get; set; }
        public DictionaryValue PreferredLanguage { get; set; }
        [CustomAudited]
        public Guid PreferredLanguageId { get; set; }
        public DictionaryValue Nationality { get; set; }
        [CustomAudited]
        public Guid NationalityId { get; set; }
        #endregion

        #region Bio Info
        [CustomAudited]
        public string DateOfBirth { get; set; }

        public DictionaryValue BirthCountry { get; set; }
        [CustomAudited]
        public Guid BirthCountryId { get; set; }
        [CustomAudited]
        public string PlaceOfBirth { get; set; }
        [CustomAudited]
        public string BioAttachment { get; set; }
        #endregion

        #region Identity Info
        public virtual ICollection<EmployeeNationalIdentity> NationalIdentities { get; set; }
        public virtual ICollection<EmployeePassportTravelDocument> PassportTravelDocuments { get; set; }
        #endregion

        #region Contact Info
        public virtual ICollection<EmployeeEmailAddress> EmailAddresses { get; set; }
        public virtual ICollection<EmployeePhoneAddress> PhoneAddresses { get; set; }
        public virtual ICollection<EmployeeHomeAddress> HomeAddresses { get; set; }
        public virtual ICollection<EmployeeContact> Contacts { get; set; }
        #endregion

        #region Dependants Info
        public virtual ICollection<Dependant> Dependants { get; set; }
        #endregion

        #endregion

        #region Employment Info

        #region Organization Info
        public OS_OrganizationStructureTemplateDepartment OrganizationStructureTemplateDepartment { get; set; }
        [CustomAudited] 
        public int DepartmentTemplateId { get; set; }
        [CustomAudited] 
        public int HeadDepartmentTemplateId { get; set; }
        [CustomAudited] 
        public int OrganizationStructureTemplateDivisionId { get; set; }
        [CustomAudited] 
        public int OrganizationStructureTemplateId { get; set; }
        [CustomAudited] 
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }
        [CustomAudited]
        public Guid LegalEntityId { get; set; }

        public DictionaryValue CostCenter { get; set; }
        [CustomAudited]
        public Guid CostCenterId { get; set; }
        #endregion

        #endregion

        #region Compensation Info

        #region Basic Salary Info
        public PS_PayGroup PayGroup { get; set; }
        [CustomAudited]
        public int PayGroupId { get; set; }
        public PS_PayGrade PayGrade { get; set; }
        [CustomAudited]
        public int PayGradeId { get; set; }
        #endregion

        #region Benefits Info
        public virtual ICollection<Benefit> EmployeeBenefits { get; set; }
        #endregion
        #region Payment Details
        public virtual ICollection<CashPaymentType> CashPaymentTypes { get; set; }
        public virtual ICollection<ChequePaymentType> ChequePaymentTypes { get; set; }
        public virtual ICollection<BankPaymentType> BankPaymentTypes { get; set; }
        #endregion

        #endregion

        #region Time Details

        #region General Details
        public DictionaryValue Timezone { get; set; }
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
        public virtual ICollection<EC_AcademiaTemplate> AcademiaProfile { get; set; }
        #endregion
        #region Skills Profile
        public virtual ICollection<EC_SkillTemplate> SkillsProfile { get; set; }
        #endregion

        #endregion

        #region Loans Information

        #region Loans List
        public virtual ICollection<EmployeeLoan> EmployeeLoans { get; set; }
        #endregion

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

    public class EmployeeNationalIdentity : AuditedAggregateTenantRoot<int>
    {
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public NationalIdentity NationalIdentity { get; set; }
        public int NationalIdentityId { get; set; }
    }
    public class EmployeePassportTravelDocument : AuditedAggregateTenantRoot<int>
    {
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public PassportTravelDocument PassportTravelDocument { get; set; }
        public int PassportTravelDocumentId { get; set; }
    }
    public class EmployeeEmailAddress : AuditedAggregateTenantRoot<int>
    {
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public EmailAddress EmailAddress { get; set; }
        public int EmailAddressId { get; set; }
    }
    public class EmployeePhoneAddress : AuditedAggregateTenantRoot<int>
    {
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public PhoneAddress PhoneAddress { get; set; }
        public int PhoneAddressId { get; set; }
    }
    public class EmployeeHomeAddress : AuditedAggregateTenantRoot<int>
    {
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public HomeAddress HomeAddress { get; set; }
        public int HomeAddressId { get; set; }
    }
    public class EmployeeContact : AuditedAggregateTenantRoot<int>
    {
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Contact Contact { get; set; }
        public int ContactId { get; set; }
    }
    public class EC_AcademiaTemplate : AuditedAggregateTenantRoot<int>
    {
        public EC_AcademiaTemplate()
        {
        }

        //public string Code { get; set; }

        public string Name { get; set; }
        public string NameLocalized { get; set; }

        public DictionaryValue Institute { get; set; }
        public Guid InstituteId { get; set; }

        public OS_AcademicType AcademicType { get; set; }
        public OS_AcademiaCertificateType AcademiaCertificateType { get; set; }

        public DictionaryValue AcademiaCertificateSubType { get; set; }
        public Guid AcademiaCertificateSubTypeId { get; set; }

        public string Description { get; set; }
        //public bool DoesKPI { get; set; }

        public int PassoutYear { get; set; }

        //public string ReviewPeriodDescription { get => EnumExtensions.GetDescription(ReviewPeriod); set => ReviewPeriod = EnumExtensions.GetValueFromDescription<OS_ReviewPeriod>(value); }
        //public OS_ReviewPeriod ReviewPeriod { get; set; }
        //public int? ReviewPeriodDays { get; set; }
    }
    public class EC_SkillTemplate : AuditedAggregateTenantRoot<int>
    {
        public EC_SkillTemplate()
        {
        }

        //public string Code { get; set; }

        //public string Name { get; set; }
        //public string NameLocalized { get; set; }

        public OS_SkillAquisitionType SkillAquisitionType { get; set; }
        public OS_SkillType SkillType { get; set; }

        public DictionaryValue SkillSubType { get; set; }
        public Guid SkillSubTypeId { get; set; }

        public string Description { get; set; }

        public bool DoesKPI { get; set; }

        //public string ReviewPeriodDescription { get => EnumExtensions.GetDescription(ReviewPeriod); set => ReviewPeriod = EnumExtensions.GetValueFromDescription<OS_ReviewPeriod>(value); }
        //public OS_ReviewPeriod ReviewPeriod { get; set; }
        //public int? ReviewPeriodDays { get; set; }

        //public OS_SkillUpdatePeriod SkillUpdatePeriod { get; set; }

        //public virtual OS_CompensationMatrixTemplate_Dto CompensationMatrix { get; set; }
        //public int CompensationMatrixId { get; set; }
    }
}
