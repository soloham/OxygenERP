using CERP.Base;
using CERP.Setup;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.Setup
{
    public class Company : AuditedAggregateTenantRoot<Guid> 
    {
        public Company()
        {

        }
        public Company(Guid guid)
        {
            Id = guid;
        }

        public string CompanyCode { get; set; }

        public string CompanyName { get; set; }
        public string CompanyNameLocalized { get; set; }
        public string ClientID { get; set; }
        public string RegistrationID { get; set; }
        public string LabourOfficeId { get; set; }
        public string TaxID { get; set; }
        public string VATID { get; set; }
        public string SocialInsuranceID { get; set; }
        public Language Language { get; set; }
        public CompanyStatus Status { get; set; }

        public ICollection<Department> Departments { get; set; }
        public ICollection<CompanyLocation> CompanyLocations { get; set; }
        public ICollection<CompanyCurrency> CompanyCurrencies { get; set; }
        public ICollection<CompanyPrintSize> CompanyPrintSizes { get; set; }
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
    }
    public class CompanyCurrency : AuditedAggregateTenantRoot<int>
    {
        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }

        public Company Company { get; set; }
        public Guid CompanyId { get; set; }

        public CurrencyType CurrencyType { get; set; }
        public double ExchangeRate { get; set; }
    }
    public class CompanyPrintSize : AuditedAggregateTenantRoot<int>
    {
        public PrintSize PrintSize { get; set; }

        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
    }
}
