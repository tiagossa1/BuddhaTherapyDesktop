﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TherapyManagementSystem.Domain.Entities
{
    public class Client : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string NIF { get; set; }
        public string JobTitle { get; set; }
    }
}
