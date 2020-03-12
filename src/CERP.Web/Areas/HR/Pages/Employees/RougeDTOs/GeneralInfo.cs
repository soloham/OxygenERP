using CERP.App;
using CERP.AppServices.HR.DepartmentService;
using Syncfusion.EJ2.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        internal void Initialize(IRepository<DictionaryValue, Guid> dictionaryValuesRepo, documentAppService docAppService)
        {
            for (int i = 0; i < PhysicalIds.Count; i++)
            {
                PhysicalIds[i].DicValuesProxy = dictionaryValuesRepo;
                PhysicalIds[i].DocAppServiceProxy = docAppService;
                PhysicalIds[i].Document = PhysicalIds[i].GetDocument;
            }
        }
    }
}
