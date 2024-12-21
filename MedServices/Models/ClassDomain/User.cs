﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedServices.Models.ClassDomain
{
    public class User
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // E.g., "Doctor", "Patient", "Admin"
        public string PhoneNumber { get; set; }
        public DateOnly CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
