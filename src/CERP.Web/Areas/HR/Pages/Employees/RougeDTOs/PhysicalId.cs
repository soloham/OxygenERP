using CERP.App;
using CERP.AppServices.HR.DepartmentService;
using CERP.Attributes;
using CERP.CERP.HR.Documents;
using CERP.HR.Documents;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace CERP.HR.EMPLOYEE.RougeDTOs
{
    public class PhysicalId<T>
    {
        [JsonIgnore]
        public IRepository<DictionaryValue, Guid> DicValuesProxy;
        [JsonIgnore]
        public documentAppService DocAppServiceProxy;

        public PhysicalId()
        {

        }

        public int Id { get; set; }

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

        [CustomAudited]
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
        [CustomAudited]
        public Guid IssuedFromId { get; set; }
        [CustomAudited]
        public string JobTitle { get; set; }
        [CustomAudited]
        public string Sponsor { get; set; }
        [CustomAudited]
        public DateTime IssuedDate { get; set; }
        [CustomAudited]
        public DateTime EndDate { get; set; }
        [JsonIgnore]
        public Document Document;
        public Document GetDocument
        {
            get
            {
                try
                {
                    if (SoftCopy != "")
                    {
                        Document document = DocAppServiceProxy.Repository.First(x => x.Id == Guid.Parse(SoftCopy));
                        Document = document;
                    }
                }
                catch(Exception ex) 
                { 
                    Document = new Document(); 
                }

                return Document;
            }
            set
            {
                Document = value;
            }
        }
        [CustomAudited]
        public string SoftCopy { get; set; }


        [JsonIgnore]
        private string parentName;
        [CustomAudited]
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
        [CustomAudited]
        public T ParentId { get; set; }
        [CustomAudited]
        public string GetParentNameLocalized { get; internal set; }
    }
}
