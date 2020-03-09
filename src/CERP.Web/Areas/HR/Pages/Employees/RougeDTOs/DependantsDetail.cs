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
    public class DependantsDetail
    {
        public DependantsDetail(IList<Dependant> dependants, IList<PhysicalId<int>> physicalIds)
        {
            Dependants = dependants;
            PhysicalIds = physicalIds;
        }

        public IList<Dependant> Dependants { get; set; }
        public IList<PhysicalId<int>> PhysicalIds { get; set; }

        internal void Initialize(IRepository<DictionaryValue, Guid> dictionaryValuesRepo)
        {
            Dependants.ForEach(x => x.DicValuesProxy = dictionaryValuesRepo);
            PhysicalIds.ForEach(x => x.DicValuesProxy = dictionaryValuesRepo);
            PhysicalIds.ForEach(x => x.Holder = Dependants.First(x1 => x1.Id == x.ParentId));
        }
    }

    public class Dependant
    {
        [JsonIgnore]
        public IRepository<DictionaryValue, Guid> DicValuesProxy;
        public Dependant()
        {

        }

        public int Id { get; set; }

        [JsonIgnore]
        private string relationType;
        public string GetRelationTypeValue
        {
            get
            {
                try
                {
                    if (RelationId != null && RelationId != Guid.Empty)
                    {
                        relationType = DicValuesProxy.First(x => x.Id == RelationId).Value;
                    }
                }
                catch { }

                return relationType;
            }
            set { relationType = value; }
        }
        public Guid RelationId { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public string DOB_H { get; set; }

        [JsonIgnore]
        private string birthPlace;
        public string GetPOBValue
        {
            get
            {
                try
                {
                    if (BirthPlaceId != null && BirthPlaceId != Guid.Empty)
                    {
                        birthPlace = DicValuesProxy.First(x => x.Id == BirthPlaceId).Value;
                    }
                }
                catch { }

                return birthPlace;
            }
            set { birthPlace = value; }
        }
        public Guid BirthPlaceId { get; set; }
        [JsonIgnore] 
        private string nationality;
        public string GetNationalityValue
        {
            get
            {
                try
                {
                    if (NationalityId != null && NationalityId != Guid.Empty)
                    {
                        nationality = DicValuesProxy.First(x => x.Id == NationalityId).Value;
                    }
                }
                catch { }

                return nationality;
            }
            set { nationality = value; }
        }
        public Guid NationalityId { get; set; }
        [JsonIgnore]
        private string gender;
        public string GetGenderValue
        {
            get
            {
                try
                {
                    if (GenderId != null && GenderId != Guid.Empty)
                    {
                        gender = DicValuesProxy.First(x => x.Id == GenderId).Value;
                    }
                }
                catch { }

                return gender;
            }
            set { gender = value; }
        }
        public Guid GenderId { get; set; }

    }
}
