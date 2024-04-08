using Lucid_Scribe.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lucid_Scribe.Data.Data
{
    public static class DataSeed
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                await SeedEmotionsAsync(context);
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
                await SeedUsersAsync(roleManager, userManager);
            }
        }

        private static async Task SeedEmotionsAsync(ApplicationDbContext context)
        {

            if (context.Emotions.Any())
            {
                return;
            }

            context.Emotions.AddRange(
                new Emotion() { Name = "Sad", IconURL = "sad.png" },
                new Emotion() { Name = "Happy", IconURL = "happy.png" },
                new Emotion() { Name = "Angry", IconURL = "angry.png" },
                new Emotion() { Name = "Nostalgic", IconURL = "nostalgic.png" }
            );

            context.Roles.AddRange(new IdentityRole() { Name = "Admin" }, new IdentityRole() { Name = "User" });
            await context.SaveChangesAsync();
        }

        private static async Task SeedUsersAsync(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            
            await SeedRoles(roleManager);

            await SeedAdminAsync(userManager);
            await SeedRegularUser(userManager);
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                string[] roles = new string[] { "ADMIN", "USER" };
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole() { Name = role });
                }
            }
        }

        private static async Task SeedAdminAsync(UserManager<AppUser> userManager)
        {
            var adminUsername = "admin@lucid-scribe.com";
            var user = await userManager.FindByNameAsync(adminUsername);
            if (user == null)
            {
                var admin = new AppUser()
                {
                    UserName = adminUsername,
                    Email = adminUsername
                };

                await userManager.CreateAsync(admin, "Pass123@");

                await userManager.AddToRoleAsync(admin, "ADMIN");
            }
        }

        private static async Task SeedRegularUser(UserManager<AppUser> userManager)
        {
            var username = "user@lucid-scribe.com";
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                var account = new AppUser()
                {
                    UserName = username,
                    Email = username
                };

                await userManager.CreateAsync(account, "Pass123@");

                await userManager.AddToRoleAsync(account, "USER");
            }
        }


    }
}
