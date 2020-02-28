﻿using CERP.FM.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.FM.COA.DTOs
{
    public class COA_AccountSubCategory_Dto : AuditedEntityDto<Guid> 
    {
        public COA_AccountSubCategory_Dto()
        {

        }
        public COA_AccountSubCategory_Dto(Guid id)
        {
            Id = id;
        }
        public COA_HeadAccount_Dto HeadAccount { get; set; }
        public Guid HeadAccountId { get; set; }
        public int SubCategoryId { get; set; }    // Index Under Parent
        public string SubCategoryCode { get; set; }    // Auto Generated Code
        public Guid? ParentId { get; set; }
        public int CLI { get; set; }  // Classification Index
        public string Title { get; set; }
        public string LocalizationKey { get; set; }
        public Branch_Dto Branch { get; set; }
        public Company_Dto Company { get; set; }
        public Guid CompanyId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
