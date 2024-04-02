using Domain.Constants.Permission;
using Domain.Constants.Role;
using Domain.Constants.User;
using Domain.Modules.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Persistence.Context;
using Persistence.Helpers;
using Shared.Interfaces.Services;

namespace Persistence
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly ILogger<DatabaseSeeder> _logger;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<RoleApp> _roleManager;

        public DatabaseSeeder(
            UserManager<User> userManager,
            RoleManager<RoleApp> roleManager,
            ApplicationDbContext db,
            ILogger<DatabaseSeeder> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
            _logger = logger;
        }

        public void Initialize()
        {
            AddAdministrator();
            AddBasicUser();
            _db.SaveChanges();
        }

        private void AddAdministrator()
        {
            Task.Run(async () =>
            {
                //Check if Role Exists
                var adminRole = new RoleApp(RoleConstants.AdministratorRole, "Administrator role with full permissions");
                var adminRoleInDb = await _roleManager.FindByNameAsync(RoleConstants.AdministratorRole);
                if (adminRoleInDb == null)
                {
                    await _roleManager.CreateAsync(adminRole);
                    adminRoleInDb = await _roleManager.FindByNameAsync(RoleConstants.AdministratorRole);
                    _logger.LogInformation("Seeded Administrator Role.");
                }
                //Check if User Exists
                var superUser = new User
                {
                    FirstName = "Rafal",
                    LastName = "Kadow",
                    Email = "rafal.kadow@gmail.com",
                    UserName = "admin",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CreatedOnDateTimeUTC = DateTime.Now,
                    IsActive = true
                };
                var superUserInDb = await _userManager.FindByEmailAsync(superUser.Email);
                if (superUserInDb == null)
                {
                    await _userManager.CreateAsync(superUser, UserConstants.DefaultPassword);
                    var result = await _userManager.AddToRoleAsync(superUser, RoleConstants.AdministratorRole);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("Seeded Default SuperAdmin User.");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            _logger.LogError(error.Description);
                        }
                    }
                }
                foreach (var permission in Permissions.GetRegisteredPermissions())
                {
                    await _roleManager.AddPermissionClaim(adminRoleInDb, permission);
                }
            }).GetAwaiter().GetResult();
        }

        private void AddBasicUser()
        {
            Task.Run(async () =>
            {
                //Check if Role Exists
                var basicRole = new RoleApp(RoleConstants.BasicRole, "Basic role with default permissions");
                var basicRoleInDb = await _roleManager.FindByNameAsync(RoleConstants.BasicRole);
                if (basicRoleInDb == null)
                {
                    await _roleManager.CreateAsync(basicRole);
                    _logger.LogInformation("Seeded Basic Role.");
                }
                //Check if User Exists
                var basicUser = new User
                {
                    FirstName = "User",
                    LastName = "App",
                    Email = "user@gmail.com",
                    UserName = "user",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CreatedOnDateTimeUTC = DateTime.Now,
                    IsActive = true
                };
                var basicUserInDb = await _userManager.FindByEmailAsync(basicUser.Email);
                if (basicUserInDb == null)
                {
                    await _userManager.CreateAsync(basicUser, UserConstants.DefaultPassword);
                    await _userManager.AddToRoleAsync(basicUser, RoleConstants.BasicRole);
                    _logger.LogInformation("Seeded User with Basic Role.");
                }
            }).GetAwaiter().GetResult();
        }
    }
}