using CERP.FM.COA.DTOs;
using CERP.FM.UV_DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.FM.COA.UV_DTOs
{
    public class COA_AccountSubCategory_UV_Dto : AuditedEntityDto<Guid> 
    {
        public COA_AccountSubCategory_UV_Dto()
        {

        }
        public COA_AccountSubCategory_UV_Dto(Guid id)
        {
            Id = id;
        }

        [Required]
        public COA_HeadAccount_Dto HeadAccount { get; set; }
        public Guid HeadAccountId { get; set; }
        [Required]
        public int GroupCategoryId { get; set; }    // Index Under Parent
        [Required]
        public int SubCategoryId { get; set; }    // Index Under Parent
        [Required]
        public string SubCategoryCode { get; set; }    // Auto Generated Code
        public string? ParentCategoryTitle { get; set; }
        public COA_AccountSubCategory_Dto? ParentCategory { get; set; }
        public Guid? ParentId { get; set; }
        [Required]
        public AccountCLI CLI { get; set; }  // Classification Index
        [Required]
        public string Title { get; set; }
        public string LocalizationKey { get; set; }
        [Required]
        public Branch_UV_Dto Branch { get; set; }
        [Required]
        public Company_UV_Dto Company { get; set; }
        public Guid CompanyId { get; set; }
        public bool? IsDeleted { get; set; } = false;
    }
}
