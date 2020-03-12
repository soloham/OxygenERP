using CERP.App;
using CERP.HR.Employees.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CERP.CERP.HR.Documents
{
    public class Document_Dto : AuditedEntityDto<Guid>
    {

        public Document_Dto()
        {

        }
        public Document_Dto(Guid id)
        {
            Id = id;
        }

        public DictionaryValue_Dto OwnerType { get; set; }
        [Required]
        public Guid OwnerTypeId { get; set; }
        public DictionaryValue_Dto DocumentType { get; set; }
        [Required]
        public Guid DocumentTypeId { get; set; }
        public DictionaryValue_Dto IssuedFrom { get; set; }
        [Required]
        public Guid IssuedFromId { get; set; }

        public Employee_Dto Owner { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public int ReferenceNo { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string Name { get; set; }
        public string NameLocalized { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        [Required]
        public string IssueDate { get; set; }
        [Required]
        public string ExpiryDate { get; set; }
    }
}
