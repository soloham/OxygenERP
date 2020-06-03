using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CERP.HR.Employee.Enums
{
    public enum PhysicalIDType
    {
        Iqama,
        Ahwal,
        Visa
    }

    public enum PhysicalIDIssuers
    {
        Iqama,
        Ahwal,
        Visa
    }

    public enum IdentityDocumentType
    {
        [Description("Passport")]
        Passport,
        [Description("Travel")]
        Travel
    }
}
