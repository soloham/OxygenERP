using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.FM.UV_DTOs
{
    public class Company_UV_Dto : AuditedEntityDto<Guid> 
    {
        public int CompanyCode { get; set; }
        [Required]
        public string Name { get; set; }
        public string NameLocalizationKey { get; set; }
        [Required]
        public string Address { get; set; }
        public string AddressLocalizationKey { get; set; }
        [Required]
        public string BankDetail { get; set; }
        public string BankDetailLocalizationKey { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        [Required]
        public int FiscalYearStartMonth { get; set; }
        public string FiscalYearBasis { get; set; }
        [Required]
        public bool? IsEnabled { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string VATNumber { get; set; }
        [Required]
        public string CRNumber { get; set; }
    }
}
