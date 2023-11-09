using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopJervson.Core.Domain
{
    public enum EstateType
    {
        House, Apartment, Room, Land, ParkingSpace, TimeShare, Garage, StorageUnit, Mansion, Castle, Station
    }
    public class RealEstate
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string? City { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public int PostalCode { get; set; }
        public int PhoneNumber { get; set; }
        public int FaxNumber { get; set; }
        public string ListingDescription { get; set; }
        public int SquareMeters { get; set; }
        public DateTime BuildDate { get; set; }
        public int Price { get; set; }
        public int RoomCount { get; set; }
        public int FloorCount { get; set; }
        public int? EstateFloor { get; set; }
        public int Bathrooms { get; set;}
        public int Bedrooms { get; set; }
        public bool DoesHaveParkingSpace { get; set; }
        public bool DoesHavePowerGridConnection { get; set; }
        public bool DoesHaveWaterGridConnection { get; set; }
        public decimal? SqMPrice 
        {
            get
            {
                return Price / SquareMeters;
            }
        }
        public string Type { get; set; }
        public bool IsPropertyNewDevelopment { get; set; }
        public bool IsPropertySold { get; set; }
                public IEnumerable<FileToApi> FilesToApi { get; set; } = new List<FileToApi>(); //files to be added to the api

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set;}
    }
}
