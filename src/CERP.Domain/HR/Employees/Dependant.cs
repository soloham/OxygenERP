using CERP.App;
using CERP.Attributes;
using CERP.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class Dependant : AuditedAggregateTenantRoot<int>
    {
        public Dependant()
        {

        }

        public DictionaryValue RelationshipType { get; set; }
        [CustomAudited]
        public Guid RelationshipTypeId { get; set; }

        [CustomAudited]
        public string FirstName { get; set; }
        [CustomAudited]
        public string FirstNameLocalized { get; set; }
        [CustomAudited]
        public string MiddleName { get; set; }
        [CustomAudited]
        public string LastName { get; set; }

        public DictionaryValue BirthCountry { get; set; }
        [CustomAudited]
        public Guid BirthCountryId { get; set; }
        [CustomAudited]
        public string DateOfBirth { get; set; }
        [CustomAudited]
        public string PlaceOfBirth { get; set; }
        [CustomAudited]
        public string BioAttachment { get; set; }

        public virtual ICollection<DependantNationalIdentity> NationalIdentities { get; set; }
        public virtual ICollection<DependantPassportTravelDocument> PassportTravelDocuments { get; set; }
    }

    public class DependantNationalIdentity : AuditedAggregateTenantRoot<int> 
    {
        public virtual Dependant Dependant { get; set; }
        public int DependantId { get; set; }
        public virtual NationalIdentity NationalIdentity { get; set; }
        public int NationalIdentityId { get; set; }

    }
    public class DependantPassportTravelDocument : AuditedAggregateTenantRoot<int>
    {
        public virtual Dependant Dependant { get; set; }
        public int DependantId { get; set; }
        public virtual PassportTravelDocument PassportTravelDocument { get; set; }
        public int PassportTravelDocumentId { get; set; }
    }
}
