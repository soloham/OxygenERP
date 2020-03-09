using CERP.App;
using Newtonsoft.Json;
using Syncfusion.EJ2.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace CERP.HR.EMPLOYEE.RougeDTOs
{
    public class FinancialDetails
    {
        public FinancialDetails(IList<BasicSalaryRDTO> basicSalaries, IList<AllowanceRDTO> allowancesDetails, IList<BanksRDTO> banks)
        {
            BasicSalaries = basicSalaries;
            AllowancesDetails = allowancesDetails;
            Banks = banks;
        }

        public IList<BasicSalaryRDTO> BasicSalaries { get; set; }
        public IList<AllowanceRDTO> AllowancesDetails { get; set; }
        public IList<BanksRDTO> Banks { get; set; }

        internal void Initialize(IRepository<DictionaryValue, Guid> dictionaryValuesRepo)
        {
            Banks.ForEach(x => x.Banks = dictionaryValuesRepo);
            AllowancesDetails.ForEach(x => x.Allowances = dictionaryValuesRepo);
        }
    }

    public class BasicSalaryRDTO
    {
        public BasicSalaryRDTO()
        {

        }

        public int Id { get; set; }
        public double Salary { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
    public class AllowanceRDTO
    {
        [JsonIgnore]
        public IRepository<DictionaryValue, Guid> Allowances;

        public int Id { get; set; }
        [JsonIgnore]
        private string allowanceName;
        public string GetAllowanceTypeName
        {
            get
            {
                try
                {
                    if (AllowanceTypeId != null && AllowanceTypeId != Guid.Empty)
                    {
                        allowanceName = Allowances.First(x => x.Id == AllowanceTypeId).Value;
                    }
                }
                catch { }

                return allowanceName;
            }
            set { allowanceName = value; }
        }
        public Guid AllowanceTypeId { get; set; }
        public double PercBasicSalary { get; set; }
        public double Amount { get; set; }
        public string FromDate { get; set; }
        //public string BasicSalaryFromHDate { get; set; }
        public string EndDate { get; set; }
        //public string? EndDate { get; set; }
    }
    public class BanksRDTO
    {
        [JsonIgnore]
        public IRepository<DictionaryValue, Guid> Banks;

        public int Id { get; set; }
        [JsonIgnore]
        private string bankName;
        public string GetBankName { 
            get 
            {
                try
                {
                    if (BankId != null && BankId != Guid.Empty)
                    {
                        bankName = Banks.First(x => x.Id == BankId).Value;
                    }

                }
                catch { }
                return bankName;
            } 
            set { bankName = value; } 
        }
        public Guid BankId { get; set; }
        public string AccountTitle { get; set; }
        public string AccountNumber { get; set; }
        public string BankIBAN { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
