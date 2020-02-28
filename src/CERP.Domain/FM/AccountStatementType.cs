using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.FM
{
    public class AccountStatementType : AuditedAggregateRoot<Guid> 
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
