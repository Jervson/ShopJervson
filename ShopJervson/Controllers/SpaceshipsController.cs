using Microsoft.AspNetCore.Mvc;
using ShopJervson.Core.Dto;
using ShopJervson.Core.ServiceInterface;
using ShopJervson.Data;
using ShopJervson.Models;
using ShopJervson.Models.Spaceship;

namespace ShopJervson.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly ShopJervsonContext _context;
        private readonly ISpaceshipsServices _spaceshipsServices;
        public SpaceshipsController
            (
            ShopJervsonContext context,
            ISpaceshipsServices spaceshipsServices
            )
        {
            _context = context;
            _spaceshipsServices = spaceshipsServices;
        }
        public IActionResult Index()
        {
            var result = _context.spaceships
                .OrderBy(x => x.CreatedAt)
                .Select(x => new SpaceshipIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    PassengerCount = x.PassengerCount,
                    EnginePower = x.EnginePower,
                });
            return View(result);
        }
        [HttpGet]
        public IActionResult Add() 
        {
            return View("Edit");    
        }
        [HttpPost]
        public async Task<IActionResult> Add(SpaceshipEditViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                PassengerCount = vm.PassengerCount,
                CrewCount = vm.CrewCount,
                CargoWeight = vm.CargoWeight,
                MaxSpeedInVacuum = vm.MaxSpeedInVacuum,
                BuiltAtDate = vm.BuiltAtDate,
                MaidenLaunch = vm.MaidenLaunch,
                Manufacturer = vm.Manufacturer,
                IsSpaceshipPreviouslyOwned = vm.IsSpaceshipPreviouslyOwned,
                FullTripsCount = vm.FullTripsCount,
                Type = vm.Type,
                EnginePower = vm.EnginePower,
                FuelConsumptionPerDay = vm.FuelConsumptionPerDay,
                MaintenanceCount = vm.MaintenanceCount,
                LastMaintenance = vm.LastMaintenance,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };
            var result = await _spaceshipsServices.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }
    }
}