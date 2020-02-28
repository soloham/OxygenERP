using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CERP.FM.COA;
using CERP.FM.COA.DTOs;
using CERP.Web.Pages;
using Syncfusion.EJ2.Grids;

namespace CERP.Web.Areas.FM.COA
{
    public class ListModel : CERPPageModel
    {
        private readonly coaAppService _coaAppService;
        public ListModel(coaAppService coaAppService)
        {
            _coaAppService = coaAppService;
        }

        public async void OnGet()
        {
            List<COA_Account_Dto> COAs = await GetListOfAccountsAsync();

            ViewData["COAs_DS"] = COAs;
            ViewData["alertbutton"] = new
            {
                content = "OK",
                isPrimary = true
            };
        }

        public List<GridColumn> GetAccountColumns()
        {
            return new List<GridColumn>()
           {
               new GridColumn { Field = "AccountCode", Width = "130", HeaderText = "Account Code", TextAlign= TextAlign.Center, MinWidth="10"  },
               new GridColumn { Field = "AccountName", Width = "135", HeaderText = "Account Name",  TextAlign= TextAlign.Center,  MinWidth="10"  }
           };
        }
        public List<GridColumn> GetClassificationColumns()
        {
            return new List<GridColumn>()
            {
                new GridColumn { Field = "CompanyCode", Width = "80", HeaderText = "Company Code", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "HeadAccount", Width = "150", HeaderText = "Head Account", TextAlign=TextAlign.Center, MinWidth="10"  },
                new GridColumn { Field = "SubCategory", Width = "150", HeaderText = "Sub Category", TextAlign=TextAlign.Center, MinWidth="10"  },
                new GridColumn { Field = "CashflowStatement", Width = "150", HeaderText = "Cashflow Statement", TextAlign=TextAlign.Center, MinWidth="10"  }
            };
        }
        public List<GridColumn> GetAttributesColumns()
        {
            return new List<GridColumn>()
            {
                new GridColumn { DisplayAsCheckBox = true, Field = "Posting", Width = "80", HeaderText = "Posting", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { DisplayAsCheckBox = true, Field = "Payment", Width = "150", HeaderText = "Payment", TextAlign=TextAlign.Center, MinWidth="10"  },
                new GridColumn { DisplayAsCheckBox = true, Field = "Receipt", Width = "150", HeaderText = "Receipt", TextAlign=TextAlign.Center, MinWidth="10"  },
            };
        }
        public List<GridColumn> GetSubLedgersColumns()
        {
            return new List<GridColumn>()
            {
                new GridColumn { Field = "Employee", Width = "80", HeaderText = "Emp.", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "Dept.", Width = "150", HeaderText = "Dept.", TextAlign=TextAlign.Center, MinWidth="10"  },
                new GridColumn { Field = "Project", Width = "150", HeaderText = "Project", TextAlign=TextAlign.Center, MinWidth="10"  },
                new GridColumn { Field = "FA", Width = "150", HeaderText = "FA", TextAlign=TextAlign.Center, MinWidth="10"  },
                new GridColumn { Field = "Vendor", Width = "150", HeaderText = "Vendor", TextAlign=TextAlign.Center, MinWidth="10"  },
                new GridColumn { Field = "Customer", Width = "150", HeaderText = "Customer", TextAlign=TextAlign.Center, MinWidth="10"  }
            };
        }


        public async Task<List<COA_Account_Dto>> GetListOfAccountsAsync()
        {
            List<COA_Account_Dto> accounts = new List<COA_Account_Dto>();
            var result = await _coaAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto() { MaxResultCount = 10 });
            for (int i = 0; i < result.TotalCount; i++)
            {
                COA_Account_Dto curDto = result.Items[i];
                Console.WriteLine(curDto.AccountName);
            }
            //int code = 10000;
            //for (int i = 1; i < 10; i++)
            //{
            //    accounts.Add(new AccountsDetails(code, $"1-101001.000", "Banks", 1 + "", "Assets", "Current Assets", "", true, true, true, "Test", "IT", "Kirchgasse 6", "", "", ""));
            //    accounts.Add(new AccountsDetails(code, $"1-101001.001", "Local Banks", 1 + "", "Assets", "Current Assets", "", false, true, false, "Test 2", "RD", "Avda.", "", "", ""));
            //    accounts.Add(new AccountsDetails(code, $"1-101001.002", "International Banks", 1 + "", "Assets", "Current Assets", "", true, true, true, "Test 3", "Salesforce", "Carrera", "", "", ""));
            //    accounts.Add(new AccountsDetails(code, $"1-101001.003", "Regional Banks", 1 + "", "Assets", "Current Assets", "", true, true, false, "Test 6", "IT", "Magazinweg 7", "", "", ""));
            //    accounts.Add(new AccountsDetails(code, $"1-101001.000", "Cash", 1 + "", "Assets", "Current Assets", "", false, true, true, "Tesst 8", "RUD", "1029 - 12th Ave. S.", "", "", ""));
            //    code += 5;
            //}

            return accounts;
        }

        public class AccountsDetails
        {
            public AccountsDetails()
            {

            }
            public AccountsDetails(int accountID, string accountCode, string accountName, string companyCode, string headAccount, string subCategory, string cashflowStatement, bool posting, bool payment, bool receipt, string employee, string department, string project, string fA, string vendor, string customer)
            {
                AccountID = accountID;
                AccountCode = accountCode;
                AccountName = accountName;
                CompanyCode = companyCode;
                HeadAccount = headAccount;
                SubCategory = subCategory;
                CashflowStatement = cashflowStatement;
                Posting = posting;
                Payment = payment;
                Receipt = receipt;
                Employee = employee;
                Department = department;
                Project = project;
                FA = fA;
                Vendor = vendor;
                Customer = customer;
            }

            

            public int AccountID { get; set; }
            public string AccountCode { get; set; }
            public string AccountName { get; set; }

            public string CompanyCode { get; set; }
            public string HeadAccount { get; set; }
            public string SubCategory { get; set; }
            public string CashflowStatement { get; set; }

            public bool Posting { get; set; }
            public bool Payment { get; set; }
            public bool Receipt { get; set; }

            public string Employee { get; set; }
            public string Department { get; set; }
            public string Project { get; set; }
            public string FA { get; set; }
            public string Vendor { get; set; }
            public string Customer { get; set; }
        }
    }
}
