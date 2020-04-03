using CERP.Base;
using CERP.HR.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Users;

namespace CERP.Users
{
    /* This entity shares the same table/collection ("AbpUsers" by default) with the
     * IdentityUser entity of the Identity module.
     *
     * - You can define your custom properties into this class.
     * - You never create or delete this entity, because it is Identity module's job.
     * - You can query users from database with this entity.
     * - You can update values of your custom properties.
     */
    public class AppUser_Dto : FullAuditedEntityTenantDto<Guid>
    {
        #region Base properties

        /* These properties are shared with the IdentityUser entity of the Identity module.
         * Do not change these properties through this class. Instead, use Identity module
         * services (like IdentityUserManager) to change them.
         * So, this properties are designed as read only!
         */

        [Required]
        public virtual Guid? TenantId { get; private set; }

        [Required]
        public virtual string UserName { get; private set; }

        [Required]
        public virtual string Name { get; private set; }

        public virtual string Surname { get; private set; }

        [Required]
        public virtual string Email { get; private set; }

        public virtual bool EmailConfirmed { get; private set; }

        public virtual string PhoneNumber { get; private set; }

        public virtual bool PhoneNumberConfirmed { get; private set; }

        #endregion

        /* Add your own properties here. Example:
         *
         * public virtual string MyProperty { get; set; }
         */
        //[NotMapped]
        //public override Dictionary<string, object> ExtraProperties { get; protected set; }

        //[ForeignKey("EmployeeId")]
        //public virtual Employee Employee { get; set; }
        public virtual Guid? EmployeeId { get; set; }

        private AppUser_Dto()
        {
            
        }
    }
}
