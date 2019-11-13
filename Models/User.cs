using System;
using System.Collections.Generic;

namespace Randomizer_Client.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime LastAccess { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}