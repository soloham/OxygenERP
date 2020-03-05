using CERP.App;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.HR.Employees
{
    public class Employee : FullAuditedAggregateRoot<Guid>
    {
        public Employee()
        {

        }
        public Employee(Guid guid)
        {
            Id = guid;
        }

        #region General Info
        public string FirstName { get; set; }
        public string FirstNameLocalized { get; set; }
        public string MiddleName { get; set; }
        public string MiddleNameLocalized { get; set; }
        public string LastName { get; set; }
        public string LastNameLocalized { get; set; }
        public string FamilyName { get; set; }
        public string FamilyNameLocalized { get; set; }

        public DateTime DOB { get; set; }
        public DateTime DOB_H { get; set; }


        [ForeignKey("POB_ID")]
        public DictionaryValue POB { get; set; }
        public Guid POB_ID { get; set; }

        [ForeignKey("NationalityId")]
        public DictionaryValue Nationality { get; set; }
        public Guid NationalityId { get; set; }

        [ForeignKey("GenderId")]
        public DictionaryValue Gender { get; set; }
        public Guid GenderId { get; set; }

        [ForeignKey("MaritalStatusId")]
        public DictionaryValue MaritalStatus { get; set; }
        public Guid MaritalStatusId { get; set; }

        public int NoOfDependents { get; set; }

        [ForeignKey("BloodGroupId")]
        public DictionaryValue? BloodGroup { get; set; }
        public Guid? BloodGroupId { get; set; }

        [ForeignKey("ReligionId")]
        public DictionaryValue Religion { get; set; }
        public Guid ReligionId { get; set; }
        #endregion

    }
}
