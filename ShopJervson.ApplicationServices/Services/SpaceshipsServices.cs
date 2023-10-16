using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopJervson.Core.Domain.Spaceship;
using ShopJervson.Core.Dto;
using ShopJervson.Core.ServiceInterface;
using ShopJervson.Data;

namespace   ShopJervson.ApplicationServices.Services
{
    public class SpaceshipsServices : ISpaceshipsServices
    {
        private readonly ShopJervsonContext _context;
        public SpaceshipsServices(ShopJervsonContext context)
        {
            _context = context;
        }

        public async Task<Spaceship> Add(SpaceshipDto dto)
        {
            var domain = new Spaceship()
            {
                Name = dto.Name,
                Description = dto.Description,
                //Dimensions = dto.Dimensions,
                PassengerCount = dto.PassengerCount,
                CrewCount = dto.CrewCount,
                CargoWeight = dto.CargoWeight,
                MaxSpeedInVacuum = dto.MaxSpeedInVacuum,
                BuiltAtDate = dto.BuiltAtDate,
                MaidenLaunch = dto.MaidenLaunch,
                Manufacturer = dto.Manufacturer,
                IsSpaceshipPreviouslyOwned = dto.IsSpaceshipPreviouslyOwned,
                FullTripsCount = dto.FullTripsCount,
                Type = dto.Type,
                EnginePower = dto.EnginePower,
                FuelConsumptionPerDay = dto.FuelConsumptionPerDay,
                MaintenanceCount = dto.MaintenanceCount,
                LastMaintenance = dto.LastMaintenance,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = dto.ModifiedAt,
            };
            await _context.spaceships.AddAsync(domain);
            await _context.SaveChangesAsync();
            return domain;
        }
    }
}