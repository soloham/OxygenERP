using CERP.App;
using CERP.AppServices.App.ApprovalRouteService;
using CERP.AppServices.App.TaskService;
using System.Threading.Tasks;

namespace CERP.Web.BusinessLogic.Core.Services.ApprovalRouteService
{
    public interface IApprovalRoutesManager
    {
        ApprovalRouteTemplateItemsAppService ApprovalRouteTemplateItemsAppService { get; set; }
        ApprovalRouteTemplatesAppService ApprovalRouteTemplatesAppService { get; set; }
        TaskTemplatesAppService TaskTemplatesAppService { get; set; }

        Task<ApprovalRouteTemplate> ProcessApprovalRoutesUpdate(ApprovalRouteViewModelBase VM, ApprovalRouteTemplate _approvalRouteTemplate);
        ApprovalRouteTemplate_Dto ProcessNewApprovalsRoute(ApprovalRouteViewModelBase VM);
    }
}