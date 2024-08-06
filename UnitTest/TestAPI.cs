using FleetManagement.Controllers;
using FleetManagement.Interfaces;
using FleetManagement.Models;
using FleetManagement.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UnitTest
{
    public class VehiclesControllerUnitTest
    {
        private readonly VehiclesController _controller;
        private readonly VehicleService _service;
        FleetManagementContext _context = new FleetManagementContext();

        public VehiclesControllerUnitTest(VehicleService service,VehiclesController controller)
        {
            
            _controller= new VehiclesController(service);
            _service = new VehicleService(_context);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _service.GetAllVehicles();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetVehicle() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Vehicle>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
    }
}