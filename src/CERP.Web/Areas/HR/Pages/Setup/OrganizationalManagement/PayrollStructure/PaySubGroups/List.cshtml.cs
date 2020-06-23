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
using CERP.ApplicationContracts.HR.OrganizationalManagement.PayrollStructure;
using CERP.HR.OrganizationalManagement.PayrollStructure;
using CERP.AppServices.HR.OrganizationalManagement.PayrollStructure;
using Microsoft.EntityFrameworkCore;

namespace CERP.Web.Areas.HR.Setup.OrganizationalManagement.PayrollStructure.Pages.PaySubGroups
{
    public class ListModel : CERPPageModel
    {
        public IWebHostEnvironment webHostEnvironment { get; set; }
        public IRepository<DictionaryValue, Guid> DictionaryValuesRepo { get; set; }
        public IAuditLogRepository AuditLogsRepo { get; set; }

        public PS_PaySubGroupAppService PS_PaySubGroupAppService { get; set; }

        public IAuditingManager AuditingManager { get; set; }
        public IRepository<CustomEntityChange> CustomEntityChangesRepo { get; set; }

        public ListModel(IJsonSerializer jsonSerializer, IRepository<DictionaryValue, Guid> dictionaryValuesRepo, IWebHostEnvironment webHostEnvironment, IAuditLogRepository auditLogsRepo, PS_PaySubGroupAppService oS_PaySubGroupAppService)
        {
            JsonSerializer = jsonSerializer;
            DictionaryValuesRepo = dictionaryValuesRepo;
            this.webHostEnvironment = webHostEnvironment;
            AuditLogsRepo = auditLogsRepo;
            PS_PaySubGroupAppService = oS_PaySubGroupAppService;
        }

        public IJsonSerializer JsonSerializer { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostPaySubGroup()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var FormData = Request.Form;

                    bool isSearching = JsonSerializer.Deserialize<bool>(FormData["isSearching"]);
                    if (isSearching)
                    {
                        PS_PaySubGroup_Search_Dto payGroupSearch_Dto = JsonSerializer.Deserialize<PS_PaySubGroup_Search_Dto>(FormData["info"]);

                        List<PS_PaySubGroup_Dto> result = new List<PS_PaySubGroup_Dto>();
                        result = await PS_PaySubGroupAppService.GetAllBySearchAsync(payGroupSearch_Dto);

                        return StatusCode(200, result);
                    }
                    else
                    {
                        PS_PaySubGroup_Dto payGroup_Dto = JsonSerializer.Deserialize<PS_PaySubGroup_Dto>(FormData["info"]);

                        bool IsEditing = payGroup_Dto.Id > 0;
                        if (IsEditing)
                        {
                            PS_PaySubGroup curPaySubGroup = await PS_PaySubGroupAppService.GetPaySubGroupRawAsync(payGroup_Dto.Id);
                            EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                            if (AuditingManager.Current != null)
                            {

                                entityChangeInfo.EntityId = payGroup_Dto.Id.ToString();
                                entityChangeInfo.EntityTenantId = payGroup_Dto.TenantId;
                                entityChangeInfo.ChangeTime = DateTime.Now;
                                entityChangeInfo.ChangeType = EntityChangeType.Updated;
                                entityChangeInfo.EntityTypeFullName = typeof(PS_PaySubGroup).FullName;

                                entityChangeInfo.PropertyChanges = new List<EntityPropertyChangeInfo>();
                                List<EntityPropertyChangeInfo> entityPropertyChanges = new List<EntityPropertyChangeInfo>();
                                var auditProps = typeof(PS_PaySubGroup).GetProperties().Where(x => Attribute.IsDefined(x, typeof(CustomAuditedAttribute))).ToList();

                                PS_PaySubGroup mappedInput = ObjectMapper.Map<PS_PaySubGroup_Dto, PS_PaySubGroup>(payGroup_Dto);
                                foreach (var prop in auditProps)
                                {
                                    EntityPropertyChangeInfo propertyChange = new EntityPropertyChangeInfo();
                                    object origVal = prop.GetValue(curPaySubGroup);
                                    propertyChange.OriginalValue = origVal == null ? "" : origVal.ToString();
                                    object newVal = prop.GetValue(mappedInput);
                                    propertyChange.NewValue = newVal == null ? "" : newVal.ToString();
                                    if (propertyChange.OriginalValue == propertyChange.NewValue) continue;

                                    propertyChange.PropertyName = prop.Name;

                                    //if (prop.Name.EndsWith("Id"))
                                    //{
                                    //    try
                                    //    {
                                    //        string valuePropName = prop.Name.TrimEnd('d', 'I');
                                    //        propertyChange.PropertyName = valuePropName;

                                    //        var valueProp = typeof(PS_PaySubGroup).GetProperty(valuePropName);

                                    //        DictionaryValue _origValObj = (DictionaryValue)valueProp.GetValue(payGroup_Dto);
                                    //        if (_origValObj == null) _origValObj = await DictionaryValuesRepo.GetAsync((Guid)origVal);
                                    //        string _origVal = _origValObj.Value;
                                    //        propertyChange.OriginalValue = origVal == null ? "" : _origVal;
                                    //        DictionaryValue _newValObj = (DictionaryValue)valueProp.GetValue(mappedInput);
                                    //        if (_newValObj == null) _newValObj = await DictionaryValuesRepo.GetAsync((Guid)newVal);
                                    //        string _newVal = _newValObj.Value;
                                    //        propertyChange.NewValue = _newValObj == null ? "" : _newVal;
                                    //    }
                                    //    catch (Exception ex)
                                    //    {

                                    //    }
                                    //}

                                    propertyChange.PropertyTypeFullName = prop.Name.GetType().FullName;

                                    entityChangeInfo.PropertyChanges.Add(propertyChange);
                                }

                                #region ExtraProperties
                                //List<EmployeeExtraPropertyHistory> allExtraPropertyHistories = new List<EmployeeExtraPropertyHistory>();
                                //if (department_Dto.ExtraProperties != curPaySubGroup.ExtraProperties)
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

                            }

                            //curPaySubGroup.Code = payGroup_Dto.Code;
                            curPaySubGroup.Name = payGroup_Dto.Name;
                            curPaySubGroup.NameLocalized = payGroup_Dto.NameLocalized;
                            curPaySubGroup.Description = payGroup_Dto.Description;

                            curPaySubGroup.PayGroupId = payGroup_Dto.PayGroupId;
                            curPaySubGroup.Frequency = null;
                            curPaySubGroup.FrequencyId = payGroup_Dto.FrequencyId;
                            curPaySubGroup.LegalEntity = null;
                            curPaySubGroup.LegalEntityId = payGroup_Dto.LegalEntityId;
                            curPaySubGroup.OrganizationStructureTemplateId = payGroup_Dto.OrganizationStructureTemplateId;
                            curPaySubGroup.IsBankPaymentAllowed = payGroup_Dto.IsBankPaymentAllowed;
                            curPaySubGroup.IsCashPaymentAllowed = payGroup_Dto.IsCashPaymentAllowed;
                            curPaySubGroup.IsChequePaymentAllowed = payGroup_Dto.IsChequePaymentAllowed;
                            curPaySubGroup.AllowThirdPartyPayments = payGroup_Dto.AllowThirdPartyPayments;

                            curPaySubGroup.PayrollPeriodId = payGroup_Dto.PayrollPeriodId;

                            #region Child Entities
                            #region Allowed Banks
                            if (payGroup_Dto.AllowedBanks != null)
                            {
                                //Getting New
                                PS_PaySubGroupBank_Dto[] PaySubGroupBanks = payGroup_Dto.AllowedBanks.ToArray();
                                //Getting Current
                                PS_PaySubGroupBank[] curPaySubGroupBanksIds = curPaySubGroup.AllowedBanks != null && curPaySubGroup.AllowedBanks.Count > 0 ? curPaySubGroup.AllowedBanks.ToArray() : new PS_PaySubGroupBank[0];
                                List<PS_PaySubGroupBank> toDeletePaySubGroupBanks = new List<PS_PaySubGroupBank>();
                                //Removing Removed
                                for (int i = 0; i < curPaySubGroupBanksIds.Length; i++)
                                {
                                    if (!PaySubGroupBanks.Any(x => x.BankId == curPaySubGroupBanksIds[i].BankId && x.IsThirdParty == curPaySubGroupBanksIds[i].IsThirdParty))
                                    {
                                        curPaySubGroup.AllowedBanks.Remove(curPaySubGroup.AllowedBanks.First(x => x.BankId == curPaySubGroupBanksIds[i].BankId));
                                        toDeletePaySubGroupBanks.Add(curPaySubGroupBanksIds[i]);
                                    }
                                }
                                //Adding & Updating New
                                for (int i = 0; i < PaySubGroupBanks.Length; i++)
                                {
                                    if (curPaySubGroup.AllowedBanks == null) curPaySubGroup.AllowedBanks = new List<PS_PaySubGroupBank>();
                                    if (!curPaySubGroup.AllowedBanks.Any(x => x.BankId == PaySubGroupBanks[i].BankId))
                                    {
                                        //PaySubGroupBanks[i].Id = 0;
                                        PS_PaySubGroupBank item = new PS_PaySubGroupBank() { BankId = PaySubGroupBanks[i].BankId, IsThirdParty = PaySubGroupBanks[i].IsThirdParty, PaySubGroupId = curPaySubGroup.Id };
                                        //curPaySubGroup.AllowedBanks.Add(item);

                                        await PS_PaySubGroupAppService.PaySubGroupBanksRepo.InsertAsync(item);
                                    }
                                    else
                                    {

                                    }
                                }
                                //Appending Deleted
                                for (int i = 0; i < toDeletePaySubGroupBanks.Count; i++)
                                {
                                    await PS_PaySubGroupAppService.PaySubGroupBanksRepo.DeleteAsync(x => x.BankId == toDeletePaySubGroupBanks[i].BankId && x.IsThirdParty == toDeletePaySubGroupBanks[i].IsThirdParty);
                                }
                            }
                            #endregion
                            #endregion

                            var preUpdate = await PS_PaySubGroupAppService.Repository.UpdateAsync(curPaySubGroup);
                            var updated = await PS_PaySubGroupAppService.GetPaySubGroupAsync(curPaySubGroup.Id);

                            if (AuditingManager.Current != null)
                            {
                                AuditingManager.Current.Log.EntityChanges.Add(entityChangeInfo);
                            }

                            return StatusCode(200, updated);
                        }
                        else
                        {
                            payGroup_Dto.Id = 0;
                            payGroup_Dto.OrganizationStructureTemplateId = null;
                            payGroup_Dto.PayrollPeriod = null;

                            PS_PaySubGroup_Dto added = await PS_PaySubGroupAppService.CreateAsync(payGroup_Dto);
                            added = await PS_PaySubGroupAppService.GetPaySubGroupAsync(added.Id);

                            if (AuditingManager.Current != null)
                            {
                                EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                                entityChangeInfo.EntityId = added.Id.ToString();
                                entityChangeInfo.EntityTenantId = added.TenantId;
                                entityChangeInfo.ChangeTime = DateTime.Now;
                                entityChangeInfo.ChangeType = EntityChangeType.Created;
                                entityChangeInfo.EntityTypeFullName = typeof(PS_PaySubGroup).FullName;

                                AuditingManager.Current.Log.EntityChanges.Add(entityChangeInfo);
                            }

                            return StatusCode(200, added);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }

            return StatusCode(500);
        }
        public async Task<IActionResult> OnDeletePaySubGroup()
        {
            PS_PaySubGroup_Dto entity = JsonSerializer.Deserialize<PS_PaySubGroup_Dto>(Request.Form["info"]);
            try
            {
                //await PaySubGroupsAppService.Repository.DeleteAsync(leaveRequest.);
                await PS_PaySubGroupAppService.Repository.DeleteAsync(entity.Id);

                if (AuditingManager.Current != null)
                {
                    EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                    entityChangeInfo.EntityId = entity.Id.ToString();
                    entityChangeInfo.EntityTenantId = entity.TenantId;
                    entityChangeInfo.ChangeTime = DateTime.Now;
                    entityChangeInfo.ChangeType = EntityChangeType.Deleted;
                    entityChangeInfo.EntityTypeFullName = typeof(PS_PaySubGroup).FullName;

                    AuditingManager.Current.Log.EntityChanges.Add(entityChangeInfo);
                }
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        public async Task<IActionResult> OnDeletePaySubGroups()
        {
            List<PS_PaySubGroup_Dto> entitites = JsonSerializer.Deserialize<List<PS_PaySubGroup_Dto>>(Request.Form["payGroups"]);
            try
            {
                for (int i = 0; i < entitites.Count; i++)
                {
                    PS_PaySubGroup_Dto entity = entitites[i];
                    //await PaySubGroupsAppService.Repository.DeleteAsync(leaveRequest.);
                    await PS_PaySubGroupAppService.Repository.DeleteAsync(entity.Id);

                    if (AuditingManager.Current != null)
                    {
                        EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                        entityChangeInfo.EntityId = entity.Id.ToString();
                        entityChangeInfo.EntityTenantId = entity.TenantId;
                        entityChangeInfo.ChangeTime = DateTime.Now;
                        entityChangeInfo.ChangeType = EntityChangeType.Deleted;
                        entityChangeInfo.EntityTypeFullName = typeof(PS_PaySubGroup).FullName;

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

            List<PS_PaySubGroup_Dto> Entities = await PS_PaySubGroupAppService.GetAllPaySubGroupsAsync();
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

                    PS_PaySubGroup_Dto department = Entities.First(x => x.Id.ToString() == entityChange.EntityId);
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
