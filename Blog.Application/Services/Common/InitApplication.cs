using Blog.Application.Common;
using Blog.Application.Interfaces.Common;
using Blog.Application.Interfaces.Repository;
using Blog.Application.Interfaces.Security;

namespace Blog.Application.Services.Common
{
    public class InitApplication(
        IRoleRepository roleRepository,
        IUserRepository userRepository,
        IPasswordService passwordService
    ) : IInitApplication
    {
        public async Task RunInitAsync()
        {
            Domain.Entity.RoleEntity? roleAdmin = await roleRepository.GetRoleByNameAsync(RoleConstantType.Admin);
            if (roleAdmin == null)
            {
                roleAdmin = new Domain.Entity.RoleEntity
                {
                    Name = RoleConstantType.Admin,
                    Description = "Administrator role with full permissions",
                };
                await roleRepository.AddAsync(roleAdmin);
            }
            Domain.Entity.RoleEntity? roleUser = await roleRepository.GetRoleByNameAsync(RoleConstantType.User);
            if (roleUser == null)
            {
                roleUser = new Domain.Entity.RoleEntity
                {
                    Name = RoleConstantType.User,
                    Description = "Regular user role with limited permissions",
                };
                await roleRepository.AddAsync(roleUser);
            }
            Domain.Entity.UserEntity? superAdmin = await userRepository.GetUserByNameAsync(
                "superadmin"
            );
            if (superAdmin == null)
            {
                superAdmin = new Domain.Entity.UserEntity
                {
                    Username = "superadmin",
                    PasswordHash = passwordService.HashPassword("superadmin"),
                    Email = "superadmin@mail.com",
                };
                var userId = await userRepository.AddAsync(superAdmin);
                superAdmin = await userRepository.GetUserByNameAsync("superadmin");

                roleAdmin = await roleRepository.GetRoleByNameAsync(RoleConstantType.Admin);
                if (roleAdmin != null) {
                    _ = await userRepository.AddRoleToUserAsync(userId, roleAdmin.Id);
                }
                
            }

        }
    }
}
