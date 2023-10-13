using Microsoft.AspNetCore.Mvc;
using ShopJervson.Data;
using ShopJervson.Models;
using ShopJervson.Models.Spaceship;

namespace ShopJervson.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly ShopJervsonContext _context;
        public SpaceshipsController(ShopJervsonContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.spaceships
                .OrderBy(x => x.CreatedAt)
                .Select(x => new SpaceshipIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    PassengerCount = x.PassengerCount,
                    EnginePower = x.EnginePower,
                });
            return View(result);
        }
        public IActionResult Add() 
        {
            return View("Edit");    
        }
    }
}