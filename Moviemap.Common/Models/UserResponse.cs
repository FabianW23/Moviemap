using Moviemap.Common.Emuns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moviemap.Common.Models
{
    public class UserResponse
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Document { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserType UserType { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
