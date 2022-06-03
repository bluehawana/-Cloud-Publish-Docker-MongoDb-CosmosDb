using Microsoft.AspNetCore.Mvc;
using westcoast_api_mongodb.Models;
using westcoast_api_mongodb.Services;

namespace westcoast_api_mongodb.Controllers
{
  [ApiController]
  [Route("api/v2/vehicles")]
  public class VehiclesController : ControllerBase
  {
    private readonly MongoDbService _mongoDbService;
    public VehiclesController(MongoDbService mongoDbService)
    {
      _mongoDbService = mongoDbService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Vehicle>>> ListAllVehicles()
    {
      return Ok(await _mongoDbService.GetVehiclesAsync());
    }

    [HttpPost]
    public async Task<IActionResult> AddNewVehicle(Vehicle vehicle)
    {
      await _mongoDbService.CreateVehicleAsync(vehicle);
      return CreatedAtAction(nameof(ListAllVehicles), new { id = vehicle.Id, vehicle });
      //   return StatusCode(201);
    }
  }
}