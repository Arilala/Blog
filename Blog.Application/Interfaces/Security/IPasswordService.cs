using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Interfaces.Security
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);

        string HashPasswordWithSalt(string password, string salt);
        bool VerifyPasswordWithSalt(string password, string salt, string hashedPassword);
    }
}
