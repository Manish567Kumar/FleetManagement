using FleetManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.Interfaces
{
    public interface IVehicle
    {
        IEnumerable<Vehicle> GetAllVehicles();
        ActionResult<Vehicle> GetVehicleById(long id);
        ActionResult AddVehicle(Vehicle vehicle);
        ActionResult EditVehicle(long id, Vehicle vehicle);
        ActionResult DeleteVehicle(long id);
    }
}