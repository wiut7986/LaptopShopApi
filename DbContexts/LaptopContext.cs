using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaptopShopApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LaptopShopApi.DbContexts
{
    public class LaptopContext : DbContext
    {
        public LaptopContext(DbContextOptions<LaptopContext> options) : base(options)
        {
        }

        public DbSet<Laptop> Laptops { get; set; }
    }
}
