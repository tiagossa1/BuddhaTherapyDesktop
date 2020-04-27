using System;
using System.Collections.Generic;
using System.Text;

namespace TherapyManagementSystem.Domain.Entities
{
    public class Login : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
