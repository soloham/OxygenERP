using CERP.App;
using Syncfusion.EJ2.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace CERP.HR.EMPLOYEE.RougeDTOs
{
    public class GeneralInfo
    {
        public GeneralInfo(IList<PhysicalId<Guid>> physicalIds)
        {
            PhysicalIds = physicalIds;
        }

        public IList<PhysicalId<Guid>> PhysicalIds { get; set; }

        internal void Initialize(IRepository<DictionaryValue, Guid> dictionaryValuesRepo)
        {
            PhysicalIds.ForEach(x => x.DicValuesProxy = dictionaryValuesRepo);
        }
    }
}
