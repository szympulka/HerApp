using Her.Domain.Entities.Dictionaries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Her.Repository.Dictionary
{
    public class WeatherRepository: SqlRepository<WeatherModel>, IWeatherRepository
	{
    }
}
