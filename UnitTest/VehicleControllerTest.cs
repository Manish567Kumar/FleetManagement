using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FleetManagement.Models;
using Microsoft.AspNetCore.Cors;
using FleetManagement.Interfaces;
using FleetManagement.Services;
using FleetManagement.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //public class VehiclesControllerTest : ControllerBase
    //{
    //    private  VehicleService _service;
    //    public VehiclesControllerTest(VehicleService service)
    //    {
    //        _service = service;
    //    }
    //    [HttpGet]
    //    public IActionResult Get()
    //    {
    //        var items = _service.GetAllItems();
    //        return Ok(items);
    //    }
    //    [HttpGet("{id}")]
    //    public IActionResult GetById(long id)
    //    {
    //        var item = _service.GetById(id);
    //        if (item == null)
    //        {
    //            return NotFound();
    //        }
    //        return Ok(item);
    //    }
    //    [HttpPost]
    //    public IActionResult Post([FromBody] Vehicle value)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }
    //        var item = _service.Add(value);
    //        return CreatedAtAction("Get", new { id = item.VehicleId }, item);
    //    }
    //    [HttpDelete("{id}")]
    //    public IActionResult Remove(long id)
    //    {
    //        var existingItem = _service.GetById(id);
    //        if (existingItem == null)
    //        {
    //            return NotFound();
    //        }
    //        _service.Delete(id);
    //        return NoContent();
    //    }
    //}
}
