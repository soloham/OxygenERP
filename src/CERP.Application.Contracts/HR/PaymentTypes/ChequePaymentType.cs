using CERP.App;
using CERP.Attributes;
using CERP.Base;
using CERP.Setup;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class ChequePaymentType_Dto : AuditedEntityTenantDto<int>
    {
        public ChequePaymentType_Dto()
        {

        }

        [CustomAudited]
        public string NameOnCheque { get; set; }

        [CustomAudited]
        public string ValidityFromDate { get; set; }
        [CustomAudited]
        public string ValidityToDate { get; set; }

        [CustomAudited]
        public bool IsPrimary { get; set; }
    }
}
