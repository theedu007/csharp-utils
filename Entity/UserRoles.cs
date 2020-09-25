using System;
using System.Collections.Generic;
using System.Text;

namespace Edu.Entity
{
    public class UserRoles
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
