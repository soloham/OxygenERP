using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CERP.App;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Syncfusion.EJ2.Grids;
using Volo.Abp.AuditLogging;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Volo.Abp.Auditing;
using CERP.CERP.HR.Documents;
using CERP.App.CustomEntityHistorySystem;
using CERP.Attributes;
using CERP.ApplicationContracts.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.OrganizationalManagement.OrganizationStructure;
using CERP.AppServices.HR.OrganizationalManagement.OrganizationStructure;
using CERP.HR.Setup.OrganizationalManagement.OrganizationStructure;

namespace CERP.Web.Areas.HR.Setup.OrganizationalManagement.OrganizationStructure.Pages.OrganizationStructures
{
    public class ListModel : CERPPageModel
    {
        public IWebHostEnvironment webHostEnvironment { get; set; }
        public IRepository<DictionaryValue, Guid> DictionaryValuesRepo { get; set; }
        public IAuditLogRepository AuditLogsRepo { get; set; }

        public OS_OrganizationStructureTemplateAppService OS_OrganizationStructureTemplateAppService { get; set; }
        public OS_PositionTemplateAppService OS_PositionTemplateAppService { get; set; }

        public IAuditingManager AuditingManager { get; set; }
        public IRepository<CustomEntityChange> CustomEntityChangesRepo { get; set; }

        public ListModel(IJsonSerializer jsonSerializer, IRepository<DictionaryValue, Guid> dictionaryValuesRepo, IWebHostEnvironment webHostEnvironment, IAuditLogRepository auditLogsRepo, OS_OrganizationStructureTemplateAppService oS_OrganizationStructureTemplateAppService, OS_PositionTemplateAppService oS_PositionTemplateAppService)
        {
            JsonSerializer = jsonSerializer;
            DictionaryValuesRepo = dictionaryValuesRepo;
            this.webHostEnvironment = webHostEnvironment;
            AuditLogsRepo = auditLogsRepo;
            OS_OrganizationStructureTemplateAppService = oS_OrganizationStructureTemplateAppService;
            OS_PositionTemplateAppService = oS_PositionTemplateAppService;
        }

        public IJsonSerializer JsonSerializer { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostOrganizationStructureTemplate()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var FormData = Request.Form;

                    OS_OrganizationStructureTemplate_Dto organizationStructureTemplate_Dto = JsonSerializer.Deserialize<OS_OrganizationStructureTemplate_Dto>(FormData["info"]);
                    StructureVM structureVM = new StructureVM() { Structure = JsonSerializer.Deserialize<List<NodeVM>>(FormData["structure"]) };
                    bool IsEditing = organizationStructureTemplate_Dto.Id > 0;
                    if (IsEditing)
                    {
                        OS_OrganizationStructureTemplate curOrganizationStructureTemplate = await OS_OrganizationStructureTemplateAppService.Repository.GetAsync(organizationStructureTemplate_Dto.Id);
                        
                        if (AuditingManager.Current != null)
                        {
                            EntityChangeInfo entityChangeInfo = new EntityChangeInfo();

                            entityChangeInfo.EntityId = organizationStructureTemplate_Dto.Id.ToString();
                            entityChangeInfo.EntityTenantId = organizationStructureTemplate_Dto.TenantId;
                            entityChangeInfo.ChangeTime = DateTime.Now;
                            entityChangeInfo.ChangeType = EntityChangeType.Updated;
                            entityChangeInfo.EntityTypeFullName = typeof(OS_OrganizationStructureTemplate).FullName;

                            entityChangeInfo.PropertyChanges = new List<EntityPropertyChangeInfo>();
                            List<EntityPropertyChangeInfo> entityPropertyChanges = new List<EntityPropertyChangeInfo>();
                            var auditProps = typeof(OS_OrganizationStructureTemplate).GetProperties().Where(x => Attribute.IsDefined(x, typeof(CustomAuditedAttribute))).ToList();

                            OS_OrganizationStructureTemplate mappedInput = ObjectMapper.Map<OS_OrganizationStructureTemplate_Dto, OS_OrganizationStructureTemplate>(organizationStructureTemplate_Dto);
                            foreach (var prop in auditProps)
                            {
                                EntityPropertyChangeInfo propertyChange = new EntityPropertyChangeInfo();
                                object origVal = prop.GetValue(curOrganizationStructureTemplate);
                                propertyChange.OriginalValue = origVal == null ? "" : origVal.ToString();
                                object newVal = prop.GetValue(mappedInput);
                                propertyChange.NewValue = newVal == null ? "" : newVal.ToString();
                                if (propertyChange.OriginalValue == propertyChange.NewValue) continue;

                                propertyChange.PropertyName = prop.Name;

                                if (prop.Name.EndsWith("Id"))
                                {
                                    try
                                    {
                                        string valuePropName = prop.Name.TrimEnd('d', 'I');
                                        propertyChange.PropertyName = valuePropName;

                                        var valueProp = typeof(OS_OrganizationStructureTemplate).GetProperty(valuePropName);

                                        DictionaryValue _origValObj = (DictionaryValue)valueProp.GetValue(organizationStructureTemplate_Dto);
                                        if (_origValObj == null) _origValObj = await DictionaryValuesRepo.GetAsync((Guid)origVal);
                                        string _origVal = _origValObj.Value;
                                        propertyChange.OriginalValue = origVal == null ? "" : _origVal;
                                        DictionaryValue _newValObj = (DictionaryValue)valueProp.GetValue(mappedInput);
                                        if (_newValObj == null) _newValObj = await DictionaryValuesRepo.GetAsync((Guid)newVal);
                                        string _newVal = _newValObj.Value;
                                        propertyChange.NewValue = _newValObj == null ? "" : _newVal;
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }

                                propertyChange.PropertyTypeFullName = prop.Name.GetType().FullName;

                                entityChangeInfo.PropertyChanges.Add(propertyChange);
                            }

                            #region ExtraProperties
                            //List<EmployeeExtraPropertyHistory> allExtraPropertyHistories = new List<EmployeeExtraPropertyHistory>();
                            //if (organizationStructureTemplate_Dto.ExtraProperties != curOrganizationStructureTemplate.ExtraProperties)
                            //{
                            //    //GeneralInfo oldGeneralInfo = organizationStructure.GetProperty<GeneralInfo>("generalInfo");
                            //    //List<EmployeeExtraPropertyHistory> physicalIdsHistory = new List<EmployeeExtraPropertyHistory>();
                            //    //var generalInfoPhysicalIdAuditProps = typeof(PhysicalID).GetProperties().Where(x => Attribute.IsDefined(x, typeof(CustomAuditedAttribute))).ToList();
                            //    //List<PhysicalId<Guid>> NewPhysicalIds = generalInfo.PhysicalIds.Where(x => !oldGeneralInfo.PhysicalIds.Any(y => y.Id == x.Id)).ToList();
                            //    //List<PhysicalId<Guid>> UpdatedPhysicalIds = generalInfo.PhysicalIds.Where(x => oldGeneralInfo.PhysicalIds.Any(y => y.Id == x.Id)).ToList();
                            //    //List<PhysicalId<Guid>> DeletedPhysicalIds = oldGeneralInfo.PhysicalIds.Where(x => !generalInfo.PhysicalIds.Any(y => y.Id == x.Id)).ToList();
                            //    //for (int i = 0; i < NewPhysicalIds.Count; i++)
                            //    //{
                            //    //    PhysicalId<Guid> curPhId = generalInfo.PhysicalIds[i];

                            //    //    EmployeeExtraPropertyHistory newPhIdHistory = new EmployeeExtraPropertyHistory(2, "Physical Id", curPhId.IDNumber, "Created");
                            //    //    physicalIdsHistory.Add(newPhIdHistory);
                            //    //}
                            //    //for (int i = 0; i < UpdatedPhysicalIds.Count; i++)
                            //    //{
                            //    //    PhysicalId<Guid> curPhId = generalInfo.PhysicalIds[i];
                            //    //    PhysicalId<Guid> oldPhId = oldGeneralInfo.PhysicalIds.First(x => x.Id == curPhId.Id);

                            //    //    EmployeeExtraPropertyHistory updatedPhIdHistory = new EmployeeExtraPropertyHistory(2, "Physical Id", curPhId.IDNumber, "Updated");
                            //    //    foreach (var prop in generalInfoPhysicalIdAuditProps)
                            //    //    {
                            //    //        updatedPhIdHistory.PropertyChanges = new List<EmployeeTypePropertyChange>();

                            //    //        EmployeeTypePropertyChange propertyChange = new EmployeeTypePropertyChange();

                            //    //        object origVal = prop.GetValue(oldPhId);
                            //    //        propertyChange.OriginalValue = origVal == null ? "" : origVal.ToString();
                            //    //        object newVal = prop.GetValue(curPhId);
                            //    //        propertyChange.NewValue = newVal == null ? "" : newVal.ToString();
                            //    //        if (propertyChange.OriginalValue == propertyChange.NewValue) continue;

                            //    //        propertyChange.PropertyName = prop.Name;

                            //    //        if (prop.Name.EndsWith("Id"))
                            //    //        {
                            //    //            try
                            //    //            {
                            //    //                string valuePropName = prop.Name.TrimEnd('d', 'I');
                            //    //                propertyChange.PropertyName = valuePropName;

                            //    //                var valueProp = typeof(PhysicalID).GetProperty(valuePropName);

                            //    //                DictionaryValue _origValObj = (DictionaryValue)valueProp.GetValue(oldPhId);
                            //    //                if (_origValObj == null) _origValObj = await DictionaryValuesRepo.GetAsync((Guid)origVal);
                            //    //                string _origVal = _origValObj.Value;
                            //    //                propertyChange.OriginalValue = origVal == null ? "" : _origVal;
                            //    //                DictionaryValue _newValObj = (DictionaryValue)valueProp.GetValue(curPhId);
                            //    //                if (_newValObj == null) _newValObj = await DictionaryValuesRepo.GetAsync((Guid)newVal);
                            //    //                string _newVal = _newValObj.Value;
                            //    //                propertyChange.NewValue = _newValObj == null ? "" : _newVal;
                            //    //            }
                            //    //            catch (Exception ex)
                            //    //            {

                            //    //            }
                            //    //        }

                            //    //        propertyChange.PropertyTypeFullName = prop.Name.GetType().FullName;

                            //    //        updatedPhIdHistory.PropertyChanges.Add(propertyChange);
                            //    //    }
                            //    //    physicalIdsHistory.Add(updatedPhIdHistory);
                            //    //}
                            //    //for (int i = 0; i < DeletedPhysicalIds.Count; i++)
                            //    //{
                            //    //    PhysicalId<Guid> curPhId = generalInfo.PhysicalIds[i];

                            //    //    EmployeeExtraPropertyHistory deletedPhIdHistory = new EmployeeExtraPropertyHistory(2, "Physical Id", curPhId.IDNumber, "Deleted");
                            //    //    physicalIdsHistory.Add(deletedPhIdHistory);
                            //    //}

                            //    entityChangeInfo.SetProperty("extraPropertiesHistory", allExtraPropertyHistories);
                            //}
                            #endregion

                            AuditingManager.Current.Log.EntityChanges.Add(entityChangeInfo);
                        }

                        curOrganizationStructureTemplate.Name = organizationStructureTemplate_Dto.Name;
                        curOrganizationStructureTemplate.NameLocalized = organizationStructureTemplate_Dto.NameLocalized;
                        curOrganizationStructureTemplate.Code = organizationStructureTemplate_Dto.Code;
                       
                        curOrganizationStructureTemplate.ReviewPeriod = organizationStructureTemplate_Dto.ReviewPeriod;
                        curOrganizationStructureTemplate.ValidityFromDate = organizationStructureTemplate_Dto.ValidityFromDate;
                        curOrganizationStructureTemplate.ValidityToDate = organizationStructureTemplate_Dto.ValidityToDate;

                        curOrganizationStructureTemplate.SetProperty("Structure", FormData["structure"]);

                        OS_OrganizationStructureTemplate_Dto updated = ObjectMapper.Map<OS_OrganizationStructureTemplate, OS_OrganizationStructureTemplate_Dto>(await OS_OrganizationStructureTemplateAppService.Repository.UpdateAsync(curOrganizationStructureTemplate));
                        OS_OrganizationStructureTemplate_Dto updatedDto = await OS_OrganizationStructureTemplateAppService.GetOrganizationStructureTemplateAsync(updated.Id);
                        return StatusCode(200, updatedDto);
                    }
                    else
                    {
                        organizationStructureTemplate_Dto.Id = 0;
                        //organizationStructureTemplate_Dto.PositionTemplates.ForEach(x => { x.Id = 0; x.Id = x.Id; });
                        //organizationStructureTemplate_Dto.SubOrganizationStructureTemplates.ForEach(x => { x.Id = 0; x.SubOrganizationStructureTemplateId = x.SubOrganizationStructureTemplate.Id; x.SubOrganizationStructureTemplate = null; });
                        organizationStructureTemplate_Dto.SetProperty("Structure", FormData["structure"]);
                        organizationStructureTemplate_Dto.OrganizationStructureTemplateBusinessUnits = new List<OS_OrganizationStructureTemplateBusinessUnit_Dto>();
                        //organizationStructureTemplate_Dto.OrganizationStructureTemplateDivisions = new List<OS_OrganizationStructureTemplateDivision_Dto>();
                        //organizationStructureTemplate_Dto.OrganizationStructureTemplateDepartments = new List<OS_OrganizationStructureTemplateDepartment_Dto>();
                        organizationStructureTemplate_Dto.OrganizationStructureTemplatePositions = new List<OS_OrganizationStructureTemplatePosition_Dto>();
                        
                        var OrganizationStructureTemplateBusinessUnits = new List<OS_OrganizationStructureTemplateBusinessUnit_Dto>();
                        var OrganizationStructureTemplateDivisions = new List<OS_OrganizationStructureTemplateDivision_Dto>();
                        var OrganizationStructureTemplateDepartments = new List<OS_OrganizationStructureTemplateDepartment_Dto>();
                        var OrganizationStructureTemplatePositions = new List<OS_OrganizationStructureTemplatePosition_Dto>();

                        structureVM.Structure.Reverse();
                        for (int i = 0; i < structureVM.Structure.Count; i++)
                        {
                            NodeVM structuralNode = structureVM.Structure[i];

                            UnitVM unit = structuralNode._unit;
                            switch (structuralNode.Type)
                            {
                                case "Business Unit":
                                    OS_OrganizationStructureTemplateBusinessUnit_Dto orgStructureBusinessUnit = new OS_OrganizationStructureTemplateBusinessUnit_Dto();
                                    orgStructureBusinessUnit.Id = structuralNode.Id;
                                    orgStructureBusinessUnit.BusinessUnitTemplateId = unit.Id;
                                    orgStructureBusinessUnit.ValidityFromDate = DateTime.Parse(unit.ValidityFromDate);
                                    orgStructureBusinessUnit.ValidityToDate = DateTime.Parse(unit.ValidityToDate);

                                    if (unit.UnitDetails != null)
                                    {
                                        orgStructureBusinessUnit.ValidityFromDate = DateTime.Parse(unit.UnitDetails.ValidityFromDate.ToString());
                                        orgStructureBusinessUnit.ValidityToDate = DateTime.Parse(unit.UnitDetails.ValidityToDate.ToString());


                                        orgStructureBusinessUnit.OrganizationStructureTemplateBusinessUnitCostCenters = new List<OS_OrganizationStructureTemplateBusinessUnitCostCenter_Dto>();
                                        List<CostCenterVM> CostCenters = JsonSerializer.Deserialize<List<CostCenterVM>>(unit.UnitDetails.costCenters.ToString());
                                        for (int y = 0; y < CostCenters.Count; y++)
                                        {
                                            CostCenterVM cc = CostCenters[y];
                                            OS_OrganizationStructureTemplateBusinessUnitCostCenter_Dto orgBUCC = new OS_OrganizationStructureTemplateBusinessUnitCostCenter_Dto();
                                            orgBUCC.CostCenterId = cc.Id;
                                            orgBUCC.Percentage = cc.Percentage;

                                            orgStructureBusinessUnit.OrganizationStructureTemplateBusinessUnitCostCenters.Add(orgBUCC);
                                        }

                                        orgStructureBusinessUnit.OrganizationStructureTemplateBusinessUnitAssociatedPositions = new List<OS_OrganizationStructureTemplateBusinessUnitPosition_Dto>();
                                        List<PositionVM> AssociatedPositions = this.JsonSerializer.Deserialize<List<PositionVM>>((unit.UnitDetails.associations as dynamic).positions.ToString());
                                        for (int y = 0; y < AssociatedPositions.Count; y++)
                                        {
                                            PositionVM p = AssociatedPositions[y];
                                            OS_OrganizationStructureTemplateBusinessUnitPosition_Dto orgBUP = new OS_OrganizationStructureTemplateBusinessUnitPosition_Dto();
                                            orgBUP.PositionTemplateId = p.Id;

                                            orgStructureBusinessUnit.OrganizationStructureTemplateBusinessUnitAssociatedPositions.Add(orgBUP);
                                        }

                                        Guid locId = Guid.Empty;
                                        Guid.TryParse(unit.UnitDetails.BULocationId.ToString(), out locId);
                                        orgStructureBusinessUnit.LocationId = locId;

                                        int headId = int.Parse(unit.UnitDetails.HeadOfBUId.ToString());
                                        orgStructureBusinessUnit.OrganizationStructureTemplateBusinessUnitAssociatedPositions.FirstOrDefault(x => x.PositionTemplateId == headId).IsHead = true;
                                        orgStructureBusinessUnit.OrganizationStructureTemplateBusinessUnitAssociatedPositions.FirstOrDefault(x => x.PositionTemplateId != headId).IsHead = false;

                                        orgStructureBusinessUnit.PaySubGroupId = int.Parse(unit.UnitDetails.BUPaygroupId.ToString());
                                    }

                                    organizationStructureTemplate_Dto.OrganizationStructureTemplateBusinessUnits.Add(orgStructureBusinessUnit);
                                    OrganizationStructureTemplateBusinessUnits.Add(orgStructureBusinessUnit);
                                    break;
                                case "Division":
                                    OS_OrganizationStructureTemplateDivision_Dto orgStructureDivision = new OS_OrganizationStructureTemplateDivision_Dto();
                                    orgStructureDivision.Id = structuralNode.Id;
                                    orgStructureDivision.DivisionTemplateId = unit.Id;
                                    orgStructureDivision.ValidityFromDate = DateTime.Parse(unit.ValidityFromDate);
                                    orgStructureDivision.ValidityToDate = DateTime.Parse(unit.ValidityToDate);

                                    if (unit.UnitDetails != null)
                                    {
                                        orgStructureDivision.ValidityFromDate = DateTime.Parse(unit.UnitDetails.ValidityFromDate.ToString());
                                        orgStructureDivision.ValidityToDate = DateTime.Parse(unit.UnitDetails.ValidityToDate.ToString());

                                        orgStructureDivision.OrganizationStructureTemplateDivisionCostCenters = new List<OS_OrganizationStructureTemplateDivisionCostCenter_Dto>();
                                        List<CostCenterVM> CostCenters = JsonSerializer.Deserialize<List<CostCenterVM>>(unit.UnitDetails.costCenters.ToString());
                                        for (int y = 0; y < CostCenters.Count; y++)
                                        {
                                            CostCenterVM cc = CostCenters[y];
                                            OS_OrganizationStructureTemplateDivisionCostCenter_Dto orgDIVCC = new OS_OrganizationStructureTemplateDivisionCostCenter_Dto();
                                            orgDIVCC.CostCenterId = cc.Id;
                                            orgDIVCC.Percentage = cc.Percentage;

                                            orgStructureDivision.OrganizationStructureTemplateDivisionCostCenters.Add(orgDIVCC);
                                        }

                                        orgStructureDivision.OrganizationStructureTemplateDivisionAssociatedPositions = new List<OS_OrganizationStructureTemplateDivisionPosition_Dto>();
                                        List<PositionVM> AssociatedPositions = this.JsonSerializer.Deserialize<List<PositionVM>>((unit.UnitDetails.associations as dynamic).positions.ToString());
                                        for (int y = 0; y < AssociatedPositions.Count; y++)
                                        {
                                            PositionVM p = AssociatedPositions[y];
                                            OS_OrganizationStructureTemplateDivisionPosition_Dto orgDIVP = new OS_OrganizationStructureTemplateDivisionPosition_Dto();
                                            orgDIVP.PositionTemplateId = p.Id;

                                            orgStructureDivision.OrganizationStructureTemplateDivisionAssociatedPositions.Add(orgDIVP);
                                        }

                                        //Guid locId = Guid.Empty;
                                        //Guid.TryParse(unit.UnitDetails.DIVLocationId.ToString(), out locId);
                                        //orgStructureDivision.LocationId = locId;

                                        int headId = int.Parse(unit.UnitDetails.HeadOfDIVId.ToString());
                                        orgStructureDivision.OrganizationStructureTemplateDivisionAssociatedPositions.FirstOrDefault(x => x.PositionTemplateId == headId).IsHead = true;
                                        orgStructureDivision.OrganizationStructureTemplateDivisionAssociatedPositions.FirstOrDefault(x => x.PositionTemplateId != headId).IsHead = false;

                                        //orgStructureDivision.ParentId = 
                                        //orgStructureDivision.PaySubGroupId = int.Parse(unit.UnitDetails.DIVPaygroupId.ToString());
                                    }

                                    int parentBUId = int.Parse(structuralNode.ParentId.ToString());
                                    var ParentBU = organizationStructureTemplate_Dto.OrganizationStructureTemplateBusinessUnits.FirstOrDefault(x => x.Id == parentBUId);
                                    if (ParentBU.OrganizationStructureTemplateDivisions == null)
                                        ParentBU.OrganizationStructureTemplateDivisions = new List<OS_OrganizationStructureTemplateDivision_Dto>();
                                    ParentBU.OrganizationStructureTemplateDivisions.Add(orgStructureDivision);

                                    OrganizationStructureTemplateDivisions.Add(orgStructureDivision);
                                    //organizationStructureTemplate_Dto.
                                    break;
                                case "Department":
                                    OS_OrganizationStructureTemplateDepartment_Dto orgStructureDepartment = new OS_OrganizationStructureTemplateDepartment_Dto();
                                    orgStructureDepartment.Id = structuralNode.Id;
                                    orgStructureDepartment.DepartmentTemplateId = unit.Id;
                                    orgStructureDepartment.ValidityFromDate = DateTime.Parse(unit.ValidityFromDate);
                                    orgStructureDepartment.ValidityToDate = DateTime.Parse(unit.ValidityToDate);

                                    if (unit.UnitDetails != null)
                                    {
                                        orgStructureDepartment.ValidityFromDate = DateTime.Parse(unit.UnitDetails.ValidityFromDate.ToString());
                                        orgStructureDepartment.ValidityToDate = DateTime.Parse(unit.UnitDetails.ValidityToDate.ToString());

                                        orgStructureDepartment.OrganizationStructureTemplateDepartmentCostCenters = new List<OS_OrganizationStructureTemplateDepartmentCostCenter_Dto>();
                                        List<CostCenterVM> CostCenters = JsonSerializer.Deserialize<List<CostCenterVM>>(unit.UnitDetails.costCenters.ToString());
                                        for (int y = 0; y < CostCenters.Count; y++)
                                        {
                                            CostCenterVM cc = CostCenters[y];
                                            OS_OrganizationStructureTemplateDepartmentCostCenter_Dto orgDEPCC = new OS_OrganizationStructureTemplateDepartmentCostCenter_Dto();
                                            orgDEPCC.CostCenterId = cc.Id;
                                            orgDEPCC.Percentage = cc.Percentage;

                                            orgStructureDepartment.OrganizationStructureTemplateDepartmentCostCenters.Add(orgDEPCC);
                                        }

                                        orgStructureDepartment.OrganizationStructureTemplateDepartmentAssociatedPositions = new List<OS_OrganizationStructureTemplateDepartmentPosition_Dto>();
                                        List<PositionVM> AssociatedPositions = this.JsonSerializer.Deserialize<List<PositionVM>>((unit.UnitDetails.associations as dynamic).positions.ToString());
                                        for (int y = 0; y < AssociatedPositions.Count; y++)
                                        {
                                            PositionVM p = AssociatedPositions[y];
                                            OS_OrganizationStructureTemplateDepartmentPosition_Dto orgDEPP = new OS_OrganizationStructureTemplateDepartmentPosition_Dto();
                                            orgDEPP.PositionTemplateId = p.Id;

                                            orgStructureDepartment.OrganizationStructureTemplateDepartmentAssociatedPositions.Add(orgDEPP);
                                        }

                                        //Guid locId = Guid.Empty;
                                        //Guid.TryParse(unit.UnitDetails.DEPLocationId.ToString(), out locId);
                                        //orgStructureDepartment.LocationId = locId;

                                        int headId = int.Parse(unit.UnitDetails.HeadOfDEPId.ToString());
                                        orgStructureDepartment.OrganizationStructureTemplateDepartmentAssociatedPositions.FirstOrDefault(x => x.PositionTemplateId == headId).IsHead = true;
                                        orgStructureDepartment.OrganizationStructureTemplateDepartmentAssociatedPositions.FirstOrDefault(x => x.PositionTemplateId != headId).IsHead = false;
                                    }

                                    int parentId = int.Parse(structuralNode.ParentId.ToString());
                                    if (OrganizationStructureTemplateBusinessUnits.Any(x => x.Id == parentId))
                                    {
                                        var _ParentBU = OrganizationStructureTemplateBusinessUnits.FirstOrDefault(x => x.Id == parentId);
                                        if (_ParentBU.OrganizationStructureTemplateDepartments == null)
                                            _ParentBU.OrganizationStructureTemplateDepartments = new List<OS_OrganizationStructureTemplateDepartment_Dto>();
                                        _ParentBU.OrganizationStructureTemplateDepartments.Add(orgStructureDepartment);
                                    }
                                    else if (OrganizationStructureTemplateDivisions.Any(x => x.Id == parentId))
                                    {
                                        var _ParentDIV = OrganizationStructureTemplateDivisions.FirstOrDefault(x => x.Id == parentId);
                                        if (_ParentDIV.OrganizationStructureTemplateDepartments == null)
                                            _ParentDIV.OrganizationStructureTemplateDepartments = new List<OS_OrganizationStructureTemplateDepartment_Dto>();
                                        _ParentDIV.OrganizationStructureTemplateDepartments.Add(orgStructureDepartment);
                                    }
                                    else if (OrganizationStructureTemplateDepartments.Any(x => x.Id == parentId))
                                    {
                                        //var _ParentDEP = OrganizationStructureTemplateDepartments.FirstOrDefault(x => x.Id == parentId);
                                        //if (_ParentDEP.OrganizationStructureTemplateDepartments == null)
                                        //    _ParentDEP.OrganizationStructureTemplateDepartments = new List<OS_OrganizationStructureTemplateDepartment_Dto>();
                                        //_ParentDEP.OrganizationStructureTemplateDepartments.Add(orgStructureDepartment);
                                    }

                                    OrganizationStructureTemplateDepartments.Add(orgStructureDepartment);
                                    //organizationStructureTemplate_Dto.OrganizationStructureTemplateDepartments.Add(orgStructureDepartment);
                                    break;
                                case "Position":
                                    OS_OrganizationStructureTemplatePosition_Dto orgStructurePosition = new OS_OrganizationStructureTemplatePosition_Dto();
                                    orgStructurePosition.Id = structuralNode.Id;
                                    orgStructurePosition.PositionTemplateId = unit.Id;
                                    orgStructurePosition.ValidityFromDate = DateTime.Parse(unit.ValidityFromDate);
                                    orgStructurePosition.ValidityToDate = DateTime.Parse(unit.ValidityToDate);

                                    if (unit.UnitDetails != null)
                                    {
                                        //orgStructurePosition.ValidityFromDate = DateTime.Parse(unit.UnitDetails.ValidityFromDate.ToString());
                                        //orgStructurePosition.ValidityToDate = DateTime.Parse(unit.UnitDetails.ValidityToDate.ToString());

                                        orgStructurePosition.OrganizationStructureTemplatePositionJobs = new List<OS_OrganizationStructureTemplatePositionJob_Dto>();
                                        List<PositionJobVM> Jobs = JsonSerializer.Deserialize<List<PositionJobVM>>(unit.UnitDetails.jobDetails.ToString());
                                        for (int y = 0; y < Jobs.Count; y++)
                                        {
                                            PositionJobVM pJ = Jobs[y];
                                            OS_OrganizationStructureTemplatePositionJob_Dto orgDEPPJ = new OS_OrganizationStructureTemplatePositionJob_Dto();
                                            orgDEPPJ.JobTemplateId = pJ.Id;

                                            orgDEPPJ.EmployeeClassId = pJ.EmployeeClassId;
                                            orgDEPPJ.LevelId = pJ.LevelId;
                                            orgDEPPJ.ContractTypeId = pJ.ContractTypeId;

                                            orgStructurePosition.OrganizationStructureTemplatePositionJobs.Add(orgDEPPJ);
                                        }
                                    }

                                    int _parentId = int.Parse(structuralNode.ParentId.ToString());
                                    if (OrganizationStructureTemplateBusinessUnits.Any(x => x.Id == _parentId))
                                    {
                                        var _ParentBU = OrganizationStructureTemplateBusinessUnits.FirstOrDefault(x => x.Id == _parentId);
                                        if (_ParentBU.OrganizationStructureTemplateBusinessUnitPositions == null)
                                            _ParentBU.OrganizationStructureTemplateBusinessUnitPositions = new List<OS_OrganizationStructureTemplatePosition_Dto>();
                                        _ParentBU.OrganizationStructureTemplateBusinessUnitPositions.Add(orgStructurePosition);
                                    }
                                    else if (OrganizationStructureTemplateDivisions.Any(x => x.Id == _parentId))
                                    {
                                        var _ParentDIV = OrganizationStructureTemplateDivisions.FirstOrDefault(x => x.Id == _parentId);
                                        if (_ParentDIV.OrganizationStructureTemplateDivisionPositions == null)
                                            _ParentDIV.OrganizationStructureTemplateDivisionPositions = new List<OS_OrganizationStructureTemplatePosition_Dto>();
                                        _ParentDIV.OrganizationStructureTemplateDivisionPositions.Add(orgStructurePosition);
                                    }
                                    else if (OrganizationStructureTemplateDepartments.Any(x => x.Id == _parentId))
                                    {
                                        var _ParentDEP = OrganizationStructureTemplateDepartments.FirstOrDefault(x => x.Id == _parentId);
                                        if (_ParentDEP.OrganizationStructureTemplateDepartmentPositions == null)
                                            _ParentDEP.OrganizationStructureTemplateDepartmentPositions = new List<OS_OrganizationStructureTemplatePosition_Dto>();
                                        _ParentDEP.OrganizationStructureTemplateDepartmentPositions.Add(orgStructurePosition);
                                    }
                                    else if (OrganizationStructureTemplatePositions.Any(x => x.Id == _parentId))
                                    {
                                        //var _ParentPOS = OrganizationStructureTemplatePositions.FirstOrDefault(x => x.Id == _parentId);
                                        //if (_ParentPOS.OrganizationStructureTemplatePositions == null)
                                        //    _ParentPOS.OrganizationStructureTemplatePositions = new List<OS_OrganizationStructureTemplatePosition_Dto>();
                                        //_ParentPOS.OrganizationStructureTemplatePositions.Add(orgStructurePosition);
                                    }

                                    OrganizationStructureTemplatePositions.Add(orgStructurePosition);
                                    break;
                            }
                        }

                        OS_OrganizationStructureTemplate_Dto added = await OS_OrganizationStructureTemplateAppService.CreateAsync(organizationStructureTemplate_Dto);
                        OS_OrganizationStructureTemplate_Dto addeddDto = await OS_OrganizationStructureTemplateAppService.GetOrganizationStructureTemplateAsync(added.Id);
                        if (AuditingManager.Current != null)
                        {
                            EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                            entityChangeInfo.EntityId = added.Id.ToString();
                            entityChangeInfo.EntityTenantId = added.TenantId;
                            entityChangeInfo.ChangeTime = DateTime.Now;
                            entityChangeInfo.ChangeType = EntityChangeType.Created;
                            entityChangeInfo.EntityTypeFullName = typeof(OS_OrganizationStructureTemplate).FullName;

                            AuditingManager.Current.Log.EntityChanges.Add(entityChangeInfo);
                        }

                        return StatusCode(200, addeddDto);
                    }
                }
                catch(Exception ex)
                {
                    return StatusCode(500, ex);
                }
            }

            return StatusCode(500);
        }
        public async Task<IActionResult> OnDeleteOrganizationStructureTemplate()
        {
            List<OS_OrganizationStructureTemplate_Dto> organizationStructures = JsonSerializer.Deserialize<List<OS_OrganizationStructureTemplate_Dto>>(Request.Form["organizationStructures"]);
            try
            {
                for (int i = 0; i < organizationStructures.Count; i++)
                {
                    OS_OrganizationStructureTemplate_Dto organizationStructure = organizationStructures[i];
                    //await TaskTemplatesAppService.Repository.DeleteAsync(leaveRequest.);
                    //var depSubDeps = OS_OrganizationStructureTemplateAppService.OrganizationStructureSubOrganizationStructureTemplateRepo.Where(x => x.OrganizationStructureTemplateId == organizationStructure.Id || x.SubOrganizationStructureTemplateId == organizationStructure.Id).ToList();
                    //for (int y = 0; y < depSubDeps.Count; y++)
                    //{
                    //    await OS_OrganizationStructureTemplateAppService.OrganizationStructureSubOrganizationStructureTemplateRepo.DeleteAsync(depSubDeps[y]);
                    //}
                    //var depPoses = OS_OrganizationStructureTemplateAppService.PositionTemplateRepo.WithDetails().Where(x => x.OrganizationStructureTemplateId == organizationStructure.Id).ToList();
                    //await Positions.ListModel.DeletePositions(depPoses, OS_PositionTemplateAppService.PositionJobsTemplateRepo, OS_PositionTemplateAppService.PositionTasksTemplateRepo, OS_PositionTemplateAppService.Repository, AuditingManager);

                    await OS_OrganizationStructureTemplateAppService.Repository.DeleteAsync(organizationStructure.Id);

                    if (AuditingManager.Current != null)
                    {
                        EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                        entityChangeInfo.EntityId = organizationStructure.Id.ToString();
                        entityChangeInfo.EntityTenantId = organizationStructure.TenantId;
                        entityChangeInfo.ChangeTime = DateTime.Now;
                        entityChangeInfo.ChangeType = EntityChangeType.Deleted;
                        entityChangeInfo.EntityTypeFullName = typeof(OS_OrganizationStructureTemplate).FullName;

                        AuditingManager.Current.Log.EntityChanges.Add(entityChangeInfo);
                    }
                }
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        public dynamic GetDataAuditTrailModel()
        {
            dynamic result = new ExpandoObject();

            List<GridColumn> primaryGridColumns = new List<GridColumn>()
            {
                new GridColumn { Field = "AuditLogId", HeaderText = "", TextAlign=TextAlign.Center, Visible=false, ShowInColumnChooser=false,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "EntityChangeId", HeaderText = "", TextAlign=TextAlign.Center, Visible=false, ShowInColumnChooser=false,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "Id", HeaderText = "Id", TextAlign=TextAlign.Center,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "Name", HeaderText = "Name", TextAlign=TextAlign.Center,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "Date", HeaderText = "Date", TextAlign=TextAlign.Center,  AllowEditing=false, MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "Time", HeaderText = "Time", TextAlign=TextAlign.Center,  AllowEditing=false, MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "User", HeaderText = "User", TextAlign=TextAlign.Center,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "Status", HeaderText = "Status", TextAlign=TextAlign.Center,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "TypeId", HeaderText = "", TextAlign=TextAlign.Center, Visible=false, ShowInColumnChooser=false,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "Type", HeaderText = "Type", TextAlign=TextAlign.Center,  AllowEditing=false, MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "ChangeStatus", HeaderText = "Change Status", TextAlign=TextAlign.Center,  AllowEditing=false, MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "Field", HeaderText = "Field", TextAlign=TextAlign.Center,  AllowEditing=false, MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "OriginalValue", HeaderText = "Original Value", TextAlign=TextAlign.Center,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "NewValue", HeaderText = "New Value", TextAlign=TextAlign.Center,  AllowEditing=false, MinWidth = "10", CustomAttributes=new {id="detailed"}  },
            };

            result.primaryGridColumns = primaryGridColumns;

            List<GridColumn> secondaryGridColumns = new List<GridColumn>()
            {
                new GridColumn { Field = "EntityChangeId", HeaderText = "", TextAlign=TextAlign.Center, Visible=false, ShowInColumnChooser=false,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "TypeId", HeaderText = "", TextAlign=TextAlign.Center, Visible=false, ShowInColumnChooser=false,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "Type", HeaderText = "Type", TextAlign=TextAlign.Center,  AllowEditing=false, MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "Status", HeaderText = "Status", TextAlign=TextAlign.Center,  AllowEditing=false, MinWidth = "10", CustomAttributes=new {id="detailed"}  },

            };
            List<GridColumn> tertiaryGridColumns = new List<GridColumn>()
            {
                new GridColumn { Field = "EntityChangeId", HeaderText = "", TextAlign=TextAlign.Center, Visible=false, ShowInColumnChooser=false,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "TypeId", HeaderText = "", TextAlign=TextAlign.Center, Visible=false, ShowInColumnChooser=false,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "Field", HeaderText = "Field", TextAlign=TextAlign.Center,  AllowEditing=false, MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "OriginalValue", HeaderText = "Original Value", TextAlign=TextAlign.Center,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
                new GridColumn { Field = "NewValue", HeaderText = "New Value", TextAlign=TextAlign.Center,  AllowEditing=false, MinWidth = "10", CustomAttributes=new {id="detailed"}  },
            };

            Grid SecondaryAGTGrid = new Grid()
            {
                DataSource = new List<dynamic>(),
                QueryString = "EntityChangeId",
                EditSettings = new Syncfusion.EJ2.Grids.GridEditSettings() { },
                AllowExcelExport = true,
                //AllowGrouping = true,
                AllowPdfExport = true,
                HierarchyPrintMode = HierarchyGridPrintMode.All,
                AllowSelection = true,
                AllowFiltering = false,
                AllowSorting = true,
                AllowMultiSorting = true,
                AllowResizing = true,
                GridLines = GridLine.Both,
                SearchSettings = new GridSearchSettings() { },
                //Toolbar = new List<object>() { "ExcelExport", "CsvExport", "Print", "Search",new { text = "Copy", tooltipText = "Copy", prefixIcon = "e-copy", id = "copy" }, new { text = "Copy With Header", tooltipText = "Copy With Header", prefixIcon = "e-copy", id = "copyHeader" } },
                ContextMenuItems = new List<object>() { "AutoFit", "AutoFitAll", "SortAscending", "SortDescending", "Copy", "Edit", "Delete", "Save", "Cancel", "PdfExport", "ExcelExport", "CsvExport", "FirstPage", "PrevPage", "LastPage", "NextPage" },
                Columns = secondaryGridColumns
            };
            Grid TertiaryAGTGrid = new Grid()
            {
                DataSource = new List<dynamic>(),
                QueryString = "TypeId",
                EditSettings = new Syncfusion.EJ2.Grids.GridEditSettings() { },
                AllowExcelExport = true,
                //AllowGrouping = true,
                AllowPdfExport = true,
                HierarchyPrintMode = HierarchyGridPrintMode.All,
                AllowSelection = true,
                AllowFiltering = false,
                AllowSorting = true,
                AllowMultiSorting = true,
                AllowResizing = true,
                GridLines = GridLine.Both,
                SearchSettings = new GridSearchSettings() { },
                //Toolbar = new List<object>() { "ExcelExport", "CsvExport", "Print", "Search",new { text = "Copy", tooltipText = "Copy", prefixIcon = "e-copy", id = "copy" }, new { text = "Copy With Header", tooltipText = "Copy With Header", prefixIcon = "e-copy", id = "copyHeader" } },
                ContextMenuItems = new List<object>() { "AutoFit", "AutoFitAll", "SortAscending", "SortDescending", "Copy", "Edit", "Delete", "Save", "Cancel", "PdfExport", "ExcelExport", "CsvExport", "FirstPage", "PrevPage", "LastPage", "NextPage" },
                Columns = tertiaryGridColumns
            };
            SecondaryAGTGrid.ChildGrid = TertiaryAGTGrid;

            //result.secondaryGrid = SecondaryAGTGrid;
            result.dataSource = null;

            return result;
        }

        public async Task<JsonResult> OnGetDataAuditTrail()
        {
            dynamic result = new ExpandoObject();
            List<dynamic> DS = new List<dynamic>();
            List<dynamic> secondaryDS = new List<dynamic>();
            List<dynamic> tertiaryDS = new List<dynamic>();
            var organizationStructureLogs = AuditLogsRepo.WithDetails().Where(x => x.Url == HttpContext.Request.Path.Value && x.EntityChanges != null && x.EntityChanges.Count > 0).ToList();

            List<OS_OrganizationStructureTemplate_Dto> Entities = await OS_OrganizationStructureTemplateAppService.GetAllOrganizationStructureTemplatesAsync();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            for (int i = 0; i < organizationStructureLogs.Count; i++)
            {
                AuditLog auditLog = organizationStructureLogs[i];
                if (auditLog.EntityChanges == null || auditLog.EntityChanges.Count == 0) continue;
                var entityChanges = auditLog.EntityChanges.ToList();
                for (int j = 0; j < entityChanges.Count; j++)
                {
                    EntityChange entityChange = entityChanges[j];

                    dynamic changeRow = new ExpandoObject();
                    changeRow.AuditLogId = entityChange.Id;
                    changeRow.EntityChangeId = entityChange.Id;

                    OS_OrganizationStructureTemplate_Dto organizationStructure = Entities.First(x => x.Id.ToString() == entityChange.EntityId);
                    changeRow.Id = organizationStructure.Id;
                    changeRow.Name = organizationStructure.Name;
                    changeRow.Date = entityChange.ChangeTime.ToShortDateString();
                    changeRow.Time = entityChange.ChangeTime.ToShortTimeString();
                    changeRow.User = auditLog.UserName;
                    changeRow.Status = entityChange.ChangeType.GetDisplayName();

                    DS.Add(changeRow);

                    dynamic generalTypeRow = new ExpandoObject();
                    generalTypeRow.EntityChangeId = entityChange.Id;
                    generalTypeRow.TypeId = 1;
                    generalTypeRow.Type = "General";
                    generalTypeRow.Name = "";
                    generalTypeRow.Status = "Updated";

                    changeRow.Type = "General";
                    //changeRow.Name = "";
                    changeRow.ChangeStatus = "Updated";

                    secondaryDS.Add(generalTypeRow);

                    var generalPropertyChanges = entityChange.PropertyChanges.ToList();

                    for (int k = 0; k < generalPropertyChanges.Count; k++)
                    {
                        EntityPropertyChange propertyChange = generalPropertyChanges[k];
                        dynamic propertyChangeRow = new ExpandoObject();
                        propertyChangeRow.TypeId = 1;
                        propertyChangeRow.EntityChangeId = propertyChange.EntityChangeId;
                        propertyChangeRow.Field = textInfo.ToTitleCase(propertyChange.PropertyName.ToSentenceCase());
                        propertyChangeRow.NewValue = propertyChange.NewValue != "null" && propertyChange.NewValue != "\"\"" ? propertyChange.NewValue.TrimStart('"').TrimEnd('"') : "—";
                        propertyChangeRow.OriginalValue = propertyChange.OriginalValue != "null" && propertyChange.OriginalValue != "\"\"" ? propertyChange.OriginalValue.TrimStart('"').TrimEnd('"') : "—"; ;

                        changeRow.Field = textInfo.ToTitleCase(propertyChange.PropertyName.ToSentenceCase());
                        changeRow.NewValue = propertyChange.NewValue != "null" && propertyChange.NewValue != "\"\"" ? propertyChange.NewValue.TrimStart('"').TrimEnd('"') : "—";
                        changeRow.OriginalValue = propertyChange.OriginalValue != "null" && propertyChange.OriginalValue != "\"\"" ? propertyChange.OriginalValue.TrimStart('"').TrimEnd('"') : "—"; ;

                        tertiaryDS.Add(propertyChangeRow);
                    }

                    //List<EmployeeExtraPropertyHistory> extraPropertyHistories = entityChange.GetProperty<List<EmployeeExtraPropertyHistory>>("extraPropertiesHistory");
                    //if (extraPropertyHistories != null && extraPropertyHistories.Count > 0)
                    //{
                    //    foreach (EmployeeExtraPropertyHistory extraPropertyHistory in extraPropertyHistories)
                    //    {
                    //        dynamic typeRow = new ExpandoObject();
                    //        typeRow.EntityChangeId = entityChange.Id;
                    //        typeRow.TypeId = extraPropertyHistory.TypeId;
                    //        typeRow.Type = extraPropertyHistory.Type;
                    //        typeRow.Name = extraPropertyHistory.Name;
                    //        typeRow.Status = extraPropertyHistory.Status;

                    //        secondaryDS.Add(typeRow);

                    //        var propertyChanges = extraPropertyHistory.PropertyChanges.ToList();

                    //        for (int k = 0; k < propertyChanges.Count; k++)
                    //        {
                    //            EmployeeTypePropertyChange propertyChange = propertyChanges[k];
                    //            dynamic propertyChangeRow = new ExpandoObject();
                    //            propertyChangeRow.TypeId = extraPropertyHistory.TypeId;
                    //            propertyChangeRow.EntityChangeId = typeRow.EntityChangeId;
                    //            propertyChangeRow.Field = textInfo.ToTitleCase(propertyChange.PropertyName.ToSentenceCase());
                    //            propertyChangeRow.NewValue = propertyChange.NewValue != "null" && propertyChange.NewValue != "\"\"" ? propertyChange.NewValue.TrimStart('"').TrimEnd('"') : "—";
                    //            propertyChangeRow.OriginalValue = propertyChange.OriginalValue != "null" && propertyChange.OriginalValue != "\"\"" ? propertyChange.OriginalValue.TrimStart('"').TrimEnd('"') : "—"; ;

                    //            tertiaryDS.Add(propertyChangeRow);
                    //        }
                    //    }
                    //}
                }
            }
            result.ds = DS;
            result.secondaryDS = secondaryDS;
            result.tertiaryDS = tertiaryDS;

            var secondaryGrid = new JsonResult(result);
            return secondaryGrid;
        }

        public class StructureVM
        {
            public List<NodeVM> Structure = new List<NodeVM>();
        }
        public class NodeVM
        {
            public int Id { get; set; }
            public string Type { get; set; }
            public UnitVM _unit { get; set; }
            public int ParentId { get; set; }

            public dynamic ParentItem { get; set; }
        }
        public class PositionVM
        {
            public int Id { get; set; }
            public string ValidityFromDate { get; set; }
            public string ValidityToDate { get; set; }
        }
        public class PositionJobVM
        {
            public int Id { get; set; }

            public Guid LevelId { get; set; }
            public Guid EmployeeClassId { get; set; }
            public Guid ContractTypeId { get; set; }

            public string ValidityFromDate { get; set; }
            public string ValidityToDate { get; set; }
        }
        public class CostCenterVM
        {
            public Guid Id { get; set; }
            public int Percentage { get; set; }
        }
        public class UnitVM
        {
            public int Id { get; set; }
            public dynamic UnitDetails { get; set; }
            public string UniqueId { get; set; }
            public string ValidityFromDate { get; set; }
            public string ValidityToDate { get; set; }
            public int PaySubGroupId { get; set; }
            public int PayGradeId { get; set; }
            public int LocationId { get; set; }

            public dynamic DepartmentCostCenterTemplates { get; set; }
        }
    }
}
