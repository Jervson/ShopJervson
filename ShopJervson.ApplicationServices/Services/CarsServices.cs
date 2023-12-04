using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopJervson.Core.Domain;
using ShopJervson.Core.Dto;
using ShopJervson.Core.ServiceInterface;
using ShopJervson.Data;
using System.Runtime.ConstrainedExecution;

namespace ShopJervson.ApplicationServices.Services
{
    public class CarsServices : ICarsServices
    {
        private readonly ShopJervsonContext _context;
        private readonly IFilesServices _filesServices;
        public CarsServices
            (
            ShopJervsonContext context,
             IFilesServices filesServices
            )
        {
            _context = context;
            _filesServices = filesServices;
        }
        public async Task<Car> Create(CarDto dto)
        {
            Car car = new Car();

            car.Id = dto.Id;
            car.Brand = dto.Brand;
            car.YearBuilt = dto.YearBuilt;
            car.Color = dto.Color;
            car.ZeroToHundred = dto.ZeroToHundred;
            car.FuelConsumption = dto.FuelConsumption;
            car.CreatedAt = dto.CreatedAt;
            car.ModifiedAt = DateTime.Now;

            _filesServices.CarFilesToApi(dto, car);

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Cars
                .Include(x => x.FilesToApi)
                .FirstOrDefaultAsync(x => x.Id == id);
            var images = await _context.FilesToApi
                    .Where(x => x.CarId == id)
                    .Select(y => new FileToApiDto
                    {
                        Id = y.Id,
                        CarId = y.CarId,
                        ExistingFilePath = y.ExistingFilePath

                    }).ToArrayAsync();
            await _filesServices.RemoveImagesFromApi(images);
            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();
            return carId;
        }
        public async Task<Car> Update(CarDto dto)
        {
            Car car = new Car();

            car.Id = dto.Id;
            car.Brand = dto.Brand;
            car.YearBuilt = dto.YearBuilt;
            car.Color = dto.Color;
            car.ZeroToHundred = dto.ZeroToHundred;
            car.FuelConsumption = dto.FuelConsumption;
            car.CreatedAt = dto.CreatedAt;
            car.ModifiedAt = DateTime.Now;

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
