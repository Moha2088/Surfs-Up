using Surfsproject.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using SeedDataModel.Models;
using SeedDataModel;
using System.Linq;
using API.Models;
using System.Net.Http;
using Azure;
using Microsoft.EntityFrameworkCore;

namespace Surfsproject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : Controller
    {
        public readonly SurfboardsContext _context;

        public BoardsController(SurfboardsContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IEnumerable<SeedDataModel.Models.SurfboardsModel> GetSeedData()
        {
            return _context.Surfboards.ToArray();
        }

        [HttpPost]
        public async Task<ActionResult<SurfboardsModel>> Postboard(SurfboardsModel surfboards)
        {
            _context.Surfboards.Add(surfboards);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetSurfboards",
                new { name = surfboards.Name },
                surfboards);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutBoard(int id, SurfboardsModel surfboards)
        {
            //Does Surfboard have same ID as Id in URI?
            if (id != surfboards.Id)
            {
                return BadRequest();
            }

            //Set Surfboard to "Modified"
            _context.Entry(surfboards).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }

            //Error handling for concurrency
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Surfboards.Any(p => p.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //Everything went according to plan  
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SurfboardsModel>> DeleteBoard(int id)
        {
            var surfboards = await _context.Surfboards.FindAsync(id);
            if (surfboards == null)
            {
                return NotFound();
            }

            _context.Surfboards.Remove(surfboards);
            await _context.SaveChangesAsync();

            return surfboards;
        }

        [HttpPost("{id}")]
        [Route("Delete")]
        public async Task<ActionResult> DeleteMultiple([FromQuery] int[] ids)
        {
            var surfboards = new List<SurfboardsModel>();
            foreach (var id in ids)
            {
                var Surfboards = await _context.Surfboards.FindAsync(id);

                if (surfboards == null)
                {
                    return NotFound();
                }
                surfboards.Add(Surfboards);
            }


            _context.Surfboards.RemoveRange(surfboards);
            await _context.SaveChangesAsync();

            return Ok(surfboards);
        }

    }
}

