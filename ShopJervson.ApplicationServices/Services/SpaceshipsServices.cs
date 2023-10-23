﻿using Microsoft.EntityFrameworkCore;
using ShopJervson.ApplicationServices.Services;
using ShopJervson.Core.Domain;
using ShopJervson.Core.Dto;
using ShopJervson.Core.ServiceInterface;
using ShopJervson.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopJervson.ApplicationServices.Services
{
    public class SpaceshipsServices : ISpaceshipsServices
    {
        private readonly ShopJervsonContext _context;
        private readonly IFilesServices _files;
        public SpaceshipsServices(ShopJervsonContext context, IFilesServices files)
        {
            _context = context;
            _files = files;
        }

        public async Task<Spaceship> Create(SpaceshipDto dto)
        {
            Spaceship spaceship = new Spaceship();
            FileToDatabase file = new FileToDatabase();

            spaceship.Id = Guid.NewGuid();
            spaceship.Name = dto.Name;
            spaceship.Description = dto.Description;
            //Dimensions = dto.Dimensions,
            spaceship.PassengerCount = dto.PassengerCount;
            spaceship.CrewCount = dto.CrewCount;
            spaceship.CargoWeight = dto.CargoWeight;
            spaceship.MaxSpeedInVacuum = dto.MaxSpeedInVacuum;
            spaceship.BuiltAtDate = dto.BuiltAtDate;
            spaceship.MaidenLaunch = dto.MaidenLaunch;
            spaceship.Manufacturer = dto.Manufacturer;
            spaceship.IsSpaceshipPreviouslyOwned = dto.IsSpaceshipPreviouslyOwned;
            spaceship.FullTripsCount = dto.FullTripsCount;
            spaceship.Type = dto.Type;
            spaceship.EnginePower = dto.EnginePower;
            spaceship.FuelConsumptionPerDay = dto.FuelConsumptionPerDay;
            spaceship.MaintenanceCount = dto.MaintenanceCount;
            spaceship.LastMaintenance = dto.LastMaintenance;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            if (dto.Files != null)
            {
                _files.UploadFilesToDatabase(dto, spaceship);
            }

            await _context.Spaceships.AddAsync(spaceship);
            await _context.SaveChangesAsync();
            return spaceship;
        }
        public async Task<Spaceship> Update(SpaceshipDto dto)
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
                ModifiedAt = DateTime.Now,
            };
            _context.Spaceships.Update(domain);
            await _context.SaveChangesAsync();
            return domain;
        }
        //public async Task<Spaceship> GetUpdate(Guid id)
        //{
        //    var result = await _context.Spaceships
        //        .FirstOrDefaultAsync(x => x.Id == id);
        //    return result;
        //}

        public async Task<Spaceship> Delete(Guid Id)
        {
            var spaceshipId = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == Id);

            _context.Spaceships.Remove(spaceshipId);
            await _context.SaveChangesAsync();

            return spaceshipId;
        }

        public async Task<Spaceship> GetAsync(Guid Id)
        {
            var result = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == Id);
            return result;
        }
    }
}
