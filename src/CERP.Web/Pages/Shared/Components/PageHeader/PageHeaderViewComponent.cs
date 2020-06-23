using CERP.App;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Grids;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Json;

namespace CERP.Web.Pages.Shared.Components
{
    public class PageHeaderViewComponent : AbpViewComponent
    {
        public IJsonSerializer JsonSerializer { get; set; }

        public PageHeaderViewComponent(IJsonSerializer jsonSerializer)
        {
            JsonSerializer = jsonSerializer;
        }

        public async Task<IViewComponentResult> InvokeAsync(string HeaderTitle, string IconClass = "fas fa-list", string SubTitle = "", bool IsList = false, bool IsSearch = false, bool IsCreate = false, string Area = "", string CreateNewLink = "", string CreateNewText = "", string OnCreateClicked = "", string SearchText = "", string OnSeachClicked = "")
        {
            PageHeaderVCModel model = new PageHeaderVCModel(IconClass, HeaderTitle, SubTitle, IsList, IsSearch, IsCreate, Area, CreateNewLink, CreateNewText, OnCreateClicked, SearchText, OnSeachClicked);

            return View(model);
        }
    }

    public class PageHeaderVCModel
    {
        public PageHeaderVCModel(string iconClass, string headerTitle, string subTitle, bool isList, bool isSearch, bool isCreate, string area, string createNewLink, string createNewText, string onCreateClicked, string searchText, string onSearchClicked)
        {
            IconClass = iconClass;
            HeaderTitle = headerTitle;
            IsList = isList;
            IsCreate = isCreate;
            Area = area;
            CreateNewLink = createNewLink;
            CreateNewText = createNewText;
            SubTitle = subTitle;
            OnCreateClicked = onCreateClicked;
            IsSearch = isSearch;
            SearchText = searchText;
            OnSearchClicked = onSearchClicked;
        }

        public string IconClass { get; set; }
        public string HeaderTitle { get; set; }
        public string SubTitle { get; set; }
        public bool IsList { get; set; }
        public bool IsSearch { get; set; }
        public bool IsCreate { get; set; }
        public string Area { get; set; }
        public string CreateNewLink { get; set; }
        public string CreateNewText { get; set; }
        public string OnCreateClicked { get; set; }
        public string SearchText { get; set; }
        public string OnSearchClicked { get; set; }
    }
}
