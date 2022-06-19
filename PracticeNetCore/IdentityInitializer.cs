using Microsoft.AspNetCore.Identity;
using PracticeNetCore.Entities;

namespace PracticeNetCore
{
    public class IdentityInitializer
    {
        public static void OlusturAdmin(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            AppUser appUser = new AppUser
            {
                Name = "Mekan",
                SurName = "Hydyrov",
                UserName = "Mekan"
            };
            if (userManager.FindByNameAsync("Mekan").Result == null)
            {
              var identityResult = userManager.CreateAsync(appUser,"1").Result;
            }
            if (roleManager.FindByNameAsync("Admin").Result == null)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin"
                };
                var IdentityResult = roleManager.CreateAsync(role).Result;
                var result = userManager.AddToRoleAsync(appUser, role.Name).Result;
            }
        }
    }
}
