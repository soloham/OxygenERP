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

namespace CERP.Web.Areas.HR.Setup.OrganizationalManagement.OrganizationStructure.Pages.Divisions
{
    public class ListModel : CERPPageModel
    {
        public IWebHostEnvironment webHostEnvironment { get; set; }
        public IRepository<DictionaryValue, Guid> DictionaryValuesRepo { get; set; }
        public IAuditLogRepository AuditLogsRepo { get; set; }

        public OS_DivisionTemplateAppService OS_DivisionTemplateAppService { get; set; }

        public IAuditingManager AuditingManager { get; set; }
        public IRepository<CustomEntityChange> CustomEntityChangesRepo { get; set; }

        public ListModel(IJsonSerializer jsonSerializer, IRepository<DictionaryValue, Guid> dictionaryValuesRepo, IWebHostEnvironment webHostEnvironment, IAuditLogRepository auditLogsRepo, OS_DivisionTemplateAppService oS_DivisionTemplateAppService)
        {
            JsonSerializer = jsonSerializer;
            DictionaryValuesRepo = dictionaryValuesRepo;
            this.webHostEnvironment = webHostEnvironment;
            AuditLogsRepo = auditLogsRepo;
            OS_DivisionTemplateAppService = oS_DivisionTemplateAppService;
        }

        public IJsonSerializer JsonSerializer { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostDivisionTemplate()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var FormData = Request.Form;

                    OS_DivisionTemplate_Dto businessUnitTemplate_Dto = JsonSerializer.Deserialize<OS_DivisionTemplate_Dto>(FormData["info"]);

                    bool IsEditing = businessUnitTemplate_Dto.Id > 0;
                    if (IsEditing)
                    {
                        OS_DivisionTemplate curDivisionTemplate = await OS_DivisionTemplateAppService.Repository.GetAsync(businessUnitTemplate_Dto.Id);

                        if (AuditingManager.Current != null)
                        {
                            EntityChangeInfo entityChangeInfo = new EntityChangeInfo();

                            entityChangeInfo.EntityId = businessUnitTemplate_Dto.Id.ToString();
                            entityChangeInfo.EntityTenantId = businessUnitTemplate_Dto.TenantId;
                            entityChangeInfo.ChangeTime = DateTime.Now;
                            entityChangeInfo.ChangeType = EntityChangeType.Updated;
                            entityChangeInfo.EntityTypeFullName = typeof(OS_DivisionTemplate).FullName;

                            entityChangeInfo.PropertyChanges = new List<EntityPropertyChangeInfo>();
                            List<EntityPropertyChangeInfo> entityPropertyChanges = new List<EntityPropertyChangeInfo>();
                            var auditProps = typeof(OS_DivisionTemplate).GetProperties().Where(x => Attribute.IsDefined(x, typeof(CustomAuditedAttribute))).ToList();

                            OS_DivisionTemplate mappedInput = ObjectMapper.Map<OS_DivisionTemplate_Dto, OS_DivisionTemplate>(businessUnitTemplate_Dto);
                            foreach (var prop in auditProps)
                            {
                                EntityPropertyChangeInfo propertyChange = new EntityPropertyChangeInfo();
                                object origVal = prop.GetValue(curDivisionTemplate);
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

                                        var valueProp = typeof(OS_DivisionTemplate).GetProperty(valuePropName);

                                        DictionaryValue _origValObj = (DictionaryValue)valueProp.GetValue(businessUnitTemplate_Dto);
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
                            //if (departmentTemplate_Dto.ExtraProperties != curDivisionTemplate.ExtraProperties)
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

                        curDivisionTemplate.Name = businessUnitTemplate_Dto.Name;
                        curDivisionTemplate.NameLocalized = businessUnitTemplate_Dto.NameLocalized;
                        curDivisionTemplate.Code = businessUnitTemplate_Dto.Code;
                        curDivisionTemplate.Description = businessUnitTemplate_Dto.Description;
                        curDivisionTemplate.ValidityFromDate = businessUnitTemplate_Dto.ValidityFromDate;
                        curDivisionTemplate.ValidityToDate = businessUnitTemplate_Dto.ValidityToDate;

                        OS_DivisionTemplate_Dto updated = ObjectMapper.Map<OS_DivisionTemplate, OS_DivisionTemplate_Dto>(await OS_DivisionTemplateAppService.Repository.UpdateAsync(curDivisionTemplate));

                        return StatusCode(200, updated);
                    }
                    else
                    {
                        businessUnitTemplate_Dto.Id = 0;

                        OS_DivisionTemplate_Dto added = await OS_DivisionTemplateAppService.CreateAsync(businessUnitTemplate_Dto);
                        added = await OS_DivisionTemplateAppService.GetAsync(added.Id);

                        if (AuditingManager.Current != null)
                        {
                            EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                            entityChangeInfo.EntityId = added.Id.ToString();
                            entityChangeInfo.EntityTenantId = added.TenantId;
                            entityChangeInfo.ChangeTime = DateTime.Now;
                            entityChangeInfo.ChangeType = EntityChangeType.Created;
                            entityChangeInfo.EntityTypeFullName = typeof(OS_DivisionTemplate).FullName;

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
        public async Task<IActionResult> OnDeleteDivisionTemplate()
        {
            List<OS_DivisionTemplate_Dto> entitites = JsonSerializer.Deserialize<List<OS_DivisionTemplate_Dto>>(Request.Form["divisions"]);
            try
            {
                for (int i = 0; i < entitites.Count; i++)
                {
                    OS_DivisionTemplate_Dto entity = entitites[i];
                    //await DivisionTemplatesAppService.Repository.DeleteAsync(leaveRequest.);
                    await OS_DivisionTemplateAppService.Repository.DeleteAsync(entity.Id);

                    if (AuditingManager.Current != null)
                    {
                        EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                        entityChangeInfo.EntityId = entity.Id.ToString();
                        entityChangeInfo.EntityTenantId = entity.TenantId;
                        entityChangeInfo.ChangeTime = DateTime.Now;
                        entityChangeInfo.ChangeType = EntityChangeType.Deleted;
                        entityChangeInfo.EntityTypeFullName = typeof(OS_DivisionTemplate).FullName;

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

        //public async Task<IActionResult> OnPostDivisionQualificationTemplate()
        //{

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var FormData = Request.Form;

        //            OS_DivisionQualificationTemplate_Dto businessUnitQualificationTemplate_Dto = JsonSerializer.Deserialize<OS_DivisionQualificationTemplate_Dto>(FormData["info"]);

        //            bool IsEditing = businessUnitQualificationTemplate_Dto.Id > 0;
        //            if (IsEditing)
        //            {
        //                OS_DivisionQualificationTemplate curDivisionQualificationTemplate = await OS_DivisionTemplateAppService.QualificationsRepository.GetAsync(businessUnitQualificationTemplate_Dto.Id);

        //                if (AuditingManager.Current != null)
        //                {
        //                    EntityChangeInfo entityChangeInfo = new EntityChangeInfo();

        //                    entityChangeInfo.EntityId = businessUnitQualificationTemplate_Dto.Id.ToString();
        //                    entityChangeInfo.EntityTenantId = businessUnitQualificationTemplate_Dto.TenantId;
        //                    entityChangeInfo.ChangeTime = DateTime.Now;
        //                    entityChangeInfo.ChangeType = EntityChangeType.Updated;
        //                    entityChangeInfo.EntityTypeFullName = typeof(OS_DivisionQualificationTemplate).FullName;

        //                    entityChangeInfo.PropertyChanges = new List<EntityPropertyChangeInfo>();
        //                    List<EntityPropertyChangeInfo> entityPropertyChanges = new List<EntityPropertyChangeInfo>();
        //                    var auditProps = typeof(OS_DivisionQualificationTemplate).GetProperties().Where(x => Attribute.IsDefined(x, typeof(CustomAuditedAttribute))).ToList();

        //                    OS_DivisionQualificationTemplate mappedInput = ObjectMapper.Map<OS_DivisionQualificationTemplate_Dto, OS_DivisionQualificationTemplate>(businessUnitQualificationTemplate_Dto);
        //                    foreach (var prop in auditProps)
        //                    {
        //                        EntityPropertyChangeInfo propertyChange = new EntityPropertyChangeInfo();
        //                        object origVal = prop.GetValue(curDivisionQualificationTemplate);
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

        //                                var valueProp = typeof(OS_DivisionQualificationTemplate).GetProperty(valuePropName);

        //                                DictionaryValue _origValObj = (DictionaryValue)valueProp.GetValue(businessUnitQualificationTemplate_Dto);
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

        //                curDivisionQualificationTemplate.DegreeId = businessUnitQualificationTemplate_Dto.DegreeId;
        //                curDivisionQualificationTemplate.InstituteId = businessUnitQualificationTemplate_Dto.InstituteId;
        //                curDivisionQualificationTemplate.PeriodStartDate = businessUnitQualificationTemplate_Dto.PeriodStartDate;
        //                curDivisionQualificationTemplate.PeriodEndDate = businessUnitQualificationTemplate_Dto.PeriodEndDate;

        //                OS_DivisionQualificationTemplate_Dto updated = ObjectMapper.Map<OS_DivisionQualificationTemplate, OS_DivisionQualificationTemplate_Dto>(await OS_DivisionTemplateAppService.QualificationsRepository.UpdateAsync(curDivisionQualificationTemplate));

        //                return StatusCode(200, updated);
        //            }
        //            else
        //            {
        //                businessUnitQualificationTemplate_Dto.Id = 0;

        //                OS_DivisionQualificationTemplate_Dto added = await OS_DivisionTemplateAppService.AddQualificationTemplate(businessUnitQualificationTemplate_Dto);

        //                if (AuditingManager.Current != null)
        //                {
        //                    EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
        //                    entityChangeInfo.EntityId = added.Id.ToString();
        //                    entityChangeInfo.EntityTenantId = added.TenantId;
        //                    entityChangeInfo.ChangeTime = DateTime.Now;
        //                    entityChangeInfo.ChangeType = EntityChangeType.Created;
        //                    entityChangeInfo.EntityTypeFullName = typeof(OS_DivisionQualificationTemplate).FullName;

        //                    AuditingManager.Current.Log.EntityChanges.Add(entityChangeInfo);
        //                }

        //                added = ObjectMapper.Map<OS_DivisionQualificationTemplate, OS_DivisionQualificationTemplate_Dto>(await OS_DivisionTemplateAppService.QualificationsRepository.GetAsync(added.Id));
        //                return StatusCode(200, added);
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }

        //    return StatusCode(500);
        //}
        //public async Task<IActionResult> OnDeleteDivisionQualificationTemplate()
        //{
        //    List<OS_DivisionQualificationTemplate_Dto> entitites = JsonSerializer.Deserialize<List<OS_DivisionQualificationTemplate_Dto>>(Request.Form["qualifications"]);
        //    try
        //    {
        //        for (int i = 0; i < entitites.Count; i++)
        //        {
        //            OS_DivisionQualificationTemplate_Dto entity = entitites[i];
        //            //await DivisionQualificationTemplatesAppService.Repository.DeleteAsync(leaveRequest.);
        //            await OS_DivisionTemplateAppService.QualificationsRepository.DeleteAsync(entity.Id);

        //            if (AuditingManager.Current != null)
        //            {
        //                EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
        //                entityChangeInfo.EntityId = entity.Id.ToString();
        //                entityChangeInfo.EntityTenantId = entity.TenantId;
        //                entityChangeInfo.ChangeTime = DateTime.Now;
        //                entityChangeInfo.ChangeType = EntityChangeType.Deleted;
        //                entityChangeInfo.EntityTypeFullName = typeof(OS_DivisionQualificationTemplate).FullName;

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

            List<OS_DivisionTemplate_Dto> Entities = await OS_DivisionTemplateAppService.GetAllDivisionTemplatesAsync();
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

                    OS_DivisionTemplate_Dto department = Entities.First(x => x.Id.ToString() == entityChange.EntityId);
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
