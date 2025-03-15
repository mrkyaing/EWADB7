using Microsoft.AspNetCore.Identity;

namespace HRMS.Web.Services {
    public class UserServie : IUserService {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<UserServie> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private const string ROLE_NAME = "Employee";
        public UserServie(UserManager<IdentityUser> userManager, ILogger<UserServie> logger, RoleManager<IdentityRole> roleManager) {
            this._userManager = userManager;
            this._logger = logger;
            this._roleManager = roleManager;
        }

        public async Task<string> CreateUserWithRole(string userName, string email) {
            string userId = "unknown";
            try {
                string defaultSystemPassword = "smartHR@101";
                var user = CreateUser();
                user.UserName = userName;
                user.Email = email;
                user.NormalizedUserName = userName;
                user.NormalizedEmail = email;
                var result = await _userManager.CreateAsync(user, defaultSystemPassword);
                if (result.Succeeded) {
                    _logger.LogInformation("User created a new account with password.");
                    userId = await _userManager.GetUserIdAsync(user);

                    // Assign "Employee" role to the user
                    var roleExists = await _roleManager.RoleExistsAsync(ROLE_NAME);
                    if (!roleExists) {
                        await _roleManager.CreateAsync(new IdentityRole(ROLE_NAME));
                    }
                    await _userManager.AddToRoleAsync(user, ROLE_NAME);
                }
            }
            catch (Exception e) {
                _logger.LogError(e, "An error occurred while creating the user.");
                throw;
            }
            return userId;
        }

        private IdentityUser CreateUser() {
            try {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
    }
}