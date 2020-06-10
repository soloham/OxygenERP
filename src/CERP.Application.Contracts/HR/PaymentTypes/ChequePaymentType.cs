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
        public string NameOnCheque { get; set; }
        public string ValidityFromDate { get; set; }
        public string ValidityToDate { get; set; }
        public bool IsPrimary { get; set; }
    }
}
