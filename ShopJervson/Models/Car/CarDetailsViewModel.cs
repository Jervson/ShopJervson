using ShopJervson.Core.Dto;

namespace ShopJervson.Models.Car
{
    public class CarDetailsViewModel
    {
        public Guid? Id { get; set; }
        public string Brand { get; set; }
        public int YearBuilt { get; set; }
        public string Color { get; set; }
        public bool ZeroToHundred { get; set; }
        public string FuelConsumption { get; set; }

        public List<FileToApiViewModel> FileToApiViewModels { get; set; } = new List<FileToApiViewModel>();
        public DateTime CreatedAt { get; set; }
        public List<IFormFile> Files { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}