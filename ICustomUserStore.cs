using Microsoft.AspNet.Identity;
using PROG3A_POE.Models;

namespace PROG3A_POE.Auth
{
    public interface ICustomUserStore
    {
        Task CreateAsync(ApplicationUser user);
        Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken);
        Task DeleteAsync(ApplicationUser user);
        Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken);
        void Dispose();
        Task<ApplicationUser> FindByIdAsync(string userId);
        Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken);
        Task<ApplicationUser> FindByNameAsync(string userName);
        Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken);
        Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken);
        Task<string> GetPasswordHashAsync(ApplicationUser user);
        Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken);
        Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken);
        Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken);
        Task<bool> HasPasswordAsync(ApplicationUser user);
        Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken);
        Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken);
        Task SetPasswordHashAsync(ApplicationUser user, string passwordHash);
        Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken);
        Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken);
        Task UpdateAsync(ApplicationUser user);
        Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken);
    }
}