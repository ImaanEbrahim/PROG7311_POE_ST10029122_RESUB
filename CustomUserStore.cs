using PROG3A_POE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROG3A_POE.Auth
{
    public class CustomUserStore
    {
        private readonly List<ApplicationUser> _users = new();

        public CustomUserStore()
        {
            // Add a farmer user
            _users.Add(new ApplicationUser
            {
                Id = "1",
                UserName = "farmer1",
                PasswordHash = "Password123", // same password to test
                Email = "farmer1@example.com",
                Role = "Farmer"
            });

            // Add another farmer user
            _users.Add(new ApplicationUser
            {
                Id = "2",
                UserName = "farmer2",
                PasswordHash = "Password123", // same password to test
                Email = "farmer2@example.com",
                Role = "Farmer"
            });

            // Add an employee user
            _users.Add(new ApplicationUser
            {
                Id = "3",
                UserName = "employee1",
                PasswordHash = "Password123",
                Email = "employee1@example.com",
                Role = "Employee"
            });
        }

        public Task<ApplicationUser> ValidateUserAsync(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.UserName == username && u.PasswordHash == password);
            return Task.FromResult(user);
        }
    }
}
