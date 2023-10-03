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
        public IEnumerable<SeedDataModel.Models.SurfboardsModel> GetSeedDataModel()
        {
            return _context.Surfboards.ToArray();

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<SurfboardsModel>> GetSurfBoardAPI(int Id, SurfboardsModel SurfboardsModel)
        {
            if (_context.Surfboards == null)
            {
                return Problem("Surfboard not found");
            }

            var Surfbords = await _context.Surfboards
                .Include(model => model.Type)
                .Include(model => model.Equipment)
                .FirstOrDefaultAsync(model => model.Id == Id);
            if (SurfboardsModel == null)
            {
                return Problem("Surfboard is null");
            }

            return Ok(Surfbords);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteSurfboardsModel(int Id)
        {
            if (_context.Surfboards == null)
            {
                return NotFound();
            }
            var surfBoards = await _context.Surfboards.FindAsync(Id);
            if (surfBoards == null)
            {
                return NotFound();
            }

            _context.Surfboards.Remove(surfBoards);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SurfBoardAPIExists(int Id)
        {
            return (_context.Surfboards?.Any(e => e.Id == Id)).GetValueOrDefault();
        }

    }
    }


