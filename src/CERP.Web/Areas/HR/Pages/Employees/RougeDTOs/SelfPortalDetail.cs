using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CERP.HR.EMPLOYEE.RougeDTOs
{
    public class SelfPortalDetail
    {

        public SelfPortalDetail()
        {

        }

        public bool CreatePortal { get; set; }
        public bool IsUsernameEmpId { get; set; }
        public string Username { get; set; }
        //public string Password { get; set; }
    }
}
