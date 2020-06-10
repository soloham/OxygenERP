using CERP.App;
using CERP.Attributes;
using CERP.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp;

namespace CERP.HR.Documents
{
    public class Dependant_Dto : AuditedEntityTenantDto<int>
    {
        public Dependant_Dto()
        {

        }

        public DictionaryValue_Dto RelationshipType { get; set; }
        public Guid RelationshipTypeId { get; set; }
        public string FirstName { get; set; }
        public string FirstNameLocalized { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public DictionaryValue_Dto BirthCountry { get; set; }
        public Guid BirthCountryId { get; set; }
        public string DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string BioAttachment { get; set; }

        public List<DependantNationalIdentity_Dto> NationalIdentities { get; set; }
        public List<DependantPassportTravelDocument_Dto> PassportTravelDocuments { get; set; }
    }

    public class DependantNationalIdentity_Dto : AuditedEntityTenantDto<int> 
    {
        public virtual Dependant_Dto Dependant { get; set; }
        public int DependantId { get; set; }
        public virtual NationalIdentity_Dto NationalIdentity { get; set; }
        public int NationalIdentityId { get; set; }

    }
    public class DependantPassportTravelDocument_Dto : AuditedEntityTenantDto<int>
    {
        public virtual Dependant_Dto Dependant { get; set; }
        public int DependantId { get; set; }
        public virtual PassportTravelDocument_Dto PassportTravelDocument { get; set; }
        public int PassportTravelDocumentId { get; set; }
    }
}
