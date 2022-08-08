using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectVehicles.Models.ViewModels;
using ProjectVehicles.Services.Abstract;
using System.Threading.Tasks;

namespace ProjectVehicles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CarVM carVM)
        {
            var car = await _carService.Create(carVM);
            if(car == null)
            {
                return BadRequest();
            }
            return Ok(car);
        }

        [HttpGet]
        [Route("ReadById/{id}")]
        public async Task<ActionResult> ReadById(int id)
        {
            var car = await _carService.ReadById(id);
            if(car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpGet]
        [Route("ReadAll")]
        public async Task<ActionResult> ReadAll()
        {
            var cars = await _carService.ReadAll();
            if (cars == null || cars.Count == 0)
            {
                return NotFound();
            }
            return Ok(cars);
        }

        [HttpPut]
        [Route("UpdateById")]
        public async Task<ActionResult> UpdateById(int id, CarVM carVM)
        {
            var car = await _carService.Update(id, carVM);
            if(car == null)
            {
                return BadRequest();
            }
            return Ok(car);
        }

        [HttpDelete]
        [Route("DeleteById")]
        public async Task<bool> DeleteById(int id)
        {
            return await _carService.Delete(id);
        }


        [HttpGet]
        [Route("SelectByColor")]
        public async Task<ActionResult> SelectByColor(string color)
        {
            var cars = await _carService.SelectByColor(color);
            if (cars == null || cars.Count == 0)
            {
                return NotFound();
            }
            return Ok(cars);
        }

        [HttpPost]
        [Route("TurnTheLightsOn")]
        public async Task<ActionResult> TurnTheLightsOn(int id)
        {
            var car = await _carService.TurnTheLightsOn(id);
            if(car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        [Route("TurnTheLightsOff")]
        public async Task<ActionResult> TurnTheLightsOff(int id)
        {
            var car = await _carService.TurnTheLightsOff(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }
    }
}
