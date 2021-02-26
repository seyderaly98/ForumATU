using System;
using System.Threading.Tasks;
using ForumATU.Models;
using Microsoft.AspNetCore.Identity;

namespace ForumATU.Services
{
    public static class RoleInitializer
    {
        public enum Roles
        {
            Admin,
            Student,
            Teacher,
            AdministratorRestaurant
        }
        public static async Task Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            
            var roles = new[] { Roles.Admin,Roles.Student,Roles.Teacher,Roles.AdministratorRestaurant};
            foreach (var value in roles)
            {
                string role = Convert.ToString(value);
                if (await roleManager.FindByNameAsync(role) is null)
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            string adminEmail = "admin@admin.com";
            string adminPassword = "Admin123";
            if (await userManager.FindByEmailAsync(adminEmail) is null)
            {
                User admin = new User
                {
                    Email = adminEmail,
                    EmailConfirmed = true,
                    UserName = "Admin",
                    Name = "SuperAdmin",
                    Surname = "Adm"
                };
                var result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin,Convert.ToString(Roles.Admin));
            }

        }
    }
}