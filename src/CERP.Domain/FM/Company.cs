using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.FM
{
    public class Company : AuditedAggregateRoot<Guid> 
    {
        public Company()
        {

        }
        public Company(Guid guid)
        {
            Id = guid;
        }
        public string Name { get; set; }
        public string NameLocalizationKey { get; set; }
        public string Address { get; set; }
        public string AddressLocalizationKey { get; set; }
        public string BankDetail { get; set; }
        public string BankDetailLocalizationKey { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public int FiscalYearStartMonth { get; set; }
        public string FiscalYearBasis { get; set; }
        public bool? IsEnabled { get; set; }
        public string Language { get; set; }
        public string VATNumber { get; set; }
        public string CRNumber { get; set; }
    }
}
