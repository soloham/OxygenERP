using CERP.App;
using CERP.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.HR.Documents
{
    public class Document : AuditedAggregateTenantRoot<Guid>, ISoftDelete
    {
        public Document()
        {

        }
        public Document(Guid id)
        {
            Id = id;
        }

        [ForeignKey("OwnerTypeId")]
        public DictionaryValue OwnerType { get; set; }
        public Guid OwnerTypeId { get; set; }
        [ForeignKey("DocumentTypeId")]
        public DictionaryValue DocumentType { get; set; }
        public Guid DocumentTypeId { get; set; }

        [ForeignKey("OwnerId")]
        public Employees.Employee Owner { get; set; }
        public Guid OwnerId { get; set; }

        [ForeignKey("IssuedFromId")]
        public DictionaryValue IssuedFrom { get; set; }
        public Guid IssuedFromId { get; set; }

        public int ReferenceNo { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }
        public string NameLocalized { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public string IssueDate { get; set; }
        public string ExpiryDate { get; set; }
    }
}
