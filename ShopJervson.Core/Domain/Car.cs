using Microsoft.AspNetCore.Http;
using ShopJervson.Core.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopJervson.Core.Domain
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public int YearBuilt { get; set; }
        public string Color { get; set; }
        public bool ZeroToHundred { get; set; }
        public string FuelConsumption { get; set; }

        public IEnumerable<FileToApiDto> FilesToApi { get; set; } = new List<FileToApiDto>(); //files to be added to the api
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
