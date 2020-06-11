using CERP.App;
using CERP.App.Helpers;
using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure;
using CERP.Attributes;
using CERP.Base;
using CERP.FM.DTOs;
using CERP.HR.Documents;
using CERP.HR.EmployeeCentral.DTOs.Attributes;
using CERP.HR.EmployeeCentral.Employee;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
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
        public string FirstName { get; set; }
        public string FirstNameLocalized { get; set; }
        public string MiddleName { get; set; }
        public string MiddleNameLocalized { get; set; }
        public string LastName { get; set; }
        public string LastNameLocalized { get; set; }
        public string Initials { get; set; }
        public string PreferredName { get; set; }
        public string DisplayName { get; set; }
        public DictionaryValue_Dto Title { get; set; }
        public Guid TitleId { get; set; }

        public DictionaryValue_Dto Gender { get; set; }
        public Guid GenderId { get; set; }
        public DictionaryValue_Dto MaritalStatus { get; set; }
        public Guid MaritalStatusId { get; set; }
        public string MarriedSince { get; set; }
        public DictionaryValue_Dto PreferredLanguage { get; set; }
        public Guid PreferredLanguageId { get; set; }
        public DictionaryValue_Dto Nationality { get; set; }
        public Guid NationalityId { get; set; }
        #endregion

        #region Bio Info
        public string DateOfBirth { get; set; }

        public DictionaryValue_Dto BirthCountry { get; set; }
        public Guid BirthCountryId { get; set; }
        public string PlaceOfBirth { get; set; }
        public string BioAttachment { get; set; }

        public List<EmployeeDisability_Dto> EmployeeDisabilities { get; set; }
        #endregion

        #region Identity Info
        #region Iqama Identity
        public string IqamaNumber { get; set; }
        public string IqamaPlaceOfIssue { get; set; }
        public string LabourOfficeNumber { get; set; }
        public string LabourOfficePlaceOfIssue { get; set; }

        public EC_IqamaSponsorType IqamaSponsorType { get; set; }
        public List<EmployeeSponsorLegalEntity_Dto> EmployeeSponsorLegalEntities { get; set; }
        public string IqamaSponsorName { get; set; }
        public string IqamaSponsorNameLocal { get; set; }
        public string IqamaSponsorAddressLine1 { get; set; }
        public string IqamaSponsorAddressLine2 { get; set; }
        public string IqamaSponsorEmailAddress { get; set; }
        public string IqamaSponsorLabourOfficeNumber { get; set; }
        public bool IqamaSponsorContractSecured { get; set; }
        public string IqamaSponsorAttachment { get; set; }

        public EmployeePrimaryValidityAttachment_Dto IqamaNumberValidities { get; set; }
        public int? IqamaNumberValiditiesId { get; set; }
        public EmployeePrimaryValidityAttachment_Dto IqamaLabourOfficeValidities { get; set; }
        public int? IqamaLabourOfficeValiditiesId { get; set; }
        #endregion
        #region National Identity
        public DictionaryValue_Dto NationalIdentityType { get; set; }
        public Guid NationalIdentityTypeId { get; set; }
        public string NationalIdentityNumber { get; set; }
        public string NationalIdentityNameOnID { get; set; }
        public string NationalIdentityNameOnIDLocal { get; set; }

        public EmployeePrimaryValidityAttachment_Dto NationalIdentities { get; set; }
        public int NationalIdentitiesId { get; set; }
        #endregion
        public List<EmployeePassportTravelDocument_Dto> PassportTravelDocuments { get; set; }
        #endregion

        #region Contact Info
        public List<EmployeeEmailAddress_Dto> EmailAddresses { get; set; }
        public List<EmployeePhoneAddress_Dto> PhoneAddresses { get; set; }
        public List<EmployeeHomeAddress_Dto> HomeAddresses { get; set; }
        public List<EmployeeContact_Dto> Contacts { get; set; }
        #endregion

        #region Dependants Info
        public List<Dependant_Dto> Dependants { get; set; }
        #endregion

        #endregion

        #region Employment Info

        #region Organization Info
        public OS_OrganizationStructureTemplateDepartment_Dto OrganizationStructureTemplateDepartment { get; set; }
        public int DepartmentTemplateId { get; set; }
        public int HeadDepartmentTemplateId { get; set; }
        public int OrganizationStructureTemplateDivisionId { get; set; }
        public int OrganizationStructureTemplateId { get; set; }
        public int OrganizationStructureTemplateBusinessUnitId { get; set; }
        public Guid LegalEntityId { get; set; }

        public DictionaryValue_Dto EmployeeSubGroup { get; set; }
        public Guid EmployeeSubGroupId { get; set; }
        public DictionaryValue_Dto EmployeeGroup { get; set; }
        public Guid EmployeeGroupId { get; set; }
        public DictionaryValue_Dto EmploymentType { get; set; }
        public Guid EmploymentTypeId { get; set; }
        //public DictionaryValue_Dto Timezone { get; set; }
        //[CustomAudited]
        //public Guid TimezoneId { get; set; }

        public DictionaryValue_Dto CostCenter { get; set; }
        public Guid CostCenterId { get; set; }
        #endregion

        #endregion

        #region Compensation Info

        #region Basic Contract Info
        public PS_PayGroup_Dto PayGroup { get; set; }
        public int PayGroupId { get; set; }
        public PS_PayGrade_Dto PayGrade { get; set; }
        public int PayGradeId { get; set; }
        public string ContractValidityFromDate { get; set; }
        public string ContractValidityToDate { get; set; }
        #endregion

        #region Benefits Info
        public List<Benefit_Dto> EmployeeBenefits { get; set; }
        #endregion
        #region Payment Details
        public List<CashPaymentType_Dto> CashPaymentTypes { get; set; }
        public List<ChequePaymentType_Dto> ChequePaymentTypes { get; set; }
        public List<BankPaymentType_Dto> BankPaymentTypes { get; set; }
        #endregion

        #endregion

        #region Time Details

        #region General Details
        public DictionaryValue_Dto Timezone { get; set; }
        public Guid TimezoneId { get; set; }
        #endregion
        #region Time Offs Info
        public string HiringDate { get; set; }
        public int YearlyTimeOffAllowance { get; set; }
        #endregion

        #endregion

        #region Academia & Skills Profile

        #region Academia Profile
        public List<EC_AcademiaTemplate_Dto> AcademiaProfile { get; set; }
        #endregion
        #region Skills Profile
        public List<EC_SkillTemplate_Dto> SkillsProfile { get; set; }
        #endregion

        #endregion

        #region Loans Information

        #region Loans List
        public List<EmployeeLoan_Dto> EmployeeLoans { get; set; }
        #endregion

        #endregion

        public string ProfilePic { get; set; }

        [ForeignKey("PortalId")]
        public virtual AppUser_Dto Portal { get; set; }
        public Guid? PortalId { get; set; }
    }

    public class EmployeeDisability_Dto : AuditedEntityTenantDto<int>
    {
        public Employee_Dto Employee { get; set; }
        public Guid EmployeeId { get; set; }
        public Disability_Dto Disability { get; set; }
        public int DisabilityId { get; set; }
    }
    public class EmployeeSponsorLegalEntity_Dto : AuditedEntityTenantDto<int>
    {
        public Employee_Dto Employee { get; set; }
        public Guid EmployeeId { get; set; }
        public Company_Dto LegalEntity { get; set; }
        public Guid LegalEntityId { get; set; }
    }
    public class EmployeePrimaryValidityAttachment_Dto : AuditedEntityTenantDto<int>
    {
        public List<PrimaryValidityAttachment_Dto> PrimaryValidityAttachments { get; set; }
    }
    public class EmployeePassportTravelDocument_Dto : AuditedEntityTenantDto<int>
    {
        public Employee_Dto Employee { get; set; }
        public Guid EmployeeId { get; set; }
        public PassportTravelDocument_Dto PassportTravelDocument { get; set; }
        public int PassportTravelDocumentId { get; set; }
    }
    public class EmployeeEmailAddress_Dto : AuditedEntityTenantDto<int>
    {
        public Employee_Dto Employee { get; set; }
        public Guid EmployeeId { get; set; }
        public EmailAddress_Dto EmailAddress { get; set; }
        public int EmailAddressId { get; set; }
    }
    public class EmployeePhoneAddress_Dto : AuditedEntityTenantDto<int>
    {
        public Employee_Dto Employee { get; set; }
        public Guid EmployeeId { get; set; }
        public PhoneAddress_Dto PhoneAddress { get; set; }
        public int PhoneAddressId { get; set; }
    }
    public class EmployeeHomeAddress_Dto : AuditedEntityTenantDto<int>
    {
        public Employee_Dto Employee { get; set; }
        public Guid EmployeeId { get; set; }
        public HomeAddress_Dto HomeAddress { get; set; }
        public int HomeAddressId { get; set; }
    }
    public class EmployeeContact_Dto : AuditedEntityTenantDto<int>
    {
        public Employee_Dto Employee { get; set; }
        public Guid EmployeeId { get; set; }
        public Contact_Dto Contact { get; set; }
        public int ContactId { get; set; }
    }
    public class EC_AcademiaTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public EC_AcademiaTemplate_Dto()
        {
        }

        //public string Code { get; set; }

        public string Name { get; set; }
        public string NameLocalized { get; set; }

        public DictionaryValue_Dto Institute { get; set; }
        public Guid InstituteId { get; set; }

        public string AcademicTypeDescription { get => EnumExtensions.GetDescription(AcademicType); set { try { AcademicType = EnumExtensions.GetValueFromDescription<OS_AcademicType>(value); } catch { } } }
        public OS_AcademicType AcademicType { get; set; }
        public string AcademiaCertificateTypeDescription { get => EnumExtensions.GetDescription(AcademiaCertificateType); set { try { AcademiaCertificateType = EnumExtensions.GetValueFromDescription<OS_AcademiaCertificateType>(value); } catch { } } }
        public OS_AcademiaCertificateType AcademiaCertificateType { get; set; }

        public DictionaryValue_Dto AcademiaCertificateSubType { get; set; }
        public Guid AcademiaCertificateSubTypeId { get; set; }

        public string Description { get; set; }
        //public bool DoesKPI { get; set; }

        public int PassoutYear { get; set; }

        //public string ReviewPeriodDescription { get => EnumExtensions.GetDescription(ReviewPeriod); set => ReviewPeriod = EnumExtensions.GetValueFromDescription<OS_ReviewPeriod>(value); }
        //public OS_ReviewPeriod ReviewPeriod { get; set; }
        //public int? ReviewPeriodDays { get; set; }
    }
    public class EC_SkillTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public EC_SkillTemplate_Dto()
        {
        }
        
        //public string Code { get; set; }

        //public string Name { get; set; }
        //public string NameLocalized { get; set; }

        public string SkillAquisitionTypeDescription { get => EnumExtensions.GetDescription(SkillAquisitionType); set => SkillAquisitionType = EnumExtensions.GetValueFromDescription<OS_SkillAquisitionType>(value); }
        public OS_SkillAquisitionType SkillAquisitionType { get; set; }
        public string SkillTypeDescription { get => EnumExtensions.GetDescription(SkillType); set => SkillType = EnumExtensions.GetValueFromDescription<OS_SkillType>(value); }
        public OS_SkillType SkillType { get; set; }

        public DictionaryValue_Dto SkillSubType { get; set; }
        public Guid SkillSubTypeId { get; set; }

        public string Description { get; set; }

        public bool DoesKPI { get; set; }

        //public string ReviewPeriodDescription { get => EnumExtensions.GetDescription(ReviewPeriod); set => ReviewPeriod = EnumExtensions.GetValueFromDescription<OS_ReviewPeriod>(value); }
        //public OS_ReviewPeriod ReviewPeriod { get; set; }
        //public int? ReviewPeriodDays { get; set; }

        //public string SkillUpdatePeriodDescription { get => EnumExtensions.GetDescription(SkillUpdatePeriod); set => SkillUpdatePeriod = EnumExtensions.GetValueFromDescription<OS_SkillUpdatePeriod>(value); }
        //public OS_SkillUpdatePeriod SkillUpdatePeriod { get; set; }

        //public virtual OS_CompensationMatrixTemplate_Dto CompensationMatrix { get; set; }
        //public int CompensationMatrixId { get; set; }
    }
}
