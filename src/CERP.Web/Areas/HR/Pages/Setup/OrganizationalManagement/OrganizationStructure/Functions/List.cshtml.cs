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

namespace CERP.Web.Areas.HR.Setup.OrganizationalManagement.OrganizationStructure.Pages.Functions
{
    public class ListModel : CERPPageModel
    {
        public IWebHostEnvironment webHostEnvironment { get; set; }
        public IRepository<DictionaryValue, Guid> DictionaryValuesRepo { get; set; }
        public IAuditLogRepository AuditLogsRepo { get; set; }

        public OS_FunctionTemplateAppService OS_FunctionTemplateAppService { get; set; }

        public IAuditingManager AuditingManager { get; set; }
        public IRepository<CustomEntityChange> CustomEntityChangesRepo { get; set; }

        public ListModel(IJsonSerializer jsonSerializer, IRepository<DictionaryValue, Guid> dictionaryValuesRepo, IWebHostEnvironment webHostEnvironment, IAuditLogRepository auditLogsRepo, OS_FunctionTemplateAppService oS_FunctionTemplateAppService)
        {
            JsonSerializer = jsonSerializer;
            DictionaryValuesRepo = dictionaryValuesRepo;
            this.webHostEnvironment = webHostEnvironment;
            AuditLogsRepo = auditLogsRepo;
            OS_FunctionTemplateAppService = oS_FunctionTemplateAppService;
        }

        public IJsonSerializer JsonSerializer { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostFunctionTemplate()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var FormData = Request.Form;

                    OS_FunctionTemplate_Dto functionTemplate_Dto = JsonSerializer.Deserialize<OS_FunctionTemplate_Dto>(FormData["info"]);

                    bool IsEditing = functionTemplate_Dto.Id > 0;
                    if (IsEditing)
                    {
                        OS_FunctionTemplate curFunctionTemplate = await OS_FunctionTemplateAppService.Repository.GetAsync(functionTemplate_Dto.Id);

                        if (AuditingManager.Current != null)
                        {
                            EntityChangeInfo entityChangeInfo = new EntityChangeInfo();

                            entityChangeInfo.EntityId = functionTemplate_Dto.Id.ToString();
                            entityChangeInfo.EntityTenantId = functionTemplate_Dto.TenantId;
                            entityChangeInfo.ChangeTime = DateTime.Now;
                            entityChangeInfo.ChangeType = EntityChangeType.Updated;
                            entityChangeInfo.EntityTypeFullName = typeof(OS_FunctionTemplate).FullName;

                            entityChangeInfo.PropertyChanges = new List<EntityPropertyChangeInfo>();
                            List<EntityPropertyChangeInfo> entityPropertyChanges = new List<EntityPropertyChangeInfo>();
                            var auditProps = typeof(OS_FunctionTemplate).GetProperties().Where(x => Attribute.IsDefined(x, typeof(CustomAuditedAttribute))).ToList();

                            OS_FunctionTemplate mappedInput = ObjectMapper.Map<OS_FunctionTemplate_Dto, OS_FunctionTemplate>(functionTemplate_Dto);
                            foreach (var prop in auditProps)
                            {
                                EntityPropertyChangeInfo propertyChange = new EntityPropertyChangeInfo();
                                object origVal = prop.GetValue(curFunctionTemplate);
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

                                        var valueProp = typeof(OS_FunctionTemplate).GetProperty(valuePropName);

                                        DictionaryValue _origValObj = (DictionaryValue)valueProp.GetValue(functionTemplate_Dto);
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
                            //if (departmentTemplate_Dto.ExtraProperties != curFunctionTemplate.ExtraProperties)
                            //{
                            //    //GeneralInfo oldGeneralInfo = department.GetProperty<GeneralInfo>("generalInfo");
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

                        curFunctionTemplate.Name = functionTemplate_Dto.Name;
                        curFunctionTemplate.NameLocalized = functionTemplate_Dto.NameLocalized;
                        curFunctionTemplate.Code = functionTemplate_Dto.Code;
                        curFunctionTemplate.ValidityFromDate = functionTemplate_Dto.ValidityFromDate;
                        curFunctionTemplate.ValidityToDate = functionTemplate_Dto.ValidityToDate;
                        curFunctionTemplate.Description = functionTemplate_Dto.Description;
                        curFunctionTemplate.DoesKPI = functionTemplate_Dto.DoesKPI;
                        curFunctionTemplate.CompensationMatrix = null;
                        curFunctionTemplate.CompensationMatrixId = functionTemplate_Dto.CompensationMatrixId;

                        #region Child Entities
                        OS_FunctionSkillTemplate_Dto[] functionSkills = functionTemplate_Dto.FunctionSkillTemplates.ToArray();
                        int[] curFunctionSkillsIds = curFunctionTemplate.FunctionSkillTemplates != null && curFunctionTemplate.FunctionSkillTemplates.Count > 0 ? curFunctionTemplate.FunctionSkillTemplates.Select(x => x.SkillTemplate.Id).ToArray() : new int[0];
                        List<int> toDeleteSkills = new List<int>();
                        for (int i = 0; i < curFunctionSkillsIds.Length; i++)
                        {
                            OS_FunctionSkillTemplate curFunctionSkill = curFunctionTemplate.FunctionSkillTemplates.First(x => x.SkillTemplate.Id == curFunctionSkillsIds[i]);
                            if (!functionSkills.Any(x => x.SkillTemplate.Id == curFunctionSkillsIds[i]))
                            {
                                curFunctionTemplate.FunctionSkillTemplates.Remove(curFunctionTemplate.FunctionSkillTemplates.First(x => x.SkillTemplate.Id == curFunctionSkillsIds[i]));
                                toDeleteSkills.Add(curFunctionSkillsIds[i]);
                            }
                        }
                        for (int i = 0; i < functionSkills.Length; i++)
                        {
                            if (!curFunctionTemplate.FunctionSkillTemplates.Any(x => x.SkillTemplateId == functionSkills[i].SkillTemplate.Id))
                            {
                                curFunctionTemplate.FunctionSkillTemplates.Add(new OS_FunctionSkillTemplate() { SkillTemplateId = functionSkills[i].SkillTemplate.Id });
                            }
                            else
                            {
                                var _functionSkill = curFunctionTemplate.FunctionSkillTemplates.First(x => x.SkillTemplateId == functionSkills[i].SkillTemplate.Id);
                                //_functionLoc.FunctionValidityStart = posFunctions[i].FunctionValidityStart;
                                //_functionLoc.FunctionValidityEnd = posFunctions[i].FunctionValidityEnd;
                                //_functionLoc.Name = posFunctions[i].Name;

                                //curFunction.FunctionSkillTemplates.Remove(curFunction.FunctionSkillTemplates.First(x => x.FunctionTemplateId == _functionLoc.FunctionTemplateId));
                                await OS_FunctionTemplateAppService.SkillsRepository.UpdateAsync(_functionSkill);
                            }
                        }
                        for (int i = 0; i < toDeleteSkills.Count; i++)
                        {
                            await OS_FunctionTemplateAppService.SkillsRepository.DeleteAsync(x => x.SkillTemplateId == toDeleteSkills[i]);
                        }

                        OS_FunctionAcademiaTemplate_Dto[] functionAcademia = functionTemplate_Dto.FunctionAcademiaTemplates.ToArray();
                        int[] curFunctionAcademiaIds = curFunctionTemplate.FunctionAcademiaTemplates != null && curFunctionTemplate.FunctionAcademiaTemplates.Count > 0 ? curFunctionTemplate.FunctionAcademiaTemplates.Select(x => x.AcademiaTemplate.Id).ToArray() : new int[0];
                        List<int> toDeleteAcademia = new List<int>();
                        for (int i = 0; i < curFunctionAcademiaIds.Length; i++)
                        {
                            OS_FunctionAcademiaTemplate curFunctionAcademia = curFunctionTemplate.FunctionAcademiaTemplates.First(x => x.AcademiaTemplate.Id == curFunctionAcademiaIds[i]);
                            if (!functionAcademia.Any(x => x.AcademiaTemplate.Id == curFunctionAcademiaIds[i]))
                            {
                                curFunctionTemplate.FunctionAcademiaTemplates.Remove(curFunctionTemplate.FunctionAcademiaTemplates.First(x => x.AcademiaTemplate.Id == curFunctionAcademiaIds[i]));
                                toDeleteSkills.Add(curFunctionAcademiaIds[i]);
                            }
                        }
                        for (int i = 0; i < functionAcademia.Length; i++)
                        {
                            if (!curFunctionTemplate.FunctionAcademiaTemplates.Any(x => x.AcademiaTemplateId == functionAcademia[i].AcademiaTemplate.Id))
                            {
                                curFunctionTemplate.FunctionAcademiaTemplates.Add(new OS_FunctionAcademiaTemplate() { AcademiaTemplateId = functionAcademia[i].AcademiaTemplate.Id });
                            }
                            else
                            {
                                var _functionAcademia = curFunctionTemplate.FunctionAcademiaTemplates.First(x => x.AcademiaTemplateId == functionAcademia[i].AcademiaTemplate.Id);
                                //_functionLoc.FunctionValidityStart = posFunctions[i].FunctionValidityStart;
                                //_functionLoc.FunctionValidityEnd = posFunctions[i].FunctionValidityEnd;
                                //_functionLoc.Name = posFunctions[i].Name;

                                //curFunction.FunctionAcademiaTemplates.Remove(curFunction.FunctionAcademiaTemplates.First(x => x.FunctionTemplateId == _functionLoc.FunctionTemplateId));
                                await OS_FunctionTemplateAppService.AcademiaRepository.UpdateAsync(_functionAcademia);
                            }
                        }
                        for (int i = 0; i < toDeleteAcademia.Count; i++)
                        {
                            await OS_FunctionTemplateAppService.AcademiaRepository.DeleteAsync(x => x.AcademiaTemplateId == toDeleteAcademia[i]);
                        }
                        #endregion

                        OS_FunctionTemplate_Dto updated = ObjectMapper.Map<OS_FunctionTemplate, OS_FunctionTemplate_Dto>(await OS_FunctionTemplateAppService.Repository.UpdateAsync(curFunctionTemplate));
                        updated.FunctionSkillTemplates = ObjectMapper.Map<List<OS_FunctionSkillTemplate>, List<OS_FunctionSkillTemplate_Dto>>(curFunctionTemplate.FunctionSkillTemplates.ToList());
                        updated.FunctionAcademiaTemplates = ObjectMapper.Map<List<OS_FunctionAcademiaTemplate>, List<OS_FunctionAcademiaTemplate_Dto>>(curFunctionTemplate.FunctionAcademiaTemplates.ToList());
                        updated.CompensationMatrix = await OS_FunctionTemplateAppService.GetCompensationMatrixAsync(updated.CompensationMatrixId);

                        return StatusCode(200, updated);
                    }
                    else
                    {
                        functionTemplate_Dto.Id = 0; 
                        if (functionTemplate_Dto.FunctionSkillTemplates != null)
                            functionTemplate_Dto.FunctionSkillTemplates.ForEach(x => { x.Id = 0; x.SkillTemplateId = x.SkillTemplate.Id; x.SkillTemplate = null; });
                        if (functionTemplate_Dto.FunctionAcademiaTemplates != null)
                            functionTemplate_Dto.FunctionAcademiaTemplates.ForEach(x => { x.Id = 0; x.AcademiaTemplateId = x.AcademiaTemplate.Id; x.AcademiaTemplate = null; });
                        functionTemplate_Dto.CompensationMatrix = null;

                        OS_FunctionTemplate_Dto added = await OS_FunctionTemplateAppService.CreateAsync(functionTemplate_Dto);

                        if (AuditingManager.Current != null)
                        {
                            EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                            entityChangeInfo.EntityId = added.Id.ToString();
                            entityChangeInfo.EntityTenantId = added.TenantId;
                            entityChangeInfo.ChangeTime = DateTime.Now;
                            entityChangeInfo.ChangeType = EntityChangeType.Created;
                            entityChangeInfo.EntityTypeFullName = typeof(OS_FunctionTemplate).FullName;

                            AuditingManager.Current.Log.EntityChanges.Add(entityChangeInfo);
                        }

                        return StatusCode(200, added);
                    }
                }
                catch(Exception ex)
                {
                    
                }
            }

            return StatusCode(500);
        }
        public async Task<IActionResult> OnDeleteFunctionTemplate()
        {
            List<OS_FunctionTemplate_Dto> entitites = JsonSerializer.Deserialize<List<OS_FunctionTemplate_Dto>>(Request.Form["functions"]);
            try
            {
                for (int i = 0; i < entitites.Count; i++)
                {
                    OS_FunctionTemplate_Dto entity = entitites[i];
                    //await FunctionTemplatesAppService.Repository.DeleteAsync(leaveRequest.);
                    await OS_FunctionTemplateAppService.Repository.DeleteAsync(entity.Id);

                    if (AuditingManager.Current != null)
                    {
                        EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                        entityChangeInfo.EntityId = entity.Id.ToString();
                        entityChangeInfo.EntityTenantId = entity.TenantId;
                        entityChangeInfo.ChangeTime = DateTime.Now;
                        entityChangeInfo.ChangeType = EntityChangeType.Deleted;
                        entityChangeInfo.EntityTypeFullName = typeof(OS_FunctionTemplate).FullName;

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

        //public async Task<IActionResult> OnPostFunctionQualificationTemplate()
        //{

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var FormData = Request.Form;

        //            OS_FunctionQualificationTemplate_Dto functionQualificationTemplate_Dto = JsonSerializer.Deserialize<OS_FunctionQualificationTemplate_Dto>(FormData["info"]);

        //            bool IsEditing = functionQualificationTemplate_Dto.Id > 0;
        //            if (IsEditing)
        //            {
        //                OS_FunctionQualificationTemplate curFunctionQualificationTemplate = await OS_FunctionTemplateAppService.QualificationsRepository.GetAsync(functionQualificationTemplate_Dto.Id);

        //                if (AuditingManager.Current != null)
        //                {
        //                    EntityChangeInfo entityChangeInfo = new EntityChangeInfo();

        //                    entityChangeInfo.EntityId = functionQualificationTemplate_Dto.Id.ToString();
        //                    entityChangeInfo.EntityTenantId = functionQualificationTemplate_Dto.TenantId;
        //                    entityChangeInfo.ChangeTime = DateTime.Now;
        //                    entityChangeInfo.ChangeType = EntityChangeType.Updated;
        //                    entityChangeInfo.EntityTypeFullName = typeof(OS_FunctionQualificationTemplate).FullName;

        //                    entityChangeInfo.PropertyChanges = new List<EntityPropertyChangeInfo>();
        //                    List<EntityPropertyChangeInfo> entityPropertyChanges = new List<EntityPropertyChangeInfo>();
        //                    var auditProps = typeof(OS_FunctionQualificationTemplate).GetProperties().Where(x => Attribute.IsDefined(x, typeof(CustomAuditedAttribute))).ToList();

        //                    OS_FunctionQualificationTemplate mappedInput = ObjectMapper.Map<OS_FunctionQualificationTemplate_Dto, OS_FunctionQualificationTemplate>(functionQualificationTemplate_Dto);
        //                    foreach (var prop in auditProps)
        //                    {
        //                        EntityPropertyChangeInfo propertyChange = new EntityPropertyChangeInfo();
        //                        object origVal = prop.GetValue(curFunctionQualificationTemplate);
        //                        propertyChange.OriginalValue = origVal == null ? "" : origVal.ToString();
        //                        object newVal = prop.GetValue(mappedInput);
        //                        propertyChange.NewValue = newVal == null ? "" : newVal.ToString();
        //                        if (propertyChange.OriginalValue == propertyChange.NewValue) continue;

        //                        propertyChange.PropertyName = prop.Name;

        //                        if (prop.Name.EndsWith("Id"))
        //                        {
        //                            try
        //                            {
        //                                string valuePropName = prop.Name.TrimEnd('d', 'I');
        //                                propertyChange.PropertyName = valuePropName;

        //                                var valueProp = typeof(OS_FunctionQualificationTemplate).GetProperty(valuePropName);

        //                                DictionaryValue _origValObj = (DictionaryValue)valueProp.GetValue(functionQualificationTemplate_Dto);
        //                                if (_origValObj == null) _origValObj = await DictionaryValuesRepo.GetAsync((Guid)origVal);
        //                                string _origVal = _origValObj.Value;
        //                                propertyChange.OriginalValue = origVal == null ? "" : _origVal;
        //                                DictionaryValue _newValObj = (DictionaryValue)valueProp.GetValue(mappedInput);
        //                                if (_newValObj == null) _newValObj = await DictionaryValuesRepo.GetAsync((Guid)newVal);
        //                                string _newVal = _newValObj.Value;
        //                                propertyChange.NewValue = _newValObj == null ? "" : _newVal;
        //                            }
        //                            catch (Exception ex)
        //                            {

        //                            }
        //                        }

        //                        propertyChange.PropertyTypeFullName = prop.Name.GetType().FullName;

        //                        entityChangeInfo.PropertyChanges.Add(propertyChange);
        //                    }

        //                    AuditingManager.Current.Log.EntityChanges.Add(entityChangeInfo);
        //                }

        //                curFunctionQualificationTemplate.DegreeId = functionQualificationTemplate_Dto.DegreeId;
        //                curFunctionQualificationTemplate.InstituteId = functionQualificationTemplate_Dto.InstituteId;
        //                curFunctionQualificationTemplate.PeriodStartDate = functionQualificationTemplate_Dto.PeriodStartDate;
        //                curFunctionQualificationTemplate.PeriodEndDate = functionQualificationTemplate_Dto.PeriodEndDate;

        //                OS_FunctionQualificationTemplate_Dto updated = ObjectMapper.Map<OS_FunctionQualificationTemplate, OS_FunctionQualificationTemplate_Dto>(await OS_FunctionTemplateAppService.QualificationsRepository.UpdateAsync(curFunctionQualificationTemplate));

        //                return StatusCode(200, updated);
        //            }
        //            else
        //            {
        //                functionQualificationTemplate_Dto.Id = 0;

        //                OS_FunctionQualificationTemplate_Dto added = await OS_FunctionTemplateAppService.AddQualificationTemplate(functionQualificationTemplate_Dto);

        //                if (AuditingManager.Current != null)
        //                {
        //                    EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
        //                    entityChangeInfo.EntityId = added.Id.ToString();
        //                    entityChangeInfo.EntityTenantId = added.TenantId;
        //                    entityChangeInfo.ChangeTime = DateTime.Now;
        //                    entityChangeInfo.ChangeType = EntityChangeType.Created;
        //                    entityChangeInfo.EntityTypeFullName = typeof(OS_FunctionQualificationTemplate).FullName;

        //                    AuditingManager.Current.Log.EntityChanges.Add(entityChangeInfo);
        //                }

        //                added = ObjectMapper.Map<OS_FunctionQualificationTemplate, OS_FunctionQualificationTemplate_Dto>(await OS_FunctionTemplateAppService.QualificationsRepository.GetAsync(added.Id));
        //                return StatusCode(200, added);
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }

        //    return StatusCode(500);
        //}
        //public async Task<IActionResult> OnDeleteFunctionQualificationTemplate()
        //{
        //    List<OS_FunctionQualificationTemplate_Dto> entitites = JsonSerializer.Deserialize<List<OS_FunctionQualificationTemplate_Dto>>(Request.Form["qualifications"]);
        //    try
        //    {
        //        for (int i = 0; i < entitites.Count; i++)
        //        {
        //            OS_FunctionQualificationTemplate_Dto entity = entitites[i];
        //            //await FunctionQualificationTemplatesAppService.Repository.DeleteAsync(leaveRequest.);
        //            await OS_FunctionTemplateAppService.QualificationsRepository.DeleteAsync(entity.Id);

        //            if (AuditingManager.Current != null)
        //            {
        //                EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
        //                entityChangeInfo.EntityId = entity.Id.ToString();
        //                entityChangeInfo.EntityTenantId = entity.TenantId;
        //                entityChangeInfo.ChangeTime = DateTime.Now;
        //                entityChangeInfo.ChangeType = EntityChangeType.Deleted;
        //                entityChangeInfo.EntityTypeFullName = typeof(OS_FunctionQualificationTemplate).FullName;

        //                AuditingManager.Current.Log.EntityChanges.Add(entityChangeInfo);
        //            }
        //        }
        //        return StatusCode(200);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500);
        //    }
        //}


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
            var departmentLogs = AuditLogsRepo.WithDetails().Where(x => x.Url == HttpContext.Request.Path.Value && x.EntityChanges != null && x.EntityChanges.Count > 0).ToList();

            List<OS_FunctionTemplate_Dto> Entities = await OS_FunctionTemplateAppService.GetAllFunctionTemplatesAsync();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            for (int i = 0; i < departmentLogs.Count; i++)
            {
                AuditLog auditLog = departmentLogs[i];
                if (auditLog.EntityChanges == null || auditLog.EntityChanges.Count == 0) continue;
                var entityChanges = auditLog.EntityChanges.ToList();
                for (int j = 0; j < entityChanges.Count; j++)
                {
                    EntityChange entityChange = entityChanges[j];

                    dynamic changeRow = new ExpandoObject();
                    changeRow.AuditLogId = entityChange.Id;
                    changeRow.EntityChangeId = entityChange.Id;

                    OS_FunctionTemplate_Dto department = Entities.First(x => x.Id.ToString() == entityChange.EntityId);
                    changeRow.Id = department.Id;
                    changeRow.Name = department.Name;
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
    }
}
