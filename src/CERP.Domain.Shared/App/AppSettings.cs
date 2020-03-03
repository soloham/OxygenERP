using System;
using System.Collections.Generic;
using System.Text;

namespace CERP
{
    public static class AppSettings
    {
        public static DicValueTypeId DicValueTypeId = new DicValueTypeId();
        
    }

    public class DicValueTypeId
    {
        public string CashflowStatementTypesKey = "0111";

        public string Location = "001";
        public string City = "008";
        public string Nationality = "002";
        public string Gender = "003";
        public string MaritalStatus = "004";
        public string BloodGroup = "005";
        public string Religion = "006";

        public string IDType = "007";
    }
}
