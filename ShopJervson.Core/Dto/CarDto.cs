using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopJervson.Core.Dto
{
    public class CarDto
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public int YearBuilt { get; set; }
        public string Color { get; set; }
        public bool ZeroToHundred { get; set; }
        public string FuelConsumption { get; set; }

        public IEnumerable<FileToApiDto> FilesToApiDtos { get; set; } = new List<FileToApiDto>(); //files to be added to the api
        public DateTime CreatedAt { get; set; }
        public List<IFormFile> Files { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
