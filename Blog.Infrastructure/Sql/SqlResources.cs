namespace Blog.Infrastructure.Sql
{
    public static class SqlResources
    {
        #region MIGRATION TABLE
        public const string CreateUserTable      = "Blog.Infrastructure.Sql.Migrations.CreateUserTable.sql"; 
        public const string InsertVersion        = "Blog.Infrastructure.Sql.Migrations.InsertVersion.sql"; 
        public const string UpdateVersion        = "Blog.Infrastructure.Sql.Migrations.UpdateVersion.sql"; 
        public const string CreateVersionTable   = "Blog.Infrastructure.Sql.Migrations.CreateVersionTable.sql"; 
        public const string GetVersion           = "Blog.Infrastructure.Sql.Migrations.GetVersion.sql"; 
        public const string CreateRoleTable      = "Blog.Infrastructure.Sql.Migrations.CreateRoleTable.sql"; 
        public const string CreateUserRolesTable = "Blog.Infrastructure.Sql.Migrations.CreateUserRoleTable.sql"; 
        #endregion
        #region USER
        public const string GetAllUsers              = "Blog.Infrastructure.Sql.Users.GetAllUsers.sql";
        public const string GetUser                  = "Blog.Infrastructure.Sql.Users.GetUser.sql";
        public const string InsertUser               = "Blog.Infrastructure.Sql.Users.InsertUser.sql";
        public const string UpdateUser               = "Blog.Infrastructure.Sql.Users.UpdateUser.sql";
        public const string DeleteUser               = "Blog.Infrastructure.Sql.Users.DeleteUser.sql";
        public const string CheckUserByNameOrByEmail = "Blog.Infrastructure.Sql.Users.CheckUserByNameOrByEmail.sql";
        public const string GetUserByName            = "Blog.Infrastructure.Sql.Users.GetUserByName.sql"; 
        public const string GetUserByEmail           = "Blog.Infrastructure.Sql.Users.GetUserByEmail.sql";
        public const string AddRoleUser              = "Blog.Infrastructure.Sql.Users.AddRoleUser.sql";
        #endregion

        #region ROLE
        public const string InsertRole  = "Blog.Infrastructure.Sql.Roles.InsertRole.sql";
        public const string UpdateRole  = "Blog.Infrastructure.Sql.Roles.UpdateRole.sql";
        public const string DeleteRole  = "Blog.Infrastructure.Sql.Roles.DeleteRole.sql"; 
        public const string GetAllRoles = "Blog.Infrastructure.Sql.Roles.GetAllRoles.sql";
        public const string GetRole     = "Blog.Infrastructure.Sql.Roles.GetRole.sql";
        public const string GetRoleByName = "Blog.Infrastructure.Sql.Roles.GetRoleByName.sql";
        public const string CheckRoleByName = "Blog.Infrastructure.Sql.Roles.CheckRoleByName.sql";
        public const string GetRoleByUserId = "Blog.Infrastructure.Sql.Roles.GetRoleByUserId.sql";
        #endregion

    }
}
