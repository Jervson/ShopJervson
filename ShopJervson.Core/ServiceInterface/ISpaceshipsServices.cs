using ShopJervson.Core.Domain;
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
        Task<Spaceship> Create(SpaceshipDto dto);
        //Task<Spaceship> GetUpdate(Guid id);         - not needed
        Task<Spaceship> Update(SpaceshipDto dto);
        Task<Spaceship> Delete(Guid Id);
        Task<Spaceship> GetAsync(Guid Id);
    }
}