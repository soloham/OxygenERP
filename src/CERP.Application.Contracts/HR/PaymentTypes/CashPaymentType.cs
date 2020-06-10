using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.Setup;
using CERP.Setup.DTOs;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class CashPaymentType_Dto : AuditedEntityTenantDto<int>
    {
        public CashPaymentType_Dto()
        {

        }

        public LocationTemplate_Dto CollectionLocation { get; set; }
        public Guid CollectionLocationId { get; set; }
        public string ValidityFromDate { get; set; }
        public string ValidityToDate { get; set; }
        public bool IsPrimary { get; set; }
    }
}
