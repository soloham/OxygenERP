using System;
using System.Collections.Generic;
using System.Linq;
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
        public Grid PrimaryDetailsGrid = new Grid();
        public Grid SecondaryDetailsGrid = new Grid();
        public ListModel(coaAppService coaAppService)
        {
            _coaAppService = coaAppService;
        }

        public async Task OnGetEditAccount(string Guid_)
        {
            Guid id = Guid.Parse(Guid_);
        }
        public void OnGet()
        {
            List<COA_Account_Dto> COAs = _coaAppService.GetChartOfAccounts();

            //TempData["AGUID"] = COAs.First().Id;

            PrimaryDetailsGrid = new Grid()
            {
                DataSource = COAs,
                QueryString = "Id",
                EditSettings = new Syncfusion.EJ2.Grids.GridEditSettings() { },
                Toolbar = new List<string>() { "Add", "Edit", "Delete", "Update", "Delete", "Group" },
                Columns = GetPrimaryGridColumns()

            };
            SecondaryDetailsGrid = new Grid()
            {
                DataSource = COAs,
                QueryString = "Id",
                EditSettings = new Syncfusion.EJ2.Grids.GridEditSettings() {},
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
                Columns = GetSecondaryGridColumns()

            };
            //List<COA_Account_Dto> COAs = (await _coaAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto())).Items.ToList();

            foreach (var item in COAs)
            {
                bool AddressBook = false;
                bool FA = false;
                bool Customer = false;

                AddressBook = item.SubLedgerRequirementAccounts.Any(x => x.SubLedgerRequirement.Title == "Address Book");
                Customer = item.SubLedgerRequirementAccounts.Any(x => x.SubLedgerRequirement.Title == "Customer");
                FA = item.SubLedgerRequirementAccounts.Any(x => x.SubLedgerRequirement.Title == "Fixed Assets");

                item.AddressBook = AddressBook;
                item.FA = FA;
                item.Customer = Customer;
            }

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
                new GridColumn { Width = "150", HeaderText = "Account",  TextAlign= TextAlign.Center,  MinWidth="10",
                    Columns = new List<GridColumn>(){
                        new GridColumn { Field = "AccountCode", Width = "130", HeaderText = "Account Code",  TextAlign= TextAlign.Center,  MinWidth="10"  },
                        new GridColumn { Field = "AccountName", Width = "135", HeaderText = "Account Name",  TextAlign= TextAlign.Center,  MinWidth="10"  }
                    }
                }
            };
        }
        public List<GridColumn> GetClassificationColumns()
        {
            return new List<GridColumn>()
            {
                new GridColumn { HeaderText = "Classification", TextAlign= TextAlign.Center, MinWidth="10", 
                    Columns = new List<GridColumn>() {
                        new GridColumn { HeaderText = "Company", TextAlign= TextAlign.Center, MinWidth="10",
                            Columns = new List<GridColumn>()
                            {
                                new GridColumn { Field = "Company.CompanyCode", Width = "80", HeaderText = "Code", TextAlign=TextAlign.Center,  MinWidth="10"  },
                                new GridColumn { Field = "Company.Name", HeaderText = "Name",  TextAlign= TextAlign.Center,  MinWidth="10"  }
                            }
                        },
                        new GridColumn { HeaderText = "Header Account", TextAlign= TextAlign.Center, MinWidth="10",
                            Columns = new List<GridColumn>()
                            {
                                new GridColumn { Field = "HeadAccount.HeadCode", Width = "80", HeaderText = "Code", TextAlign=TextAlign.Center, MinWidth="10"  },
                                new GridColumn { Field = "HeadAccount.AccountName", HeaderText = "Name", TextAlign=TextAlign.Center, MinWidth="10"  },
                            }
                        },
                        new GridColumn { HeaderText = "Sub Header Account", TextAlign= TextAlign.Center, MinWidth="10",
                            Columns = new List<GridColumn>()
                            {
                                new GridColumn { Field = "AccountSubCategory.SubCategoryId", Width = "80", HeaderText = "Code", TextAlign=TextAlign.Center, MinWidth="10"  },
                                new GridColumn { Field = "AccountSubCategory.Title", HeaderText = "Name", TextAlign=TextAlign.Center, MinWidth="10"  },
                            }
                        },
                        new GridColumn { HeaderText = "Account Group", TextAlign= TextAlign.Center, MinWidth="10",
                            Columns = new List<GridColumn>()
                            {
                                new GridColumn { Field = "AccountGroupCategory.SubCategoryId", Width = "80", HeaderText = "Code", TextAlign=TextAlign.Center, MinWidth="10"  },
                                new GridColumn { Field = "AccountGroupCategory.Title", HeaderText = "Name", TextAlign=TextAlign.Center, MinWidth="10"  },
                            }
                        }
                    }
                }
            };
        }
        public List<GridColumn> GetReportingColumns()
        {
            return new List<GridColumn>()
            {
                new GridColumn { HeaderText = "Reporting", TextAlign = TextAlign.Center,  MinWidth="10",
                    Columns = new List<GridColumn>()
                    {
                        new GridColumn { HeaderText = "BS & PNL", TextAlign = TextAlign.Center,  MinWidth="10",
                            Columns = new List<GridColumn>()
                            {
                                new GridColumn { Field = "AccountStatementType.Title", HeaderText = "Type", TextAlign = TextAlign.Center,  MinWidth="10" },
                                new GridColumn { Field = "AccountStatementDetailType.Title", HeaderText = "Detail", TextAlign = TextAlign.Center,  MinWidth="10" },
                            }
                        },
                        new GridColumn { HeaderText = "Cash Flow", TextAlign = TextAlign.Center,  MinWidth="10",
                            Columns = new List<GridColumn>()
                            {
                                new GridColumn { Field = "CashFlowStatementType.Value", HeaderText = "Main", TextAlign = TextAlign.Center,  MinWidth="10" },
                                new GridColumn { Field = "", HeaderText = "Detail", TextAlign = TextAlign.Center,  MinWidth="10" },
                            }
                        }
                    }
                },
            };
        }
        public List<GridColumn> GetAccountAttributesColumns()
        {
            return new List<GridColumn>()
            {
                new GridColumn { HeaderText = "Account Attributes", TextAlign=TextAlign.Center, MinWidth="10",
                    Columns = new List<GridColumn>(){
                        new GridColumn { DisplayAsCheckBox = true, Field = "AllowPosting", Width = "80", HeaderText = "Posting", TextAlign=TextAlign.Center,  MinWidth="10"  },
                        new GridColumn { DisplayAsCheckBox = true, Field = "AllowPayment", Width = "80", HeaderText = "Payment", TextAlign=TextAlign.Center, MinWidth="10"  },
                        new GridColumn { DisplayAsCheckBox = true, Field = "AllowReceipt", Width = "80", HeaderText = "Receipt", TextAlign=TextAlign.Center, MinWidth="10"  },
                    }
                }
            };
        }
        public List<GridColumn> GetPostingAttributesColumns()
        {
            return new List<GridColumn>()
            {
                new GridColumn { HeaderText = "Posting Attributes", TextAlign=TextAlign.Center, MinWidth="10",
                    Columns = new List<GridColumn>(){
                        new GridColumn { DisplayAsCheckBox = true, Field = "AddressBook", Width = "80", HeaderText = "Address Book", TextAlign=TextAlign.Center, MinWidth="10"  },
                        new GridColumn { DisplayAsCheckBox = true, Field = "FA", Width = "80", HeaderText = "Fixed Assets", TextAlign=TextAlign.Center, MinWidth="10"  },
                        new GridColumn { DisplayAsCheckBox = true, Field = "Customer", Width = "80", HeaderText = "Customer", TextAlign=TextAlign.Center, MinWidth="10"  }
                    }
                }
            };
        }
        public List<GridColumn> GetSubLedgerAccountColumns()
        {
            return new List<GridColumn>()
            {
                new GridColumn { Width = "200", HeaderText = "Subledger Account", TextAlign=TextAlign.Center, MinWidth="10",
                    Columns = new List<GridColumn>(){
                        new GridColumn { Field = "SubLedgerAccount.AccountCode", Width = "80", HeaderText = "Code", TextAlign=TextAlign.Center, MinWidth="10"  },
                        new GridColumn { Field = "SubLedgerAccount.AccountName", Width = "150", HeaderText = "Name", TextAlign=TextAlign.Center, MinWidth="10"  }
                    }
                }
            };
        }
        public List<GridColumn> GetCommandsColumns()
        {
            List<object> commands = new List<object>();
            commands.Add(new { type = "Copy", buttonOption = new { iconCss = "e-icons e-copy", cssClass = "e-flat" } });
            commands.Add(new { type = "Edit", buttonOption = new { iconCss = "e-icons e-edit", cssClass = "e-flat" } });
            commands.Add(new { type = "Delete", buttonOption = new { iconCss = "e-icons e-delete", cssClass = "e-flat" } });
            commands.Add(new { type = "Save", buttonOption = new { iconCss = "e-icons e-update", cssClass = "e-flat" } });
            commands.Add(new { type = "Cancel", buttonOption = new { iconCss = "e-icons e-cancel-icon", cssClass = "e-flat" } });

            return new List<GridColumn>()
            {
                new GridColumn { Width = "200", HeaderText = "Actions", TextAlign=TextAlign.Center, MinWidth="10", Commands = commands }
            };
        }

        public List<GridColumn> GetPrimaryGridColumns()
        {
            List<GridColumn> gridColumns = new List<GridColumn>();

            gridColumns.AddRange(GetAccountColumns());
            gridColumns.AddRange(GetReportingColumns());
            gridColumns.AddRange(GetAccountAttributesColumns());
            gridColumns.AddRange(GetPostingAttributesColumns());
            gridColumns.AddRange(GetCommandsColumns());

            return gridColumns;
        }
        public List<GridColumn> GetSecondaryGridColumns()
        {
            List<GridColumn> gridColumns = new List<GridColumn>();

            gridColumns.AddRange(GetClassificationColumns());
            gridColumns.AddRange(GetSubLedgerAccountColumns());

            return gridColumns;
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
            accounts = result.Items.ToList();
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
    }
}
