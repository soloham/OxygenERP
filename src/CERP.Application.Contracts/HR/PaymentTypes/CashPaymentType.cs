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
        [CustomAudited]
        public int CollectionLocationId { get; set; }

        [CustomAudited]
        public string ValidityFromDate { get; set; }
        [CustomAudited]
        public string ValidityToDate { get; set; }

        [CustomAudited]
        public bool IsPrimary { get; set; }
    }
}
