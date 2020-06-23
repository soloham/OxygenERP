using CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERP
{
    public static class CustomHelpers
    {
        public static bool CheckIfMatches(object toMatch, object with)
        {
            var generalProperties = toMatch.GetType().GetProperties();
            bool result = false;
            for (int i = 0; i < generalProperties.Length; i++)
            {
                try
                {
                    var prop = generalProperties[i];
                    string searchValue = (string)prop.GetValue(with);
                    string actualValue = (string)prop.GetValue(toMatch);

                    if (actualValue == searchValue)
                        result = true;
                    else
                    {
                        if (searchValue[0] == '*')
                        {
                            string checkValue = searchValue.Substring(1, searchValue.Length);
                            string actualCheckValue = actualValue.Substring(0, checkValue.Length);

                            if (actualCheckValue == checkValue)
                            {
                                result = true;
                                return result;
                            }
                        }
                        if (searchValue[searchValue.Length - 1] == '*')
                        {
                            string checkValue = searchValue.Substring(0, searchValue.Length);
                            string actualCheckValue = actualValue.Substring(actualValue.Length - checkValue.Length - 1, actualValue.Length);

                            if (actualCheckValue == checkValue)
                            {
                                result = true;
                                return result;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return result;
        }

    }
}
