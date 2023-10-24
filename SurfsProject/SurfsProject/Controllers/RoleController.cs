using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SurfsProject.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
    }
}
