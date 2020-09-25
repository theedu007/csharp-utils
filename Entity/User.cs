using System;
using System.Collections.Generic;
using System.Text;

namespace Edu.Entity
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<UserRoles> Roles { get; set; }

    }
}
