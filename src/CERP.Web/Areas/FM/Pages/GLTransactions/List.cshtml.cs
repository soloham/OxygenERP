using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CERP.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.EJ2.Grids;

namespace CERP.Web.Areas.FM.Pages.GLTransactions
{
    public class ListModel : CERPPageModel
    {
        private readonly coaAppService _coaAppService;
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

            SecondaryDetailsGrid = new Grid()
            {
                DataSource = null,
                QueryString = "Id",
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
                //Toolbar = new List<object>() { "ExcelExport", "PdfExport", "CsvExport", "Print", "Search", "Delete", new { text = "Copy", tooltipText = "Copy", prefixIcon = "e-copy", id = "copy" }, new { text = "Copy With Header", tooltipText = "Copy With Header", prefixIcon = "e-copy", id = "copyHeader" } },
                ContextMenuItems = new List<object>() { "AutoFit", "AutoFitAll", "SortAscending", "SortDescending", "Copy", "Edit", "Delete", "Save", "Cancel", "PdfExport", "ExcelExport", "CsvExport", "FirstPage", "PrevPage", "LastPage", "NextPage" },
                Columns = GetSecondaryGridColumns()

            };
            //List<COA_Account_Dto> COAs = (await _coaAppService.GetListAsync(new Volo.Abp.Application.Dtos.PagedAndSortedResultRequestDto())).Items.ToList();

            ViewData["COAs_DS"] = null;
            ViewData["alertbutton"] = new
            {
                content = "OK",
                isPrimary = true
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
                new GridColumn { Width = "200", HeaderText = "Commands", TextAlign=TextAlign.Center, MinWidth="10", Commands = commands }
            };
        }

        public List<GridColumn> GetPrimaryGridColumns()
        {
            List<GridColumn> gridColumns = new List<GridColumn>() {
                new GridColumn { Field = "BacthId", Width = "80", HeaderText = "Batch#", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "DocId", Width = "80", HeaderText = "Doc#", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "BatchDate", Width = "80", HeaderText = "Batch Date", TextAlign=TextAlign.Center,  MinWidth="10"  },
                new GridColumn { Field = "Notes", Width = "80", HeaderText = "Notes", TextAlign=TextAlign.Center,  MinWidth="10"  },

            };

            return gridColumns;
        }
        public List<GridColumn> GetSecondaryGridColumns()
        {
            List<GridColumn> gridColumns = new List<GridColumn>();

           

            return gridColumns;
        }

    }
}
