using CERP.App;
using CERP.App.Helpers;
using CERP.Base;
using CERP.FM;
using CERP.HR.Employees;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure
{
    public class OS_DepartmentTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_DepartmentTemplate_Dto()
        {
        }

        public string Name { get; set; }
        public string NameLocalized { get; set; }
        public string Code { get; set; }

        //public OS_DepartmentPositionTemplate_Dto DepartmentHead { get; set; }
        //public int DepartmentHeadId { get; set; }

        public DateTime ValidityFromDate { get; set; }
        public DateTime ValidityToDate { get; set; }

        public string ReviewPeriodDescription { get => EnumExtensions.GetDescription(ReviewPeriod); set => ReviewPeriod = EnumExtensions.GetValueFromDescription<OS_ReviewPeriod>(value); }
        public OS_ReviewPeriod ReviewPeriod { get; set; }
        public int? ReviewPeriodDays { get; set; }

        public string GetDepartmentPositionsString { get
            {
                string result = "";
                try
                {
                    for (int i = 0; i < PositionTemplates.Count; i++)
                    {
                        OS_PositionTemplate_Dto curPos = PositionTemplates[i];
                        result += curPos.Name + (i == PositionTemplates.Count - 1 ? "" : ", ");
                    }
                }
                catch (Exception ex)
                {

                }
                return result == "" ? "-" : result;
            }
        }
        public List<OS_PositionTemplate_Dto> PositionTemplates { get; set; } = new List<OS_PositionTemplate_Dto>();

        public bool ContainsDepartment(int id, bool state = false)
        {
            bool result = state;
            if (!state && SubDepartmentTemplates != null && SubDepartmentTemplates.Count > 0)
                result = SubDepartmentTemplates.Any(x => x.SubDepartmentTemplateId == id || x.SubDepartmentTemplate.ContainsDepartment(id, state));
            return result;
        }
        public string GetDepartmentStructure()
        {
            string result = Name;
            try
            {
                for (int i = 0; i < SubDepartmentTemplates.Count; i++)
                {
                    OS_DepartmentSubDepartmentTemplate_Dto curSubDep = SubDepartmentTemplates[i];
                    string prefix = i == 0 ? ">" : "";
                    result += $" {prefix} (" + curSubDep.SubDepartmentTemplate.Name;
                    if (curSubDep.SubDepartmentTemplate.SubDepartmentTemplates.Count > 0)
                    {
                        for (int y = 0; y < curSubDep.SubDepartmentTemplate.SubDepartmentTemplates.Count; y++)
                        {
                            result += " > " + curSubDep.SubDepartmentTemplate.SubDepartmentTemplates[y].SubDepartmentTemplate.GetDepartmentStructure();
                        }
                        //result += ")";
                    }
                    result += (i == SubDepartmentTemplates.Count - 1 ? "" : "), ");
                }
                result += SubDepartmentTemplates.Count == 0 ? "" : ")";
            }
            catch (Exception ex)
            {

            }
            return result == "" ? "-" : result;
        }
        public string GetDepartmentStructureString { get => GetDepartmentStructure(); }
        public List<OS_DepartmentSubDepartmentTemplate_Dto> SubDepartmentTemplates { get; set; } = new List<OS_DepartmentSubDepartmentTemplate_Dto>();
        public List<OS_DepartmentCostCenterTemplate_Dto> DepartmentCostCenterTemplates { get; set; } = new List<OS_DepartmentCostCenterTemplate_Dto>();
    }

    public class OS_DepartmentCostCenterTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_DepartmentTemplate_Dto DepartmentTemplate { get; set; }
        public int DepartmentTemplateId { get; set; }

        public DictionaryValue_Dto CostCenter { get; set; }
        public Guid CostCenterId { get; set; }

        public double Percentage { get; set; }
    }
    public class OS_DepartmentPositionTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_DepartmentTemplate_Dto DepartmentTemplate { get; set; }
        public int DepartmentTemplateId { get; set; }

        public OS_PositionTemplate_Dto PositionTemplate { get; set; }
        public int PositionTemplateId { get; set; }
    }
    public class OS_DepartmentSubDepartmentTemplate_Dto : AuditedEntityTenantDto<int>
    {
        public OS_DepartmentTemplate_Dto DepartmentTemplate { get; set; }
        public int DepartmentTemplateId { get; set; }

        public string Name { get; set; }

        public string SubDepartmentRelationshipTypeDescription { get => EnumExtensions.GetDescription(SubDepartmentRelationshipType); set => SubDepartmentRelationshipType = EnumExtensions.GetValueFromDescription<OS_SubDepartmentRelationshipType>(value); }
        public OS_SubDepartmentRelationshipType SubDepartmentRelationshipType { get; set; }

        public OS_DepartmentTemplate_Dto SubDepartmentTemplate { get; set; }
        public int SubDepartmentTemplateId { get; set; }
    }
}
