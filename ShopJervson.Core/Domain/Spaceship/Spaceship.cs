using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopJervson.Core.Domain.Spaceship
{
    public class Spaceship
    {
        [Key]
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }    
        public int[] Dimensions { get; set; }
        public int PassangerCount { get; set; }
        public int CrewCount { get; set; }
        public int CargoWeight { get; set; }
        public int MaxSpeedInVaccum { get; set; }
        public DateTime BuiltAtDate { get; set; }
        public DateTime MaidenLaunch { get; set; }
        public string Manufacturer { get; set; }
        public bool IsSpaceshipPreviouslyOwned { get; set; }
        public int FullTripsCount { get; set; }
        public string Type { get; set; }
        public int EnginePower { get; set; }
        public int FuelConsumptionPerDay { get; set; }
        public int MaintananceCount { get; set; }
       
        // only in database

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
