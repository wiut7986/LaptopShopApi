using LaptopShopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopShopApi.Repository
{
    public interface ILaptopRepository
    {
        void InsertLaptop(Laptop laptop);
        void UpdateLaptop(Laptop laptop);
        void DeleteLaptop(int laptopId);
        Laptop GetLaptopById(int id);
        IEnumerable<Laptop> GetLaptops();
    }
}
