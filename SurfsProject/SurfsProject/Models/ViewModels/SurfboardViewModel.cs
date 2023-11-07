using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace SurfsProject.Models.ViewModels
{
    public class SurfboardViewModel
    {
        public Surfboard Surfboard { get; set; }
        public IdentityUser Rentee { get; set; }
        public string[] Equipment { get; set; }

        public SurfboardViewModel(Surfboard surfboard, IdentityUser rentee)
        {
            if (rentee == null)
            {
                if (!surfboard.Rentee.IsNullOrEmpty())
                {
                    throw new ArgumentException("A user object has not been submitted, despite the board having a rentee in the database.");
                }
            }
            else if(surfboard.Rentee.IsNullOrEmpty())
            {
                if(rentee != null)
                {
                    throw new ArgumentException("A user object has been submitted, despite the board not having a rentee in the database.");
                }
            }
            else if (surfboard.Rentee != rentee.Id)
            {
                throw new ArgumentException("Provided Rentee is not the listed Id for board Rentee.");
            }

            Surfboard = surfboard;
            Rentee = rentee;
            if(surfboard.Equipment.IsNullOrEmpty())
            {
                Equipment = new string[0];
            }
            else
            {
                string[] equipment = surfboard.Equipment.Split(',');
                for(int i = 0; i < equipment.Length; i++)
                {
                    equipment[i] = equipment[i].Trim();
                }
            }
        }
        
    }
}
