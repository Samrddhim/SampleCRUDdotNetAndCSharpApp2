using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleCRUDusingDotNetAndCSharp2.Data;
using SampleCRUDusingDotNetAndCSharp2.Models;
using SampleCRUDusingDotNetAndCSharp2.Models.Entities;

namespace SampleCRUDusingDotNetAndCSharp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public VehicleController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllVehicles()
        {
            var VehicleList = dbContext.Vehicles.ToList();
            return Ok(VehicleList);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetVehicleById(Guid id)
        {
            var Vehicle = dbContext.Vehicles.Find(id);
            if (Vehicle == null)
            {
                return NotFound();

            }

            return Ok(Vehicle);
        }

        [HttpPost]
        public IActionResult AddVehicle(AddVehicleDto addVehicleDto)
        {
            var VehicleEntity = new Vehicle()
            {
                VehicleName = addVehicleDto.VehicleName,
                EngineCapacity = addVehicleDto.EngineCapacity,
                Price = addVehicleDto.Price,
            };

            dbContext.Vehicles.Add(VehicleEntity);
            dbContext.SaveChanges();
            return Ok(VehicleEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]

        public IActionResult UpdateVehicle(UpdateVehicleDto updateVehicleDto, Guid id)
        {
            var vehicle = dbContext.Vehicles.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            vehicle.VehicleName = updateVehicleDto.VehicleName;
            vehicle.EngineCapacity = updateVehicleDto.EngineCapacity;
            vehicle.Price = updateVehicleDto.Price;

            dbContext.SaveChanges();
            return Ok(vehicle);
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult DeleteVehicle(Guid id)
        {
            var Vehicle = dbContext.Vehicles.Find(id);
            if (Vehicle == null)
            {
                return NotFound();
            }
            dbContext.Remove(Vehicle);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
