using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SurfsProject.Data;

namespace SurfsProject.Controllers
{
    
    public class UsersController : Controller
    {
        private readonly SurfsProjectContext _context;

        public UsersController(SurfsProjectContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IQueryable<IdentityUser> users = from s in _context.Users select s;

            return View(users);
        }
    }
}
