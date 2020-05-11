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

namespace CERP.Web.Areas.Setup.Pages.Companies
{
    public class ListModel : CERPPageModel
    {
        public IWebHostEnvironment webHostEnvironment { get; set; }
        public IRepository<DictionaryValue> DictionaryValuesRepo { get; set; }
        public CompanyAppService CompanyAppService { get; set; }
        public documentAppService documentAppService { get; set; }

        public ListModel(IJsonSerializer jsonSerializer, IRepository<DictionaryValue> dictionaryValuesRepo, CompanyAppService companyAppService, IWebHostEnvironment webHostEnvironment, documentAppService documentAppService)
        {
            JsonSerializer = jsonSerializer;
            DictionaryValuesRepo = dictionaryValuesRepo;
            CompanyAppService = companyAppService;
            this.webHostEnvironment = webHostEnvironment;
            this.documentAppService = documentAppService;
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
                        if(logoChanged)
                            curCompany.CompanyLogo = company.CompanyLogo;

                        curCompany.CompanyName = company.CompanyName;
                        curCompany.CompanyNameLocalized = company.CompanyNameLocalized;
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
                                //var _companyLoc = await CompanyAppService.LocationsRepository.GetAsync(x => x.LocationId == compLocs[i].Location.Id);
                                //_companyLoc.LocationValidityStart = compLocs[i].LocationValidityStart;
                                //_companyLoc.LocationValidityEnd = compLocs[i].LocationValidityEnd;
                                //_companyLoc.Name = compLocs[i].Name;

                                ////curCompany.CompanyLocations.Remove(curCompany.CompanyLocations.First(x => x.LocationId == _companyLoc.LocationId));
                                //await CompanyAppService.LocationsRepository.UpdateAsync(_companyLoc);
                            }
                        }
                        
                        CompanyCurrency_Dto[] compCurrencies = company.CompanyCurrencies.ToArray();
                        int[] curCompCurrenciesIds = curCompany.CompanyCurrencies.Select(x => x.Currency.Id).ToArray();
                        for (int i = 0; i < compCurrencies.Length; i++)
                        {
                            if (!curCompCurrenciesIds.Contains(compCurrencies[i].Currency.Id))
                            {
                                curCompany.CompanyCurrencies.Add(new CompanyCurrency() { ExchangeRate = compCurrencies[i].ExchangeRate,  CurrencyId = compCurrencies[i].Currency.Id });
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
                }
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
