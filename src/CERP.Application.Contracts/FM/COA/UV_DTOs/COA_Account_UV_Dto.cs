using CERP.App;
using CERP.FM.COA.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;
using CERP.FM.DTOs;

namespace CERP.FM.COA.UV_DTOs
{
    public class COA_Account_UV_Dto : FullAuditedEntityDto<Guid> 
    {
        public COA_Account_UV_Dto()
        {

        }
        public COA_Account_UV_Dto(Guid id)
        {
            Id = id;
        }

        [Required]
        public virtual COA_HeadAccount_Dto HeadAccount { get; set; }
        public Guid HeadAccountId { get; set; }

        [Required]
        public virtual COA_AccountSubCategory_Dto AccountSubCategory_1 { get; set; }
        public Guid AccountSubCat1Id { get; set; }
        [Required]
        public virtual COA_AccountSubCategory_Dto AccountSubCategory_2 { get; set; }
        public Guid AccountSubCat2Id { get; set; }
        public virtual COA_AccountSubCategory_Dto AccountSubCategory_3 { get; set; }
        public Guid AccountSubCat3Id { get; set; }
        public virtual COA_AccountSubCategory_Dto AccountSubCategory_4 { get; set; }
        public Guid AccountSubCat4Id { get; set; }

        [Required]
        public int AccountId { get; set; }

        public virtual COA_Account_Dto? SubLedgerAccount { get; set; }
        public virtual Guid? SubLedgerAccountId { get; set; }
        public int? SubLedgerTypeId { get; set; }

        [Required]
        public int AccountCode { get; set; }

        [Required]
        public virtual Company_Dto Company { get; set; }
        public virtual Guid CompanyId { get; set; }

        [Required]
        public virtual Branch_Dto Branch { get; set; }
        public Guid BranchId { get; set; }

        [Required]
        public string AccountName { get; set; }
        public string AccountNameLocalizationKey { get; set; }


        [Required]
        public virtual AccountStatementType_UV_Dto AccountStatementType { get; set; }
        public Guid AccountStatementTypeId { get; set; }
        [Required]
        public virtual AccountStatementType_UV_Dto AccountStatementDetailType { get; set; }
        public Guid AccountStatementDetailTypeId { get; set; }
        [Required]
        public virtual DictionaryValue_Dto CashFlowStatementType { get; set; }
        public Guid CashFlowStatementTypeId { get; set; }

        public bool AllowPosting { get; set; }
        public bool AllowPayment { get; set; }
        public bool AllowReceipt { get; set; }

        [Required]
        public virtual ICollection<COA_SubLedgerRequirement_Dto> SubLedgerRequirements { get; set; }

        public bool? ActiveStatus { get; set; }
    }
}
