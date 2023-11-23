using Microsoft.AspNetCore.Mvc;
using ShopJervson.Core.Dto;
using ShopJervson.Core.ServiceInterface;
using ShopJervson.Models.Car;
using ShopJervson.ApplicationServices.Services;
using System.Diagnostics.Metrics;
using System.Net;
using ShopJervson.Data;
using ShopJervson.Models.Spaceship;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using ShopJervson.Core.Domain;

namespace ShopJervson.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsServices _cars;
        private readonly ShopJervsonContext _context;
        private readonly IFilesServices _filesServices;
        public CarsController
            (
            ICarsServices cars,
            ShopJervsonContext context,
            IFilesServices filesServices
            )
        {
            _cars = cars;
            _context = context;
            _filesServices = filesServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Cars
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    YearBuilt = x.YearBuilt,
                    Color = x.Color,
                    ZeroToHundred = x.ZeroToHundred,
                    FuelConsumption = x.FuelConsumption,
                    });
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarCreateUpdateViewModel vm = new();
            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {                              
            Id = Guid.NewGuid(),
            Brand = vm.Brand,
            YearBuilt = vm.YearBuilt,
            Color = vm.Color,
            ZeroToHundred = vm.ZeroToHundred,
            FuelConsumption = vm.FuelConsumption,
            CreatedAt = DateTime.Now,
            ModifiedAt = DateTime.Now,
            Files = vm.Files,
            FilesToApiDtos = vm.FileToApiViewModels
            .Select(z => new FileToApiDto
                {
                    Id = z.ImageId,
                    ExistingFilePath = z.FilePath,
                    CarId = z.CarId,
                }).ToArray()
            };
            var result = await _cars.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _cars.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToApi
            .Where(x => x.CarId == id)
            .Select(y => new FileToApiViewModel
            {
                FilePath = y.ExistingFilePath,
                ImageId = y.Id
            }).ToArrayAsync();
            var vm = new CarCreateUpdateViewModel();

            vm.Id = car.Id;
            vm.Brand = car.Brand;
            vm.YearBuilt = car.YearBuilt;
            vm.Color = car.Color;
            vm.ZeroToHundred = car.ZeroToHundred;
            vm.FuelConsumption = car.FuelConsumption;
            vm.CreatedAt = DateTime.Now;
            vm.ModifiedAt = DateTime.Now;
            vm.FileToApiViewModels.AddRange(images);

            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = (Guid)vm.Id,
                Brand = vm.Brand,
                YearBuilt = vm.YearBuilt,
                Color = vm.Color,
                ZeroToHundred = vm.ZeroToHundred,
                FuelConsumption = vm.FuelConsumption,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Files = vm.Files,
                FilesToApiDtos = vm.FileToApiViewModels
            .Select(z => new FileToApiDto
            {
                Id = z.ImageId,
                ExistingFilePath = z.FilePath,
                CarId = z.CarId,
            }).ToArray()
            };
            var result = await _cars.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _cars.GetAsync(id);
            if (car == null)
            {

                return NotFound();
            }
            var images = await _context.FilesToApi
              .Where(x => x.CarId == id)
              .Select(y => new FileToApiViewModel
              {
                  FilePath = y.ExistingFilePath,
                  ImageId = y.Id
              }).ToArrayAsync();

            var vm = new CarDetailDeleteViewModel();

            vm.Id = car.Id;
            vm.Brand = car.Brand;
            vm.YearBuilt = car.YearBuilt;
            vm.Color = car.Color;
            vm.ZeroToHundred = car.ZeroToHundred;
            vm.FuelConsumption = car.FuelConsumption;
            vm.CreatedAt = DateTime.Now;
            vm.ModifiedAt = DateTime.Now;
            vm.FileToApiViewModels.AddRange(images);

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _cars.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToApi
            .Where(x => x.CarId == id)
            .Select(y => new FileToApiViewModel
            {
                FilePath = y.ExistingFilePath,
                ImageId = y.Id
            }).ToArrayAsync();

            var vm = new CarDetailDeleteViewModel();

            vm.Id = car.Id;
            vm.Brand = car.Brand;
            vm.YearBuilt = car.YearBuilt;
            vm.Color = car.Color;
            vm.ZeroToHundred = car.ZeroToHundred;
            vm.FuelConsumption = car.FuelConsumption;
            vm.CreatedAt = DateTime.Now;
            vm.ModifiedAt = DateTime.Now;
            vm.FileToApiViewModels.AddRange(images);

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var car = await _cars.GetAsync(id);
            if (car == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public async Task<IActionResult> RemoveImage(FileToApiViewModel vm)
        {
            var dto = new FileToApiDto()
            {
                Id = vm.ImageId
            };
            var image = await _filesServices.RemoveImageFromApi(dto);
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}