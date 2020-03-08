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
    public class ContactInformation
    {
        public ContactInformation(Contact primaryContact, NationalAddress nationalAddress, IList<Contact> secondaryContacts)
        {
            PrimaryContact = primaryContact;
            NationalAddress = nationalAddress;
            SecondaryContacts = secondaryContacts;
        }

        public Contact PrimaryContact { get; set; }
        public NationalAddress NationalAddress { get; set; }
        public IList<Contact> SecondaryContacts { get; set; }

        internal void Initialize(IRepository<DictionaryValue, Guid> dictionaryValuesRepo)
        {
            SecondaryContacts.ForEach(x => x.DicValuesProxy = dictionaryValuesRepo);
            PrimaryContact.DicValuesProxy = dictionaryValuesRepo;
        }
    }

    public class Contact
    {
        [JsonIgnore]
        public IRepository<DictionaryValue, Guid> DicValuesProxy;

        [JsonIgnore]
        private string relationType;
        public string GetRelationType
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
        public Guid? RelationId { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        private string country;
        public string GetCountryName
        {
            get
            {
                try
                {
                    if (RelationId != null && RelationId != Guid.Empty)
                    {
                        country = DicValuesProxy.First(x => x.Id == RelationId).Value;
                    }
                }
                catch { }

                return country;
            }
            set { country = value; }
        }
        public Guid CountryId { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string POBox { get; set; }
    }
    public class NationalAddress
    {
        public string BuildingNumber { get; set; }
        public string StreetName { get; set; }
        public string NADistrict { get; set; }
        public string NACity { get; set; }
        public string NAPostalCode { get; set; }
        public string NAAdditionalNumber { get; set; }
    }
}
