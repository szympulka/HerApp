using System.Diagnostics;
using Her.Services.DashboardService;
using Her.Services.UserService;
using Her.ViewModel;
using Her.ViewModel.DashboardViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Her.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IDashboardService _dashboardService;

        public HomeController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            var model =_dashboardService.GetUserNameDashboard();
			return View(model);
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
