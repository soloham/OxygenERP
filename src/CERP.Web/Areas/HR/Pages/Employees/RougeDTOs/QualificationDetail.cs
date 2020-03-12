using CERP.App;
using Newtonsoft.Json;
using Syncfusion.EJ2.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace CERP.HR.EMPLOYEE.RougeDTOs
{
    public class QualificationDetail
    {
        public QualificationDetail(IList<Qualification> qualifications)
        {
            Qualifications = qualifications;
        }

        public IList<Qualification> Qualifications { get; set; }

        internal void Initialize(IRepository<DictionaryValue, Guid> dictionaryValuesRepo)
        {
            Qualifications.ForEach(x => x.DicValuesProxy = dictionaryValuesRepo);
        }
    }

    public class Qualification
    {
        [JsonIgnore]
        public IRepository<DictionaryValue, Guid> DicValuesProxy;
        public Qualification()
        {

        }

        public int Id { get; set; }
        [JsonIgnore]
        private string degree;
        public string GetDegreeValue
        {
            get
            {
                try
                {
                    if (DegreeId != null && DegreeId != Guid.Empty)
                    {
                        degree = DicValuesProxy.First(x => x.Id == DegreeId).Value;
                    }
                }
                catch { }
                return degree;
            }
            set { degree = value; }
        }
        public Guid DegreeId { get; set; }

        [JsonIgnore]
        private string institution;
        public string GetInstitutionValue
        {
            get
            {
                try
                {
                    if (InstitutionId != null && InstitutionId != Guid.Empty)
                    {
                        institution = DicValuesProxy.First(x => x.Id == InstitutionId).Value;
                    }
                }
                catch { }

                return institution;
            }
            set { institution = value; }
        }
        public Guid InstitutionId { get; set; }
        public string FromDate { get; set; }
        public string FromHDate { get; set; }
        public string ToDate { get; set; }
        public string ToHDate { get; set; }
    }
}
