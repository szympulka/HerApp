using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Her.Services.AzureServices
{
    public interface ICosmoDbService
    {
		//Task AddJsonAsync(List<WrocItemsViewModel> list, string Database, string Document);
		Task RemoveDocument(string Database, string Document);
	}
}
