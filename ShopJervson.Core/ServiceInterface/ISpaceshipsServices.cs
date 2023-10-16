using ShopJervson.Core.Domain.Spaceship;
using ShopJervson.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopJervson.Core.ServiceInterface
{
    public interface ISpaceshipsServices
    {
        Task<Spaceship> Add(SpaceshipDto dto);
    }
}