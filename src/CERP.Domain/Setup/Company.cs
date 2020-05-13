using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.HR.Documents;
using System;
using System.Collections.Generic;
using Volo.Abp.Auditing;

namespace CERP.Setup
{
    [DisableAuditing]
    public class Company : AuditedAggregateTenantRoot<Guid> 
    {
        public Company()
        {

        }
        public Company(Guid guid)
        {
            Id = guid;
        }

        [CustomAudited]
        public string CompanyLogo { get; set; }

        [CustomAudited]
        public string CompanyCode { get; set; }

        [CustomAudited]
        public string CompanyName { get; set; }
        [CustomAudited]
        public string CompanyNameLocalized { get; set; }
        [CustomAudited]
        public string ClientID { get; set; }
        [CustomAudited]
        public string RegistrationID { get; set; }
        [CustomAudited]
        public string LabourOfficeId { get; set; }
        [CustomAudited]
        public string TaxID { get; set; }
        [CustomAudited]
        public string VATID { get; set; }
        [CustomAudited]
        public string SocialInsuranceID { get; set; }
        [CustomAudited]
        public Language Language { get; set; }
        [CustomAudited]
        public CompanyStatus Status { get; set; }

        public ICollection<Department> Departments { get; set; }
        public ICollection<CompanyLocation> CompanyLocations { get; set; }
        public ICollection<CompanyCurrency> CompanyCurrencies { get; set; }
        public ICollection<CompanyPrintSize> CompanyPrintSizes { get; set; }
        public ICollection<CompanyDocument> CompanyDocuments { get; set; }
    }

    public class CompanyLocation : AuditedAggregateTenantRoot<int>
    {
        public LocationTemplate Location { get; set; }
        public Guid LocationId { get; set; }

        public Company Company { get; set; }
        public Guid CompanyId { get; set; }

        public string Name { get; set; }

        public string LocationValidityStart { get; set; }
        public string LocationValidityEnd { get; set; }

        public LocationType LocationType { get; set; }
    }
    public class CompanyCurrency : AuditedAggregateTenantRoot<int>
    {
        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }

        public Company Company { get; set; }
        public Guid CompanyId { get; set; }

        public CurrencyType CurrencyType { get; set; }
        public double ExchangeRate { get; set; }

        public CurrencyStatus Status { get; set; }
    }
    public class CompanyPrintSize : AuditedAggregateTenantRoot<int>
    {
        public PrintSize PrintSize { get; set; }

        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
    }
    public class CompanyDocument : AuditedAggregateTenantRoot<int>
    {
        public string DocumentTitle { get; set; }
        public string DocumentTitleLocalized { get; set; }

        public string IssueDate { get; set; }
        public string EndDate { get; set; }

        public DictionaryValue DocumentType { get; set; }
        public Guid DocumentTypeId { get; set; }

        public Document Document { get; set; }
        public Guid DocumentId { get; set; }

        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
    }
}
