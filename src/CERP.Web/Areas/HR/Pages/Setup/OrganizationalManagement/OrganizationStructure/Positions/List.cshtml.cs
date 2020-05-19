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
using CERP.App.Helpers;

namespace CERP.Web.Areas.HR.Setup.OrganizationalManagement.OrganizationStructure.Pages.Positions
{
    public class ListModel : CERPPageModel
    {
        public IWebHostEnvironment webHostEnvironment { get; set; }
        public IRepository<DictionaryValue, Guid> DictionaryValuesRepo { get; set; }
        public IAuditLogRepository AuditLogsRepo { get; set; }

        public OS_DepartmentTemplateAppService OS_DepartmentTemplateAppService { get; set; }
        public OS_PositionTemplateAppService OS_PositionTemplateAppService { get; set; }

        public IAuditingManager AuditingManager { get; set; }
        public IRepository<CustomEntityChange> CustomEntityChangesRepo { get; set; }

        public ListModel(IJsonSerializer jsonSerializer, IRepository<DictionaryValue, Guid> dictionaryValuesRepo, IWebHostEnvironment webHostEnvironment, IAuditLogRepository auditLogsRepo, OS_PositionTemplateAppService oS_PositionTemplateAppService, OS_DepartmentTemplateAppService oS_DepartmentTemplateAppService)
        {
            JsonSerializer = jsonSerializer;
            DictionaryValuesRepo = dictionaryValuesRepo;
            this.webHostEnvironment = webHostEnvironment;
            AuditLogsRepo = auditLogsRepo;
            OS_PositionTemplateAppService = oS_PositionTemplateAppService;
            OS_DepartmentTemplateAppService = oS_DepartmentTemplateAppService;
        }

        public IJsonSerializer JsonSerializer { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostPositionTemplate()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var FormData = Request.Form;

                    OS_PositionTemplate_Dto positionTemplate_Dto = JsonSerializer.Deserialize<OS_PositionTemplate_Dto>(FormData["info"]);

                    if (positionTemplate_Dto.Level == OS_PositionLevel.One)
                    {
                        OS_DepartmentTemplate curPositionDepTemplate = await OS_DepartmentTemplateAppService.Repository.GetAsync(positionTemplate_Dto.DepartmentTemplateId);
                        if(curPositionDepTemplate.PositionTemplates.Any(x => x.Level == OS_PositionLevel.One && x.Id != positionTemplate_Dto.Id))
                        {
                            Exception ex = new Exception($"The position '{curPositionDepTemplate.PositionTemplates.First(x => x.Level == OS_PositionLevel.One).Name}' as a level '{App.Helpers.EnumExtensions.GetDescription(OS_PositionLevel.One)}' position already exists in the department '{curPositionDepTemplate.Name}'");
                            throw ex;
                        }
                    }

                    bool IsEditing = positionTemplate_Dto.Id > 0;
                    if (IsEditing)
                    {
                        OS_PositionTemplate curPositionTemplate = await OS_PositionTemplateAppService.Repository.GetAsync(positionTemplate_Dto.Id);

                        if (AuditingManager.Current != null)
                        {
                            EntityChangeInfo entityChangeInfo = new EntityChangeInfo();

                            entityChangeInfo.EntityId = positionTemplate_Dto.Id.ToString();
                            entityChangeInfo.EntityTenantId = positionTemplate_Dto.TenantId;
                            entityChangeInfo.ChangeTime = DateTime.Now;
                            entityChangeInfo.ChangeType = EntityChangeType.Updated;
                            entityChangeInfo.EntityTypeFullName = typeof(OS_PositionTemplate).FullName;

                            entityChangeInfo.PropertyChanges = new List<EntityPropertyChangeInfo>();
                            List<EntityPropertyChangeInfo> entityPropertyChanges = new List<EntityPropertyChangeInfo>();
                            var auditProps = typeof(OS_PositionTemplate).GetProperties().Where(x => Attribute.IsDefined(x, typeof(CustomAuditedAttribute))).ToList();

                            OS_PositionTemplate mappedInput = ObjectMapper.Map<OS_PositionTemplate_Dto, OS_PositionTemplate>(positionTemplate_Dto);
                            foreach (var prop in auditProps)
                            {
                                EntityPropertyChangeInfo propertyChange = new EntityPropertyChangeInfo();
                                object origVal = prop.GetValue(curPositionTemplate);
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

                                        var valueProp = typeof(OS_PositionTemplate).GetProperty(valuePropName);

                                        DictionaryValue _origValObj = (DictionaryValue)valueProp.GetValue(positionTemplate_Dto);
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
                            //if (positionTemplate_Dto.ExtraProperties != curPositionTemplate.ExtraProperties)
                            //{
                            //    //GeneralInfo oldGeneralInfo = position.GetProperty<GeneralInfo>("generalInfo");
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

                        curPositionTemplate.Name = positionTemplate_Dto.Name;
                        curPositionTemplate.NameLocalized = positionTemplate_Dto.NameLocalized;
                        curPositionTemplate.Code = positionTemplate_Dto.Code;
                        curPositionTemplate.Level = positionTemplate_Dto.Level;
                        curPositionTemplate.DepartmentTemplate = null;
                        curPositionTemplate.DepartmentTemplateId = positionTemplate_Dto.DepartmentTemplateId;
                        curPositionTemplate.CostCenter = null;
                        curPositionTemplate.CostCenterId = positionTemplate_Dto.CostCenterId;
                        curPositionTemplate.ReviewPeriod = positionTemplate_Dto.ReviewPeriod;
                        curPositionTemplate.HiringType = positionTemplate_Dto.HiringType;
                        curPositionTemplate.ValidityFromDate = positionTemplate_Dto.ValidityFromDate;
                        curPositionTemplate.ValidityToDate = positionTemplate_Dto.ValidityToDate;
                        curPositionTemplate.ActivationDate = positionTemplate_Dto.ActivationDate;

                        #region Child Entities
                        OS_PositionJobTemplate_Dto[] posJobs = positionTemplate_Dto.PositionJobTemplates.ToArray();
                        int[] curPosJobsIds = curPositionTemplate.PositionJobTemplates != null && curPositionTemplate.PositionJobTemplates.Count > 0 ? curPositionTemplate.PositionJobTemplates.Select(x => x.PositionTemplate.Id).ToArray() : new int[0];
                        List<int> toDeleteJobs = new List<int>();
                        for (int i = 0; i < curPosJobsIds.Length; i++)
                        {
                            OS_PositionJobTemplate curPositionJob = curPositionTemplate.PositionJobTemplates.First(x => x.PositionTemplate.Id == curPosJobsIds[i]);
                            if (!posJobs.Any(x => x.PositionTemplateId == curPosJobsIds[i] && x.CreationTime == curPositionJob.CreationTime))
                            {
                                curPositionTemplate.PositionJobTemplates.Remove(curPositionTemplate.PositionJobTemplates.First(x => x.PositionTemplate.Id == curPosJobsIds[i]));
                                toDeleteJobs.Add(curPosJobsIds[i]);
                            }
                        }
                        for (int i = 0; i < posJobs.Length; i++)
                        {
                            if (!curPositionTemplate.PositionJobTemplates.Any(x => x.JobTemplateId == posJobs[i].JobTemplate.Id && x.CreationTime == posJobs[i].CreationTime))
                            {
                                curPositionTemplate.PositionJobTemplates.Add(new OS_PositionJobTemplate() { JobTemplateId = posJobs[i].JobTemplate.Id });
                            }
                            else
                            {
                                var _positionJob = curPositionTemplate.PositionJobTemplates.First(x => x.PositionTemplateId == posJobs[i].PositionTemplate.Id);
                                //_positionLoc.PositionValidityStart = posJobs[i].PositionValidityStart;
                                //_positionLoc.PositionValidityEnd = posJobs[i].PositionValidityEnd;
                                //_positionLoc.Name = posJobs[i].Name;

                                //curPosition.PositionJobTemplates.Remove(curPosition.PositionJobTemplates.First(x => x.PositionTemplateId == _positionLoc.PositionTemplateId));
                                await OS_PositionTemplateAppService.PositionJobsTemplateRepo.UpdateAsync(_positionJob);
                            }
                        }

                        OS_PositionTaskTemplate_Dto[] posTasks = positionTemplate_Dto.PositionTaskTemplates.ToArray();
                        int[] curPosTaskIds = curPositionTemplate.PositionTaskTemplates != null && curPositionTemplate.PositionTaskTemplates.Count > 0 ? curPositionTemplate.PositionTaskTemplates.Select(x => x.PositionTemplate.Id).ToArray() : new int[0];
                        List<int> toDeleteTasks = new List<int>();
                        for (int i = 0; i < curPosTaskIds.Length; i++)
                        {
                            OS_PositionTaskTemplate curPositionTask = curPositionTemplate.PositionTaskTemplates.First(x => x.PositionTemplate.Id == curPosTaskIds[i]);
                            if (!posTasks.Any(x => x.PositionTemplateId == curPosTaskIds[i] && x.CreationTime == curPositionTask.CreationTime))
                            {
                                curPositionTemplate.PositionTaskTemplates.Remove(curPositionTemplate.PositionTaskTemplates.First(x => x.PositionTemplate.Id == curPosTaskIds[i]));
                                toDeleteTasks.Add(curPosTaskIds[i]);
                            }
                        }
                        for (int i = 0; i < posTasks.Length; i++)
                        {
                            if (!curPositionTemplate.PositionTaskTemplates.Any(x => x.PositionTemplateId == posTasks[i].PositionTemplateId))
                            {
                                curPositionTemplate.PositionTaskTemplates.Add(new OS_PositionTaskTemplate() { TaskTemplateId = posTasks[i].TaskTemplate.Id });
                            }
                            else
                            {
                                var _positionTask = curPositionTemplate.PositionTaskTemplates.First(x => x.PositionTemplateId == posTasks[i].PositionTemplate.Id);
                                //_positionLoc.PositionValidityStart = posTasks[i].PositionValidityStart;
                                //_positionLoc.PositionValidityEnd = posTasks[i].PositionValidityEnd;
                                //_positionLoc.Name = posTasks[i].Name;

                                //curPosition.PositionTaskTemplates.Remove(curPosition.PositionTaskTemplates.First(x => x.PositionTemplateId == _positionLoc.PositionTemplateId));
                                await OS_PositionTemplateAppService.PositionTasksTemplateRepo.UpdateAsync(_positionTask);
                            }
                        }

                        for (int i = 0; i < toDeleteTasks.Count; i++)
                        {
                            await OS_PositionTemplateAppService.PositionTasksTemplateRepo.DeleteAsync(x => x.PositionTemplateId == toDeleteTasks[i]);
                        }
                        for (int i = 0; i < toDeleteJobs.Count; i++)
                        {
                            await OS_PositionTemplateAppService.PositionJobsTemplateRepo.DeleteAsync(x => x.PositionTemplateId == toDeleteJobs[i]);
                        }
                        #endregion

                        OS_PositionTemplate_Dto updated = ObjectMapper.Map<OS_PositionTemplate, OS_PositionTemplate_Dto>(await OS_PositionTemplateAppService.Repository.UpdateAsync(curPositionTemplate));
                        updated.CostCenter = ObjectMapper.Map<DictionaryValue, DictionaryValue_Dto>(await DictionaryValuesRepo.GetAsync(updated.CostCenterId));
                        updated.PositionJobTemplates = ObjectMapper.Map<List<OS_PositionJobTemplate>, List<OS_PositionJobTemplate_Dto>>(curPositionTemplate.PositionJobTemplates.ToList());
                        updated.PositionTaskTemplates = ObjectMapper.Map<List<OS_PositionTaskTemplate>, List<OS_PositionTaskTemplate_Dto>>(curPositionTemplate.PositionTaskTemplates.ToList());
                        updated.DepartmentTemplate = await OS_DepartmentTemplateAppService.GetDepartmentTemplateAsync(updated.DepartmentTemplateId);

                        return StatusCode(200, updated);
                    }
                    else
                    {
                        positionTemplate_Dto.Id = 0;
                        if(positionTemplate_Dto.PositionJobTemplates != null)
                            positionTemplate_Dto.PositionJobTemplates.ForEach(x => { x.Id = 0; x.JobTemplateId = x.JobTemplate.Id; x.JobTemplate = null; });
                        if(positionTemplate_Dto.PositionTaskTemplates != null)
                            positionTemplate_Dto.PositionTaskTemplates.ForEach(x => { x.Id = 0; x.TaskTemplateId = x.TaskTemplate.Id; x.TaskTemplate = null; });

                        OS_PositionTemplate_Dto added = await OS_PositionTemplateAppService.CreateAsync(positionTemplate_Dto);
                        added.CostCenter = ObjectMapper.Map<DictionaryValue, DictionaryValue_Dto>(await DictionaryValuesRepo.GetAsync(added.CostCenterId));
                        added.DepartmentTemplate = await OS_DepartmentTemplateAppService.GetDepartmentTemplateAsync(added.DepartmentTemplateId);

                        if (AuditingManager.Current != null)
                        {
                            EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                            entityChangeInfo.EntityId = added.Id.ToString();
                            entityChangeInfo.EntityTenantId = added.TenantId;
                            entityChangeInfo.ChangeTime = DateTime.Now;
                            entityChangeInfo.ChangeType = EntityChangeType.Created;
                            entityChangeInfo.EntityTypeFullName = typeof(OS_PositionTemplate).FullName;

                            AuditingManager.Current.Log.EntityChanges.Add(entityChangeInfo);
                        }

                        return StatusCode(200, added);
                    }
                }
                catch(Exception ex)
                {
                    return StatusCode(500, ex);
                }
            }

            return StatusCode(500);
        }
        public async Task<IActionResult> OnDeletePositionTemplate()
        {
            List<OS_PositionTemplate_Dto> positions = JsonSerializer.Deserialize<List<OS_PositionTemplate_Dto>>(Request.Form["positions"]);
            int statusCode = await DeletePositions(positions, OS_PositionTemplateAppService.PositionJobsTemplateRepo, OS_PositionTemplateAppService.PositionTasksTemplateRepo, OS_PositionTemplateAppService.Repository, AuditingManager);
            return StatusCode(statusCode);
        }

        public static async Task<int> DeletePositions(List<OS_PositionTemplate> positions, IRepository<OS_PositionJobTemplate> PositionJobsTemplateRepo, IRepository<OS_PositionTaskTemplate> PositionTasksTemplateRepo, IRepository<OS_PositionTemplate, int> PositionTemplatesRepo, IAuditingManager _AuditingManager)
        {
            try
            {
                for (int i = 0; i < positions.Count; i++)
                {
                    OS_PositionTemplate position = positions[i];
                    //await TaskTemplatesAppService.Repository.DeleteAsync(leaveRequest.);
                    if (position.PositionJobTemplates != null)
                    {
                        for (int y = 0; y < position.PositionJobTemplates.Count; y++)
                        {
                            await PositionJobsTemplateRepo.DeleteAsync(x => x.JobTemplateId == position.PositionJobTemplates.ElementAt(y).JobTemplateId && x.CreationTime == position.PositionJobTemplates.ElementAt(y).CreationTime);
                        }
                    }
                    if (position.PositionTaskTemplates != null)
                    {
                        for (int y = 0; y < position.PositionTaskTemplates.Count; y++)
                        {
                            await PositionTasksTemplateRepo.DeleteAsync(x => x.TaskTemplateId == position.PositionTaskTemplates.ElementAt(y).TaskTemplateId && x.CreationTime == position.PositionTaskTemplates.ElementAt(y).CreationTime);
                        }
                    }
                    await PositionTemplatesRepo.DeleteAsync(position.Id);

                    if (_AuditingManager.Current != null)
                    {
                        EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                        entityChangeInfo.EntityId = position.Id.ToString();
                        entityChangeInfo.EntityTenantId = position.TenantId;
                        entityChangeInfo.ChangeTime = DateTime.Now;
                        entityChangeInfo.ChangeType = EntityChangeType.Deleted;
                        entityChangeInfo.EntityTypeFullName = typeof(OS_PositionTemplate).FullName;

                        _AuditingManager.Current.Log.EntityChanges.Add(entityChangeInfo);
                    }
                }
                return 200;
            }
            catch (Exception ex)
            {
                return 500;
            }
        }
        public static async Task<int> DeletePositions(List<OS_PositionTemplate_Dto> positions, IRepository<OS_PositionJobTemplate> PositionJobsTemplateRepo, IRepository<OS_PositionTaskTemplate> PositionTasksTemplateRepo, IRepository<OS_PositionTemplate, int> PositionTemplatesRepo, IAuditingManager _AuditingManager)
        {
            try
            {
                for (int i = 0; i < positions.Count; i++)
                {
                    OS_PositionTemplate_Dto position = positions[i];
                    //await TaskTemplatesAppService.Repository.DeleteAsync(leaveRequest.);
                    if (position.PositionJobTemplates != null)
                    {
                        for (int y = 0; y < position.PositionJobTemplates.Count; y++)
                        {
                            await PositionJobsTemplateRepo.DeleteAsync(x => x.JobTemplateId == position.PositionJobTemplates[y].JobTemplateId && x.CreationTime == position.PositionJobTemplates[y].CreationTime);
                        }
                    }
                    if (position.PositionTaskTemplates != null)
                    {
                        for (int y = 0; y < position.PositionTaskTemplates.Count; y++)
                        {
                            await PositionTasksTemplateRepo.DeleteAsync(x => x.TaskTemplateId == position.PositionTaskTemplates[y].TaskTemplateId && x.CreationTime == position.PositionTaskTemplates[y].CreationTime);
                        }
                    }
                    await PositionTemplatesRepo.DeleteAsync(position.Id);

                    if (_AuditingManager.Current != null)
                    {
                        EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                        entityChangeInfo.EntityId = position.Id.ToString();
                        entityChangeInfo.EntityTenantId = position.TenantId;
                        entityChangeInfo.ChangeTime = DateTime.Now;
                        entityChangeInfo.ChangeType = EntityChangeType.Deleted;
                        entityChangeInfo.EntityTypeFullName = typeof(OS_PositionTemplate).FullName;

                        _AuditingManager.Current.Log.EntityChanges.Add(entityChangeInfo);
                    }
                }
                return 200;
            }
            catch (Exception ex)
            {
                return 500;
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
            var positionLogs = AuditLogsRepo.WithDetails().Where(x => x.Url == HttpContext.Request.Path.Value && x.EntityChanges != null && x.EntityChanges.Count > 0).ToList();

            List<OS_PositionTemplate_Dto> Entities = await OS_PositionTemplateAppService.GetAllPositionTemplatesAsync();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            for (int i = 0; i < positionLogs.Count; i++)
            {
                AuditLog auditLog = positionLogs[i];
                if (auditLog.EntityChanges == null || auditLog.EntityChanges.Count == 0) continue;
                var entityChanges = auditLog.EntityChanges.ToList();
                for (int j = 0; j < entityChanges.Count; j++)
                {
                    EntityChange entityChange = entityChanges[j];

                    dynamic changeRow = new ExpandoObject();
                    changeRow.AuditLogId = entityChange.Id;
                    changeRow.EntityChangeId = entityChange.Id;

                    OS_PositionTemplate_Dto position = Entities.First(x => x.Id.ToString() == entityChange.EntityId);
                    changeRow.Id = position.Id;
                    changeRow.Name = position.Name;
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
