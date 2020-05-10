using CERP.App;
using CERP.App.Helpers;
using CERP.Base;
using CERP.CERP.HR.Documents;
using CERP.Setup;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.FM.DTOs
{
    public class Company_Dto : AuditedEntityTenantDto<Guid> 
    {
        public Company_Dto()
        {

        }

        public string CompanyLogo { get; set; }

        public string CompanyCode { get; set; }

        public string CompanyName { get; set; }
        public string CompanyNameLocalized { get; set; }
        public string ClientID { get; set; }
        public string RegistrationID { get; set; }
        public string LabourOfficeId { get; set; }
        public string TaxID { get; set; }
        public string VATID { get; set; }
        public string SocialInsuranceID { get; set; }

        public string LanguageDescription { get => EnumExtensions.GetDescription(Language); set => Language = EnumExtensions.GetValueFromDescription<Language>(value); }
        public Language Language { get; set; }
        public string StatusDescription { get => EnumExtensions.GetDescription(Status); set => Status = EnumExtensions.GetValueFromDescription<CompanyStatus>(value); }
        public CompanyStatus Status { get; set; }

        public List<Department_Dto> Departments { get; set; }
        public List<CompanyLocation_Dto> CompanyLocations { get; set; }
        public List<CompanyCurrency_Dto> CompanyCurrencies { get; set; }
        public List<CompanyPrintSize_Dto> CompanyPrintSizes { get; set; }
        public List<CompanyDocument_Dto> CompanyDocuments { get; set; }
    }

    public class CompanyLocation_Dto : AuditedEntityTenantDto<int>
    {
        public LocationTemplate_Dto Location { get; set; }
        public Guid LocationId { get; set; }

        public Company_Dto Company { get; set; }
        public Guid CompanyId { get; set; }

        public string Name { get; set; }

        public string LocationValidityStart { get; set; }
        public string LocationValidityEnd { get; set; }
    }
    public class CompanyCurrency_Dto : AuditedEntityTenantDto<int>
    {
        public Currency_Dto Currency { get; set; }
        public int CurrencyId { get; set; }

        public Company_Dto Company { get; set; }
        public Guid CompanyId { get; set; }

        public string CurrencyTypeDescription { get => EnumExtensions.GetDescription(CurrencyType); }
        public CurrencyType CurrencyType { get; set; }

        public double ExchangeRate { get; set; }
    }
    public class CompanyPrintSize_Dto : AuditedEntityTenantDto<int>
    {
        public string PrintSizeDescription { get => EnumExtensions.GetDescription(PrintSize); set => PrintSize = EnumExtensions.GetValueFromDescription<PrintSize>(value); }
        public PrintSize PrintSize { get; set; }

        public Company_Dto Company { get; set; }
        public Guid CompanyId { get; set; }
    }
    public class CompanyDocument_Dto : AuditedEntityTenantDto<int>
    {
        public string DocumentTitle { get; set; }
        public string DocumentTitleLocalized { get; set; }

        public string IssueDate { get; set; }
        public string EndDate { get; set; }

        public DictionaryValue_Dto DocumentType { get; set; }
        public Guid DocumentTypeId { get; set; }

        public Document_Dto Document { get; set; }
        public Guid DocumentId { get; set; }

        public Company_Dto Company { get; set; }
        public Guid CompanyId { get; set; }
    }
}
