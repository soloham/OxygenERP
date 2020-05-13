using CERP.Base;
using System;

namespace CERP.FM
{
    public class AccountStatementType : AuditedAggregateTenantRoot<Guid> 
    {
        public AccountStatementType()
        {

        }
        public AccountStatementType(Guid id)
        {
            Id = id;
        }
        public AccountStatementTypeEnum AccountStatementTypeId { get; set; }
        public AccountStatementDetailTypeEnum AccountStatementDetailTypeId { get; set; }
        public string Title { get; set; }
        public string TitleLocalizationKey { get; set; }
        public Guid? ParentId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
