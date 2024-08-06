using Microsoft.AspNetCore.Mvc;
using FleetManagement.Models;
using Microsoft.AspNetCore.Cors;
using FleetManagement.Services;

namespace FleetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
       
        private readonly VehicleService _service;
        public VehiclesController(VehicleService service)
        {
            _service = service;
        }

        [EnableCors]
        // GET: api/Vehicles
        [HttpGet]
        public IEnumerable<Vehicle> GetVehicle()
        {
            return _service.GetAllVehicles();
        }

        // GET: api/Vehicles/5
        [EnableCors]
        [HttpGet("{id}")]
        public ActionResult<Vehicle> GetVehicle(long id)
        {
            return _service.GetVehicleById(id);
        }


        // POST: api/Vehicles        
        [EnableCors]
        [HttpPost]
        public ActionResult PostVehicle(Vehicle vehicle)
        {
            return _service.AddVehicle(vehicle);
        }

        // PUT: api/Vehicles/5        
        [EnableCors]
        [HttpPut("{id}")]
        public ActionResult PutVehicle(long id, Vehicle ExistingVehicle)
        {
            return _service.EditVehicle(id, ExistingVehicle);
        }

        // DELETE: api/Vehicles/5
        [EnableCors]
        [HttpDelete("{id}")]
        public ActionResult DeleteVehicle(long id)
        {
            return _service.DeleteVehicle(id);
        }
    }
}
