using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Her.ViewModel.DashboardViewModels;

namespace Her.Services.DashboardService
{
    public interface IDashboardService
    {
		DashboardViewModel GetUserNameDashboard();
	}
}
