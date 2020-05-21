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

namespace CERP.Web.Areas.HR.Setup.OrganizationalManagement.OrganizationStructure.Pages.Departments
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

        public ListModel(IJsonSerializer jsonSerializer, IRepository<DictionaryValue, Guid> dictionaryValuesRepo, IWebHostEnvironment webHostEnvironment, IAuditLogRepository auditLogsRepo, OS_DepartmentTemplateAppService oS_DepartmentTemplateAppService, OS_PositionTemplateAppService oS_PositionTemplateAppService)
        {
            JsonSerializer = jsonSerializer;
            DictionaryValuesRepo = dictionaryValuesRepo;
            this.webHostEnvironment = webHostEnvironment;
            AuditLogsRepo = auditLogsRepo;
            OS_DepartmentTemplateAppService = oS_DepartmentTemplateAppService;
            OS_PositionTemplateAppService = oS_PositionTemplateAppService;
        }

        public IJsonSerializer JsonSerializer { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostDepartmentTemplate()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var FormData = Request.Form;

                    OS_DepartmentTemplate_Dto departmentTemplate_Dto = JsonSerializer.Deserialize<OS_DepartmentTemplate_Dto>(FormData["info"]);

                    bool IsEditing = departmentTemplate_Dto.Id > 0;
                    if (IsEditing)
                    {
                        OS_DepartmentTemplate curDepartmentTemplate = await OS_DepartmentTemplateAppService.Repository.GetAsync(departmentTemplate_Dto.Id);
                        
                        if (AuditingManager.Current != null)
                        {
                            EntityChangeInfo entityChangeInfo = new EntityChangeInfo();

                            entityChangeInfo.EntityId = departmentTemplate_Dto.Id.ToString();
                            entityChangeInfo.EntityTenantId = departmentTemplate_Dto.TenantId;
                            entityChangeInfo.ChangeTime = DateTime.Now;
                            entityChangeInfo.ChangeType = EntityChangeType.Updated;
                            entityChangeInfo.EntityTypeFullName = typeof(OS_DepartmentTemplate).FullName;

                            entityChangeInfo.PropertyChanges = new List<EntityPropertyChangeInfo>();
                            List<EntityPropertyChangeInfo> entityPropertyChanges = new List<EntityPropertyChangeInfo>();
                            var auditProps = typeof(OS_DepartmentTemplate).GetProperties().Where(x => Attribute.IsDefined(x, typeof(CustomAuditedAttribute))).ToList();

                            OS_DepartmentTemplate mappedInput = ObjectMapper.Map<OS_DepartmentTemplate_Dto, OS_DepartmentTemplate>(departmentTemplate_Dto);
                            foreach (var prop in auditProps)
                            {
                                EntityPropertyChangeInfo propertyChange = new EntityPropertyChangeInfo();
                                object origVal = prop.GetValue(curDepartmentTemplate);
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

                                        var valueProp = typeof(OS_DepartmentTemplate).GetProperty(valuePropName);

                                        DictionaryValue _origValObj = (DictionaryValue)valueProp.GetValue(departmentTemplate_Dto);
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
                            //if (departmentTemplate_Dto.ExtraProperties != curDepartmentTemplate.ExtraProperties)
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

                        curDepartmentTemplate.Name = departmentTemplate_Dto.Name;
                        curDepartmentTemplate.NameLocalized = departmentTemplate_Dto.NameLocalized;
                        curDepartmentTemplate.Code = departmentTemplate_Dto.Code;
                        curDepartmentTemplate.ReviewPeriod = departmentTemplate_Dto.ReviewPeriod;
                        curDepartmentTemplate.ValidityFromDate = departmentTemplate_Dto.ValidityFromDate;
                        curDepartmentTemplate.ValidityToDate = departmentTemplate_Dto.ValidityToDate;


                        OS_DepartmentCostCenterTemplate_Dto[] depCostCenters = departmentTemplate_Dto.DepartmentCostCenterTemplates.ToArray();
                        int[] curPosCostCentersIds = curDepartmentTemplate.DepartmentCostCenterTemplates != null && curDepartmentTemplate.DepartmentCostCenterTemplates.Count > 0 ? curDepartmentTemplate.DepartmentCostCenterTemplates.Select(x => x.DepartmentTemplate.Id).ToArray() : new int[0];
                        List<int> toDeleteCostCenters = new List<int>();
                        for (int i = 0; i < curPosCostCentersIds.Length; i++)
                        {
                            OS_DepartmentCostCenterTemplate curDepartmentCostCenter = curDepartmentTemplate.DepartmentCostCenterTemplates.First(x => x.DepartmentTemplate.Id == curPosCostCentersIds[i]);
                            if (!depCostCenters.Any(x => x.DepartmentTemplateId == curPosCostCentersIds[i] && x.CreationTime == curDepartmentCostCenter.CreationTime))
                            {
                                curDepartmentTemplate.DepartmentCostCenterTemplates.Remove(curDepartmentTemplate.DepartmentCostCenterTemplates.First(x => x.DepartmentTemplate.Id == curPosCostCentersIds[i]));
                                toDeleteCostCenters.Add(curPosCostCentersIds[i]);
                            }
                        }
                        for (int i = 0; i < depCostCenters.Length; i++)
                        {
                            if (!curDepartmentTemplate.DepartmentCostCenterTemplates.Any(x => x.CostCenterId == depCostCenters[i].CostCenter.Id && x.CreationTime == depCostCenters[i].CreationTime))
                            {
                                curDepartmentTemplate.DepartmentCostCenterTemplates.Add(new OS_DepartmentCostCenterTemplate() { CostCenterId = depCostCenters[i].CostCenter.Id, Percentage = depCostCenters[i].Percentage });
                            }
                            else
                            {
                                var _departmentCostCenter = curDepartmentTemplate.DepartmentCostCenterTemplates.First(x => x.DepartmentTemplateId == depCostCenters[i].DepartmentTemplate.Id);
                                //_departmentLoc.DepartmentValidityStart = posCostCenters[i].DepartmentValidityStart;
                                //_departmentLoc.DepartmentValidityEnd = posCostCenters[i].DepartmentValidityEnd;
                                //_departmentLoc.Name = posCostCenters[i].Name;

                                //curDepartment.DepartmentCostCenterTemplates.Remove(curDepartment.DepartmentCostCenterTemplates.First(x => x.DepartmentTemplateId == _departmentLoc.DepartmentTemplateId));
                                await OS_DepartmentTemplateAppService.DepartmentCostCentersTemplateRepo.UpdateAsync(_departmentCostCenter);
                            }
                        }
                        for (int i = 0; i < toDeleteCostCenters.Count; i++)
                        {
                            await OS_DepartmentTemplateAppService.DepartmentCostCentersTemplateRepo.DeleteAsync(x => x.DepartmentTemplateId == toDeleteCostCenters[i]);
                        }

                        OS_PositionTemplate_Dto[] depPositions = departmentTemplate_Dto.PositionTemplates.ToArray();
                        int[] curDepPositionsIds = curDepartmentTemplate.PositionTemplates != null && curDepartmentTemplate.PositionTemplates.Count > 0? curDepartmentTemplate.PositionTemplates.Select(x => x.Id).ToArray() : new int[0];
                        List<OS_PositionTemplate> toDeletePositions = new List<OS_PositionTemplate>();
                        for (int i = 0; i < curDepPositionsIds.Length; i++)
                        {
                            OS_PositionTemplate curDepartmentPosition = curDepartmentTemplate.PositionTemplates.First(x => x.Id == curDepPositionsIds[i]);
                            if (!depPositions.Any(x => x.Id == curDepPositionsIds[i] && x.CreationTime == curDepartmentPosition.CreationTime))
                            {
                                //curDepartmentTemplate.PositionTemplates.Remove(curDepartmentPosition);
                                toDeletePositions.Add(curDepartmentPosition);
                            }
                            else
                            {

                            }
                        }
                        for (int i = 0; i < depPositions.Length; i++)
                        {
                            if (!curDepartmentTemplate.PositionTemplates.Any(x => x.Id == depPositions[i].Id && x.CreationTime == depPositions[i].CreationTime))
                            {
                                OS_PositionTemplate positionTemplate = await OS_DepartmentTemplateAppService.PositionTemplateRepo.GetAsync(depPositions[i].Id);
                                curDepartmentTemplate.PositionTemplates.Add(positionTemplate);
                                positionTemplate.DepartmentTemplateId = curDepartmentTemplate.Id;
                                positionTemplate.DepartmentTemplate = null;
                            }
                            else
                            {
                                var _positionLoc = curDepartmentTemplate.PositionTemplates.First(x => x.Id == depPositions[i].Id);
                                //_departmentLoc.PositionValidityStart = depPositions[i].PositionValidityStart;
                                //_departmentLoc.PositionValidityEnd = depPositions[i].PositionValidityEnd;
                                //_departmentLoc.Name = depPositions[i].Name;

                                //curDepartment.DepartmentPositionTemplates.Remove(curDepartment.DepartmentPositionTemplates.First(x => x.PositionTemplateId == _departmentLoc.PositionTemplateId));
                                //await OS_DepartmentTemplateAppService.PositionTemplateRepo.UpdateAsync(_positionLoc);
                            }
                        }        
                        for (int i = 0; i < toDeletePositions.Count; i++)
                        {
                            curDepartmentTemplate.PositionTemplates.Remove(curDepartmentTemplate.PositionTemplates.First(x => x.Id == toDeletePositions[i].Id && x.CreationTime == toDeletePositions[i].CreationTime));
                            if (toDeletePositions[i].PositionJobTemplates != null)
                            {
                                for (int y = 0; y < toDeletePositions[i].PositionJobTemplates.Count; y++)
                                {
                                    await OS_PositionTemplateAppService.PositionJobsTemplateRepo.DeleteAsync(toDeletePositions[i].PositionJobTemplates.ElementAt(y).Id);
                                }
                            }
                            if (toDeletePositions[i].PositionTaskTemplates != null)
                            {
                                for (int y = 0; y < toDeletePositions[i].PositionTaskTemplates.Count; y++)
                                {
                                    await OS_PositionTemplateAppService.PositionTasksTemplateRepo.DeleteAsync(toDeletePositions[i].PositionTaskTemplates.ElementAt(y).Id);
                                }
                            }
                            await OS_DepartmentTemplateAppService.PositionTemplateRepo.DeleteAsync(x => x.Id == toDeletePositions[i].Id && x.CreationTime == toDeletePositions[i].CreationTime);
                        }

                        OS_DepartmentSubDepartmentTemplate_Dto[] depSubDeps = departmentTemplate_Dto.SubDepartmentTemplates.ToArray();
                        int[] curDepSubDepsIds = curDepartmentTemplate.SubDepartmentTemplates != null && curDepartmentTemplate.SubDepartmentTemplates.Count > 0? curDepartmentTemplate.SubDepartmentTemplates.Select(x => x.Id).ToArray() : new int[0];
                        List<OS_DepartmentSubDepartmentTemplate> toDeleteSubDeps = new List<OS_DepartmentSubDepartmentTemplate>();
                        for (int i = 0; i < curDepSubDepsIds.Length; i++)
                        {
                            OS_DepartmentSubDepartmentTemplate curSubDepartment = curDepartmentTemplate.SubDepartmentTemplates.First(x => x.Id == curDepSubDepsIds[i]);
                            if (!depSubDeps.Any(x => x.Id == curDepSubDepsIds[i] && x.CreationTime == curSubDepartment.CreationTime))
                            {
                                OS_DepartmentSubDepartmentTemplate item = curDepartmentTemplate.SubDepartmentTemplates.First(x => x.Id == curDepSubDepsIds[i]);
                                curDepartmentTemplate.SubDepartmentTemplates.Remove(item);
                                toDeleteSubDeps.Add(item);
                            }
                        }
                        for (int i = 0; i < depSubDeps.Length; i++)
                        {
                            if (!curDepartmentTemplate.SubDepartmentTemplates.Any(x => x.Id == depSubDeps[i].Id && x.CreationTime == depSubDeps[i].CreationTime))
                            {
                                if (!depSubDeps[i].SubDepartmentTemplate.ContainsDepartment(curDepartmentTemplate.Id))
                                    curDepartmentTemplate.SubDepartmentTemplates.Add(new OS_DepartmentSubDepartmentTemplate { 
                                        SubDepartmentTemplateId = depSubDeps[i].SubDepartmentTemplate.Id,
                                        SubDepartmentRelationshipType = depSubDeps[i].SubDepartmentRelationshipType,
                                        Name = depSubDeps[i].Name
                                    });
                                else {
                                    Exception ex = new Exception($"Cannot add the parent/sibling department '{depSubDeps[i].SubDepartmentTemplate.Name}', as a sub department.");
                                    ex.Data.Add(depSubDeps[i], "main");
                                    ex.Data.Add(depSubDeps[i].SubDepartmentTemplate, "subDepartment");
                                    throw ex;
                                }
                            }
                            else
                            {
                                var _departmentSubDep = curDepartmentTemplate.SubDepartmentTemplates.First(x => x.SubDepartmentTemplateId == depSubDeps[i].SubDepartmentTemplateId);
                                _departmentSubDep.SubDepartmentRelationshipType = depSubDeps[i].SubDepartmentRelationshipType;
                                _departmentSubDep.Name = depSubDeps[i].Name;

                                //curDepartmentTemplate.SubDepartmentTemplates.Remove(curDepartmentTemplate.SubDepartmentTemplates.First(x => x.Id == _departmentLoc.Id));
                                await OS_DepartmentTemplateAppService.DepartmentSubDepartmentTemplateRepo.UpdateAsync(_departmentSubDep);
                            }
                        }
                        for (int i = 0; i < toDeleteSubDeps.Count; i++)
                        {
                            await OS_DepartmentTemplateAppService.DepartmentSubDepartmentTemplateRepo.DeleteAsync(x => x.SubDepartmentTemplateId == toDeleteSubDeps[i].SubDepartmentTemplateId && x.CreationTime == toDeleteSubDeps[i].CreationTime);
                        }

                        OS_DepartmentTemplate_Dto updated = ObjectMapper.Map<OS_DepartmentTemplate, OS_DepartmentTemplate_Dto>(await OS_DepartmentTemplateAppService.Repository.UpdateAsync(curDepartmentTemplate));
                        OS_DepartmentTemplate_Dto updatedDto = await OS_DepartmentTemplateAppService.GetDepartmentTemplateAsync(updated.Id);
                        return StatusCode(200, updatedDto);
                    }
                    else
                    {
                        departmentTemplate_Dto.Id = 0;
                        //departmentTemplate_Dto.PositionTemplates.ForEach(x => { x.Id = 0; x.Id = x.Id; });
                        departmentTemplate_Dto.SubDepartmentTemplates.ForEach(x => { x.Id = 0; x.SubDepartmentTemplateId = x.SubDepartmentTemplate.Id; x.SubDepartmentTemplate = null; });

                        OS_DepartmentTemplate_Dto added = await OS_DepartmentTemplateAppService.CreateAsync(departmentTemplate_Dto);
                        OS_DepartmentTemplate_Dto addeddDto = await OS_DepartmentTemplateAppService.GetDepartmentTemplateAsync(added.Id);
                        if (AuditingManager.Current != null)
                        {
                            EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                            entityChangeInfo.EntityId = added.Id.ToString();
                            entityChangeInfo.EntityTenantId = added.TenantId;
                            entityChangeInfo.ChangeTime = DateTime.Now;
                            entityChangeInfo.ChangeType = EntityChangeType.Created;
                            entityChangeInfo.EntityTypeFullName = typeof(OS_DepartmentTemplate).FullName;

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
        public async Task<IActionResult> OnDeleteDepartmentTemplate()
        {
            List<OS_DepartmentTemplate_Dto> departments = JsonSerializer.Deserialize<List<OS_DepartmentTemplate_Dto>>(Request.Form["departments"]);
            try
            {
                for (int i = 0; i < departments.Count; i++)
                {
                    OS_DepartmentTemplate_Dto department = departments[i];
                    //await TaskTemplatesAppService.Repository.DeleteAsync(leaveRequest.);
                    var depSubDeps = OS_DepartmentTemplateAppService.DepartmentSubDepartmentTemplateRepo.Where(x => x.DepartmentTemplateId == department.Id || x.SubDepartmentTemplateId == department.Id).ToList();
                    for (int y = 0; y < depSubDeps.Count; y++)
                    {
                        await OS_DepartmentTemplateAppService.DepartmentSubDepartmentTemplateRepo.DeleteAsync(depSubDeps[y]);
                    }
                    var depPoses = OS_DepartmentTemplateAppService.PositionTemplateRepo.WithDetails().Where(x => x.DepartmentTemplateId == department.Id).ToList();
                    await Positions.ListModel.DeletePositions(depPoses, OS_PositionTemplateAppService.PositionJobsTemplateRepo, OS_PositionTemplateAppService.PositionTasksTemplateRepo, OS_PositionTemplateAppService.Repository, AuditingManager);

                    await OS_DepartmentTemplateAppService.Repository.DeleteAsync(department.Id);

                    if (AuditingManager.Current != null)
                    {
                        EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                        entityChangeInfo.EntityId = department.Id.ToString();
                        entityChangeInfo.EntityTenantId = department.TenantId;
                        entityChangeInfo.ChangeTime = DateTime.Now;
                        entityChangeInfo.ChangeType = EntityChangeType.Deleted;
                        entityChangeInfo.EntityTypeFullName = typeof(OS_DepartmentTemplate).FullName;

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
            var departmentLogs = AuditLogsRepo.WithDetails().Where(x => x.Url == HttpContext.Request.Path.Value && x.EntityChanges != null && x.EntityChanges.Count > 0).ToList();

            List<OS_DepartmentTemplate_Dto> Entities = await OS_DepartmentTemplateAppService.GetAllDepartmentTemplatesAsync();
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

                    OS_DepartmentTemplate_Dto department = Entities.First(x => x.Id.ToString() == entityChange.EntityId);
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
