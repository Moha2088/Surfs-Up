using Microsoft.AspNetCore.Mvc;
using LuxurySeedData.Models;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using SeedData.Models;

namespace Surfsproject.API.Controllers.v1
{

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BoardsController : ControllerBase
    {
        private readonly SurfboardsContext _Normalcontext;

        public BoardsController(SurfboardsContext Normalcontext)
        {
            _Normalcontext = Normalcontext;

            _Normalcontext.Database.EnsureCreated();
        }

        [HttpGet]
        public ActionResult<LuxurySeedData.Models.LuxurySurfboardsModel> GetSeedData()
        {   
            return Ok(_Normalcontext.Surfboards.ToArray());
        }

        [HttpPost]
        public async Task<ActionResult<SurfboardsModel>> Postboard(SurfboardsModel surfboards)
        {
            _Normalcontext.Surfboards.Add(surfboards);
            await _Normalcontext.SaveChangesAsync();

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
            _Normalcontext.Entry(surfboards).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            try
            {
                await _Normalcontext.SaveChangesAsync();
            }

            //Error handling for concurrency
            catch (DbUpdateConcurrencyException)
            {
                if (!_Normalcontext.Surfboards.Any(p => p.Id == id))
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
            var surfboards = await _Normalcontext.Surfboards.FindAsync(id);
            if (surfboards == null)
            {
                return NotFound();
            }

            _Normalcontext.Surfboards.Remove(surfboards);
            await _Normalcontext.SaveChangesAsync();

            return surfboards;
        }

        /*[HttpPost("{id}")]
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
        }*/

    }
}


