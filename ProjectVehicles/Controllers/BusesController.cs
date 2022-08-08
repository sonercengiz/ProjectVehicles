using Microsoft.AspNetCore.Mvc;
using ProjectVehicles.Models.ViewModels;
using ProjectVehicles.Services.Abstract;
using System.Threading.Tasks;

namespace ProjectVehicles.Controllers
{
    public class BusesController : Controller
    {
        private IBusService _busService;
        public BusesController(IBusService busService)
        {
            _busService = busService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] BusVM busVM)
        {
            var bus = await _busService.Create(busVM);
            if (bus == null)
            {
                return BadRequest();
            }
            return Ok(bus);
        }

        [HttpGet]
        [Route("ReadById/{id}")]
        public async Task<ActionResult> ReadById(int id)
        {
            var bus = await _busService.ReadById(id);
            if (bus == null)
            {
                return NotFound();
            }
            return Ok(bus);
        }

        [HttpGet]
        [Route("ReadAll")]
        public async Task<ActionResult> ReadAll()
        {
            var buses = await _busService.ReadAll();
            if (buses == null || buses.Count == 0)
            {
                return NotFound();
            }
            return Ok(buses);
        }

        [HttpPut]
        [Route("UpdateById")]
        public async Task<ActionResult> UpdateById(int id, BusVM busVM)
        {
            var bus = await _busService.Update(id, busVM);
            if (bus == null)
            {
                return BadRequest();
            }
            return Ok(bus);
        }

        [HttpDelete]
        [Route("DeleteById")]
        public async Task<bool> DeleteById(int id)
        {
            return await _busService.Delete(id);
        }


        [HttpGet]
        [Route("SelectByColor")]
        public async Task<ActionResult> SelectByColor(string color)
        {
            var buses = await _busService.SelectByColor(color);
            if (buses == null || buses.Count == 0)
            {
                return NotFound();
            }
            return Ok(buses);
        }
    }
}
