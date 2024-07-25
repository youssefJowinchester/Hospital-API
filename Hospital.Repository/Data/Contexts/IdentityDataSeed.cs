using Hospital.Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Data.Contexts
{
    public static class IdentityDataSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> roleManager)
        {
            // Define roles
            var roles = new List<string> { "Management", "HR", "CEO", "Development" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }


            if (_userManager.Users.Count() == 0)
            {

                var user = new ApplicationUser()
                {
                    FullName = "Ramy Elsayed",
                    Email = "Ramye301@gmail.com",
                    UserName = "Ramy.Elsayed",
                    PhoneNumber = "01123456543"
                };
                var result = await _userManager.CreateAsync(user, "Pa$$W0rd");
                if (result.Succeeded)
                {
                    // Add roles to the user
                    await _userManager.AddToRolesAsync(user, roles);
                }
            }
        }
    }
}
