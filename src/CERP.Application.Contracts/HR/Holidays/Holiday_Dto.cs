using CERP.App;
using CERP.Base;
using CERP.Setup;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERP.HR.Holidays
{
    public class Holiday_Dto : AuditedEntityTenantDto<int>
    {
        public Holiday_Dto()
        {

        }
        public Holiday_Dto(int id)
        {
            Id = id;
        }

        public string Title { get; set; }
        public string TitleLocalized { get; set; }
       
        public DictionaryValue_Dto HolidayType { get; set; }
        public Guid HolidayTypeId { get; set; }

        public bool IsPublic { get; set; }

        public string GetStartDate { get {
                string result = "";
                if (StartDate.HasValue)
                    result = StartDate.Value.ToShortDateString();
                return result;
            } 
        }
        public DateTime? StartDate { get; set; }
        public string GetEndDate { get {
                string result = "";
                if (EndDate.HasValue)
                    result = EndDate.Value.ToShortDateString();
                return result;
            } 
        }
        public DateTime? EndDate { get; set; }

        public DictionaryValue_Dto ReligiousDenomination { get; set; }
        public Guid? ReligiousDenominationId { get; set; }
    }
    
}
