using System;
using System.Collections.Generic;
using System.Text;

namespace Edu.Entity
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserRoles> Users { get; set; }
    }
}
