using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopJervson.Core.Dto.WeatherDtos;

namespace ShopJervson.Core.ServiceInterface
{
    public interface IWeatherForecastsServices
    {
        Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto);
    }
}
