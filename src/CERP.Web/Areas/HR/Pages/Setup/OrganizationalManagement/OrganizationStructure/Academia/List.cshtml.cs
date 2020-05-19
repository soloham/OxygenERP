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

namespace CERP.Web.Areas.HR.Setup.OrganizationalManagement.OrganizationStructure.Pages.Academia
{
    public class ListModel : CERPPageModel
    {
        public IWebHostEnvironment webHostEnvironment { get; set; }
        public IRepository<DictionaryValue, Guid> DictionaryValuesRepo { get; set; }
        public IAuditLogRepository AuditLogsRepo { get; set; }

        public OS_AcademiaTemplateAppService OS_AcademiaTemplateAppService { get; set; }

        public IAuditingManager AuditingManager { get; set; }
        public IRepository<CustomEntityChange> CustomEntityChangesRepo { get; set; }

        public ListModel(IJsonSerializer jsonSerializer, IRepository<DictionaryValue, Guid> dictionaryValuesRepo, IWebHostEnvironment webHostEnvironment, IAuditLogRepository auditLogsRepo, OS_AcademiaTemplateAppService oS_AcademiaTemplateAppService)
        {
            JsonSerializer = jsonSerializer;
            DictionaryValuesRepo = dictionaryValuesRepo;
            this.webHostEnvironment = webHostEnvironment;
            AuditLogsRepo = auditLogsRepo;
            OS_AcademiaTemplateAppService = oS_AcademiaTemplateAppService;
        }

        public IJsonSerializer JsonSerializer { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAcademiaTemplate()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var FormData = Request.Form;

                    OS_AcademiaTemplate_Dto academiaTemplate_Dto = JsonSerializer.Deserialize<OS_AcademiaTemplate_Dto>(FormData["info"]);

                    bool IsEditing = academiaTemplate_Dto.Id > 0;
                    if (IsEditing)
                    {
                        OS_AcademiaTemplate curAcademiaTemplate = await OS_AcademiaTemplateAppService.Repository.GetAsync(academiaTemplate_Dto.Id);

                        if (AuditingManager.Current != null)
                        {
                            EntityChangeInfo entityChangeInfo = new EntityChangeInfo();

                            entityChangeInfo.EntityId = academiaTemplate_Dto.Id.ToString();
                            entityChangeInfo.EntityTenantId = academiaTemplate_Dto.TenantId;
                            entityChangeInfo.ChangeTime = DateTime.Now;
                            entityChangeInfo.ChangeType = EntityChangeType.Updated;
                            entityChangeInfo.EntityTypeFullName = typeof(OS_AcademiaTemplate).FullName;

                            entityChangeInfo.PropertyChanges = new List<EntityPropertyChangeInfo>();
                            List<EntityPropertyChangeInfo> entityPropertyChanges = new List<EntityPropertyChangeInfo>();
                            var auditProps = typeof(OS_AcademiaTemplate).GetProperties().Where(x => Attribute.IsDefined(x, typeof(CustomAuditedAttribute))).ToList();

                            OS_AcademiaTemplate mappedInput = ObjectMapper.Map<OS_AcademiaTemplate_Dto, OS_AcademiaTemplate>(academiaTemplate_Dto);
                            foreach (var prop in auditProps)
                            {
                                EntityPropertyChangeInfo propertyChange = new EntityPropertyChangeInfo();
                                object origVal = prop.GetValue(curAcademiaTemplate);
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

                                        var valueProp = typeof(OS_AcademiaTemplate).GetProperty(valuePropName);

                                        DictionaryValue _origValObj = (DictionaryValue)valueProp.GetValue(academiaTemplate_Dto);
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
                            //if (departmentTemplate_Dto.ExtraProperties != curAcademiaTemplate.ExtraProperties)
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

                        curAcademiaTemplate.Name = academiaTemplate_Dto.Name;
                        curAcademiaTemplate.NameLocalized = academiaTemplate_Dto.NameLocalized;
                        curAcademiaTemplate.Code = academiaTemplate_Dto.Code;
                        curAcademiaTemplate.Description = academiaTemplate_Dto.Description;
                        curAcademiaTemplate.DoesKPI = academiaTemplate_Dto.DoesKPI;
                        curAcademiaTemplate.ReviewPeriod = academiaTemplate_Dto.ReviewPeriod;
                        curAcademiaTemplate.ReviewPeriodDays = academiaTemplate_Dto.ReviewPeriodDays;
                        curAcademiaTemplate.PassoutYear = academiaTemplate_Dto.PassoutYear;
                        curAcademiaTemplate.AcademicType = academiaTemplate_Dto.AcademicType;
                        curAcademiaTemplate.AcademiaCertificateType = academiaTemplate_Dto.AcademiaCertificateType;
                        curAcademiaTemplate.AcademiaCertificateSubType = null;
                        curAcademiaTemplate.AcademiaCertificateSubTypeId = academiaTemplate_Dto.AcademiaCertificateSubTypeId;
                        curAcademiaTemplate.Institute = null;
                        curAcademiaTemplate.InstituteId = academiaTemplate_Dto.InstituteId;
                        curAcademiaTemplate.CompensationMatrix = null;
                        curAcademiaTemplate.CompensationMatrixId = academiaTemplate_Dto.CompensationMatrixId;

                        OS_AcademiaTemplate_Dto updated = ObjectMapper.Map<OS_AcademiaTemplate, OS_AcademiaTemplate_Dto>(await OS_AcademiaTemplateAppService.Repository.UpdateAsync(curAcademiaTemplate));
                        updated = await OS_AcademiaTemplateAppService.GetAsync(updated.Id);

                        return StatusCode(200, updated);
                    }
                    else
                    {
                        academiaTemplate_Dto.Id = 0;
                        academiaTemplate_Dto.Institute = null;
                        academiaTemplate_Dto.AcademiaCertificateSubType = null;
                        academiaTemplate_Dto.CompensationMatrix = null;

                        OS_AcademiaTemplate_Dto added = await OS_AcademiaTemplateAppService.CreateAsync(academiaTemplate_Dto);

                        if (AuditingManager.Current != null)
                        {
                            EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                            entityChangeInfo.EntityId = added.Id.ToString();
                            entityChangeInfo.EntityTenantId = added.TenantId;
                            entityChangeInfo.ChangeTime = DateTime.Now;
                            entityChangeInfo.ChangeType = EntityChangeType.Created;
                            entityChangeInfo.EntityTypeFullName = typeof(OS_AcademiaTemplate).FullName;

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
        public async Task<IActionResult> OnDeleteAcademiaTemplate()
        {
            List<OS_AcademiaTemplate_Dto> entitites = JsonSerializer.Deserialize<List<OS_AcademiaTemplate_Dto>>(Request.Form["academias"]);
            try
            {
                for (int i = 0; i < entitites.Count; i++)
                {
                    OS_AcademiaTemplate_Dto entity = entitites[i];
                    //await AcademiaTemplatesAppService.Repository.DeleteAsync(leaveRequest.);
                    await OS_AcademiaTemplateAppService.Repository.DeleteAsync(entity.Id);

                    if (AuditingManager.Current != null)
                    {
                        EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                        entityChangeInfo.EntityId = entity.Id.ToString();
                        entityChangeInfo.EntityTenantId = entity.TenantId;
                        entityChangeInfo.ChangeTime = DateTime.Now;
                        entityChangeInfo.ChangeType = EntityChangeType.Deleted;
                        entityChangeInfo.EntityTypeFullName = typeof(OS_AcademiaTemplate).FullName;

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

        //public async Task<IActionResult> OnPostAcademiaQualificationTemplate()
        //{

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var FormData = Request.Form;

        //            OS_AcademiaQualificationTemplate_Dto academiaQualificationTemplate_Dto = JsonSerializer.Deserialize<OS_AcademiaQualificationTemplate_Dto>(FormData["info"]);

        //            bool IsEditing = academiaQualificationTemplate_Dto.Id > 0;
        //            if (IsEditing)
        //            {
        //                OS_AcademiaQualificationTemplate curAcademiaQualificationTemplate = await OS_AcademiaTemplateAppService.QualificationsRepository.GetAsync(academiaQualificationTemplate_Dto.Id);

        //                if (AuditingManager.Current != null)
        //                {
        //                    EntityChangeInfo entityChangeInfo = new EntityChangeInfo();

        //                    entityChangeInfo.EntityId = academiaQualificationTemplate_Dto.Id.ToString();
        //                    entityChangeInfo.EntityTenantId = academiaQualificationTemplate_Dto.TenantId;
        //                    entityChangeInfo.ChangeTime = DateTime.Now;
        //                    entityChangeInfo.ChangeType = EntityChangeType.Updated;
        //                    entityChangeInfo.EntityTypeFullName = typeof(OS_AcademiaQualificationTemplate).FullName;

        //                    entityChangeInfo.PropertyChanges = new List<EntityPropertyChangeInfo>();
        //                    List<EntityPropertyChangeInfo> entityPropertyChanges = new List<EntityPropertyChangeInfo>();
        //                    var auditProps = typeof(OS_AcademiaQualificationTemplate).GetProperties().Where(x => Attribute.IsDefined(x, typeof(CustomAuditedAttribute))).ToList();

        //                    OS_AcademiaQualificationTemplate mappedInput = ObjectMapper.Map<OS_AcademiaQualificationTemplate_Dto, OS_AcademiaQualificationTemplate>(academiaQualificationTemplate_Dto);
        //                    foreach (var prop in auditProps)
        //                    {
        //                        EntityPropertyChangeInfo propertyChange = new EntityPropertyChangeInfo();
        //                        object origVal = prop.GetValue(curAcademiaQualificationTemplate);
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

        //                                var valueProp = typeof(OS_AcademiaQualificationTemplate).GetProperty(valuePropName);

        //                                DictionaryValue _origValObj = (DictionaryValue)valueProp.GetValue(academiaQualificationTemplate_Dto);
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

        //                curAcademiaQualificationTemplate.DegreeId = academiaQualificationTemplate_Dto.DegreeId;
        //                curAcademiaQualificationTemplate.InstituteId = academiaQualificationTemplate_Dto.InstituteId;
        //                curAcademiaQualificationTemplate.PeriodStartDate = academiaQualificationTemplate_Dto.PeriodStartDate;
        //                curAcademiaQualificationTemplate.PeriodEndDate = academiaQualificationTemplate_Dto.PeriodEndDate;

        //                OS_AcademiaQualificationTemplate_Dto updated = ObjectMapper.Map<OS_AcademiaQualificationTemplate, OS_AcademiaQualificationTemplate_Dto>(await OS_AcademiaTemplateAppService.QualificationsRepository.UpdateAsync(curAcademiaQualificationTemplate));

        //                return StatusCode(200, updated);
        //            }
        //            else
        //            {
        //                academiaQualificationTemplate_Dto.Id = 0;

        //                OS_AcademiaQualificationTemplate_Dto added = await OS_AcademiaTemplateAppService.AddQualificationTemplate(academiaQualificationTemplate_Dto);

        //                if (AuditingManager.Current != null)
        //                {
        //                    EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
        //                    entityChangeInfo.EntityId = added.Id.ToString();
        //                    entityChangeInfo.EntityTenantId = added.TenantId;
        //                    entityChangeInfo.ChangeTime = DateTime.Now;
        //                    entityChangeInfo.ChangeType = EntityChangeType.Created;
        //                    entityChangeInfo.EntityTypeFullName = typeof(OS_AcademiaQualificationTemplate).FullName;

        //                    AuditingManager.Current.Log.EntityChanges.Add(entityChangeInfo);
        //                }

        //                added = ObjectMapper.Map<OS_AcademiaQualificationTemplate, OS_AcademiaQualificationTemplate_Dto>(await OS_AcademiaTemplateAppService.QualificationsRepository.GetAsync(added.Id));
        //                return StatusCode(200, added);
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }

        //    return StatusCode(500);
        //}
        //public async Task<IActionResult> OnDeleteAcademiaQualificationTemplate()
        //{
        //    List<OS_AcademiaQualificationTemplate_Dto> entitites = JsonSerializer.Deserialize<List<OS_AcademiaQualificationTemplate_Dto>>(Request.Form["qualifications"]);
        //    try
        //    {
        //        for (int i = 0; i < entitites.Count; i++)
        //        {
        //            OS_AcademiaQualificationTemplate_Dto entity = entitites[i];
        //            //await AcademiaQualificationTemplatesAppService.Repository.DeleteAsync(leaveRequest.);
        //            await OS_AcademiaTemplateAppService.QualificationsRepository.DeleteAsync(entity.Id);

        //            if (AuditingManager.Current != null)
        //            {
        //                EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
        //                entityChangeInfo.EntityId = entity.Id.ToString();
        //                entityChangeInfo.EntityTenantId = entity.TenantId;
        //                entityChangeInfo.ChangeTime = DateTime.Now;
        //                entityChangeInfo.ChangeType = EntityChangeType.Deleted;
        //                entityChangeInfo.EntityTypeFullName = typeof(OS_AcademiaQualificationTemplate).FullName;

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

            List<OS_AcademiaTemplate_Dto> Entities = await OS_AcademiaTemplateAppService.GetAllAcademiaTemplatesAsync();
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

                    OS_AcademiaTemplate_Dto department = Entities.First(x => x.Id.ToString() == entityChange.EntityId);
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
