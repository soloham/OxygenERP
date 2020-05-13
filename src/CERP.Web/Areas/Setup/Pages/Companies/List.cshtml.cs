using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CERP.App;
using CERP.AppServices.HR.EmployeeService;
using CERP.AppServices.Setup.CompanySetup;
using CERP.FM.DTOs;
using CERP.Setup;
using CERP.HR.EMPLOYEE.RougeDTOs;
using CERP.HR.Employees.DTOs;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.OpenApi.Extensions;
using Syncfusion.EJ2.Grids;
using Volo.Abp.AuditLogging;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Json;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using CERP.CERP.HR.Documents;
using CERP.AppServices.HR.DepartmentService;
using Volo.Abp.Auditing;
using CERP.App.CustomEntityHistorySystem;
using CERP.Attributes;

namespace CERP.Web.Areas.Setup.Pages.Companies
{
    public class ListModel : CERPPageModel
    {
        public IWebHostEnvironment webHostEnvironment { get; set; }
        public IRepository<DictionaryValue, Guid> DictionaryValuesRepo { get; set; }
        public IAuditLogRepository AuditLogsRepo { get; set; }

        public CompanyAppService CompanyAppService { get; set; }
        public documentAppService documentAppService { get; set; }

        public IAuditingManager AuditingManager { get; set; }
        public IRepository<CustomEntityChange> CustomEntityChangesRepo { get; set; }

        public ListModel(IJsonSerializer jsonSerializer, IRepository<DictionaryValue, Guid> dictionaryValuesRepo, CompanyAppService companyAppService, IWebHostEnvironment webHostEnvironment, documentAppService documentAppService, IAuditLogRepository auditLogsRepo)
        {
            JsonSerializer = jsonSerializer;
            DictionaryValuesRepo = dictionaryValuesRepo;
            CompanyAppService = companyAppService;
            this.webHostEnvironment = webHostEnvironment;
            this.documentAppService = documentAppService;
            AuditLogsRepo = auditLogsRepo;
        }

        public IJsonSerializer JsonSerializer { get; set; }

        public void OnGet()
        {

        }

        private string UploadedFile(IFormFile file)
        {
            string uniqueFileName = null;

            if (file != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                uniqueFileName = ((new Random()).Next(1, 9) * (new Random()).Next(10000, 900000)).ToString() + Path.GetExtension(file.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public async Task<IActionResult> OnPostCompany()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var FormData = Request.Form;

                    Company_Dto company = JsonSerializer.Deserialize<Company_Dto>(FormData["info"]);
                    //List<CompanyLocation_Dto> addresses = JsonSerializer.Deserialize<List<CompanyLocation_Dto>>(Request.Form["locations"]);
                    //company.SetProperty("addresses", addresses);

                    bool logoChanged = false;
                    if (FormData.Files.Count > 0 && FormData.Files.Any(x => x.Name == "CompanyPic"))
                    {
                        IFormFile formFile = FormData.Files.First(x => x.Name == "CompanyPic");

                        string uploadedFileName = UploadedFile(formFile);
                        company.CompanyLogo = uploadedFileName;

                        logoChanged = true;
                    }

                    bool IsEditing = company.Id != Guid.Empty;
                    if (IsEditing)
                    {
                        Company curCompany = await CompanyAppService.Repository.GetAsync(company.Id);
                        if (curCompany.CompanyLogo != null && curCompany.CompanyLogo != "noimage.jpg" && logoChanged)
                        {
                            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                            string filePath = Path.Combine(uploadsFolder, curCompany.CompanyLogo);

                            if (System.IO.File.Exists(filePath))
                            {
                                System.IO.File.Delete(filePath);
                            }

                        }

                        if (logoChanged)
                            curCompany.CompanyLogo = company.CompanyLogo;
                        else
                            company.CompanyLogo = curCompany.CompanyLogo;

                        if (AuditingManager.Current != null)
                        {
                            EntityChangeInfo entityChangeInfo = new EntityChangeInfo();

                            entityChangeInfo.EntityId = company.Id.ToString();
                            entityChangeInfo.EntityTenantId = company.TenantId;
                            entityChangeInfo.ChangeTime = DateTime.Now;
                            entityChangeInfo.ChangeType = EntityChangeType.Updated;
                            entityChangeInfo.EntityTypeFullName = typeof(Company).FullName;

                            entityChangeInfo.PropertyChanges = new List<EntityPropertyChangeInfo>();
                            List<EntityPropertyChangeInfo> entityPropertyChanges = new List<EntityPropertyChangeInfo>();
                            var auditProps = typeof(Company).GetProperties().Where(x => Attribute.IsDefined(x, typeof(CustomAuditedAttribute))).ToList();

                            Company mappedInput = ObjectMapper.Map<Company_Dto, Company>(company);
                            foreach (var prop in auditProps)
                            {
                                EntityPropertyChangeInfo propertyChange = new EntityPropertyChangeInfo();
                                object origVal = prop.GetValue(curCompany);
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

                                        var valueProp = typeof(Company).GetProperty(valuePropName);

                                        DictionaryValue _origValObj = (DictionaryValue)valueProp.GetValue(company);
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
                            List<EmployeeExtraPropertyHistory> allExtraPropertyHistories = new List<EmployeeExtraPropertyHistory>();
                            if (company.ExtraProperties != curCompany.ExtraProperties)
                            {
                                //GeneralInfo oldGeneralInfo = company.GetProperty<GeneralInfo>("generalInfo");
                                //List<EmployeeExtraPropertyHistory> physicalIdsHistory = new List<EmployeeExtraPropertyHistory>();
                                //var generalInfoPhysicalIdAuditProps = typeof(PhysicalID).GetProperties().Where(x => Attribute.IsDefined(x, typeof(CustomAuditedAttribute))).ToList();
                                //List<PhysicalId<Guid>> NewPhysicalIds = generalInfo.PhysicalIds.Where(x => !oldGeneralInfo.PhysicalIds.Any(y => y.Id == x.Id)).ToList();
                                //List<PhysicalId<Guid>> UpdatedPhysicalIds = generalInfo.PhysicalIds.Where(x => oldGeneralInfo.PhysicalIds.Any(y => y.Id == x.Id)).ToList();
                                //List<PhysicalId<Guid>> DeletedPhysicalIds = oldGeneralInfo.PhysicalIds.Where(x => !generalInfo.PhysicalIds.Any(y => y.Id == x.Id)).ToList();
                                //for (int i = 0; i < NewPhysicalIds.Count; i++)
                                //{
                                //    PhysicalId<Guid> curPhId = generalInfo.PhysicalIds[i];

                                //    EmployeeExtraPropertyHistory newPhIdHistory = new EmployeeExtraPropertyHistory(2, "Physical Id", curPhId.IDNumber, "Created");
                                //    physicalIdsHistory.Add(newPhIdHistory);
                                //}
                                //for (int i = 0; i < UpdatedPhysicalIds.Count; i++)
                                //{
                                //    PhysicalId<Guid> curPhId = generalInfo.PhysicalIds[i];
                                //    PhysicalId<Guid> oldPhId = oldGeneralInfo.PhysicalIds.First(x => x.Id == curPhId.Id);

                                //    EmployeeExtraPropertyHistory updatedPhIdHistory = new EmployeeExtraPropertyHistory(2, "Physical Id", curPhId.IDNumber, "Updated");
                                //    foreach (var prop in generalInfoPhysicalIdAuditProps)
                                //    {
                                //        updatedPhIdHistory.PropertyChanges = new List<EmployeeTypePropertyChange>();

                                //        EmployeeTypePropertyChange propertyChange = new EmployeeTypePropertyChange();

                                //        object origVal = prop.GetValue(oldPhId);
                                //        propertyChange.OriginalValue = origVal == null ? "" : origVal.ToString();
                                //        object newVal = prop.GetValue(curPhId);
                                //        propertyChange.NewValue = newVal == null ? "" : newVal.ToString();
                                //        if (propertyChange.OriginalValue == propertyChange.NewValue) continue;

                                //        propertyChange.PropertyName = prop.Name;

                                //        if (prop.Name.EndsWith("Id"))
                                //        {
                                //            try
                                //            {
                                //                string valuePropName = prop.Name.TrimEnd('d', 'I');
                                //                propertyChange.PropertyName = valuePropName;

                                //                var valueProp = typeof(PhysicalID).GetProperty(valuePropName);

                                //                DictionaryValue _origValObj = (DictionaryValue)valueProp.GetValue(oldPhId);
                                //                if (_origValObj == null) _origValObj = await DictionaryValuesRepo.GetAsync((Guid)origVal);
                                //                string _origVal = _origValObj.Value;
                                //                propertyChange.OriginalValue = origVal == null ? "" : _origVal;
                                //                DictionaryValue _newValObj = (DictionaryValue)valueProp.GetValue(curPhId);
                                //                if (_newValObj == null) _newValObj = await DictionaryValuesRepo.GetAsync((Guid)newVal);
                                //                string _newVal = _newValObj.Value;
                                //                propertyChange.NewValue = _newValObj == null ? "" : _newVal;
                                //            }
                                //            catch (Exception ex)
                                //            {

                                //            }
                                //        }

                                //        propertyChange.PropertyTypeFullName = prop.Name.GetType().FullName;

                                //        updatedPhIdHistory.PropertyChanges.Add(propertyChange);
                                //    }
                                //    physicalIdsHistory.Add(updatedPhIdHistory);
                                //}
                                //for (int i = 0; i < DeletedPhysicalIds.Count; i++)
                                //{
                                //    PhysicalId<Guid> curPhId = generalInfo.PhysicalIds[i];

                                //    EmployeeExtraPropertyHistory deletedPhIdHistory = new EmployeeExtraPropertyHistory(2, "Physical Id", curPhId.IDNumber, "Deleted");
                                //    physicalIdsHistory.Add(deletedPhIdHistory);
                                //}

                                entityChangeInfo.SetProperty("extraPropertiesHistory", allExtraPropertyHistories);
                            }
                            #endregion

                            AuditingManager.Current.Log.EntityChanges.Add(entityChangeInfo);
                        }

                        curCompany.CompanyName = company.CompanyName;
                        curCompany.CompanyNameLocalized = company.CompanyNameLocalized;
                        curCompany.CompanyLogo = company.CompanyLogo;
                        curCompany.CompanyCode = company.CompanyCode;
                        curCompany.Status = company.Status;
                        curCompany.TaxID = company.TaxID;
                        curCompany.SocialInsuranceID = company.SocialInsuranceID;
                        curCompany.VATID = company.VATID;
                        curCompany.RegistrationID = company.RegistrationID;
                        curCompany.LabourOfficeId = company.LabourOfficeId;
                        curCompany.Language = company.Language;

                        CompanyLocation_Dto[] compLocs = company.CompanyLocations.ToArray();
                        Guid[] curCompLocsIds = curCompany.CompanyLocations.Select(x => x.Location.Id).ToArray();
                        List<Guid> toDeleteLocs = new List<Guid>();
                        for (int i = 0; i < curCompLocsIds.Length; i++)
                        {
                            CompanyLocation curCompanyLocation = curCompany.CompanyLocations.First(x => x.Location.Id == curCompLocsIds[i]);
                            if (!compLocs.Any(x => x.LocationId == curCompLocsIds[i] && x.CreationTime == curCompanyLocation.CreationTime))
                            {
                                curCompany.CompanyLocations.Remove(curCompany.CompanyLocations.First(x => x.Location.Id == curCompLocsIds[i]));
                                toDeleteLocs.Add(curCompLocsIds[i]);
                            }
                        }
                        for (int i = 0; i < compLocs.Length; i++)
                        {
                            if (!curCompany.CompanyLocations.Any(x => x.LocationId == compLocs[i].Location.Id && x.CreationTime == compLocs[i].CreationTime))
                            {
                                curCompany.CompanyLocations.Add(new CompanyLocation() { Name = compLocs[i].Name, LocationValidityStart = compLocs[i].LocationValidityStart, LocationValidityEnd = compLocs[i].LocationValidityEnd, LocationId = compLocs[i].Location.Id, LocationType = compLocs[i].LocationType });
                            }
                            else
                            {
                                var _companyLoc = curCompany.CompanyLocations.First(x => x.LocationId == compLocs[i].Location.Id);
                                _companyLoc.LocationValidityStart = compLocs[i].LocationValidityStart;
                                _companyLoc.LocationValidityEnd = compLocs[i].LocationValidityEnd;
                                _companyLoc.Name = compLocs[i].Name;

                                //curCompany.CompanyLocations.Remove(curCompany.CompanyLocations.First(x => x.LocationId == _companyLoc.LocationId));
                                await CompanyAppService.LocationsRepository.UpdateAsync(_companyLoc);
                            }
                        }
                        
                        CompanyCurrency_Dto[] compCurrencies = company.CompanyCurrencies.ToArray();
                        int[] curCompCurrenciesIds = curCompany.CompanyCurrencies.Select(x => x.Currency.Id).ToArray();
                        for (int i = 0; i < compCurrencies.Length; i++)
                        {
                            if (!curCompCurrenciesIds.Contains(compCurrencies[i].Currency.Id))
                            {
                                curCompany.CompanyCurrencies.Add(new CompanyCurrency() { ExchangeRate = compCurrencies[i].ExchangeRate,  CurrencyId = compCurrencies[i].Currency.Id, Status = compCurrencies[i].Status });
                            }
                            else
                            {
                                var _companyCurrency = curCompany.CompanyCurrencies.First(x => x.CurrencyId == compCurrencies[i].Currency.Id);
                                _companyCurrency.ExchangeRate = compCurrencies[i].ExchangeRate;
                                _companyCurrency.Status = compCurrencies[i].Status;

                                //curCompany.CompanyLocations.Remove(curCompany.CompanyLocations.First(x => x.LocationId == _companyLoc.LocationId));
                                await CompanyAppService.CurrenciesRepository.UpdateAsync(_companyCurrency);
                            }
                        }
                        List<int> toDeleteCurrencies = new List<int>();
                        for (int i = 0; i < curCompCurrenciesIds.Length; i++)
                        {
                            if (!compCurrencies.Any(x => x.Currency.Id == curCompCurrenciesIds[i]))
                            {
                                curCompany.CompanyCurrencies.Remove(curCompany.CompanyCurrencies.First(x => x.CurrencyId == curCompCurrenciesIds[i]));
                                toDeleteCurrencies.Add(curCompCurrenciesIds[i]);
                            }
                        }

                        CompanyPrintSize_Dto[] compPrintSizes = company.CompanyPrintSizes.ToArray();
                        int[] curCompPrintSizesIds = curCompany.CompanyPrintSizes.Select(x => x.Id).ToArray();
                        for (int i = 0; i < compPrintSizes.Length; i++)
                        {
                            if (!curCompPrintSizesIds.Contains(compPrintSizes[i].Id))
                            {
                                curCompany.CompanyPrintSizes.Add(new CompanyPrintSize() { PrintSize = compPrintSizes[i].PrintSize });
                            }
                        }
                        List<int> toDeletePrintSizes = new List<int>();
                        for (int i = 0; i < curCompPrintSizesIds.Length; i++)
                        {
                            if (!compPrintSizes.Any(x => x.Id == curCompPrintSizesIds[i]))
                            {
                                curCompany.CompanyPrintSizes.Remove(curCompany.CompanyPrintSizes.First(x => x.Id == curCompPrintSizesIds[i]));
                                toDeletePrintSizes.Add(curCompPrintSizesIds[i]);
                            }
                        }
                        
                        CompanyDocument_Dto[] compDocuments = company.CompanyDocuments.ToArray();
                        int[] curCompDocumentsIds = curCompany.CompanyDocuments.Select(x => x.Id).ToArray();
                        for (int i = 0; i < compDocuments.Length; i++)
                        {
                            if (!curCompDocumentsIds.Contains(compDocuments[i].Id))
                            {
                                string curFileName = compDocuments[i].Document.Name;
                                if (FormData.Files.Any(x => x.Name == curFileName))
                                {
                                    var curDoc = compDocuments[i].Document;
                                    if (curDoc.Id == Guid.Empty)
                                    {
                                        IFormFile document = FormData.Files.First(x => x.Name == curFileName);
                                        string uploadedFileName = UploadedFile(document);

                                        Document_Dto doc = new Document_Dto(GuidGenerator.Create());
                                        doc.ReferenceNo = (new Random()).Next(10, 90) * (new Random()).Next(10000, 90000);
                                        doc.Name = company.CompanyName + "_" + compDocuments[i].DocumentType.Value + "_" + compDocuments[i].Id;
                                        doc.NameLocalized = company.CompanyNameLocalized + "_" + compDocuments[i].DocumentType.Value + "_" + compDocuments[i].Id;
                                        doc.Description = $"Soft copy of {compDocuments[i].DocumentType.Value}";
                                        doc.OwnerId = company.Id;
                                        doc.OwnerTypeId = DictionaryValuesRepo.WithDetails().Where(x => x.Value == "Company").First(x => x.ValueType.ValueTypeFor == ValueTypeModules.OwnerType).Id;
                                        doc.DocumentTypeId = compDocuments[i].DocumentType.Id;
                                        doc.IssuedFromId = doc.OwnerTypeId;
                                        doc.IssueDate = compDocuments[i].IssueDate;
                                        doc.ExpiryDate = compDocuments[i].EndDate;
                                        doc.FileName = uploadedFileName;

                                        Document_Dto created = await documentAppService.CreateAsync(doc);
                                        compDocuments[i].DocumentId = created.Id;
                                    }
                                }

                                curCompany.CompanyDocuments.Add(new CompanyDocument() { 
                                    DocumentTitle = compDocuments[i].DocumentTitle, 
                                    DocumentTitleLocalized = compDocuments[i].DocumentTitleLocalized,
                                    DocumentTypeId = compDocuments[i].DocumentType.Id,
                                    DocumentId = compDocuments[i].DocumentId,
                                    IssueDate = compDocuments[i].IssueDate,
                                    EndDate = compDocuments[i].EndDate
                                });
                            }
                        }
                        List<CompanyDocument> toDeleteDocuments = new List<CompanyDocument>();
                        for (int i = 0; i < curCompDocumentsIds.Length; i++)
                        {
                            if (!compDocuments.Any(x => x.Id == curCompDocumentsIds[i]))
                            {
                                var doc = curCompany.CompanyDocuments.First(x => x.Id == curCompDocumentsIds[i]);
                                toDeleteDocuments.Add(doc);
                                curCompany.CompanyDocuments.Remove(doc);
                            }
                        }

                        for (int i = 0; i < toDeletePrintSizes.Count; i++)
                        {
                            await CompanyAppService.PrintSizesRepository.DeleteAsync(x => x.Id == toDeletePrintSizes[i]);
                        }
                        for (int i = 0; i < toDeleteLocs.Count; i++)
                        {
                            await CompanyAppService.LocationsRepository.DeleteAsync(x => x.LocationId == toDeleteLocs[i]);
                        }
                        for (int i = 0; i < toDeleteCurrencies.Count; i++)
                        {
                            await CompanyAppService.CurrenciesRepository.DeleteAsync(x => x.CurrencyId == toDeleteCurrencies[i]);
                        }
                        for (int i = 0; i < toDeleteDocuments.Count; i++)
                        {
                            await documentAppService.Repository.DeleteAsync(toDeleteDocuments[i].DocumentId);
                            await CompanyAppService.DocumentsRepository.DeleteAsync(x => x.Id == toDeleteDocuments[i].Id);
                        }

                        Company_Dto updated = ObjectMapper.Map<Company, Company_Dto>(await CompanyAppService.Repository.UpdateAsync(curCompany));

                        return StatusCode(200, updated);
                    }
                    else
                    {
                        List<Document_Dto> documentsToAdd = new List<Document_Dto>();
                        List<CompanyDocument_Dto> companyDocuments = company.CompanyDocuments;
                        if (FormData.Files.Count > 0)
                        {
                            for (int i = 0; i < companyDocuments.Count; i++)
                            {
                                CompanyDocument_Dto compDoc = companyDocuments[i];
                                string curFileName = compDoc.Document.Name;
                                if (FormData.Files.Any(x => x.Name == curFileName))
                                {
                                    var curDoc = compDoc.Document;
                                    if (curDoc.Id == Guid.Empty)
                                    {
                                        IFormFile document = FormData.Files.First(x => x.Name == curFileName);
                                        string uploadedFileName = UploadedFile(document);

                                        Document_Dto doc = new Document_Dto(GuidGenerator.Create());
                                        doc.ReferenceNo = (new Random()).Next(10, 90) * (new Random()).Next(10000, 90000);
                                        doc.Name = company.CompanyName + "_" + compDoc.DocumentType.Value + "_" + compDoc.Id;
                                        doc.NameLocalized = company.CompanyNameLocalized + "_" + compDoc.DocumentType.Value + "_" + compDoc.Id;
                                        doc.Description = $"Soft copy of {compDoc.DocumentType.Value}";
                                        doc.OwnerId = company.Id;
                                        doc.OwnerTypeId = DictionaryValuesRepo.WithDetails().Where(x => x.Value == "Company").First(x => x.ValueType.ValueTypeFor == ValueTypeModules.OwnerType).Id;
                                        doc.DocumentTypeId = compDoc.DocumentTypeId;
                                        doc.IssuedFromId = compDoc.Document.IssuedFromId;
                                        doc.IssueDate = compDoc.IssueDate;
                                        doc.ExpiryDate = compDoc.EndDate;
                                        doc.FileName = uploadedFileName;

                                        Document_Dto created = await documentAppService.CreateAsync(doc);
                                        compDoc.DocumentId = created.Id;
                                    }
                                }
                            }
                            if (company.CompanyLogo == null)
                            {
                                company.CompanyLogo = "noimage.jpg";
                            }
                        }
                        for (int i = 0; i < documentsToAdd.Count; i++)
                        {
                            Document_Dto curDoc = documentsToAdd[i];
                        }

                        company.Id = Guid.Empty;
                        company.CompanyCurrencies.ForEach(x => { x.Id = 0; x.CurrencyId = x.Currency.Id; x.Currency = null; });
                        company.CompanyLocations.ForEach(x => { x.Id = 0; x.LocationId = x.Location.Id; x.Location = null; });
                        company.CompanyPrintSizes.ForEach(x => { x.Id = 0; });

                        Company_Dto added = await CompanyAppService.CreateAsync(company);

                        if (AuditingManager.Current != null)
                        {
                            EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                            entityChangeInfo.EntityId = added.Id.ToString();
                            entityChangeInfo.EntityTenantId = added.TenantId;
                            entityChangeInfo.ChangeTime = DateTime.Now;
                            entityChangeInfo.ChangeType = EntityChangeType.Created;
                            entityChangeInfo.EntityTypeFullName = typeof(Company).FullName;

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
        public async Task<IActionResult> OnDeleteCompany()
        {
            List<Company_Dto> companies = JsonSerializer.Deserialize<List<Company_Dto>>(Request.Form["companies"]);
            try
            {
                for (int i = 0; i < companies.Count; i++)
                {
                    Company_Dto company = companies[i];
                    //await TaskTemplatesAppService.Repository.DeleteAsync(leaveRequest.);
                    await CompanyAppService.Repository.DeleteAsync(company.Id);

                    if (AuditingManager.Current != null)
                    {
                        EntityChangeInfo entityChangeInfo = new EntityChangeInfo();
                        entityChangeInfo.EntityId = company.Id.ToString();
                        entityChangeInfo.EntityTenantId = company.TenantId;
                        entityChangeInfo.ChangeTime = DateTime.Now;
                        entityChangeInfo.ChangeType = EntityChangeType.Deleted;
                        entityChangeInfo.EntityTypeFullName = typeof(Company).FullName;

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

            //List<GridColumn> primaryGridColumns = new List<GridColumn>()
            //{
            //    new GridColumn { Field = "AuditLogId", HeaderText = "", TextAlign=TextAlign.Center, Visible=false, ShowInColumnChooser=false,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
            //    new GridColumn { Field = "EntityChangeId", HeaderText = "", TextAlign=TextAlign.Center, Visible=false, ShowInColumnChooser=false,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
            //    new GridColumn { Field = "Id", HeaderText = "Id", TextAlign=TextAlign.Center,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
            //    new GridColumn { Field = "Name", HeaderText = "Name", TextAlign=TextAlign.Center,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
            //    new GridColumn { Field = "Date", HeaderText = "Date", TextAlign=TextAlign.Center,  AllowEditing=false, MinWidth = "10", CustomAttributes=new {id="detailed"}  },
            //    new GridColumn { Field = "Time", HeaderText = "Time", TextAlign=TextAlign.Center,  AllowEditing=false, MinWidth = "10", CustomAttributes=new {id="detailed"}  },
            //    new GridColumn { Field = "User", HeaderText = "User", TextAlign=TextAlign.Center,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
            //    new GridColumn { Field = "Status", HeaderText = "Status", TextAlign=TextAlign.Center,  AllowEditing=false,  MinWidth = "10", CustomAttributes=new {id="detailed"}  },
            //};
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
            var companyLogs = AuditLogsRepo.WithDetails().Where(x => x.Url == "/Setup/Companies" && x.EntityChanges != null && x.EntityChanges.Count > 0).ToList();

            List<Company_Dto> Comapanies = CompanyAppService.GetAllCompanies();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            for (int i = 0; i < companyLogs.Count; i++)
            {
                AuditLog auditLog = companyLogs[i];
                if (auditLog.EntityChanges == null || auditLog.EntityChanges.Count == 0) continue;
                var entityChanges = auditLog.EntityChanges.ToList();
                for (int j = 0; j < entityChanges.Count; j++)
                {
                    EntityChange entityChange = entityChanges[j];

                    dynamic changeRow = new ExpandoObject();
                    changeRow.AuditLogId = entityChange.Id;
                    changeRow.EntityChangeId = entityChange.Id;

                    Company_Dto company = Comapanies.First(x => x.Id.ToString() == entityChange.EntityId);
                    changeRow.Id = company.ClientID;
                    changeRow.Name = company.CompanyName;
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
