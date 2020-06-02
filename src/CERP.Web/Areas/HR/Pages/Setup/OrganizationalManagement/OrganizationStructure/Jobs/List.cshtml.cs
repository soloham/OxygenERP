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

namespace CERP.Web.Areas.HR.Setup.OrganizationalManagement.OrganizationStructure.Pages.Jobs
{
    public class ListModel : CERPPageModel
    {
        public IWebHostEnvironment webHostEnvironment { get; set; }
        public IRepository<DictionaryValue, Guid> DictionaryValuesRepo { get; set; }
        public IAuditLogRepository AuditLogsRepo { get; set; }

        public OS_JobTemplateAppService OS_JobTemplateAppService { get; set; }

        public IAuditingManager AuditingManager { get; set; }
        public IRepository<CustomEntityChange> CustomEntityChangesRepo { get; set; }

        public ListModel(IJsonSerializer jsonSerializer, IRepository<DictionaryValue, Guid> dictionaryValuesRepo, IWebHostEnvironment webHostEnvironment, IAuditLogRepository auditLogsRepo, OS_JobTemplateAppService oS_JobTemplateAppService)
        {
            JsonSerializer = jsonSerializer;
            DictionaryValuesRepo = dictionaryValuesRepo;
            this.webHostEnvironment = webHostEnvironment;
            AuditLogsRepo = auditLogsRepo;
            OS_JobTemplateAppService = oS_JobTemplateAppService;
        }

        public IJsonSerializer JsonSerializer { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostJobTemplate()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var FormData = Request.Form;

                    OS_JobTemplate_Dto jobTemplate_Dto = JsonSerializer.Deserialize<OS_JobTemplate_Dto>(FormData["info"]);

                    bool IsEditing = jobTemplate_Dto.Id > 0;
                    if (IsEditing)
                    {
                        OS_JobTemplate curJobTemplate = await OS_JobTemplateAppService.Repository.GetAsync(jobTemplate_Dto.Id);

                        if (AuditingManager.Current != null)
                        {
                            EntityChangeInfo entityChangeInfo = new EntityChangeInfo();

                            entityChangeInfo.EntityId = jobTemplate_Dto.Id.ToString();
                            entityChangeInfo.EntityTenantId = jobTemplate_Dto.TenantId;
                            entityChangeInfo.ChangeTime = DateTime.Now;
                            entityChangeInfo.ChangeType = EntityChangeType.Updated;
                            entityChangeInfo.EntityTypeFullName = typeof(OS_JobTemplate).FullName;

                            entityChangeInfo.PropertyChanges = new List<EntityPropertyChangeInfo>();
                            List<EntityPropertyChangeInfo> entityPropertyChanges = new List<EntityPropertyChangeInfo>();
                            var auditProps = typeof(OS_JobTemplate).GetProperties().Where(x => Attribute.IsDefined(x, typeof(CustomAuditedAttribute))).ToList();

                            OS_JobTemplate mappedInput = ObjectMapper.Map<OS_JobTemplate_Dto, OS_JobTemplate>(jobTemplate_Dto);
                            foreach (var prop in auditProps)
                            {
                                EntityPropertyChangeInfo propertyChange = new EntityPropertyChangeInfo();
                                object origVal = prop.GetValue(curJobTemplate);
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

                                        var valueProp = typeof(OS_JobTemplate).GetProperty(valuePropName);

                                        DictionaryValue _origValObj = (DictionaryValue)valueProp.GetValue(jobTemplate_Dto);
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
                            //if (departmentTemplate_Dto.ExtraProperties != curJobTemplate.ExtraProperties)
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

                        curJobTemplate.Name = jobTemplate_Dto.Name;
                        curJobTemplate.NameLocalized = jobTemplate_Dto.NameLocalized;
                        curJobTemplate.Code = jobTemplate_Dto.Code;
                        curJobTemplate.ReviewPeriod = jobTemplate_Dto.ReviewPeriod;
                        curJobTemplate.ReviewPeriodDays = jobTemplate_Dto.ReviewPeriodDays;
                        curJobTemplate.ValidityFromDate = jobTemplate_Dto.ValidityFromDate;
                        curJobTemplate.ValidityToDate = jobTemplate_Dto.ValidityToDate;
                        curJobTemplate.Description = jobTemplate_Dto.Description;
                        //curJobTemplate.MaxJobPositions = jobTemplate_Dto.MaxJobPositions;
                        curJobTemplate.CompensationMatrix = null;
                        curJobTemplate.CompensationMatrixId = jobTemplate_Dto.CompensationMatrixId;

                        #region Child Entities
                        OS_JobWorkshiftTemplate_Dto[] jobWorkshifts = jobTemplate_Dto.JobWorkshiftTemplates.ToArray();
                        int[] curJobWorkshiftsIds = curJobTemplate.JobWorkshiftTemplates != null && curJobTemplate.JobWorkshiftTemplates.Count > 0 ? curJobTemplate.JobWorkshiftTemplates.Select(x => x.Workshift.Id).ToArray() : new int[0];
                        List<int> toDeleteWorkshifts = new List<int>();
                        for (int i = 0; i < curJobWorkshiftsIds.Length; i++)
                        {
                            OS_JobWorkshiftTemplate curJobWorkshift = curJobTemplate.JobWorkshiftTemplates.First(x => x.WorkshiftId == curJobWorkshiftsIds[i]);
                            if (!jobWorkshifts.Any(x => x.Workshift.Id == curJobWorkshiftsIds[i]))
                            {
                                curJobTemplate.JobWorkshiftTemplates.Remove(curJobTemplate.JobWorkshiftTemplates.First(x => x.WorkshiftId == curJobWorkshiftsIds[i]));
                                toDeleteWorkshifts.Add(curJobWorkshiftsIds[i]);
                            }
                        }
                        for (int i = 0; i < jobWorkshifts.Length; i++)
                        {
                            if (!curJobTemplate.JobWorkshiftTemplates.Any(x => x.WorkshiftId == jobWorkshifts[i].Workshift.Id))
                            {
                                curJobTemplate.JobWorkshiftTemplates.Add(new OS_JobWorkshiftTemplate() { WorkshiftId = jobWorkshifts[i].Workshift.Id });
                            }
                            else
                            {
                                var _jobWorkshift = curJobTemplate.JobWorkshiftTemplates.First(x => x.WorkshiftId == jobWorkshifts[i].Workshift.Id);
                                //_jobLoc.JobValidityStart = posJobs[i].JobValidityStart;
                                //_jobLoc.JobValidityEnd = posJobs[i].JobValidityEnd;
                                //_jobLoc.Name = posJobs[i].Name;

                                //curJob.JobWorkshiftTemplates.Remove(curJob.JobWorkshiftTemplates.First(x => x.JobTemplateId == _jobLoc.JobTemplateId));
                                await OS_JobTemplateAppService.WorkshiftsRepository.UpdateAsync(_jobWorkshift);
                            }
                        }
                        for (int i = 0; i < toDeleteWorkshifts.Count; i++)
                        {
                            await OS_JobTemplateAppService.WorkshiftsRepository.DeleteAsync(x => x.WorkshiftId == toDeleteWorkshifts[i]);
                        }
                        
                        OS_JobTaskTemplate_Dto[] jobTasks = jobTemplate_Dto.JobTaskTemplates.ToArray();
                        int[] curJobTasksIds = curJobTemplate.JobTaskTemplates != null && curJobTemplate.JobTaskTemplates.Count > 0 ? curJobTemplate.JobTaskTemplates.Select(x => x.TaskTemplate.Id).ToArray() : new int[0];
                        List<int> toDeleteTasks = new List<int>();
                        for (int i = 0; i < curJobTasksIds.Length; i++)
                        {
                            OS_JobTaskTemplate curJobTask = curJobTemplate.JobTaskTemplates.First(x => x.TaskTemplateId == curJobTasksIds[i]);
                            if (!jobTasks.Any(x => x.TaskTemplate.Id == curJobTasksIds[i]))
                            {
                                curJobTemplate.JobTaskTemplates.Remove(curJobTemplate.JobTaskTemplates.First(x => x.TaskTemplateId == curJobTasksIds[i]));
                                toDeleteTasks.Add(curJobTasksIds[i]);
                            }
                        }
                        for (int i = 0; i < jobTasks.Length; i++)
                        {
                            if (!curJobTemplate.JobTaskTemplates.Any(x => x.TaskTemplateId == jobTasks[i].TaskTemplate.Id))
                            {
                                curJobTemplate.JobTaskTemplates.Add(new OS_JobTaskTemplate() { TaskTemplateId = jobTasks[i].TaskTemplate.Id });
                            }
                            else
                            {
                                var _jobTask = curJobTemplate.JobTaskTemplates.First(x => x.TaskTemplateId == jobTasks[i].TaskTemplate.Id);
                                //_jobLoc.JobValidityStart = posJobs[i].JobValidityStart;
                                //_jobLoc.JobValidityEnd = posJobs[i].JobValidityEnd;
                                //_jobLoc.Name = posJobs[i].Name;

                                //curJob.JobTaskTemplates.Remove(curJob.JobTaskTemplates.First(x => x.JobTemplateId == _jobLoc.JobTemplateId));
                                await OS_JobTemplateAppService.TasksRepository.UpdateAsync(_jobTask);
                            }
                        }
                        for (int i = 0; i < toDeleteTasks.Count; i++)
                        {
                            await OS_JobTemplateAppService.TasksRepository.DeleteAsync(x => x.TaskTemplateId == toDeleteTasks[i]);
                        }

                        OS_JobFunctionTemplate_Dto[] jobFunctions = jobTemplate_Dto.JobFunctionTemplates.ToArray();
                        int[] curJobFunctionsIds = curJobTemplate.JobFunctionTemplates != null && curJobTemplate.JobFunctionTemplates.Count > 0 ? curJobTemplate.JobFunctionTemplates.Select(x => x.FunctionTemplate.Id).ToArray() : new int[0];
                        List<int> toDeleteFunctions = new List<int>();
                        for (int i = 0; i < curJobFunctionsIds.Length; i++)
                        {
                            OS_JobFunctionTemplate curJobFunction = curJobTemplate.JobFunctionTemplates.First(x => x.FunctionTemplateId == curJobFunctionsIds[i]);
                            if (!jobFunctions.Any(x => x.FunctionTemplate.Id == curJobFunctionsIds[i]))
                            {
                                curJobTemplate.JobFunctionTemplates.Remove(curJobTemplate.JobFunctionTemplates.First(x => x.FunctionTemplateId == curJobFunctionsIds[i]));
                                toDeleteFunctions.Add(curJobFunctionsIds[i]);
                            }
                        }
                        for (int i = 0; i < jobFunctions.Length; i++)
                        {
                            if (!curJobTemplate.JobFunctionTemplates.Any(x => x.FunctionTemplateId == jobFunctions[i].FunctionTemplate.Id))
                            {
                                curJobTemplate.JobFunctionTemplates.Add(new OS_JobFunctionTemplate() { FunctionTemplateId = jobFunctions[i].FunctionTemplate.Id });
                            }
                            else
                            {
                                var _jobFunction = curJobTemplate.JobFunctionTemplates.First(x => x.FunctionTemplateId == jobFunctions[i].FunctionTemplate.Id);
                                //_jobLoc.JobValidityStart = posJobs[i].JobValidityStart;
                                //_jobLoc.JobValidityEnd = posJobs[i].JobValidityEnd;
                                //_jobLoc.Name = posJobs[i].Name;

                                //curJob.JobFunctionTemplates.Remove(curJob.JobFunctionTemplates.First(x => x.JobTemplateId == _jobLoc.JobTemplateId));
                                await OS_JobTemplateAppService.FunctionsRepository.UpdateAsync(_jobFunction);
                            }
                        }
                        for (int i = 0; i < toDeleteFunctions.Count; i++)
                        {
                            await OS_JobTemplateAppService.FunctionsRepository.DeleteAsync(x => x.FunctionTemplateId == toDeleteFunctions[i]);
                        }


                        OS_JobSkillTemplate_Dto[] jobSkills = jobTemplate_Dto.JobSkillTemplates.ToArray();
                        int[] curJobSkillsIds = curJobTemplate.JobSkillTemplates != null && curJobTemplate.JobSkillTemplates.Count > 0 ? curJobTemplate.JobSkillTemplates.Select(x => x.SkillTemplate.Id).ToArray() : new int[0];
                        List<int> toDeleteSkills = new List<int>();
                        for (int i = 0; i < curJobSkillsIds.Length; i++)
                        {
                            OS_JobSkillTemplate curJobSkill = curJobTemplate.JobSkillTemplates.First(x => x.SkillTemplateId == curJobSkillsIds[i]);
                            if (!jobSkills.Any(x => x.SkillTemplate.Id == curJobSkillsIds[i] && x.CreationTime == curJobSkill.CreationTime))
                            {
                                curJobTemplate.JobSkillTemplates.Remove(curJobTemplate.JobSkillTemplates.First(x => x.SkillTemplateId == curJobSkillsIds[i]));
                                toDeleteSkills.Add(curJobSkillsIds[i]);
                            }
                        }
                        for (int i = 0; i < jobSkills.Length; i++)
                        {
                            if (!curJobTemplate.JobSkillTemplates.Any(x => x.SkillTemplateId == jobSkills[i].SkillTemplate.Id))
                            {
                                curJobTemplate.JobSkillTemplates.Add(new OS_JobSkillTemplate() { SkillTemplateId = jobSkills[i].SkillTemplate.Id });
                            }
                            else
                            {
                                var _jobSkill = curJobTemplate.JobSkillTemplates.First(x => x.SkillTemplateId == jobSkills[i].SkillTemplate.Id);
                                //_jobLoc.JobValidityStart = posJobs[i].JobValidityStart;
                                //_jobLoc.JobValidityEnd = posJobs[i].JobValidityEnd;
                                //_jobLoc.Name = posJobs[i].Name;

                                //curJob.JobSkillTemplates.Remove(curJob.JobSkillTemplates.First(x => x.JobTemplateId == _jobLoc.JobTemplateId));
                                await OS_JobTemplateAppService.SkillsRepository.UpdateAsync(_jobSkill);
                            }
                        }
                        for (int i = 0; i < toDeleteSkills.Count; i++)
                        {
                            await OS_JobTemplateAppService.SkillsRepository.DeleteAsync(x => x.SkillTemplateId == toDeleteSkills[i]);
                        }

                        OS_JobAcademiaTemplate_Dto[] jobAcademia = jobTemplate_Dto.JobAcademiaTemplates.ToArray();
                        int[] curJobAcademiaIds = curJobTemplate.JobAcademiaTemplates != null && curJobTemplate.JobAcademiaTemplates.Count > 0 ? curJobTemplate.JobAcademiaTemplates.Select(x => x.AcademiaTemplateId).ToArray() : new int[0];
                        List<int> toDeleteAcademia = new List<int>();
                        for (int i = 0; i < curJobAcademiaIds.Length; i++)
                        {
                            OS_JobAcademiaTemplate curJobAcademia = curJobTemplate.JobAcademiaTemplates.First(x => x.AcademiaTemplateId == curJobAcademiaIds[i]);
                            if (!jobAcademia.Any(x => x.AcademiaTemplate.Id == curJobAcademiaIds[i]))
                            {
                                curJobTemplate.JobAcademiaTemplates.Remove(curJobTemplate.JobAcademiaTemplates.First(x => x.AcademiaTemplateId == curJobAcademiaIds[i]));
                                toDeleteSkills.Add(curJobAcademiaIds[i]);
                            }
                        }
                        for (int i = 0; i < jobAcademia.Length; i++)
                        {
                            if (!curJobTemplate.JobAcademiaTemplates.Any(x => x.AcademiaTemplateId == jobAcademia[i].AcademiaTemplate.Id))
                            {
                                curJobTemplate.JobAcademiaTemplates.Add(new OS_JobAcademiaTemplate() { AcademiaTemplateId = jobAcademia[i].AcademiaTemplate.Id });
                            }
                            else
                            {
                                var _jobAcademia = curJobTemplate.JobAcademiaTemplates.First(x => x.AcademiaTemplateId == jobAcademia[i].AcademiaTemplate.Id);
                                //_jobLoc.JobValidityStart = posJobs[i].JobValidityStart;
                                //_jobLoc.JobValidityEnd = posJobs[i].JobValidityEnd;
                                //_jobLoc.Name = posJobs[i].Name;

                                //curJob.JobAcademiaTemplates.Remove(curJob.JobAcademiaTemplates.First(x => x.JobTemplateId == _jobLoc.JobTemplateId));
                                await OS_JobTemplateAppService.AcademiaRepository.UpdateAsync(_jobAcademia);
                            }
                        }
                        for (int i = 0; i < toDeleteAcademia.Count; i++)
                        {
                            await OS_JobTemplateAppService.AcademiaRepository.DeleteAsync(x => x.AcademiaTemplateId == toDeleteAcademia[i]);
                        }
                        #endregion

                        OS_JobTemplate_Dto updated = ObjectMapper.Map<OS_JobTemplate, OS_JobTemplate_Dto>(await OS_JobTemplateAppService.Repository.UpdateAsync(curJobTemplate));
                        updated = ObjectMapper.Map<OS_JobTemplate, OS_JobTemplate_Dto>(await OS_JobTemplateAppService.Repository.GetAsync(updated.Id));

                        return StatusCode(200, updated);
                    }
                    else
                    {
                        jobTemplate_Dto.Id = 0;
                        if (jobTemplate_Dto.JobTaskTemplates != null)
                            jobTemplate_Dto.JobTaskTemplates.ForEach(x => { x.Id = 0; x.TaskTemplateId = x.TaskTemplate.Id; x.TaskTemplate = null; });
                        if (jobTemplate_Dto.JobFunctionTemplates != null)
                            jobTemplate_Dto.JobFunctionTemplates.ForEach(x => { x.Id = 0; x.FunctionTemplateId = x.FunctionTemplate.Id; x.FunctionTemplate = null; });
                        if (jobTemplate_Dto.JobSkillTemplates != null)
                            jobTemplate_Dto.JobSkillTemplates.ForEach(x => { x.Id = 0; x.SkillTemplateId = x.SkillTemplate.Id; x.SkillTemplate = null; });
                        if (jobTemplate_Dto.JobAcademiaTemplates != null)
                            jobTemplate_Dto.JobAcademiaTemplates.ForEach(x => { x.Id = 0; x.AcademiaTemplateId = x.AcademiaTemplate.Id; x.AcademiaTemplate = null; });
                        if (jobTemplate_Dto.JobWorkshiftTemplates != null)
                            jobTemplate_Dto.JobWorkshiftTemplates.ForEach(x => { x.Id = 0; x.WorkshiftId = x.Workshift.Id; x.Workshift = null; });
                        jobTemplate_Dto.CompensationMatrix = null;

                        OS_JobTemplate_Dto added = await OS_JobTemplateAppService.CreateAsync(jobTemplate_Dto);
                        added = await OS_JobTemplateAppService.GetAsync(added.Id);

                        if (AuditingManager.Current != null)
                        {
                            EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                            entityChangeInfo.EntityId = added.Id.ToString();
                            entityChangeInfo.EntityTenantId = added.TenantId;
                            entityChangeInfo.ChangeTime = DateTime.Now;
                            entityChangeInfo.ChangeType = EntityChangeType.Created;
                            entityChangeInfo.EntityTypeFullName = typeof(OS_JobTemplate).FullName;

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
        public async Task<IActionResult> OnDeleteJobTemplate()
        {
            List<OS_JobTemplate_Dto> entitites = JsonSerializer.Deserialize<List<OS_JobTemplate_Dto>>(Request.Form["jobs"]);
            try
            {
                for (int i = 0; i < entitites.Count; i++)
                {
                    OS_JobTemplate_Dto entity = entitites[i];
                    //await TaskTemplatesAppService.Repository.DeleteAsync(leaveRequest.);
                    await OS_JobTemplateAppService.Repository.DeleteAsync(entity.Id);

                    if (AuditingManager.Current != null)
                    {
                        EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                        entityChangeInfo.EntityId = entity.Id.ToString();
                        entityChangeInfo.EntityTenantId = entity.TenantId;
                        entityChangeInfo.ChangeTime = DateTime.Now;
                        entityChangeInfo.ChangeType = EntityChangeType.Deleted;
                        entityChangeInfo.EntityTypeFullName = typeof(OS_JobTemplate).FullName;

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

        //public async Task<IActionResult> OnPostJobQualificationTemplate()
        //{

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var FormData = Request.Form;

        //            OS_JobQualificationTemplate_Dto jobQualificationTemplate_Dto = JsonSerializer.Deserialize<OS_JobQualificationTemplate_Dto>(FormData["info"]);

        //            bool IsEditing = jobQualificationTemplate_Dto.Id > 0;
        //            if (IsEditing)
        //            {
        //                OS_JobQualificationTemplate curJobQualificationTemplate = await OS_JobTemplateAppService.QualificationsRepository.GetAsync(jobQualificationTemplate_Dto.Id);

        //                if (AuditingManager.Current != null)
        //                {
        //                    EntityChangeInfo entityChangeInfo = new EntityChangeInfo();

        //                    entityChangeInfo.EntityId = jobQualificationTemplate_Dto.Id.ToString();
        //                    entityChangeInfo.EntityTenantId = jobQualificationTemplate_Dto.TenantId;
        //                    entityChangeInfo.ChangeTime = DateTime.Now;
        //                    entityChangeInfo.ChangeType = EntityChangeType.Updated;
        //                    entityChangeInfo.EntityTypeFullName = typeof(OS_JobQualificationTemplate).FullName;

        //                    entityChangeInfo.PropertyChanges = new List<EntityPropertyChangeInfo>();
        //                    List<EntityPropertyChangeInfo> entityPropertyChanges = new List<EntityPropertyChangeInfo>();
        //                    var auditProps = typeof(OS_JobQualificationTemplate).GetProperties().Where(x => Attribute.IsDefined(x, typeof(CustomAuditedAttribute))).ToList();

        //                    OS_JobQualificationTemplate mappedInput = ObjectMapper.Map<OS_JobQualificationTemplate_Dto, OS_JobQualificationTemplate>(jobQualificationTemplate_Dto);
        //                    foreach (var prop in auditProps)
        //                    {
        //                        EntityPropertyChangeInfo propertyChange = new EntityPropertyChangeInfo();
        //                        object origVal = prop.GetValue(curJobQualificationTemplate);
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

        //                                var valueProp = typeof(OS_JobQualificationTemplate).GetProperty(valuePropName);

        //                                DictionaryValue _origValObj = (DictionaryValue)valueProp.GetValue(jobQualificationTemplate_Dto);
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

        //                curJobQualificationTemplate.DegreeId = jobQualificationTemplate_Dto.DegreeId;
        //                curJobQualificationTemplate.InstituteId = jobQualificationTemplate_Dto.InstituteId;
        //                curJobQualificationTemplate.PeriodStartDate = jobQualificationTemplate_Dto.PeriodStartDate;
        //                curJobQualificationTemplate.PeriodEndDate = jobQualificationTemplate_Dto.PeriodEndDate;

        //                OS_JobQualificationTemplate_Dto updated = ObjectMapper.Map<OS_JobQualificationTemplate, OS_JobQualificationTemplate_Dto>(await OS_JobTemplateAppService.QualificationsRepository.UpdateAsync(curJobQualificationTemplate));
        //                updated = ObjectMapper.Map<OS_JobQualificationTemplate, OS_JobQualificationTemplate_Dto>(await OS_JobTemplateAppService.QualificationsRepository.GetAsync(updated.Id));

        //                return StatusCode(200, updated);
        //            }
        //            else
        //            {
        //                jobQualificationTemplate_Dto.Id = 0;

        //                OS_JobQualificationTemplate_Dto added = await OS_JobTemplateAppService.AddQualificationTemplate(jobQualificationTemplate_Dto);

        //                if (AuditingManager.Current != null)
        //                {
        //                    EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
        //                    entityChangeInfo.EntityId = added.Id.ToString();
        //                    entityChangeInfo.EntityTenantId = added.TenantId;
        //                    entityChangeInfo.ChangeTime = DateTime.Now;
        //                    entityChangeInfo.ChangeType = EntityChangeType.Created;
        //                    entityChangeInfo.EntityTypeFullName = typeof(OS_JobQualificationTemplate).FullName;

        //                    AuditingManager.Current.Log.EntityChanges.Add(entityChangeInfo);
        //                }

        //                added = ObjectMapper.Map<OS_JobQualificationTemplate, OS_JobQualificationTemplate_Dto>(await OS_JobTemplateAppService.QualificationsRepository.GetAsync(added.Id));

        //                return StatusCode(200, added);
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }

        //    return StatusCode(500);
        //}
        //public async Task<IActionResult> OnDeleteJobQualificationTemplate()
        //{
        //    List<OS_JobQualificationTemplate_Dto> entitites = JsonSerializer.Deserialize<List<OS_JobQualificationTemplate_Dto>>(Request.Form["qualifications"]);
        //    try
        //    {
        //        for (int i = 0; i < entitites.Count; i++)
        //        {
        //            OS_JobQualificationTemplate_Dto entity = entitites[i];
        //            //await JobQualificationTemplatesAppService.Repository.DeleteAsync(leaveRequest.);
        //            await OS_JobTemplateAppService.QualificationsRepository.DeleteAsync(entity.Id);

        //            if (AuditingManager.Current != null)
        //            {
        //                EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
        //                entityChangeInfo.EntityId = entity.Id.ToString();
        //                entityChangeInfo.EntityTenantId = entity.TenantId;
        //                entityChangeInfo.ChangeTime = DateTime.Now;
        //                entityChangeInfo.ChangeType = EntityChangeType.Deleted;
        //                entityChangeInfo.EntityTypeFullName = typeof(OS_JobQualificationTemplate).FullName;

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

            List<OS_JobTemplate_Dto> Entities = await OS_JobTemplateAppService.GetAllJobTemplatesAsync();
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

                    OS_JobTemplate_Dto department = Entities.First(x => x.Id.ToString() == entityChange.EntityId);
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
