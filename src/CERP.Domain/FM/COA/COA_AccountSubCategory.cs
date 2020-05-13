using CERP.Base;
using CERP.Setup;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CERP.FM.COA
{

    public class COA_AccountSubCategory : FullAuditedAggregateTenantRoot<Guid>
    {
        public COA_AccountSubCategory()
        {

        }
        public COA_AccountSubCategory(Guid id)
        {
            Id = id;
        }
        [ForeignKey("HeadAccountId")]
        public COA_HeadAccount HeadAccount { get; set; }   
        public Guid HeadAccountId { get; set; }   
        public int SubCategoryId { get; set; }    // Index Under Header
        public int GroupCategoryId { get; set; }    // Index Under Parent
        public string SubCategoryCode { get; set; }    // Auto Generated Code
        public COA_AccountSubCategory? ParentCategory { get; set; }
        public Guid? ParentId { get; set; }
        public AccountCLI CLI { get; set; }  // Classification Index
        public string Title { get; set; }
        public string LocalizationKey { get; set; }
        public Branch? Branch { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
