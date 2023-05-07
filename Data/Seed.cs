using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using VinniDatingApp.Entities;

namespace VinniDatingApp.Data
{
    public static class Seed
    {

        public static async Task SeedUsers(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var UserData = await File.ReadAllTextAsync("Data/UserSeedData.json");

            var options= new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var users=JsonSerializer.Deserialize<List<AppUser>>(UserData);

            foreach (var user in users)
            {
               var hmac = new HMACSHA512();
                user.UserName=user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("P@ssw0rd7"));
                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
        }
    }
}
