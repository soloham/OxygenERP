using CERP.App;
using CERP.Base;
using CERP.Setup;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERP.HR.Holidays
{
    public class Holiday : AuditedAggregateTenantRoot<int>
    {
        public Holiday()
        {

        }
        public Holiday(int id)
        {
            Id = id;
        }

        public string Title { get; set; }
        public string TitleLocalized { get; set; }
       
        public DictionaryValue HolidayType { get; set; }
        public Guid HolidayTypeId { get; set; }

        public bool IsPublic { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public DictionaryValue ReligiousDenomination { get; set; }
        public Guid? ReligiousDenominationId { get; set; }
    }
    
}
