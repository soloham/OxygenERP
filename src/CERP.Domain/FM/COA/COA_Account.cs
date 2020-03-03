using CERP.App;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.FM.COA
{
    public class COA_Account : FullAuditedAggregateRoot<Guid> 
    {
        public COA_Account()
        {

        }
        public COA_Account(Guid id)
        {
            Id = id;
        }

        [ForeignKey("HeadAccountId")]
        public virtual COA_HeadAccount HeadAccount { get; set; }
        public Guid HeadAccountId { get; set; }

        [ForeignKey("AccountSubCatId")]
        public virtual COA_AccountSubCategory AccountSubCategory { get; set; }
        public Guid AccountSubCatId { get; set; }
        [ForeignKey("AccountGroupCatId")]
        public virtual COA_AccountSubCategory? AccountGroupCategory { get; set; }
        public Guid? AccountGroupCatId { get; set; }

        public int AccountId { get; set; }

        [ForeignKey("SubLedgerAccountId")]
        public virtual COA_Account? SubLedgerAccount { get; set; }
        public virtual Guid? SubLedgerAccountId { get; set; }
        public int? SubLedgerTypeId { get; set; }

        public string AccountCode { get; set; }
        
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        public virtual Guid CompanyId { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }
        public Guid? BranchId { get; set; }

        public string AccountName { get; set; }
        public string AccountNameLocalizationKey { get; set; }


        [ForeignKey("AccountStatementTypeId")]
        public virtual AccountStatementType AccountStatementType { get; set; }
        public Guid AccountStatementTypeId { get; set; }
        [ForeignKey("AccountStatementDetailTypeId")]
        public virtual AccountStatementType AccountStatementDetailType { get; set; }
        public Guid AccountStatementDetailTypeId { get; set; }
        [ForeignKey("CashFlowStatementTypeId")]
        public virtual DictionaryValue CashFlowStatementType { get; set; }
        public Guid CashFlowStatementTypeId { get; set; }

        public bool AllowPosting { get; set; }
        public bool AllowPayment { get; set; }
        public bool AllowReceipt { get; set; }

        public virtual ICollection<COA_SubLedgerRequirement_Account> SubLedgerRequirementAccounts { get; set; }

        public bool? ActiveStatus { get; set; }
    }
}
