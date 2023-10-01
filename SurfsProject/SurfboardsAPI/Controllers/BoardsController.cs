using Surfsproject.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using SeedDataAPI.Models;
using SeedDataAPI;
using System.Linq;
using API.Models;

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
        public IEnumerable<SeedDataAPI.Models.SurfboardsAPI> GetSeedDataAPI()
        {
            return _context.Surfboards.ToArray();
        }

    }
}

