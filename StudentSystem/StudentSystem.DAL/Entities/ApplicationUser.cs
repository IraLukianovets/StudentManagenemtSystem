using System.Collections.Generic;

namespace StudentSystem.DAL.Entities
{
    public class ApplicationUser : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}