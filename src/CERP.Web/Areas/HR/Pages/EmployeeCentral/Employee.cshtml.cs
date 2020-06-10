using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CERP.App.CustomEntityHistorySystem;
using CERP.AppServices.HR.EmployeeService;
using CERP.HR.Documents;
using CERP.HR.EmployeeCentral.DTOs.Employee;
using CERP.HR.EmployeeCentral.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Syncfusion.EJ2.Charts;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Json;

namespace CERP.Web.Areas.HR.Pages.EmployeeCentral
{
    [Authorize]
    public class EmployeeModel : AbpPageModel
    {
        public EmployeeModel(IWebHostEnvironment webHostEnvironment, IAuditingManager auditingManager, IRepository<CustomEntityChange> customEntityChangesRepo, IJsonSerializer jsonSerializer, EmployeeAppService employeeAppService)
        {
            this.webHostEnvironment = webHostEnvironment;
            AuditingManager = auditingManager;
            CustomEntityChangesRepo = customEntityChangesRepo;
            JsonSerializer = jsonSerializer;
            EmployeeAppService = employeeAppService;
        }

        public IWebHostEnvironment webHostEnvironment { get; set; }
        public IAuditingManager AuditingManager { get; set; }
        public IJsonSerializer JsonSerializer { get; set; }

        public EmployeeAppService EmployeeAppService { get; set; }
        public IRepository<CustomEntityChange> CustomEntityChangesRepo { get; set; }

        public const string EMPLOYEE_CENTRAL_PATH = "/Content/HR/EmployeeCentral";
        public const string EMPLOYEE_PATH = EMPLOYEE_CENTRAL_PATH + "/Employee";
        public const string EMPLOYEE_GENERAL_PATH = EMPLOYEE_PATH + "/General";
        public const string EMPLOYEE_DEPENDANTS_PATH = EMPLOYEE_PATH + "/Dependants";
        public const string EMPLOYEE_DEPENDANT_NATID_PATH = EMPLOYEE_DEPENDANTS_PATH + "/NatIds";
        public const string EMPLOYEE_DEPENDANT_PTD_PATH = EMPLOYEE_DEPENDANTS_PATH + "/PTDs";
        public const string EMPLOYEE_NATID_PATH = EMPLOYEE_PATH + "/NatIds";
        public const string EMPLOYEE_PTD_PATH = EMPLOYEE_PATH + "/PTDs";

        public Guid? Id { get; set; }

        public void OnGet()
        {
            RouteData.Values.TryGetValue("Id", out object _Id);

            try {
                Id = _Id != null ? Guid.Parse(_Id.ToString()) : Guid.Empty;
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<IActionResult> OnPost()
        {
            var FormData = Request.Form;

            var changes = await CustomEntityChangesRepo.GetListAsync();
            try 
            {
                Employee_Dto employeeRaw = JsonSerializer.Deserialize<Employee_Dto>(FormData["general"].ToString());
                Employee_Dto employee = JsonSerializer.Deserialize<Employee_Dto>(FormData["general"].ToString());

                bool IsEditing = employee.Id != Guid.Empty;
                if (IsEditing)
                {
                    Employee toUpdate = EmployeeAppService.Repository
                       .Include(x => x.NationalIdentities)
                            .ThenInclude(x => x.NationalIdentity)
                        .Include(x => x.PassportTravelDocuments)
                            .ThenInclude(x => x.PassportTravelDocument)

                         .Include(x => x.Dependants)
                             .ThenInclude(x => x.NationalIdentities)
                             .ThenInclude(x => x.NationalIdentity)
                         .Include(x => x.Dependants)
                             .ThenInclude(x => x.PassportTravelDocuments)
                             .ThenInclude(x => x.PassportTravelDocument)

                         .Include(x => x.OrganizationStructureTemplateDepartment)
                             .ThenInclude(x => x.DepartmentTemplate)

                         .Include(x => x.EmailAddresses)
                             .ThenInclude(x => x.EmailAddress)
                         .Include(x => x.PhoneAddresses)
                             .ThenInclude(x => x.PhoneAddress)
                         .Include(x => x.HomeAddresses)
                             .ThenInclude(x => x.HomeAddress)
                         .Include(x => x.Contacts)
                             .ThenInclude(x => x.Contact)

                         .Include(x => x.EmployeeBenefits)

                         .Include(x => x.CashPaymentTypes)
                         .Include(x => x.ChequePaymentTypes)
                         .Include(x => x.BankPaymentTypes)

                         .Include(x => x.AcademiaProfile)
                         .Include(x => x.SkillsProfile)

                         .Include(x => x.EmployeeLoans)
                         .First(x => x.Id == employee.Id);

                    toUpdate.LegalEntityId = employee.LegalEntityId;
                    toUpdate.HeadDepartmentTemplateId = employee.HeadDepartmentTemplateId;
                    toUpdate.OrganizationStructureTemplateDivisionId = employee.OrganizationStructureTemplateDivisionId;
                    toUpdate.OrganizationStructureTemplateBusinessUnitId = employee.OrganizationStructureTemplateBusinessUnitId;
                    toUpdate.DepartmentTemplateId = employee.DepartmentTemplateId;
                    toUpdate.GenderId = employee.GenderId;
                    toUpdate.TitleId = employee.TitleId;
                    toUpdate.MaritalStatusId = employee.MaritalStatusId;
                    toUpdate.PreferredLanguageId = employee.PreferredLanguageId;
                    toUpdate.NationalityId = employee.NationalityId;
                    toUpdate.BirthCountryId = employee.BirthCountryId;
                    toUpdate.CostCenterId = employee.CostCenterId;
                    toUpdate.PayGroupId = employee.PayGroupId;
                    toUpdate.PayGradeId = employee.PayGradeId;
                    toUpdate.TimezoneId = employee.TimezoneId;
                    toUpdate.PortalId = employee.PortalId;
                    
                    toUpdate.FirstName = employee.FirstName;
                    toUpdate.FirstNameLocalized = employee.FirstNameLocalized;
                    toUpdate.MiddleName = employee.MiddleName;
                    toUpdate.MiddleNameLocalized = employee.MiddleNameLocalized;
                    toUpdate.LastName = employee.LastName;
                    toUpdate.LastNameLocalized = employee.LastNameLocalized;
                    toUpdate.Initials = employee.Initials;
                    toUpdate.PreferredName = employee.PreferredName;
                    toUpdate.DisplayName = employee.DisplayName;
                    toUpdate.DateOfBirth = employee.DateOfBirth;
                    toUpdate.Initials = employee.Initials;
                    toUpdate.PlaceOfBirth = employee.PlaceOfBirth;
                    toUpdate.BioAttachment = employee.BioAttachment;
                    toUpdate.YearlyTimeOffAllowance = employee.YearlyTimeOffAllowance;
                    //toUpdate.Title = employee.Title;

                    if (FormData.Files.Count > 0)
                    {
                        if (FormData.Files.Any(x => x.Name == "ProfilePicture"))
                        {
                            IFormFile formFile = FormData.Files.First(x => x.Name == "ProfilePicture");
                            if(System.IO.File.Exists(toUpdate.ProfilePic))
                                System.IO.File.Delete(toUpdate.ProfilePic);

                            string uploadedFileName = UploadedFile(formFile, $"Profile", EMPLOYEE_GENERAL_PATH);
                            toUpdate.ProfilePic = uploadedFileName;
                        }
                        if (FormData.Files.Any(x => x.Name == "BioAttachment"))
                        {
                            IFormFile formFile = FormData.Files.First(x => x.Name == "BioAttachment");
                            if (System.IO.File.Exists(toUpdate.BioAttachment))
                                 System.IO.File.Delete(toUpdate.BioAttachment);

                            string uploadedFileName = UploadedFile(formFile, $"BIO", EMPLOYEE_GENERAL_PATH);
                            toUpdate.BioAttachment = uploadedFileName;
                        }

                        for (int i = 0; i < toUpdate.NationalIdentities.Count; i++)
                        {
                            EmployeeNationalIdentity_Dto curIdentityRaw = employeeRaw.NationalIdentities[i];
                            EmployeeNationalIdentity curIdentity = toUpdate.NationalIdentities.ElementAt(i);
                            string attachName = $"ENatId_{curIdentityRaw.NationalIdentity.Id}_Attachment";

                            if (FormData.Files.Any(x => x.Name.Contains(attachName)))
                            {
                                IFormFile formFile = FormData.Files.First(x => x.Name == attachName);
                                if (System.IO.File.Exists(curIdentity.NationalIdentity.IDAttachment))
                                    System.IO.File.Delete(curIdentity.NationalIdentity.IDAttachment);

                                string uploadedFileName = UploadedFile(formFile, $"{toUpdate.Id}NATID{curIdentity.NationalIdentityId}", EMPLOYEE_NATID_PATH);
                                curIdentity.NationalIdentity.IDAttachment = uploadedFileName;
                            }
                        }
                        for (int i = 0; i < toUpdate.PassportTravelDocuments.Count; i++)
                        {
                            EmployeePassportTravelDocument_Dto curIdentityRaw = employeeRaw.PassportTravelDocuments[i];
                            EmployeePassportTravelDocument curIdentity = toUpdate.PassportTravelDocuments.ElementAt(i);
                            string attachName = $"EPTD_{curIdentityRaw.PassportTravelDocument.Id}_Attachment";

                            if (FormData.Files.Any(x => x.Name.Contains(attachName)))
                            {
                                IFormFile formFile = FormData.Files.First(x => x.Name == attachName);
                                if (System.IO.File.Exists(curIdentity.PassportTravelDocument.DocumentAttachment))
                                    System.IO.File.Delete(curIdentity.PassportTravelDocument.DocumentAttachment);

                                string uploadedFileName = UploadedFile(formFile, $"{toUpdate.Id}PTD{curIdentity.PassportTravelDocumentId}", EMPLOYEE_PTD_PATH);
                                curIdentity.PassportTravelDocument.DocumentAttachment = uploadedFileName;
                            }
                        }

                        for (int y = 0; y < toUpdate.Dependants.Count; y++)
                        {
                            Dependant_Dto curDependantRaw = employeeRaw.Dependants[y];
                            Dependant curDependant = toUpdate.Dependants.ElementAt(y);

                            for (int i = 0; i < curDependant.NationalIdentities.Count; i++)
                            {
                                DependantNationalIdentity_Dto curIdentityRaw = curDependantRaw.NationalIdentities[i];
                                DependantNationalIdentity curIdentity = curDependant.NationalIdentities.ElementAt(i);
                                string attachName = $"DNatId_{curDependantRaw.Id}_{curIdentityRaw.NationalIdentity.Id}_Attachment";

                                if (FormData.Files.Any(x => x.Name.Contains(attachName)))
                                {
                                    IFormFile formFile = FormData.Files.First(x => x.Name == attachName);
                                    if (System.IO.File.Exists(curIdentity.NationalIdentity.IDAttachment))
                                        System.IO.File.Delete(curIdentity.NationalIdentity.IDAttachment);

                                    string uploadedFileName = UploadedFile(formFile, $"{toUpdate.Id}DEP{curDependant.Id}NATID{curIdentity.NationalIdentityId}", EMPLOYEE_DEPENDANT_NATID_PATH);
                                    curIdentity.NationalIdentity.IDAttachment = uploadedFileName;
                                }
                            }
                            for (int i = 0; i < curDependant.PassportTravelDocuments.Count; i++)
                            {
                                DependantPassportTravelDocument_Dto curIdentityRaw = curDependantRaw.PassportTravelDocuments[i];
                                DependantPassportTravelDocument curIdentity = curDependant.PassportTravelDocuments.ElementAt(i);
                                string attachName = $"DPTD_{curDependantRaw.Id}_{curIdentityRaw.PassportTravelDocument.Id}_Attachment";

                                if (FormData.Files.Any(x => x.Name.Contains(attachName)))
                                {
                                    IFormFile formFile = FormData.Files.First(x => x.Name == attachName);
                                    if (System.IO.File.Exists(curIdentity.PassportTravelDocument.DocumentAttachment))
                                        System.IO.File.Delete(curIdentity.PassportTravelDocument.DocumentAttachment);

                                    string uploadedFileName = UploadedFile(formFile, $"{toUpdate.Id}DEP{curDependant.Id}PTD{curIdentity.PassportTravelDocumentId}", EMPLOYEE_DEPENDANT_PTD_PATH);
                                    curIdentity.PassportTravelDocument.DocumentAttachment = uploadedFileName;
                                }
                            }
                        }
                    }



                    #region Child Entities
                    #region Employee National Identities
                    //Getting New
                    EmployeeNationalIdentity_Dto[] employeeNationalIdentities = employee.NationalIdentities.ToArray();
                    //Getting Current
                    int[] curNationalIdentitiesIds = toUpdate.NationalIdentities != null && toUpdate.NationalIdentities.Count > 0 ? toUpdate.NationalIdentities.Select(x => x.NationalIdentity.Id).ToArray() : new int[0];
                    List<int> toDeleteNationalIdentities = new List<int>();
                    //Removing Removed
                    for (int i = 0; i < curNationalIdentitiesIds.Length; i++)
                    {
                        EmployeeNationalIdentity curNationalIdentity = toUpdate.NationalIdentities.First(x => x.NationalIdentityId == curNationalIdentitiesIds[i]);
                        if (!employeeNationalIdentities.Any(x => x.NationalIdentity.Id == curNationalIdentitiesIds[i]))
                        {
                            toUpdate.NationalIdentities.Remove(toUpdate.NationalIdentities.First(x => x.NationalIdentityId == curNationalIdentitiesIds[i]));
                            toDeleteNationalIdentities.Add(curNationalIdentitiesIds[i]);
                        }
                    }
                    //Adding & Updating New
                    for (int i = 0; i < employeeNationalIdentities.Length; i++)
                    {
                        if (!toUpdate.NationalIdentities.Any(x => x.NationalIdentityId == employeeNationalIdentities[i].NationalIdentity.Id))
                        {
                            employeeNationalIdentities[i].NationalIdentity.Id = 0;
                            toUpdate.NationalIdentities.Add(new EmployeeNationalIdentity() { NationalIdentity = ObjectMapper.Map<NationalIdentity_Dto, NationalIdentity>(employeeNationalIdentities[i].NationalIdentity) });
                        }
                        else
                        {
                            var _emailAddressNew = employeeNationalIdentities[i].NationalIdentity;
                            var _emailAddress = toUpdate.NationalIdentities.First(x => x.NationalIdentityId == employeeNationalIdentities[i].NationalIdentity.Id);

                            _emailAddress.NationalIdentity.IdTypeId = _emailAddressNew.IdTypeId;
                            _emailAddress.NationalIdentity.IDNumber = _emailAddressNew.IDNumber;
                            _emailAddress.NationalIdentity.IDAttachment = _emailAddressNew.IDNumber;
                            _emailAddress.NationalIdentity.IsPrimary = _emailAddressNew.IsPrimary;
                            _emailAddress.NationalIdentity.ValidityFromDate = _emailAddressNew.ValidityFromDate;
                            _emailAddress.NationalIdentity.ValidityToDate = _emailAddressNew.ValidityToDate;

                            await EmployeeAppService.NationalIdentitiesRepo.UpdateAsync(_emailAddress.NationalIdentity);
                        }
                    }
                    //Appending Deleted
                    for (int i = 0; i < toDeleteNationalIdentities.Count; i++)
                    {
                        await EmployeeAppService.EmployeeNationalIdentitiesRepo.DeleteAsync(x => x.NationalIdentityId == toDeleteNationalIdentities[i]);
                    }
                    #endregion
                    #region Employee Passport Travel Documents
                    //Getting New
                    EmployeePassportTravelDocument_Dto[] employeePassportTravelDocuments = employee.PassportTravelDocuments.ToArray();
                    //Getting Current
                    int[] curPassportTravelDocumentsIds = toUpdate.PassportTravelDocuments != null && toUpdate.PassportTravelDocuments.Count > 0 ? toUpdate.PassportTravelDocuments.Select(x => x.PassportTravelDocument.Id).ToArray() : new int[0];
                    List<int> toDeletePassportTravelDocuments = new List<int>();
                    //Removing Removed
                    for (int i = 0; i < curPassportTravelDocumentsIds.Length; i++)
                    {
                        EmployeePassportTravelDocument curPassportTravelDocument = toUpdate.PassportTravelDocuments.First(x => x.PassportTravelDocumentId == curPassportTravelDocumentsIds[i]);
                        if (!employeePassportTravelDocuments.Any(x => x.PassportTravelDocument.Id == curPassportTravelDocumentsIds[i]))
                        {
                            toUpdate.PassportTravelDocuments.Remove(toUpdate.PassportTravelDocuments.First(x => x.PassportTravelDocumentId == curPassportTravelDocumentsIds[i]));
                            toDeletePassportTravelDocuments.Add(curPassportTravelDocumentsIds[i]);
                        }
                    }
                    //Adding & Updating New
                    for (int i = 0; i < employeePassportTravelDocuments.Length; i++)
                    {
                        if (!toUpdate.PassportTravelDocuments.Any(x => x.PassportTravelDocumentId == employeePassportTravelDocuments[i].PassportTravelDocument.Id))
                        {
                            employeePassportTravelDocuments[i].PassportTravelDocument.Id = 0;
                            toUpdate.PassportTravelDocuments.Add(new EmployeePassportTravelDocument() { PassportTravelDocument = ObjectMapper.Map<PassportTravelDocument_Dto, PassportTravelDocument>(employeePassportTravelDocuments[i].PassportTravelDocument) });
                        }
                        else
                        {
                            var _passportTravelDocumentsNew = employeePassportTravelDocuments[i].PassportTravelDocument;
                            var _passportTravelDocument = toUpdate.PassportTravelDocuments.First(x => x.PassportTravelDocumentId == employeePassportTravelDocuments[i].PassportTravelDocument.Id);

                            _passportTravelDocument.PassportTravelDocument.DocumentType = _passportTravelDocumentsNew.DocumentType;
                            _passportTravelDocument.PassportTravelDocument.IssuingCountryId = _passportTravelDocumentsNew.IssuingCountryId;
                            _passportTravelDocument.PassportTravelDocument.DocumentNumber = _passportTravelDocumentsNew.DocumentNumber;
                            _passportTravelDocument.PassportTravelDocument.DocumentAttachment = _passportTravelDocumentsNew.DocumentAttachment;
                            _passportTravelDocument.PassportTravelDocument.IsPrimary = _passportTravelDocumentsNew.IsPrimary;
                            _passportTravelDocument.PassportTravelDocument.ValidityFromDate = _passportTravelDocumentsNew.ValidityFromDate;
                            _passportTravelDocument.PassportTravelDocument.ValidityToDate = _passportTravelDocumentsNew.ValidityToDate;

                            await EmployeeAppService.PassportTravelDocumentsRepo.UpdateAsync(_passportTravelDocument.PassportTravelDocument);
                        }
                    }
                    //Appending Deleted
                    for (int i = 0; i < toDeletePassportTravelDocuments.Count; i++)
                    {
                        await EmployeeAppService.EmployeePassportTravelDocumentsRepo.DeleteAsync(x => x.PassportTravelDocumentId == toDeletePassportTravelDocuments[i]);
                    }
                    #endregion

                    #region Email Addresses
                    //Getting New
                    EmployeeEmailAddress_Dto[] employeeEmailAddresses = employee.EmailAddresses.ToArray();
                    //Getting Current
                    int[] curEmailAddressesIds = toUpdate.EmailAddresses != null && toUpdate.EmailAddresses.Count > 0 ? toUpdate.EmailAddresses.Select(x => x.EmailAddress.Id).ToArray() : new int[0];
                    List<int> toDeleteEmailAddresses = new List<int>();
                    //Removing Removed
                    for (int i = 0; i < curEmailAddressesIds.Length; i++)
                    {
                        EmployeeEmailAddress curEmailAddress = toUpdate.EmailAddresses.First(x => x.EmailAddressId == curEmailAddressesIds[i]);
                        if (!employeeEmailAddresses.Any(x => x.EmailAddress.Id == curEmailAddressesIds[i]))
                        {
                            toUpdate.EmailAddresses.Remove(toUpdate.EmailAddresses.First(x => x.EmailAddressId == curEmailAddressesIds[i]));
                            toDeleteEmailAddresses.Add(curEmailAddressesIds[i]);
                        }
                    }
                    //Adding & Updating New
                    for (int i = 0; i < employeeEmailAddresses.Length; i++)
                    {
                        if (!toUpdate.EmailAddresses.Any(x => x.EmailAddressId == employeeEmailAddresses[i].EmailAddress.Id))
                        {
                            employeeEmailAddresses[i].EmailAddress.Id = 0;
                            toUpdate.EmailAddresses.Add(new EmployeeEmailAddress() { EmailAddress = ObjectMapper.Map<EmailAddress_Dto, EmailAddress>(employeeEmailAddresses[i].EmailAddress) });
                        }
                        else
                        {
                            var _emailAddressNew = employeeEmailAddresses[i].EmailAddress;
                            var _emailAddress = toUpdate.EmailAddresses.First(x => x.EmailAddressId == employeeEmailAddresses[i].EmailAddress.Id);

                            _emailAddress.EmailAddress.EmailTypeId = _emailAddressNew.EmailTypeId;
                            _emailAddress.EmailAddress.Email = _emailAddressNew.Email;
                            _emailAddress.EmailAddress.IsPrimary = _emailAddressNew.IsPrimary;

                            await EmployeeAppService.EmailAddressesRepo.UpdateAsync(_emailAddress.EmailAddress);
                        }
                    }
                    //Appending Deleted
                    for (int i = 0; i < toDeleteEmailAddresses.Count; i++)
                    {
                        await EmployeeAppService.EmployeeEmailAddressesRepo.DeleteAsync(x => x.EmailAddressId == toDeleteEmailAddresses[i]);
                    }
                    #endregion
                    #region Phone Addresses
                    //Getting New
                    EmployeePhoneAddress_Dto[] employeePhoneAddresses = employee.PhoneAddresses.ToArray();
                    //Getting Current
                    int[] curPhoneAddressesIds = toUpdate.PhoneAddresses != null && toUpdate.PhoneAddresses.Count > 0 ? toUpdate.PhoneAddresses.Select(x => x.PhoneAddress.Id).ToArray() : new int[0];
                    List<int> toDeletePhoneAddresses = new List<int>();
                    //Removing Removed
                    for (int i = 0; i < curPhoneAddressesIds.Length; i++)
                    {
                        EmployeePhoneAddress curPhoneAddress = toUpdate.PhoneAddresses.First(x => x.PhoneAddressId == curPhoneAddressesIds[i]);
                        if (!employeePhoneAddresses.Any(x => x.PhoneAddress.Id == curPhoneAddressesIds[i]))
                        {
                            toUpdate.PhoneAddresses.Remove(toUpdate.PhoneAddresses.First(x => x.PhoneAddressId == curPhoneAddressesIds[i]));
                            toDeletePhoneAddresses.Add(curPhoneAddressesIds[i]);
                        }
                    }
                    //Adding & Updating New
                    for (int i = 0; i < employeePhoneAddresses.Length; i++)
                    {
                        if (!toUpdate.PhoneAddresses.Any(x => x.PhoneAddressId == employeePhoneAddresses[i].PhoneAddress.Id))
                        {
                            employeePhoneAddresses[i].PhoneAddress.Id = 0;
                            toUpdate.PhoneAddresses.Add(new EmployeePhoneAddress() { PhoneAddress = ObjectMapper.Map<PhoneAddress_Dto, PhoneAddress>(employeePhoneAddresses[i].PhoneAddress) });
                        }
                        else
                        {
                            var _phoneAddressNew = employeePhoneAddresses[i].PhoneAddress;
                            var _phoneAddress = toUpdate.PhoneAddresses.First(x => x.PhoneAddressId == employeePhoneAddresses[i].PhoneAddress.Id);

                            _phoneAddress.PhoneAddress.PhoneTypeId = _phoneAddressNew.PhoneTypeId;
                            _phoneAddress.PhoneAddress.PhoneNumber = _phoneAddressNew.PhoneNumber;
                            _phoneAddress.PhoneAddress.Extension = _phoneAddressNew.Extension;
                            _phoneAddress.PhoneAddress.IsPrimary = _phoneAddressNew.IsPrimary;

                            await EmployeeAppService.PhoneAddressesRepo.UpdateAsync(_phoneAddress.PhoneAddress);
                        }
                    }
                    //Appending Deleted
                    for (int i = 0; i < toDeletePhoneAddresses.Count; i++)
                    {
                        await EmployeeAppService.EmployeePhoneAddressesRepo.DeleteAsync(x => x.PhoneAddressId == toDeletePhoneAddresses[i]);
                    }
                    #endregion
                    #region Home Addresses
                    //Getting New
                    EmployeeHomeAddress_Dto[] employeeHomeAddresses = employee.HomeAddresses.ToArray();
                    //Getting Current
                    int[] curHomeAddressesIds = toUpdate.HomeAddresses != null && toUpdate.HomeAddresses.Count > 0 ? toUpdate.HomeAddresses.Select(x => x.HomeAddress.Id).ToArray() : new int[0];
                    List<int> toDeleteHomeAddresses = new List<int>();
                    //Removing Removed
                    for (int i = 0; i < curHomeAddressesIds.Length; i++)
                    {
                        EmployeeHomeAddress curHomeAddress = toUpdate.HomeAddresses.First(x => x.HomeAddressId == curHomeAddressesIds[i]);
                        if (!employeeHomeAddresses.Any(x => x.HomeAddress.Id == curHomeAddressesIds[i]))
                        {
                            toUpdate.HomeAddresses.Remove(toUpdate.HomeAddresses.First(x => x.HomeAddressId == curHomeAddressesIds[i]));
                            toDeleteHomeAddresses.Add(curHomeAddressesIds[i]);
                        }
                    }
                    //Adding & Updating New
                    for (int i = 0; i < employeeHomeAddresses.Length; i++)
                    {
                        if (!toUpdate.HomeAddresses.Any(x => x.HomeAddressId == employeeHomeAddresses[i].HomeAddress.Id))
                        {
                            employeeHomeAddresses[i].HomeAddress.Id = 0;
                            toUpdate.HomeAddresses.Add(new EmployeeHomeAddress() { HomeAddress = ObjectMapper.Map<HomeAddress_Dto, HomeAddress>(employeeHomeAddresses[i].HomeAddress) });
                        }
                        else
                        {
                            var _homeAddressNew = employeeHomeAddresses[i].HomeAddress;
                            var _homeAddress = toUpdate.HomeAddresses.First(x => x.HomeAddressId == employeeHomeAddresses[i].HomeAddress.Id);

                            _homeAddress.HomeAddress.AddressTypeId = _homeAddressNew.AddressTypeId;
                            _homeAddress.HomeAddress.RegularAddress = _homeAddressNew.RegularAddress;
                            _homeAddress.HomeAddress.AddressLine1 = _homeAddressNew.AddressLine1;
                            _homeAddress.HomeAddress.AddressLine2 = _homeAddressNew.AddressLine2;
                            _homeAddress.HomeAddress.City = _homeAddressNew.City;
                            _homeAddress.HomeAddress.State = _homeAddressNew.State;
                            _homeAddress.HomeAddress.PostalCode = _homeAddressNew.PostalCode;
                            _homeAddress.HomeAddress.CountryId = _homeAddressNew.CountryId;
                            _homeAddress.HomeAddress.IsPrimary = _homeAddressNew.IsPrimary;

                            await EmployeeAppService.EmployeeHomeAddressesRepo.UpdateAsync(_homeAddress);
                        }
                    }
                    //Appending Deleted
                    for (int i = 0; i < toDeleteHomeAddresses.Count; i++)
                    {
                        await EmployeeAppService.EmployeeHomeAddressesRepo.DeleteAsync(x => x.HomeAddressId == toDeleteHomeAddresses[i]);
                    }
                    #endregion
                    #region Contacts
                    //Getting New
                    EmployeeContact_Dto[] employeeContacts = employee.Contacts.ToArray();
                    //Getting Current
                    int[] curContactsIds = toUpdate.Contacts != null && toUpdate.Contacts.Count > 0 ? toUpdate.Contacts.Select(x => x.Contact.Id).ToArray() : new int[0];
                    List<int> toDeleteContacts = new List<int>();
                    //Removing Removed
                    for (int i = 0; i < curContactsIds.Length; i++)
                    {
                        EmployeeContact curContact = toUpdate.Contacts.First(x => x.ContactId == curContactsIds[i]);
                        if (!employeeContacts.Any(x => x.Contact.Id == curContactsIds[i]))
                        {
                            toUpdate.Contacts.Remove(toUpdate.Contacts.First(x => x.ContactId == curContactsIds[i]));
                            toDeleteContacts.Add(curContactsIds[i]);
                        }
                    }
                    //Adding & Updating New
                    for (int i = 0; i < employeeContacts.Length; i++)
                    {
                        if (!toUpdate.Contacts.Any(x => x.ContactId == employeeContacts[i].Contact.Id))
                        {
                            employeeContacts[i].Contact.Id = 0;
                            toUpdate.Contacts.Add(new EmployeeContact() { Contact = ObjectMapper.Map<Contact_Dto, Contact>(employeeContacts[i].Contact) });
                        }
                        else
                        {
                            var _contactNew = employeeContacts[i].Contact;
                            var _contact = toUpdate.Contacts.First(x => x.ContactId == employeeContacts[i].Contact.Id);

                            _contact.Contact.RelationshipTypeId = _contactNew.RelationshipTypeId;
                            _contact.Contact.Name = _contactNew.Name;
                            _contact.Contact.PhoneNumber = _contactNew.PhoneNumber;
                            _contact.Contact.EmailAddress = _contactNew.EmailAddress;
                            _contact.Contact.AlternatePhone = _contactNew.AlternatePhone;
                            _contact.Contact.IsEmergencyContact = _contactNew.IsEmergencyContact;
                            _contact.Contact.AddressLine1 = _contactNew.AddressLine1;
                            _contact.Contact.AddressLine2 = _contactNew.AddressLine2;
                            _contact.Contact.City = _contactNew.City;
                            _contact.Contact.State = _contactNew.State;
                            _contact.Contact.PostalCode = _contactNew.PostalCode;
                            _contact.Contact.CountryId = _contactNew.CountryId;
                            _contact.Contact.IsPrimary = _contactNew.IsPrimary;

                            await EmployeeAppService.ContactsRepo.UpdateAsync(_contact.Contact);
                        }
                    }
                    //Appending Deleted
                    for (int i = 0; i < toDeleteContacts.Count; i++)
                    {
                        await EmployeeAppService.EmployeeContactsRepo.DeleteAsync(x => x.ContactId == toDeleteContacts[i]);
                    }
                    #endregion

                    #region Employee Dependants
                    //Getting New
                    Dependant_Dto[] dependants = employee.Dependants.ToArray();
                    //Getting Current
                    int[] curDependantsIds = toUpdate.Dependants != null && toUpdate.Dependants.Count > 0 ? toUpdate.Dependants.Select(x => x.Id).ToArray() : new int[0];
                    List<int> toDeleteDependants = new List<int>();
                    //Removing Removed
                    for (int i = 0; i < curDependantsIds.Length; i++)
                    {
                        Dependant curDependant = toUpdate.Dependants.First(x => x.Id == curDependantsIds[i]);
                        if (!dependants.Any(x => x.Id == curDependantsIds[i]))
                        {
                            toUpdate.Dependants.Remove(toUpdate.Dependants.First(x => x.Id == curDependantsIds[i]));
                            toDeleteDependants.Add(curDependantsIds[i]);
                        }
                    }
                    //Adding & Updating New
                    for (int i = 0; i < dependants.Length; i++)
                    {
                        if (!toUpdate.Dependants.Any(x => x.Id == dependants[i].Id))
                        {
                            dependants[i].Id = 0;
                            for (int y = 0; y < dependants[i].NationalIdentities.Count; y++)
                            {
                                dependants[i].NationalIdentities[y].Id = 0;
                                dependants[i].NationalIdentities[y].NationalIdentity.Id = 0;
                            }
                            for (int y = 0; y < dependants[i].PassportTravelDocuments.Count; y++)
                            {
                                dependants[i].PassportTravelDocuments[y].Id = 0;
                                dependants[i].PassportTravelDocuments[y].PassportTravelDocument.Id = 0;
                            }
                            toUpdate.Dependants.Add(ObjectMapper.Map<Dependant_Dto, Dependant>(dependants[i]));
                        }
                        else
                        {
                            var dependantRaw = employee.Dependants.First(x => x.Id == dependants[i].Id);
                            var dependant = toUpdate.Dependants.First(x => x.Id == dependants[i].Id);

                            #region Dependant National Identities
                            //Getting New
                            DependantNationalIdentity_Dto[] dependantNationalIdentities = dependantRaw.NationalIdentities.ToArray();
                            //Getting Current
                            int[] curDependantNationalIdentitiesIds = dependant.NationalIdentities != null && dependant.NationalIdentities.Count > 0 ? dependant.NationalIdentities.Select(x => x.NationalIdentity.Id).ToArray() : new int[0];
                            List<int> toDeleteDependantNationalIdentities = new List<int>();
                            //Removing Removed
                            for (int i_dep = 0; i_dep < curDependantNationalIdentitiesIds.Length; i_dep++)
                            {
                                DependantNationalIdentity curNationalIdentity = dependant.NationalIdentities.First(x => x.NationalIdentityId == curDependantNationalIdentitiesIds[i_dep]);
                                if (!dependantNationalIdentities.Any(x => x.NationalIdentity.Id == curDependantNationalIdentitiesIds[i_dep]))
                                {
                                    dependant.NationalIdentities.Remove(dependant.NationalIdentities.First(x => x.NationalIdentityId == curDependantNationalIdentitiesIds[i_dep]));
                                    toDeleteDependantNationalIdentities.Add(curDependantNationalIdentitiesIds[i_dep]);
                                }
                            }
                            //Adding & Updating New
                            for (int i_dep = 0; i_dep < dependantNationalIdentities.Length; i_dep++)
                            {
                                if (!dependant.NationalIdentities.Any(x => x.NationalIdentityId == dependantNationalIdentities[i_dep].NationalIdentity.Id))
                                {
                                    dependantNationalIdentities[i_dep].NationalIdentity.Id = 0;
                                    dependant.NationalIdentities.Add(new DependantNationalIdentity() { NationalIdentity = ObjectMapper.Map<NationalIdentity_Dto, NationalIdentity>(dependantNationalIdentities[i_dep].NationalIdentity) });
                                }
                                else
                                {
                                    var _natIdNew = dependantNationalIdentities[i_dep].NationalIdentity;
                                    var _natId = dependant.NationalIdentities.First(x => x.NationalIdentityId == dependantNationalIdentities[i_dep].NationalIdentity.Id);

                                    _natId.NationalIdentity.IdTypeId = _natIdNew.IdTypeId;
                                    _natId.NationalIdentity.IDNumber = _natIdNew.IDNumber;
                                    _natId.NationalIdentity.IDAttachment = _natIdNew.IDNumber;
                                    _natId.NationalIdentity.IsPrimary = _natIdNew.IsPrimary;
                                    _natId.NationalIdentity.ValidityFromDate = _natIdNew.ValidityFromDate;
                                    _natId.NationalIdentity.ValidityToDate = _natIdNew.ValidityToDate;

                                    await EmployeeAppService.NationalIdentitiesRepo.UpdateAsync(_natId.NationalIdentity);
                                }
                            }
                            //Appending Deleted
                            for (int i_dep = 0; i_dep < toDeleteDependantNationalIdentities.Count; i_dep++)
                            {
                                await EmployeeAppService.DependantNationalIdentitiesRepo.DeleteAsync(x => x.NationalIdentityId == toDeleteDependantNationalIdentities[i_dep]);
                            }
                            #endregion
                            #region Dependant Passport Travel Documents
                            //Getting New
                            DependantPassportTravelDocument_Dto[] dependantPassportTravelDocuments = dependantRaw.PassportTravelDocuments.ToArray();
                            //Getting Current
                            int[] curDependantPassportTravelDocumentsIds = dependant.PassportTravelDocuments != null && dependant.PassportTravelDocuments.Count > 0 ? dependant.PassportTravelDocuments.Select(x => x.PassportTravelDocument.Id).ToArray() : new int[0];
                            List<int> toDeleteDependantPassportTravelDocuments = new List<int>();
                            //Removing Removed
                            for (int i_dep = 0; i_dep < curDependantPassportTravelDocumentsIds.Length; i_dep++)
                            {
                                DependantPassportTravelDocument curPassportTravelDocument = dependant.PassportTravelDocuments.First(x => x.PassportTravelDocumentId == curDependantPassportTravelDocumentsIds[i_dep]);
                                if (!dependantPassportTravelDocuments.Any(x => x.PassportTravelDocument.Id == curDependantPassportTravelDocumentsIds[i_dep]))
                                {
                                    dependant.PassportTravelDocuments.Remove(dependant.PassportTravelDocuments.First(x => x.PassportTravelDocumentId == curDependantPassportTravelDocumentsIds[i_dep]));
                                    toDeleteDependantPassportTravelDocuments.Add(curDependantPassportTravelDocumentsIds[i_dep]);
                                }
                            }
                            //Adding & Updating New
                            for (int i_dep = 0; i_dep < dependantPassportTravelDocuments.Length; i_dep++)
                            {
                                if (!dependant.PassportTravelDocuments.Any(x => x.PassportTravelDocumentId == dependantPassportTravelDocuments[i_dep].PassportTravelDocument.Id))
                                {
                                    dependantPassportTravelDocuments[i_dep].PassportTravelDocument.Id = 0;
                                    dependant.PassportTravelDocuments.Add(new DependantPassportTravelDocument() { PassportTravelDocument = ObjectMapper.Map<PassportTravelDocument_Dto, PassportTravelDocument>(dependantPassportTravelDocuments[i_dep].PassportTravelDocument) });
                                }
                                else
                                {
                                    var _passportTravelDocumentsNew = dependantPassportTravelDocuments[i_dep].PassportTravelDocument;
                                    var _passportTravelDocument = dependant.PassportTravelDocuments.First(x => x.PassportTravelDocumentId == dependantPassportTravelDocuments[i_dep].PassportTravelDocument.Id);

                                    _passportTravelDocument.PassportTravelDocument.DocumentType = _passportTravelDocumentsNew.DocumentType;
                                    _passportTravelDocument.PassportTravelDocument.IssuingCountryId = _passportTravelDocumentsNew.IssuingCountryId;
                                    _passportTravelDocument.PassportTravelDocument.DocumentNumber = _passportTravelDocumentsNew.DocumentNumber;
                                    _passportTravelDocument.PassportTravelDocument.DocumentAttachment = _passportTravelDocumentsNew.DocumentAttachment;
                                    _passportTravelDocument.PassportTravelDocument.IsPrimary = _passportTravelDocumentsNew.IsPrimary;
                                    _passportTravelDocument.PassportTravelDocument.ValidityFromDate = _passportTravelDocumentsNew.ValidityFromDate;
                                    _passportTravelDocument.PassportTravelDocument.ValidityToDate = _passportTravelDocumentsNew.ValidityToDate;

                                    await EmployeeAppService.PassportTravelDocumentsRepo.UpdateAsync(_passportTravelDocument.PassportTravelDocument);
                                }
                            }
                            //Appending Deleted
                            for (int i_dep = 0; i_dep < toDeleteDependantPassportTravelDocuments.Count; i_dep++)
                            {
                                await EmployeeAppService.DependantPassportTravelDocumentsRepo.DeleteAsync(x => x.PassportTravelDocumentId == toDeleteDependantPassportTravelDocuments[i_dep]);
                            }
                            #endregion

                            dependant.FirstName = dependantRaw.FirstName;
                            dependant.FirstNameLocalized = dependantRaw.FirstNameLocalized;
                            dependant.LastName = dependantRaw.LastName;
                            dependant.MiddleName = dependantRaw.MiddleName;
                            dependant.LastName = dependantRaw.LastName;
                            dependant.BirthCountryId = dependantRaw.BirthCountryId;
                            dependant.DateOfBirth = dependantRaw.DateOfBirth;
                            dependant.PlaceOfBirth = dependantRaw.PlaceOfBirth;
                            dependant.BioAttachment = dependantRaw.BioAttachment;

                            var dep = await EmployeeAppService.DependantsRepo.UpdateAsync(dependant);
                        }
                    }
                    //Appending Deleted
                    for (int i = 0; i < toDeleteDependants.Count; i++)
                    {
                        await EmployeeAppService.DependantsRepo.DeleteAsync(x => x.Id == toDeleteDependants[i]);
                    }
                    #endregion

                    #region Employee EmployeeBenefits
                    //Getting New
                    Benefit_Dto[] employeeBenefits = employee.EmployeeBenefits.ToArray();
                    //Getting Current
                    int[] curEmployeeBenefitsIds = toUpdate.EmployeeBenefits != null && toUpdate.EmployeeBenefits.Count > 0 ? toUpdate.EmployeeBenefits.Select(x => x.Id).ToArray() : new int[0];
                    List<int> toDeleteEmployeeBenefits = new List<int>();
                    //Removing Removed
                    for (int i = 0; i < curEmployeeBenefitsIds.Length; i++)
                    {
                        //Benefit curBenefit = toUpdate.EmployeeBenefits.First(x => x.Id == curEmployeeBenefitsIds[i]);
                        if (!employeeBenefits.Any(x => x.Id == curEmployeeBenefitsIds[i]))
                        {
                            toUpdate.EmployeeBenefits.Remove(toUpdate.EmployeeBenefits.First(x => x.Id == curEmployeeBenefitsIds[i]));
                            toDeleteEmployeeBenefits.Add(curEmployeeBenefitsIds[i]);
                        }
                    }
                    //Adding & Updating New
                    for (int i = 0; i < employeeBenefits.Length; i++)
                    {
                        if (!toUpdate.EmployeeBenefits.Any(x => x.Id == employeeBenefits[i].Id))
                        {
                            toUpdate.EmployeeBenefits.Add(ObjectMapper.Map<Benefit_Dto, Benefit>(employeeBenefits[i]));
                        }
                        else
                        {
                            var benefitRaw = employee.EmployeeBenefits.First(x => x.Id == employeeBenefits[i].Id);
                            var benefit = toUpdate.EmployeeBenefits.First(x => x.Id == employeeBenefits[i].Id);

                            benefit.PayComponentId = benefitRaw.PayComponentId;
                            benefit.PayComponentComponentTypeAmount = benefitRaw.PayComponentComponentTypeAmount;
                            benefit.ValidityFromDate = benefitRaw.ValidityFromDate;
                            benefit.ValidityToDate = benefitRaw.ValidityToDate;

                            var benefitUpdated = await EmployeeAppService.BenefitsRepo.UpdateAsync(benefit);
                        }
                    }
                    //Appending Deleted
                    for (int i = 0; i < toDeleteEmployeeBenefits.Count; i++)
                    {
                        await EmployeeAppService.BenefitsRepo.DeleteAsync(x => x.Id == toDeleteEmployeeBenefits[i]);
                    }
                    #endregion

                    #region Academia Templates
                    //Getting New
                    EC_AcademiaTemplate_Dto[] academiaTemplates = employee.AcademiaProfile.ToArray();
                    //Getting Current
                    int[] curAcademiaProfileIds = toUpdate.AcademiaProfile != null && toUpdate.AcademiaProfile.Count > 0 ? toUpdate.AcademiaProfile.Select(x => x.Id).ToArray() : new int[0];
                    List<int> toDeleteAcademiaProfile = new List<int>();
                    //Removing Removed
                    for (int i = 0; i < curAcademiaProfileIds.Length; i++)
                    {
                        EC_AcademiaTemplate curContact = toUpdate.AcademiaProfile.First(x => x.Id == curAcademiaProfileIds[i]);
                        if (!academiaTemplates.Any(x => x.Id == curAcademiaProfileIds[i]))
                        {
                            toUpdate.AcademiaProfile.Remove(toUpdate.AcademiaProfile.First(x => x.Id == curAcademiaProfileIds[i]));
                            toDeleteAcademiaProfile.Add(curAcademiaProfileIds[i]);
                        }
                    }
                    //Adding & Updating New
                    for (int i = 0; i < academiaTemplates.Length; i++)
                    {
                        if (!toUpdate.AcademiaProfile.Any(x => x.Id == academiaTemplates[i].Id))
                        {
                            academiaTemplates[i].Id = 0;
                            toUpdate.AcademiaProfile.Add(ObjectMapper.Map<EC_AcademiaTemplate_Dto, EC_AcademiaTemplate>(academiaTemplates[i]));
                        }
                        else
                        {
                            var _academiaTemplateNew = academiaTemplates[i];
                            var _academiaTemplate = toUpdate.AcademiaProfile.First(x => x.Id == academiaTemplates[i].Id);

                            _academiaTemplate.Name = _academiaTemplateNew.Name;
                            _academiaTemplate.NameLocalized = _academiaTemplateNew.NameLocalized;
                            _academiaTemplate.InstituteId = _academiaTemplateNew.InstituteId;
                            _academiaTemplate.AcademicType = _academiaTemplateNew.AcademicType;
                            _academiaTemplate.AcademiaCertificateType = _academiaTemplateNew.AcademiaCertificateType;
                            _academiaTemplate.AcademiaCertificateSubTypeId = _academiaTemplateNew.AcademiaCertificateSubTypeId;
                            _academiaTemplate.Description = _academiaTemplateNew.Description;
                            _academiaTemplate.PassoutYear = _academiaTemplateNew.PassoutYear;

                            await EmployeeAppService.EC_AcademiaTemplatesRepo.UpdateAsync(_academiaTemplate);
                        }
                    }
                    //Appending Deleted
                    for (int i = 0; i < toDeleteAcademiaProfile.Count; i++)
                    {
                        await EmployeeAppService.EC_AcademiaTemplatesRepo.DeleteAsync(x => x.Id == toDeleteAcademiaProfile[i]);
                    }
                    #endregion
                    #region Skills Templates
                    //Getting New
                    EC_SkillTemplate_Dto[] skillsTemplates = employee.SkillsProfile.ToArray();
                    //Getting Current
                    int[] curSkillsProfileIds = toUpdate.SkillsProfile != null && toUpdate.SkillsProfile.Count > 0 ? toUpdate.SkillsProfile.Select(x => x.Id).ToArray() : new int[0];
                    List<int> toDeleteSkillsProfile = new List<int>();
                    //Removing Removed
                    for (int i = 0; i < curSkillsProfileIds.Length; i++)
                    {
                        //EC_SkillTemplate curContact = toUpdate.SkillsProfile.First(x => x.Id == curSkillsProfileIds[i]);
                        if (!skillsTemplates.Any(x => x.Id == curSkillsProfileIds[i]))
                        {
                            toUpdate.SkillsProfile.Remove(toUpdate.SkillsProfile.First(x => x.Id == curSkillsProfileIds[i]));
                            toDeleteSkillsProfile.Add(curSkillsProfileIds[i]);
                        }
                    }
                    //Adding & Updating New
                    for (int i = 0; i < skillsTemplates.Length; i++)
                    {
                        if (!toUpdate.SkillsProfile.Any(x => x.Id == skillsTemplates[i].Id))
                        {
                            skillsTemplates[i].Id = 0;
                            toUpdate.SkillsProfile.Add(ObjectMapper.Map<EC_SkillTemplate_Dto, EC_SkillTemplate>(skillsTemplates[i]));
                        }
                        else
                        {
                            var _skillTemplateNew = skillsTemplates[i];
                            var _skillTemplate = toUpdate.SkillsProfile.First(x => x.Id == skillsTemplates[i].Id);

                            _skillTemplate.SkillAquisitionType = _skillTemplateNew.SkillAquisitionType;
                            _skillTemplate.SkillType = _skillTemplateNew.SkillType;
                            _skillTemplate.SkillSubTypeId = _skillTemplateNew.SkillSubTypeId;
                            _skillTemplate.Description = _skillTemplateNew.Description;
                            _skillTemplate.DoesKPI = _skillTemplateNew.DoesKPI;

                            await EmployeeAppService.EC_SkillTemplatesRepo.UpdateAsync(_skillTemplate);
                        }
                    }
                    //Appending Deleted
                    for (int i = 0; i < toDeleteSkillsProfile.Count; i++)
                    {
                        await EmployeeAppService.EC_SkillTemplatesRepo.DeleteAsync(x => x.Id == toDeleteSkillsProfile[i]);
                    }
                    #endregion

                    #region Employee Loans
                    //Getting New
                    EmployeeLoan_Dto[] loans = employee.EmployeeLoans.ToArray();
                    //Getting Current
                    int[] curEmployeeLoansIds = toUpdate.EmployeeLoans != null && toUpdate.EmployeeLoans.Count > 0 ? toUpdate.EmployeeLoans.Select(x => x.Id).ToArray() : new int[0];
                    List<int> toDeleteEmployeeLoans = new List<int>();
                    //Removing Removed
                    for (int i = 0; i < curEmployeeLoansIds.Length; i++)
                    {
                        //EmployeeLoan curContact = toUpdate.EmployeeLoans.First(x => x.Id == curEmployeeLoansIds[i]);
                        if (!loans.Any(x => x.Id == curEmployeeLoansIds[i]))
                        {
                            toUpdate.EmployeeLoans.Remove(toUpdate.EmployeeLoans.First(x => x.Id == curEmployeeLoansIds[i]));
                            toDeleteEmployeeLoans.Add(curEmployeeLoansIds[i]);
                        }
                    }
                    //Adding & Updating New
                    for (int i = 0; i < loans.Length; i++)
                    {
                        if (!toUpdate.EmployeeLoans.Any(x => x.Id == loans[i].Id))
                        {
                            loans[i].Id = 0;
                            toUpdate.EmployeeLoans.Add(ObjectMapper.Map<EmployeeLoan_Dto, EmployeeLoan>(loans[i]));
                        }
                        else
                        {
                            var _employeeLoanNew = loans[i];
                            var _employeeLoan = toUpdate.EmployeeLoans.First(x => x.Id == loans[i].Id);

                            _employeeLoan.LoanTypeId = _employeeLoanNew.LoanTypeId;
                            _employeeLoan.LoanStatus = _employeeLoanNew.LoanStatus;
                            _employeeLoan.Name = _employeeLoanNew.Name;
                            _employeeLoan.Amount = _employeeLoanNew.Amount;
                            _employeeLoan.ValidityFromDate = _employeeLoanNew.ValidityFromDate;
                            _employeeLoan.ValidityToDate = _employeeLoanNew.ValidityToDate;

                            await EmployeeAppService.EmployeeLoansRepo.UpdateAsync(_employeeLoan);
                        }
                    }
                    //Appending Deleted
                    for (int i = 0; i < toDeleteEmployeeLoans.Count; i++)
                    {
                        await EmployeeAppService.EC_SkillTemplatesRepo.DeleteAsync(x => x.Id == toDeleteEmployeeLoans[i]);
                    }
                    #endregion
                    #endregion

                    Employee updated = await EmployeeAppService.Repository.UpdateAsync(toUpdate); 
                    var _updated = ObjectMapper.Map<Employee, Employee_Dto>(await EmployeeAppService.Repository.GetAsync(toUpdate.Id));
                }
                else
                {
                    employee.Id = Guid.Empty;

                    if (employee.NationalIdentities != null)
                        employee.NationalIdentities.ForEach(x => { x.Id = 0; x.NationalIdentity.Id = 0; x.NationalIdentityId = x.NationalIdentity.Id; });
                    if (employee.PassportTravelDocuments != null)
                        employee.PassportTravelDocuments.ForEach(x => { x.Id = 0; x.PassportTravelDocument.Id = 0; x.PassportTravelDocumentId = x.PassportTravelDocument.Id; });

                    if (employee.EmailAddresses != null)
                    employee.EmailAddresses.ForEach(x => { x.Id = 0; x.EmailAddress.Id = 0; x.EmailAddressId = x.EmailAddress.Id; });
                    if (employee.PhoneAddresses != null)
                    employee.PhoneAddresses.ForEach(x => { x.Id = 0; x.PhoneAddress.Id = 0; x.PhoneAddressId = x.PhoneAddress.Id; });
                    if (employee.HomeAddresses != null)
                    employee.HomeAddresses.ForEach(x => { x.Id = 0; x.HomeAddress.Id = 0; x.HomeAddressId = x.HomeAddress.Id; });
                    if (employee.Contacts != null)
                    employee.Contacts.ForEach(x => { x.Id = 0; x.Contact.Id = 0; x.ContactId = x.Contact.Id; });

                     if (employee.Dependants != null)
                    employee.Dependants.ForEach(x => { x.Id = 0; x.NationalIdentities.ForEach(y => { y.Id = 0; y.NationalIdentity.Id = 0; y.NationalIdentityId = 0; });  x.PassportTravelDocuments.ForEach(y => { y.Id = 0; y.PassportTravelDocument.Id = 0; y.PassportTravelDocumentId = 0; }); });

                    if (employee.EmployeeBenefits != null)
                        employee.EmployeeBenefits.ForEach(x => { x.Id = 0; });
                    
                    if (employee.EmployeeLoans != null)
                        employee.EmployeeLoans.ForEach(x => { x.Id = 0; });
                    
                    if (employee.CashPaymentTypes != null)
                        employee.CashPaymentTypes.ForEach(x => { x.Id = 0; });
                    if (employee.ChequePaymentTypes != null)
                        employee.ChequePaymentTypes.ForEach(x => { x.Id = 0; });
                    if (employee.BankPaymentTypes != null)
                         employee.BankPaymentTypes.ForEach(x => { x.Id = 0; });

                    if (employee.AcademiaProfile != null)
                        employee.AcademiaProfile.ForEach(x => { x.Id = 0; });
                    if (employee.SkillsProfile != null)
                        employee.SkillsProfile.ForEach(x => { x.Id = 0; });

                    employee.OrganizationStructureTemplateDepartment = null;

                    employee.Gender = null;
                    employee.MaritalStatus = null;
                    employee.PreferredLanguage = null;
                    employee.Nationality = null;
                    employee.BirthCountry = null;
                    employee.CostCenter = null;
                    employee.PayGroup = null;
                    employee.PayGrade = null;
                    employee.Timezone = null;
                    employee.Portal = null;

                    Employee_Dto added = await EmployeeAppService.CreateAsync(employee);

                    Employee toUpdate = EmployeeAppService.Repository
                        .Include(x => x.NationalIdentities)
                        .ThenInclude(x => x.NationalIdentity)
                        .Include(x => x.PassportTravelDocuments)
                        .ThenInclude(x => x.PassportTravelDocument)
                        .Include(x => x.Dependants)
                        .ThenInclude(x => x.NationalIdentities)
                        .ThenInclude(x => x.NationalIdentity)
                        .Include(x => x.Dependants)
                        .ThenInclude(x => x.PassportTravelDocuments)
                        .ThenInclude(x => x.PassportTravelDocument)
                        .First(x => x.Id == added.Id);

                    toUpdate.OrganizationStructureTemplateDepartment = null;

                    toUpdate.Gender = null;
                    toUpdate.MaritalStatus = null;
                    toUpdate.PreferredLanguage = null;
                    toUpdate.Nationality = null;
                    toUpdate.BirthCountry = null;
                    toUpdate.CostCenter = null;
                    toUpdate.PayGroup = null;
                    toUpdate.PayGrade = null;
                    toUpdate.Timezone = null;
                    toUpdate.Portal = null;

                    if (FormData.Files.Count > 0)
                    {
                        if (FormData.Files.Any(x => x.Name == "ProfilePicture"))
                        {
                            IFormFile formFile = FormData.Files.First(x => x.Name == "ProfilePicture");

                            string uploadedFileName = UploadedFile(formFile, $"Profile", EMPLOYEE_GENERAL_PATH);
                            toUpdate.ProfilePic = uploadedFileName;
                        }
                        if (FormData.Files.Any(x => x.Name == "BioAttachment"))
                        {
                            IFormFile formFile = FormData.Files.First(x => x.Name == "BioAttachment");

                            string uploadedFileName = UploadedFile(formFile, $"BIO", EMPLOYEE_GENERAL_PATH);
                            toUpdate.BioAttachment = uploadedFileName;
                        }

                        for (int i = 0; i < toUpdate.NationalIdentities.Count; i++)
                        {
                            EmployeeNationalIdentity_Dto curIdentityRaw = employeeRaw.NationalIdentities[i];
                            EmployeeNationalIdentity curIdentity = toUpdate.NationalIdentities.ElementAt(i);
                            string attachName = $"ENatId_{curIdentityRaw.NationalIdentity.Id}_Attachment";

                            if (FormData.Files.Any(x => x.Name.Contains(attachName)))
                            {
                                IFormFile formFile = FormData.Files.First(x => x.Name == attachName);

                                string uploadedFileName = UploadedFile(formFile, $"{toUpdate.Id}NATID{curIdentity.NationalIdentityId}", EMPLOYEE_NATID_PATH);
                                curIdentity.NationalIdentity.IDAttachment = uploadedFileName;
                            }
                        }
                        for (int i = 0; i < toUpdate.PassportTravelDocuments.Count; i++)
                        {
                            EmployeePassportTravelDocument_Dto curIdentityRaw = employeeRaw.PassportTravelDocuments[i];
                            EmployeePassportTravelDocument curIdentity = toUpdate.PassportTravelDocuments.ElementAt(i);
                            string attachName = $"EPTD_{curIdentityRaw.PassportTravelDocument.Id}_Attachment";

                            if (FormData.Files.Any(x => x.Name.Contains(attachName)))
                            {
                                IFormFile formFile = FormData.Files.First(x => x.Name == attachName);

                                string uploadedFileName = UploadedFile(formFile, $"{toUpdate.Id}PTD{curIdentity.PassportTravelDocumentId}", EMPLOYEE_PTD_PATH);
                                curIdentity.PassportTravelDocument.DocumentAttachment = uploadedFileName;
                            }
                        }

                        for (int y = 0; y < toUpdate.Dependants.Count; y++)
                        {
                            Dependant_Dto curDependantRaw = employeeRaw.Dependants[y];
                            Dependant curDependant = toUpdate.Dependants.ElementAt(y);

                            for (int i = 0; i < curDependant.NationalIdentities.Count; i++)
                            {
                                DependantNationalIdentity_Dto curIdentityRaw = curDependantRaw.NationalIdentities[i];
                                DependantNationalIdentity curIdentity = curDependant.NationalIdentities.ElementAt(i);
                                string attachName = $"DNatId_{curDependantRaw.Id}_{curIdentityRaw.NationalIdentity.Id}_Attachment";

                                if (FormData.Files.Any(x => x.Name.Contains(attachName)))
                                {
                                    IFormFile formFile = FormData.Files.First(x => x.Name == attachName);

                                    string uploadedFileName = UploadedFile(formFile, $"{toUpdate.Id}DEP{curDependant.Id}NATID{curIdentity.NationalIdentityId}", EMPLOYEE_DEPENDANT_NATID_PATH);
                                    curIdentity.NationalIdentity.IDAttachment = uploadedFileName;
                                }
                            }
                            for (int i = 0; i < curDependant.PassportTravelDocuments.Count; i++)
                            {
                                DependantPassportTravelDocument_Dto curIdentityRaw = curDependantRaw.PassportTravelDocuments[i];
                                DependantPassportTravelDocument curIdentity = curDependant.PassportTravelDocuments.ElementAt(i);
                                string attachName = $"DPTD_{curDependantRaw.Id}_{curIdentityRaw.PassportTravelDocument.Id}_Attachment";

                                if (FormData.Files.Any(x => x.Name.Contains(attachName)))
                                {
                                    IFormFile formFile = FormData.Files.First(x => x.Name == attachName);

                                    string uploadedFileName = UploadedFile(formFile, $"{toUpdate.Id}DEP{curDependant.Id}PTD{curIdentity.PassportTravelDocumentId}", EMPLOYEE_DEPENDANT_PTD_PATH);
                                    curIdentity.PassportTravelDocument.DocumentAttachment = uploadedFileName;
                                }
                            }
                        }
                    }

                    Employee updated = await EmployeeAppService.Repository.UpdateAsync(toUpdate);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

            return NoContent();
        }

        private string UploadedFile(IFormFile file, string Name = "", string path = "Uploads", bool _override = false)
        
        {   
            
            string uniqueFileName = Name + Path.GetExtension(file.FileName);
            //return uniqueFileName;
            string filePath = uniqueFileName;
            if (file != null)
            {
                string uploadPath = webHostEnvironment.WebRootPath + "/" + path;
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                if (uniqueFileName == "" || (!_override && System.IO.File.Exists(uploadPath + "/" + uniqueFileName + Path.GetExtension(file.FileName))))
                {
                    uniqueFileName = ((new Random()).Next(1, 9) * (new Random()).Next(10000, 900000)).ToString() + Path.GetExtension(file.FileName);
                }
                filePath = Path.Combine(uploadPath, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return path + "/" + uniqueFileName;
        }
    }
}
