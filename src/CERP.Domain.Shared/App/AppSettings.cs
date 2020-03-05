using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CERP
{
    public static class AppSettings
    {
        public static DicValueTypeId DicValueTypeId = new DicValueTypeId();
        
    }

    public class DicValueTypeId
    {
        public string CashflowStatementTypesKey = "01";

        public string Location = "02";
        public string City = "03";
        public string Nationality = "04";
        public string Gender = "05";
        public string MaritalStatus = "06";
        public string BloodGroup = "07";
        public string Religion = "08";

        public string IDType = "09";
    }

    public enum ValueTypeModules
    {
        [Description("Country")]
        Country,
        [Description("Gender")]
        Gender,
        [Description("Marital Status")]
        MaritalStatus,
        [Description("Blood Group")]
        BloodGroup,
        [Description("Religion")]
        Religion,
        [Description("ID Type")]
        IDType,
        [Description("Cashflow Statement Type")]
        CashflowStatementType,
    }
}
