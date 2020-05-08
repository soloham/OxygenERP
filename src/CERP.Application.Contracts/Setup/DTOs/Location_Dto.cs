using CERP.App.Helpers;
using CERP.Base;
using CERP.FM;
using CERP.FM.DTOs;
using CERP.HR.Employees;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.IO;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.Setup.DTOs
{
    public class LocationTemplate_Dto : AuditedEntityTenantDto<Guid>
    {
        public LocationTemplate_Dto()
        {

        }
        public LocationTemplate_Dto(Guid id)
        {
            Id = id;
        }

        public void Initialize()
        {
            try
            {
                string value = ExtraProperties["addresses"].ToString();
                List<LocationAddress> addresses = JsonConvert.DeserializeObject<List<LocationAddress>>(value);
                for (int i = 0; i < addresses.Count; i++)
                {
                    addresses[i].Id = Id.ToString();
                }
                this.SetProperty("addresses", addresses);
            }
            catch(Exception ex)
            {

            }
        }

        public string LocationName { get; set; }
        public string LocationNameLocalized { get; set; }
        public string LocationCode { get; set; }

        public string StatusDescription { get => EnumExtensions.GetDescription(Status); set => Status = EnumExtensions.GetValueFromDescription<LocationStatus>(value); }
        public LocationStatus Status { get; set; }
    }

    public class LocationAddress 
    {
        public string Id { get; set; }

        public string geoPhone { get; set; }
        public string geoMobile { get; set; }
        public string geoFax { get; set; }
        public string geoEmail { get; set; }
        public string geoCountry { get; set; }
        public string geoCity { get; set; }
        public string geoZip { get; set; }
        public string geoPO { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }

        public bool hasNationalAddress { get; set; }

        public string buildingNumber { get; set; }
        public string streetName { get; set; }
        public string naDistrict { get; set; }
        public string naCity { get; set; }
        public string naPostalCode { get; set; }
        public string naAdditionalNumber { get; set; }
    }

}
