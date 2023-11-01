using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using ShopJervson.Core.Dto;
using ShopJervson.Core.ServiceInterface;
using ShopJervson.Data;
using ShopJervson.Models.RealEstate;
using ShopJervson.Models.Spaceship;
using ShopJervson.Core.Domain;

namespace ShopJervson.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly IRealEstatesServices _realEstates;
        private readonly ShopJervsonContext _context;
        public RealEstatesController
            (
            IRealEstatesServices realEstates,
            ShopJervsonContext context
            )
        {
            _realEstates = realEstates;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.RealEstates
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new RealEstateIndexViewModel
                {
                    Id = x.Id,
                    Address = x.Address,
                    City = x.City,
                    Country = x.Country,
                    SquareMeters = x.SquareMeters,
                    Price = x.Price,
                    IsPropertySold = x.IsPropertySold,
                });
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            RealEstateCreateUpdateViewModel vm = new();
            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = Guid.NewGuid(),
                Address = vm.Address,
                City = vm.City,
                Country = vm.Country,
                County = vm.County,
                SquareMeters = vm.SquareMeters,
                Price = vm.Price,
                PostalCode = vm.PostalCode,
                PhoneNumber = vm.PhoneNumber,
                FaxNumber = vm.FaxNumber,
                ListingDescription = vm.ListingDescription,
                BuildDate = vm.BuildDate,
                RoomCount = vm.RoomCount,
                FloorCount = vm.FloorCount,
                EstateFloor = vm.EstateFloor,
                Bathrooms = vm.Bathrooms,
                Bedrooms = vm.Bedrooms,
                DoesHaveParkingSpace = vm.DoesHaveParkingSpace,
                DoesHavePowerGridConnection = vm.DoesHavePowerGridConnection,
                DoesHaveWaterGridConnection = vm.DoesHaveWaterGridConnection,
                Type = vm.Type,
                IsPropertyNewDevelopment = vm.IsPropertyNewDevelopment,
                IsPropertySold = vm.IsPropertySold,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
            var result = await _realEstates.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", vm);
        }
        public async Task<IActionResult> Update(RealEstateDto dto)
        {
            var domain = new RealEstate()
            {
                Id = Guid.NewGuid(),
                Address = dto.Address,
                City = dto.City,
                Country = dto.Country,
                County = dto.County,
                SquareMeters = dto.SquareMeters,
                Price = dto.Price,
                PostalCode = dto.PostalCode,
                PhoneNumber = dto.PhoneNumber,
                FaxNumber = dto.FaxNumber,
                ListingDescription = dto.ListingDescription,
                BuildDate = dto.BuildDate,
                RoomCount = dto.RoomCount,
                FloorCount = dto.FloorCount,
                EstateFloor = dto.EstateFloor,
                Bathrooms = dto.Bathrooms,
                Bedrooms = dto.Bedrooms,
                DoesHaveParkingSpace = dto.DoesHaveParkingSpace,
                DoesHavePowerGridConnection = dto.DoesHavePowerGridConnection,
                DoesHaveWaterGridConnection = dto.DoesHaveWaterGridConnection,
                Type = dto.Type,
                IsPropertyNewDevelopment = dto.IsPropertyNewDevelopment,
                IsPropertySold = dto.IsPropertySold,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = DateTime.Now,
            };
            _context.RealEstates.Update(domain);
            await _context.SaveChangesAsync();
            return domain;
        }
    }
}