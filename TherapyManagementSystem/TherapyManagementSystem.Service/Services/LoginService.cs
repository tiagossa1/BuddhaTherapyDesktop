using System;
using System.Collections.Generic;
using System.Text;
using TherapyManagementSystem.Domain.Entities;
using TherapyManagementSystem.Infrastructure.Data.Repository;
using BCrypt;

namespace TherapyManagementSystem.Service.Services
{
    public class LoginService
    {
        public Login Login { get; }

        public LoginService(Login login)
        {
            Login = login ?? throw new ArgumentNullException(nameof(login));
        }

        public bool VerifyLoginCredentials()
        {
            var loginRepository = new BaseRepository<Login>();
            return loginRepository.CheckIfExists(x => x.Username == Login.Username && x.Password == BCrypt.Net.BCrypt.HashPassword(Login.Password));
        }
    }
}
