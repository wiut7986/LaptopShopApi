using LaptopShopApi.DbContexts;
using LaptopShopApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopShopApi.Repository
{
    public class LaptopRepository : ILaptopRepository
    {
        private readonly LaptopContext _dbContext;

        public LaptopRepository(LaptopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteLaptop(int laptopId)
        {
            var laptop = _dbContext.Laptops.Find(laptopId);
            _dbContext.Remove(laptop);
            Save();
        }

        public Laptop GetLaptopById(int id)
        {
            var laptop = _dbContext.Laptops.Find(id);
            //****************************
            //_dbContext.Entry(laptop).Reference(s => s.Brand).Load();
            return laptop;
        }

        public IEnumerable<Laptop> GetLaptops()
        {
            return _dbContext.Laptops.ToList();
        }

        public void InsertLaptop(Laptop laptop)
        {
            _dbContext.Add(laptop);
            Save();
        }

        public void UpdateLaptop(Laptop laptop)
        {
            _dbContext.Entry(laptop).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
