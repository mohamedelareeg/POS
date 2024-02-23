using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using POS.Persistence.Context;
using POS.Persistence.Models;
using System.Collections.ObjectModel;
using System.Security.Claims;

namespace POS
{
    public class AuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private ApplicationUser _currentUser;
        private readonly AppDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }
        public async Task<string> GetSelectedRoleForUserAsync(string userName)
        {
            // Query the user by username
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                // Get the roles for the user
                var userRoles = await _userManager.GetRolesAsync(user);
                if (userRoles.Any())
                {
                    // Assuming you want to return the first role associated with the user
                    return userRoles.FirstOrDefault();
                }
            }
            return null; // Return null if user not found or has no roles
        }
        public async Task<IdentityResult> AddRoleAsync(string roleName)
        {
            // Check if the role already exists
            if (await _roleManager.RoleExistsAsync(roleName))
            {
                return IdentityResult.Failed(new IdentityError { Description = $"Role '{roleName}' already exists." });
            }

            // Create a new role
            var role = new IdentityRole(roleName);
            return await _roleManager.CreateAsync(role);
        }
        public async Task<bool> RoleExists(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }
        public async Task<IdentityResult> EditRoleNameAsync(string oldRoleName, string newRoleName)
        {
            // Find the role by its name
            var role = await _roleManager.FindByNameAsync(oldRoleName);
            if (role == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = $"Role '{oldRoleName}' not found." });
            }

            // Update the role name
            role.Name = newRoleName;
            return await _roleManager.UpdateAsync(role);
        }

        public async Task<IdentityResult> DeleteRoleAsync(string roleName)
        {
            // Find the role by its name
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = $"Role '{roleName}' not found." });
            }

            // Delete the role
            return await _roleManager.DeleteAsync(role);
        }

        public async Task<ObservableCollection<string>> LoadRolesAsync()
        {
            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return new ObservableCollection<string>(roles);
        }
        public async Task UpdateRolePermissionsAsync(string roleName, IList<string> permissionIdentifiers)
        {
            var role = await _roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                throw new ArgumentException($"Role '{roleName}' not found.");
            }

            // Remove existing role claims
            var existingClaims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in existingClaims)
            {
                await _roleManager.RemoveClaimAsync(role, claim);
            }

            // Add new role claims based on permission identifiers
            foreach (var permissionIdentifier in permissionIdentifiers)
            {
                var claim = new Claim(ClaimTypes.Role, permissionIdentifier);
                await _roleManager.AddClaimAsync(role, claim);
            }
        }

        public async Task<IEnumerable<string>> GetRoleClaimsAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role != null)
            {
                var roleClaims = await _roleManager.GetClaimsAsync(role);
                return roleClaims.Select(c => c.Value);
            }
            return Enumerable.Empty<string>();
        }
        public async Task<ObservableCollection<ApplicationUser>> LoadEmployeesAsync(string roleName = null)
        {
            // Get all users
            var users = _userManager.Users;

            if (!string.IsNullOrEmpty(roleName))
            {
                // Get users who are in the specified role
                users = users.Where(u => _userManager.IsInRoleAsync(u, roleName).Result);
            }

            // Execute the query and return the result as an ObservableCollection
            var userList = await users.ToListAsync();
            return new ObservableCollection<ApplicationUser>(userList);
        }
        public ApplicationUser CurrentUser => _currentUser;

        public async Task<bool> SignInAsync(string userName, string password, bool rememberMe)
        {
            // Check if username or password is empty
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                return false; // Return failed result for empty username or password
            }

            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                // Check if user is locked out
                if (await _userManager.IsLockedOutAsync(user))
                {
                    return false; // Return locked out result if user is locked out
                }

                // Check if user's email is confirmed if email confirmation is required
                if (_userManager.Options.SignIn.RequireConfirmedEmail && !await _userManager.IsEmailConfirmedAsync(user))
                {
                    return false; // Return not allowed result if email is not confirmed
                }

                // Check if user's phone number is confirmed if phone number confirmation is required
                if (_userManager.Options.SignIn.RequireConfirmedPhoneNumber && !await _userManager.IsPhoneNumberConfirmedAsync(user))
                {
                    return false; // Return not allowed result if phone number is not confirmed
                }

                // Attempt to sign in the user
                var result = await _userManager.CheckPasswordAsync(user, password);

                if (result)
                {
                    _currentUser = user; // Store the current user
                }

                return result; // Return the sign-in result
            }
            else
            {
                _currentUser = null;
                return false; // Return failed result for invalid user
            }
        }


        //public async Task<SignInResult> SignInAsync(string userName, string password, bool rememberMe)
        //{
        //    // Create a mock HttpContext
        //    var httpContext = new DefaultHttpContext();
        //    httpContext.RequestServices = new ServiceCollection().BuildServiceProvider();

        //    // Set the HttpContext manually on the SignInManager
        //    _signInManager.Context = httpContext;

        //    // Perform the sign-in operation
        //    return await _signInManager.PasswordSignInAsync(userName, password, rememberMe, lockoutOnFailure: false);
        //}

        public async Task SignOutAsync()
        {
            if (_currentUser != null)
            {
                _currentUser = null;
            }

            await _signInManager.SignOutAsync();
        }

        public async Task<IList<string>> GetUserRolesAsync()
        {
            if (_currentUser == null)
            {
                // If there is no current user, return null or throw an exception
                return null;
            }

            var user = await _userManager.FindByNameAsync(_currentUser.UserName);
            if (user != null)
            {
                return await _userManager.GetRolesAsync(user);
            }
            return null;
        }

        public async Task<ObservableCollection<string>> GetUserRoleClaimsAsync()
        {
            if (_currentUser == null)
            {
                // If there is no current user, return null or throw an exception
                return null;
            }

            var user = await _userManager.FindByNameAsync(_currentUser.UserName);
            if (user != null)
            {
                var roleNames = await _userManager.GetRolesAsync(user);
                var roleClaims = new List<string>();

                foreach (var roleName in roleNames)
                {
                    var role = await _roleManager.FindByNameAsync(roleName);
                    if (role != null)
                    {
                        var claims = await _roleManager.GetClaimsAsync(role);
                        foreach (var claim in claims)
                        {
                            roleClaims.Add(claim.Value);
                        }
                    }
                }

                return new ObservableCollection<string>(roleClaims);
            }

            return null;
        }




        public async Task<IdentityResult> RegisterUserAsync(string userName, string email, string password, string firstName, string lastName, string phoneNumber)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber
            };

            // Hash the password
            var hashedPassword = new PasswordHasher<ApplicationUser>().HashPassword(user, password);
            user.PasswordHash = hashedPassword;

            // Create the user with the hashed password
            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                // Add the default role "Employee" to the new user
                await _userManager.AddToRoleAsync(user, "Employee");
            }

            return result;
        }

        #region Users

        public async Task<IdentityResult> AddUserAsync(string userName, string email, string password, string firstName, string lastName, string phoneNumber, string? defaultRole)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                DefaultRole = defaultRole
            };

            // Create the user with the specified password
            return await _userManager.CreateAsync(user, password);
        }
        public async Task<IdentityResult> ChangeUserPasswordAsync(string userName, string newPassword, string oldPassword)
        {
            // Find the user by ID
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = $"User with UserName '{userName}' not found." });
            }

            // Check if newPassword is provided and update the password if it is
            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                var changePasswordResult = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
                return changePasswordResult;
            }
            else
            {
                // If newPassword is not provided, return a failed result
                return IdentityResult.Failed(new IdentityError { Description = "New password cannot be empty." });
            }
        }

        public async Task<IdentityResult> EditUserAsync(string userId, string userName, string email, string firstName, string lastName, string phoneNumber, string? defaultRole)
        {
            // Find the user by ID
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = $"User with UserName '{userName}' not found." });
            }

            // Update user properties
            user.UserName = userName;
            user.Email = email;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.PhoneNumber = phoneNumber;
            user.DefaultRole = defaultRole;



            // Update the user
            return await _userManager.UpdateAsync(user);
        }


        public async Task<IdentityResult> EditUserAsync(string userId, string userName, string email, string firstName, string lastName, string phoneNumber)
        {
            // Find the user by ID
            var user = await _userManager.FindByNameAsync(userId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = $"User with UserName '{userName}' not found." });
            }

            // Update user properties
            user.UserName = userName;
            user.Email = email;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.PhoneNumber = phoneNumber;

            // Update the user
            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> DeleteUserAsync(string userName)
        {
            // Find the user by ID
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = $"User with UserName '{userName}' not found." });
            }

            // Delete the user
            return await _userManager.DeleteAsync(user);
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            // Find the user by ID
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<ApplicationUser> GetUserByNameAsync(string userName)
        {
            // Find the user by username
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            // Find the user by email
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            // Get all users
            return await _userManager.Users.ToListAsync();
        }
        //public async Task<IdentityResult> AddUserToRoleAsync(string userId, string roleName)
        //{
        //    // Find the user by ID
        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null)
        //    {
        //        return IdentityResult.Failed(new IdentityError { Description = $"User with ID '{userId}' not found." });
        //    }

        //    // Remove user from all existing roles
        //    var userRoles = await _userManager.GetRolesAsync(user);
        //    if (userRoles.Any())
        //    {
        //        // Remove user from all existing roles
        //        foreach (var role in userRoles)
        //        {
        //            await _userManager.RemoveFromRoleAsync(user, role);
        //        }
        //    }

        //    // Assign the user to the specified role
        //    return await _userManager.AddToRoleAsync(user, roleName);
        //}
        public async Task<IdentityResult> AddUserToRoleAsync(string userName, string roleName)
        {
            // Find the user by username
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = $"User with username '{userName}' not found." });
            }

            // Remove user from all existing roles
            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles.Any())
            {
                // Remove user from all existing roles
                foreach (var role in userRoles)
                {
                    await _userManager.RemoveFromRoleAsync(user, role);
                }
            }

            // Assign the user to the specified role
            return await _userManager.AddToRoleAsync(user, roleName);
        }

        #endregion
        //public async Task SignOutAsync()
        //{
        //    // Create a mock HttpContext
        //    var httpContext = new DefaultHttpContext();
        //    httpContext.RequestServices = new ServiceCollection().BuildServiceProvider();

        //    // Set the HttpContext manually on the SignInManager
        //    _signInManager.Context = httpContext;

        //    // Perform the sign-out operation
        //    await _signInManager.SignOutAsync();
        //}
    }
}
