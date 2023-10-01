using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SurfboardsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        [HttpGet]
        public string GetBoards()
        {
            return "OK";
        }
    }
}
