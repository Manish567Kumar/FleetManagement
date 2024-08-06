using FleetManagement.Interfaces;
using FleetManagement.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Web.Http;

namespace FleetManagement.Services
{
    public class VehicleService : ControllerBase, IVehicle
    {
        private readonly FleetManagementContext _context;

        private readonly List<Vehicle> _VehicleInfo;
        public VehicleService (FleetManagementContext context)
        {
            _VehicleInfo = new List<Vehicle>()
            {
                new Vehicle() { VehicleId = 1,ChassisId="1234",ChassisNumber="2323def",ChassisSeries="zer23",
                    Type="Car",Color="Red"},
                new Vehicle() { VehicleId = 2,ChassisId="123456",ChassisNumber="545",ChassisSeries="zer23",
                    Type="Truck",Color="Blue"},
                new Vehicle(){ VehicleId = 3,ChassisId="9876",ChassisNumber="2323def",ChassisSeries="zer23",
                    Type="Bus",Color="Green"}
            };
            _context = context;
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _VehicleInfo;
        }
        public ActionResult<Vehicle> GetVehicleById(long id)
        {
            try
            {
                var data = _context.Vehicle.FirstOrDefault(a => a.ChassisId == id.ToString()) ?? throw new Exception("No data found for Vehicle");
                return data;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public ActionResult AddVehicle(Vehicle vehicle)
        {
            try
            {
                if (vehicle != null)
                {
                    _context.Vehicle.Add(vehicle);
                    _context.SaveChanges();                    
                }
                return Ok("Vehicle added successfully");
            }
            catch(Exception ex)
            {
                if (ex.InnerException != null && ((Microsoft.Data.SqlClient.SqlException)ex.InnerException).Number == 2601)
                    return BadRequest("Chassis ID already exists!");
                else return BadRequest(ex.Message);
            }
        }
        public ActionResult EditVehicle(long id, Vehicle vehicle)
        {
            try
            {
                var vehicleExists = _context.Vehicle.FirstOrDefault(a => a.ChassisId == id.ToString()) ?? throw new Exception("No data found for Vehicle");
                if (vehicleExists != null)
                {
                    var vehicleInfo = _context.Vehicle.Single(e => e.ChassisId == id.ToString());
                    vehicleInfo.Color = vehicle.Color;
                    _context.Update(vehicleInfo);
                    _context.SaveChanges();
                }
                return Ok("Vehicle updated successfully");
            }
            catch( Exception ex )
            {
                return BadRequest(ex.Message);
            }
        }
        public ActionResult DeleteVehicle(long id)
        {
            try
            {
                var vehicle = _context.Vehicle.Where(x => x.ChassisId == id.ToString()).FirstOrDefault() ?? throw new Exception("No Vehicle found for Chassis ID" + id);
                _context.Vehicle.Remove(vehicle);
                _context.SaveChanges();
                return Ok("Vehicle deleted successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}