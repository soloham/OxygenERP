using CERP.App;
using CERP.FM.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.FM.COA.DTOs
{
    public class COA_Account_Dto : FullAuditedEntityDto<Guid> 
    {
        public COA_Account_Dto()
        {

        }
        public COA_Account_Dto(Guid id)
        {
            Id = id;
        }

        public virtual COA_HeadAccount_Dto HeadAccount { get; set; }
        public Guid HeadAccountId { get; set; }

        public virtual COA_AccountSubCategory_Dto AccountSubCategory_1 { get; set; }
        public Guid AccountSubCat1Id { get; set; }
        public virtual COA_AccountSubCategory_Dto AccountSubCategory_2 { get; set; }
        public Guid AccountSubCat2Id { get; set; }
        public virtual COA_AccountSubCategory_Dto AccountSubCategory_3 { get; set; }
        public Guid AccountSubCat3Id { get; set; }
        public virtual COA_AccountSubCategory_Dto AccountSubCategory_4 { get; set; }
        public Guid AccountSubCat4Id { get; set; }

        public int AccountId { get; set; }

        public virtual COA_Account_Dto? SubLedgerAccount { get; set; }
        public virtual Guid? SubLedgerAccountId { get; set; }
        public int? SubLedgerTypeId { get; set; }

        public int AccountCode { get; set; }

        public virtual Company_Dto Company { get; set; }
        public virtual Guid CompanyId { get; set; }

        public virtual Branch_Dto Branch { get; set; }
        public Guid BranchId { get; set; }

        public string AccountName { get; set; }
        public string AccountNameLocalizationKey { get; set; }


        public virtual AccountStatementType_UV_Dto AccountStatementType { get; set; }
        public Guid AccountStatementTypeId { get; set; }
        public virtual AccountStatementType_UV_Dto AccountStatementDetailType { get; set; }
        public Guid AccountStatementDetailTypeId { get; set; }
        public virtual DictionaryValue_Dto CashFlowStatementType { get; set; }
        public Guid CashFlowStatementTypeId { get; set; }

        public bool AllowPosting { get; set; }
        public bool AllowPayment { get; set; }
        public bool AllowReceipt { get; set; }

        public virtual ICollection<COA_SubLedgerRequirement_Dto> SubLedgerRequirements { get; set; }

        public bool? ActiveStatus { get; set; }
    }
}
