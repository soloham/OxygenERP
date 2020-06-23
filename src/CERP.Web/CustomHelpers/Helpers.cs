using CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CERP.Helpers
{
    public static class EnumExtensions
    {
        public static string GetDescription<T>(this T enumerationValue)
          where T : struct
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException($"{nameof(enumerationValue)} must be of Enum type", nameof(enumerationValue));
            }
            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumerationValue.ToString();
        }


    }
    public static class HelperMethods
    {
        public static bool CheckIfMatches(PS_PaySubGroup_Dto toMatch, PS_PaySubGroup_Dto with)
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
