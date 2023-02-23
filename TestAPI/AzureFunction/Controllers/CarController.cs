using Application.Interaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunction.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        public readonly ICarCosmosService _carCosmosService;
        public CarController(ICarCosmosService carCosmosService)
        {
            _carCosmosService = carCosmosService;
        }
        public CarController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sqlCosmosQuery = "Select * from c";
            var result = await _carCosmosService.Get(sqlCosmosQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Car newCar)
        {
            newCar.Id = Guid.NewGuid().ToString();
            var result = await _carCosmosService.AddAsync(newCar);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put(Car carToUpdate)
        {
            var result = await _carCosmosService.Update(carToUpdate);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _carCosmosService.Delete(id);
            return Ok();
        }

        internal static IActionResult Post(object taskDocument)
        {
            throw new NotImplementedException();
        }
    }
}
