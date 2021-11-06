using LaptopShopApi.Models;
using LaptopShopApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaptopShopApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Laptop")]
    [ApiController]
    public class LaptopController : Controller
    {
        private readonly ILaptopRepository _laptopRepository;

        public LaptopController(ILaptopRepository laptopRepository)
        {
            _laptopRepository = laptopRepository;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            var laptops = _laptopRepository.GetLaptops();
            return new OkObjectResult(laptops);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var laptop = _laptopRepository.GetLaptopById(id);
            return new OkObjectResult(laptop);
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Laptop laptop)
        {
            using (var scope = new TransactionScope())
            {
                _laptopRepository.InsertLaptop(laptop);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = laptop.Id }, laptop);
            }

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Laptop laptop)
        {
            if (laptop != null)
            {
                using (var scope = new TransactionScope())
                {
                    _laptopRepository.UpdateLaptop(laptop);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _laptopRepository.DeleteLaptop(id);
            return new OkResult();
        }
    }
}
