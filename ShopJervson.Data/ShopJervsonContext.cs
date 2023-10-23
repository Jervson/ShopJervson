using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopJervson.Core.Domain;

namespace ShopJervson.Data
{
    public class ShopJervsonContext : DbContext
    {
        public ShopJervsonContext(DbContextOptions<ShopJervsonContext> options) : base(options) { }

        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
    }
}