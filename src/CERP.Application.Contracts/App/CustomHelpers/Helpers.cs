using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CERP.App.Helpers
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

        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", nameof(description));
            // or return default(T);
        }

        public static string[] GetDescriptions(Type enumerationType)
        {
            List<string> result = new List<string>();
            TypeInfo enumerationTypeInfo = enumerationType.GetTypeInfo();
            if (!enumerationType.IsEnum)
            {
                throw new ArgumentException($"{nameof(enumerationType)} must be of Enum type", nameof(enumerationType));
            }
            var members = enumerationTypeInfo.DeclaredFields.ToList();
            for (int i = 0; i < members.Count; i++)
            {
                    var attrs = members[i].GetCustomAttributes(typeof(DescriptionAttribute), false);

                    if (attrs.Length > 0)
                    {
                        result.Add(((DescriptionAttribute)attrs[0]).Description);
                    }
                
            }
            //return enumerationValue.ToString();
            return result.ToArray();
        }

    }
}
