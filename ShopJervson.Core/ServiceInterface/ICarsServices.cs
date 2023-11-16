using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopJervson.Core.Domain;
using ShopJervson.Core.Dto;

namespace ShopJervson.Core.ServiceInterface
{
    public interface ICarsServices
    {
        Task<Car> GetAsync(Guid Id);
        Task<Car> Create(CarDto dto);
        Task<Car> Update(CarDto dto);
        Task<Car> Delete(Guid id);
    }
}
