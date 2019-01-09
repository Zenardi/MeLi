using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using meli.Controllers.Resources;
using meli.Models;
using meli.Persistence;
using Microsoft.EntityFrameworkCore;

namespace meli.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly MeliDbContext context;

        public VehiclesController(IMapper mapper, MeliDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
        if (!ModelState.IsValid)
          return BadRequest(ModelState);

        var vehicle = await context.Vehicles
          .Include(v => v.Features)
            .ThenInclude(vf => vf.Feature)
          .Include(v => v.Model)
            .ThenInclude(m => m.Maker)
          .SingleOrDefaultAsync(v => v.Id == id);

        if (vehicle == null)
          return NotFound();

        mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
        vehicle.LastUpdate = DateTime.Now;

        await context.SaveChangesAsync();

        var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

        return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            vehicle = await context.Vehicles
                .Include(vf=>vf.Features)
                    .ThenInclude(vf => vf.Feature)
                .Include(vf => vf.Model)
                    .ThenInclude(m=>m.Maker)
                .SingleOrDefaultAsync(v1=>v1.Id==vehicle.Id);

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var v = await context.Vehicles.FindAsync(id);
            if(v == null)
                return NotFound();


            context.Remove(v);
            await context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
        var vehicle = await context.Vehicles
          .Include(v => v.Features)
            .ThenInclude(vf => vf.Feature)
          .Include(v => v.Model)
            .ThenInclude(m => m.Maker)
          .SingleOrDefaultAsync(v => v.Id == id);

        if (vehicle == null)
          return NotFound();

        var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

        return Ok(vehicleResource);
        }
    }
}