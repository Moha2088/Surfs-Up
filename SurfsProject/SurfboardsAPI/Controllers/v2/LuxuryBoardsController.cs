using Microsoft.AspNetCore.Mvc;
using LuxurySeedData.Models;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using SurfsProject.API.SeedDataModel.Models;
using SurfsProject.API.LuxurySeedData.Models;
using LuxuryAPI.Models;
using API.Models;

namespace Surfsproject.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
        public class LuxuryBoardsController : ControllerBase
        {
            private readonly LuxuryContext _Luxurycontext;

            public LuxuryBoardsController(LuxuryContext Luxurycontext)
            {
                _Luxurycontext = Luxurycontext;

            _Luxurycontext.Database.EnsureCreated();
            }

            /*[HttpGet("api2/LuxuryBoards/SeedData")]
            public ActionResult<LuxurySeedData.Models.LuxurySurfboardsModel> GetSeedData()
            {
                return Ok(_context.Surfboards.ToArray());
            }
            */

            [HttpGet]
            public ActionResult<LuxurySeedData.Models.LuxurySurfboardsModel> GetLuxurySeedData()
            {
                return Ok(_Luxurycontext.LuxurySurfboards.ToArray());
            }

            [HttpPost]
            public async Task<ActionResult<LuxurySurfboardsModel>> Postboard(LuxurySurfboardsModel LuxurySurfboards)
            {
                _Luxurycontext.LuxurySurfboards.Add(LuxurySurfboards);
                await _Luxurycontext.SaveChangesAsync();

                return CreatedAtAction(
                    "GetSurfboards",
                    new { name = LuxurySurfboards.Name },
                    LuxurySurfboards);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult> PutBoard(int id, LuxurySurfboardsModel LuxurySurfboards)
            {
                //Does Surfboard have same ID as Id in URI?
                if (id != LuxurySurfboards.Id)
                {
                    return BadRequest();
                }

                //Set Surfboard to "Modified"
                _Luxurycontext.Entry(LuxurySurfboards).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                try
                {
                    await _Luxurycontext.SaveChangesAsync();
                }

                //Error handling for concurrency
                catch (DbUpdateConcurrencyException)
                {
                    if (!_Luxurycontext.LuxurySurfboards.Any(p => p.Id == id))
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
            public async Task<ActionResult<LuxurySurfboardsModel>> DeleteBoard(int id)
            {
                var LuxurySurfboards = await _Luxurycontext.LuxurySurfboards.FindAsync(id);
                if (LuxurySurfboards == null)
                {
                    return NotFound();
                }

                _Luxurycontext.LuxurySurfboards.Remove(LuxurySurfboards);
                await _Luxurycontext.SaveChangesAsync();

                return LuxurySurfboards;
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


