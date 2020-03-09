﻿using CERP.App;
using CERP.HR.EMPLOYEE.DTOs;
using CERP.Setup.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.HR.Employees.DTOs
{
    public class Employee_Dto : FullAuditedEntityDto<Guid>
    {
        public Employee_Dto()
        {

        }
        public Employee_Dto(Guid guid)
        {
            Id = guid;
        }

        public string GetReferenceId { get => Id.ToString().Substring(0, 4); }

        #region General Info
        public string Name { get => FirstName + " " + LastName; }
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

        public DictionaryValue_Dto POB { get; set; }
        public Guid POB_ID { get; set; }

        public DictionaryValue_Dto Nationality { get; set; }
        public Guid NationalityId { get; set; }

        public DictionaryValue_Dto Gender { get; set; }
        public Guid GenderId { get; set; }

        public DictionaryValue_Dto MaritalStatus { get; set; }
        public Guid MaritalStatusId { get; set; }

        public int NoOfDependents { get; set; }

        public DictionaryValue_Dto? BloodGroup { get; set; }
        public Guid? BloodGroupId { get; set; }

        public DictionaryValue_Dto Religion { get; set; }
        public Guid ReligionId { get; set; }

        public DictionaryValue_Dto EmployeeStatus { get; set; }
        public Guid EmployeeStatusId { get; set; }
        #endregion


        #region ID & Residence
        #endregion


        #region Contract Details
        [ForeignKey("PositionId")]
        public Position_Dto Position { get; set; }
        public Guid PositionId { get; set; }
        #endregion

        #region Workshifts
        public WorkShift_Dto WorkShift { get; set; }
        public int WorkShiftId { get; set; }
        #endregion

        public IDictionary<string, object> ExtraProperties { get; set; } 
    }
}