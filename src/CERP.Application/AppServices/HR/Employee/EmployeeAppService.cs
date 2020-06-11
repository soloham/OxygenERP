using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using CERP.HR.EmployeeCentral.Employee;
using Volo.Abp.Application.Dtos;
using CERP.HR.EmployeeCentral.DTOs.Employee;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CERP.HR.Documents;

namespace CERP.AppServices.HR.EmployeeService
{
    public class EmployeeAppService : CrudAppService<Employee, Employee_Dto, Guid, PagedAndSortedResultRequestDto, Employee_Dto, Employee_Dto>
    {
        public EmployeeAppService(IRepository<Employee, Guid> repository, IRepository<EmployeePrimaryValidityAttachment> employeeNationalIdentitiesRepo, IRepository<EmployeePassportTravelDocument> employeePassportTravelDocumentsRepo, IRepository<Dependant> dependantsRepo, IRepository<EmployeeEmailAddress> employeeEmailAddressesRepo, IRepository<EmployeePhoneAddress> employeePhoneAddressesRepo, IRepository<EmployeeHomeAddress> employeeHomeAddressesRepo, IRepository<EmployeeContact> employeeContactsRepo, IRepository<Benefit> benefitsRepo, IRepository<CashPaymentType> cashPaymentTypesRepo, IRepository<ChequePaymentType> chequePaymentTypesRepo, IRepository<BankPaymentType> bankPaymentTypesRepo, IRepository<EC_AcademiaTemplate> eC_AcademiaTemplatesRepo, IRepository<EC_SkillTemplate> eC_SkillTemplatesRepo, IRepository<EmployeeLoan> employeeLoansRepo, IRepository<DependantPassportTravelDocument> dependantPassportTravelDocumentsRepo, IRepository<DependantNationalIdentity> dependantNationalIdentitiesRepo, IRepository<NationalIdentity> nationalIdentitiesRepo, IRepository<PassportTravelDocument> passportTravelDocumentsRepo, IRepository<EmailAddress> emailAddressesRepo, IRepository<PhoneAddress> phoneAddressesRepo, IRepository<HomeAddress> homeAddressesRepo, IRepository<Contact> contactsRepo, IRepository<EmployeeDisability> employeeDisabilitiesRepo, IRepository<Disability> disabilitiesRepo, IRepository<PrimaryValidityAttachment> primaryValidityAttachmentsRepo, IRepository<EmployeeSponsorLegalEntity> employeeSponsorLegalEntitysRepo, IRepository<EmployeePrimaryValidityAttachment> employeePrimaryValidityAttachmentsRepo) : base(repository)
        {
            Repository = repository;
            EmployeePrimaryValidityAttachmentsRepo = employeeNationalIdentitiesRepo;
            EmployeePassportTravelDocumentsRepo = employeePassportTravelDocumentsRepo;
            DependantsRepo = dependantsRepo;
            EmployeeEmailAddressesRepo = employeeEmailAddressesRepo;
            EmployeePhoneAddressesRepo = employeePhoneAddressesRepo;
            EmployeeHomeAddressesRepo = employeeHomeAddressesRepo;
            EmployeeContactsRepo = employeeContactsRepo;
            BenefitsRepo = benefitsRepo;
            CashPaymentTypesRepo = cashPaymentTypesRepo;
            ChequePaymentTypesRepo = chequePaymentTypesRepo;
            BankPaymentTypesRepo = bankPaymentTypesRepo;
            EC_AcademiaTemplatesRepo = eC_AcademiaTemplatesRepo;
            EC_SkillTemplatesRepo = eC_SkillTemplatesRepo;
            EmployeeLoansRepo = employeeLoansRepo;
            DependantPassportTravelDocumentsRepo = dependantPassportTravelDocumentsRepo;
            DependantNationalIdentitiesRepo = dependantNationalIdentitiesRepo;
            NationalIdentitiesRepo = nationalIdentitiesRepo;
            PassportTravelDocumentsRepo = passportTravelDocumentsRepo;
            EmailAddressesRepo = emailAddressesRepo;
            PhoneAddressesRepo = phoneAddressesRepo;
            HomeAddressesRepo = homeAddressesRepo;
            ContactsRepo = contactsRepo;
            EmployeeDisabilitiesRepo = employeeDisabilitiesRepo;
            DisabilitiesRepo = disabilitiesRepo;
            PrimaryValidityAttachmentsRepo = primaryValidityAttachmentsRepo;
            EmployeeSponsorLegalEntitysRepo = employeeSponsorLegalEntitysRepo;
            EmployeePrimaryValidityAttachmentsRepo = employeePrimaryValidityAttachmentsRepo;
        }

        public IRepository<Employee, Guid> Repository { get; }

        public IRepository<EmployeeDisability> EmployeeDisabilitiesRepo { get; }
        public IRepository<Disability> DisabilitiesRepo { get; }

        public IRepository<PrimaryValidityAttachment> PrimaryValidityAttachmentsRepo { get; }

        public IRepository<NationalIdentity> NationalIdentitiesRepo { get; }
        public IRepository<PassportTravelDocument> PassportTravelDocumentsRepo { get; }
        public IRepository<EmployeePrimaryValidityAttachment> EmployeePrimaryValidityAttachmentsRepo { get; }
        public IRepository<EmployeeSponsorLegalEntity> EmployeeSponsorLegalEntitysRepo { get; }
        public IRepository<EmployeePassportTravelDocument> EmployeePassportTravelDocumentsRepo { get; }
        public IRepository<Dependant> DependantsRepo { get; }
        public IRepository<DependantPassportTravelDocument> DependantPassportTravelDocumentsRepo { get; }
        public IRepository<DependantNationalIdentity> DependantNationalIdentitiesRepo { get; }
        public IRepository<EmailAddress> EmailAddressesRepo { get; }
        public IRepository<PhoneAddress> PhoneAddressesRepo { get; }
        public IRepository<HomeAddress> HomeAddressesRepo { get; }
        public IRepository<Contact> ContactsRepo { get; }
        public IRepository<EmployeeEmailAddress> EmployeeEmailAddressesRepo { get; }
        public IRepository<EmployeePhoneAddress> EmployeePhoneAddressesRepo { get; }
        public IRepository<EmployeeHomeAddress> EmployeeHomeAddressesRepo { get; }
        public IRepository<EmployeeContact> EmployeeContactsRepo { get; }
        public IRepository<Benefit> BenefitsRepo { get; }
        public IRepository<CashPaymentType> CashPaymentTypesRepo { get; }
        public IRepository<ChequePaymentType> ChequePaymentTypesRepo { get; }
        public IRepository<BankPaymentType> BankPaymentTypesRepo { get; }
        public IRepository<EC_AcademiaTemplate> EC_AcademiaTemplatesRepo { get; }
        public IRepository<EC_SkillTemplate> EC_SkillTemplatesRepo { get; }
        public IRepository<EmployeeLoan> EmployeeLoansRepo { get; }

        public async Task<Employee_Dto> CreateEmployee(Employee_Dto employeee)
        {
            try
            {
                Employee employee = MapToEntity(employeee);

                Employee_Dto dto = MapToGetOutputDto(await Repository.InsertAsync(employee));
                return dto;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Employee_Dto>> GetAllEmployeesForEC() 
        {
            List<Employee_Dto> employees = null;
            try
            {
                employees = await Task.Run(() =>
                    Repository
                        .Include(p => p.Gender)
                        .Include(p => p.MaritalStatus)
                        .Include(p => p.PreferredLanguage)
                        .Include(p => p.Nationality)
                        .Include(p => p.BirthCountry)
                        .Include(p => p.CostCenter)
                        .Include(p => p.PayGroup)
                        .Include(p => p.PayGrade)
                        .Include(p => p.Timezone)
                        .Include(p => p.EmployeeSubGroup)
                        .Include(p => p.EmployeeGroup)
                        .Include(p => p.EmploymentType)
                        //.Include(p => p.OrganizationStructureTemplateDepartment)
                        .Include(p => p.Portal)

                        .Select(MapToGetOutputDto).ToList()
                    );
            }
            catch(Exception ex)
            {

            }
            return employees;
        }
        public async Task<Employee_Dto> GetFullEmployee(Guid Id, int concurrency = 1) 
        {
            Employee_Dto employee = null;
            try
            {
                if (concurrency == 1)
                {
                    Employee entity = await Task.Run(() => Repository
                    .Include(x => x.NationalIdentities)
                         .ThenInclude(x => x.PrimaryValidityAttachments)
                     .Include(x => x.PassportTravelDocuments)
                         .ThenInclude(x => x.PassportTravelDocument)

                     .Include(x => x.EmployeeDisabilities)
                        .ThenInclude(x => x.Disability)

                     .Include(x => x.EmployeeSponsorLegalEntities)

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
                        .ThenInclude(x => x.PayComponent)

                     .Include(x => x.CashPaymentTypes)
                        .ThenInclude(x => x.CollectionLocation)
                     .Include(x => x.ChequePaymentTypes)
                     .Include(x => x.BankPaymentTypes)

                     .Include(x => x.AcademiaProfile)
                        .ThenInclude(x => x.AcademiaCertificateSubType)
                     .Include(x => x.SkillsProfile)
                        .ThenInclude(x => x.SkillSubType)

                     .Include(x => x.EmployeeLoans)
                     .First(x => x.Id == Id));
                    employee = base.MapToGetOutputDto(entity);
                }
                else
                {
                    Employee entity = await Task.Run(() => Repository
                     .Include(x => x.Dependants)
                         .ThenInclude(x => x.NationalIdentities)
                         .ThenInclude(x => x.NationalIdentity)
                     .Include(x => x.Dependants)
                         .ThenInclude(x => x.PassportTravelDocuments)
                         .ThenInclude(x => x.PassportTravelDocument)
                     .Include(x => x.Dependants)

                     .Include(x => x.IqamaNumberValidities)
                         .ThenInclude(x => x.PrimaryValidityAttachments)
                     .Include(x => x.IqamaLabourOfficeValidities)
                         .ThenInclude(x => x.PrimaryValidityAttachments)
                     .First(x => x.Id == Id));
                    employee = base.MapToGetOutputDto(entity);
                }
            }
            catch(Exception ex)
            {

            }
            return employee;
        }
        
        public async Task<Employee_Dto> GetEmployee(Guid Id, bool withDetails = false) 
        {
            Employee_Dto employee = null;
            try
            {
                Employee entity = await Repository.GetAsync(Id, withDetails);
                employee = base.MapToGetOutputDto(entity);
            }
            catch(Exception ex)
            {

            }
            return employee;
        }

        public async Task<List<Employee_Dto>> GetAllEmployees(bool withDetails = false) 
        { 
            var result = await Repository.GetListAsync(withDetails);
            return result.Select(MapToGetListOutputDto).ToList();
        }
        public List<Employee_Dto> GetEmployeesByPositionId(Guid positionId, params System.Linq.Expressions.Expression<Func<Employee, object>>[] details)
        {
            //var result = Repository.WithDetails(details).Where(x => x.PositionId == positionId);
            //return result.Select(MapToGetListOutputDto).ToList();
            return new List<Employee_Dto>();
        }

    }
}
