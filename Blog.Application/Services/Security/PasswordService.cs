using Blog.Application.Interfaces.Security;
using System.Text;

namespace Blog.Application.Services.Security
{
    internal class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            return _HashPassword(password);
        }

        public string HashPasswordWithSalt(string password, string salt)
        {
            return _HashPassword(string.Concat(password, salt));
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return _HashPassword(password) == hashedPassword;
        }

        public bool VerifyPasswordWithSalt(string password, string salt, string hashedPassword)
        {
            return _HashPassword(string.Concat(password, salt)) == hashedPassword;
        }

        string _HashPassword(string password)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hashed = sha256.ComputeHash(bytes);
           // return Encoding.UTF8.GetString(hashed);
            return Convert.ToBase64String(hashed);
        }
    }
}
