using Her.Repository.Dictionary;
using Her.ViewModel;
using System.Collections.Generic;

namespace Her.Services.DictionaryService
{
	public class DictionaryServices : IDictionaryServices
	{
		private IInterestRepository _interestRepository;
		public DictionaryServices(IInterestRepository interest)
		{
			_interestRepository = interest;
		}
		public List<IntrestViewModel> GetInterest()
		{
			var list = new List<IntrestViewModel>();
			foreach (var item in _interestRepository.All())
			{
				list.Add(new IntrestViewModel()
				{
					Id = item.Id,
					Name = item.Name,
				});
			}
			return list;
		}
	}
}
