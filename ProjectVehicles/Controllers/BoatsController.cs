using Microsoft.AspNetCore.Mvc;
using ProjectVehicles.Models;
using ProjectVehicles.Models.ViewModels;
using ProjectVehicles.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectVehicles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoatsController : ControllerBase
    {

        private IBoatService _boatService;
        public BoatsController(IBoatService boatService)
        {
            _boatService = boatService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] BoatVM boatVM)
        {
            var boat = await _boatService.Create(boatVM);
            if (boat == null)
            {
                return BadRequest();
            }
            return Ok(boat);
        }

        [HttpGet]
        [Route("ReadById/{id}")]
        public async Task<ActionResult> ReadById(int id)
        {
            var boat = await _boatService.ReadById(id);
            if (boat == null)
            {
                return NotFound();
            }
            return Ok(boat);
        }

        [HttpGet]
        [Route("ReadAll")]
        public async Task<ActionResult> ReadAll()
        {
            var boats = await _boatService.ReadAll();
            if (boats == null || boats.Count == 0)
            {
                return NotFound();
            }
            return Ok(boats);
        }

        [HttpPut]
        [Route("UpdateById")]
        public async Task<ActionResult> UpdateById(int id, BoatVM boatVM)
        {
            var boat = await _boatService.Update(id, boatVM);
            if (boat == null)
            {
                return BadRequest();
            }
            return Ok(boat);
        }

        [HttpDelete]
        [Route("DeleteById")]
        public async Task<bool> DeleteById(int id)
        {
            return await _boatService.Delete(id);
        }


        [HttpGet]
        [Route("SelectByColor")]
        public async Task<ActionResult> SelectByColor(string color)
        {
            var boats = await _boatService.SelectByColor(color);
            if (boats == null || boats.Count == 0)
            {
                return NotFound();
            }
            return Ok(boats);
        }
    }
}
