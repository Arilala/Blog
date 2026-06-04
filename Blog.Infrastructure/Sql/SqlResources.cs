namespace Blog.Infrastructure.Sql
{
    public static class SqlResources
    {
        #region MIGRATION TABLE
        public const string CreateUserTable    = "Blog.Infrastructure.Sql.Migrations.CreateUserTable.sql"; 
        public const string InsertVersion      = "Blog.Infrastructure.Sql.Migrations.InsertVersion.sql"; 
        public const string UpdateVersion      = "Blog.Infrastructure.Sql.Migrations.UpdateVersion.sql"; 
        public const string CreateVersionTable = "Blog.Infrastructure.Sql.Migrations.CreateVersionTable.sql"; 
        public const string GetVersion         = "Blog.Infrastructure.Sql.Migrations.GetVersion.sql"; 
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
        #endregion
    }
}
