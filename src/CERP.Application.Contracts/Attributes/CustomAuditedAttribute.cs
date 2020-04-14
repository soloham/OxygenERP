using System;
using System.Collections.Generic;
using System.Text;

namespace CERP.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field)]
    public class CustomAuditedAttribute : Attribute
    {

        public CustomAuditedAttribute()
        {

        }
    }
}
