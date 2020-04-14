using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CERP.HR.EMPLOYEE.RougeDTOs
{
    public class EmployeeExtraPropertyHistory
    {
        public EmployeeExtraPropertyHistory(int typeId, string type, string name = "", string status = "")
        {
            TypeId = typeId;
            Type = type;
            Name = name;
            Status = status;
        }

        public int TypeId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public List<EmployeeTypePropertyChange> PropertyChanges { get; set; }
    }

    public class EmployeeTypePropertyChange
    {
        public int TypeId { get; set; }

        public string PropertyTypeFullName { get; set; }

        public string NewValue { get; set; }
        public string OriginalValue { get; set; }
        public string PropertyName { get; set; }
    }
}
