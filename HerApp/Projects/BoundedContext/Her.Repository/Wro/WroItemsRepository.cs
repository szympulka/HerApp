using Her.Domain.Entities.Wro;
using System;
using System.Collections.Generic;
using System.Text;

namespace Her.Repository.Wro
{
	public class WrocItemsRepository: SqlRepository<WrocItemsModel>, IWrocItemsRepository
	{
	}
}
