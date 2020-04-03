using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Auditing;
using Volo.Abp.Identity;

namespace CERP.Identity
{
    public class RegisterDto
    {
        [Required]
        [StringLength(IdentityUserConsts.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(IdentityUserConsts.MaxEmailLength)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(IdentityUserConsts.MaxPasswordLength)]
        [DataType(DataType.Password)]
        [DisableAuditing]
        public string Password { get; set; }

        [Required]
        public string AppName { get; set; }

        public Guid? EmployeeId { get; set; }
    }
}
