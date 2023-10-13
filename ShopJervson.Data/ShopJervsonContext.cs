using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopJervson.Core.Domain.Spaceship;

namespace ShopJervson.Data
{
    public class ShopJervsonContext : DbContext
    {
        public ShopJervsonContext(DbContextOptions<ShopJervsonContext> options) : base(options) { }

        public DbSet<Spaceship> spaceships { get; set; }
    }
}