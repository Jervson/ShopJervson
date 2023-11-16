using ShopJervson.Core.Dto;
using ShopJervson.Models.RealEstate;

namespace ShopJervson.Models.Car
{
    public class CarIndexViewModel
    {

        public Guid Id { get; set; }
        public string Brand { get; set; }
        public int YearBuilt { get; set; }
        public string Color { get; set; }
        public bool ZeroToHundred { get; set; }
        public string FuelConsumption { get; set; }

        public IEnumerable<FileToApiViewModel> FileToApiViewModels { get; set; } = new List<FileToApiViewModel>(); //files to be added to the api
        public DateTime CreatedAt { get; set; }
        public List<IFormFile> Files { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
