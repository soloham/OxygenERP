using CERP.App;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace CERP.HR.EMPLOYEE.RougeDTOs
{
    public class PhysicalId<T>
    {
        [JsonIgnore]
        public IRepository<DictionaryValue, Guid> DicValuesProxy;

        public PhysicalId()
        {

        }


        [JsonIgnore]
        private string idType;
        public string GetIDTypeValue
        {
            get
            {
                try
                {
                    if (IDTypeId != null && IDTypeId != Guid.Empty)
                    {
                        idType = DicValuesProxy.First(x => x.Id == IDTypeId).Value;
                    }
                }
                catch { }

                return idType;
            }
            set { idType = value; }
        }
        public Guid IDTypeId { get; set; }
        public string IDNumber { get; set; }


        [JsonIgnore]
        private string issuedFrom;
        public string GetIssuedFromValue
        {
            get
            {
                try
                {
                    if (IssuedFromId != null && IssuedFromId != Guid.Empty)
                    {
                        issuedFrom = DicValuesProxy.First(x => x.Id == IssuedFromId).Value;
                    }
                }
                catch { }


                return issuedFrom;
            }
            set { issuedFrom = value; }
        }
        public Guid IssuedFromId { get; set; }
        public string JobTitle { get; set; }
        public string Sponsor { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime EndDate { get; set; }
        public string IDCopy { get; set; }


        [JsonIgnore]
        private string parentName;
        public string GetParentName
        {
            get
            {
                try
                {
                    if (Holder != null)
                    {
                        parentName = Holder.Name;
                    }
                }
                catch { }


                return parentName;
            }
            set { parentName = value; }
        }
        [JsonIgnore]
        public Dependant Holder;
        public T ParentId { get; set; }
    }
}
