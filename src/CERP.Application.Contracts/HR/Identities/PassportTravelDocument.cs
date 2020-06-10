using CERP.App;
using CERP.App.Helpers;
using CERP.Attributes;
using CERP.Base;
using CERP.HR.Employee.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class PassportTravelDocument_Dto : AuditedEntityTenantDto<int>
    {
        public PassportTravelDocument_Dto()
        {

        }
        public string DocumentTypeDescription { get => EnumExtensions.GetDescription(DocumentType); set { try { DocumentType = EnumExtensions.GetValueFromDescription<IdentityDocumentType>(value); } catch { } } }
        public IdentityDocumentType DocumentType { get; set; }
        public DictionaryValue_Dto IssuingCountry { get; set; }
        public Guid IssuingCountryId { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentAttachment { get; set; }
        public bool IsPrimary { get; set; }
        public string ValidityFromDate { get; set; }
        public string ValidityToDate { get; set; }
    }
}
