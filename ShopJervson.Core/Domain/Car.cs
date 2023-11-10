using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopJervson.Core.Domain
{
    internal class Car
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public int YearBuilt { get; set; }
        public string Color { get; set; }
        public int ZeroToHundred { get; set; }
        public string FuelConsumption { get; set; }

        public IEnumerable<FileToApi> FilesToApi { get; set; } = new List<FileToApi>(); //files to be added to the api
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
