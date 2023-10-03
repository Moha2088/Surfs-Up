using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurfsProject.Models
{
    public class User : IdentityUser
    {
        [ForeignKey("AspNetRoles")]
        public String Role { get; set; }
    }
}
