using System;
using System.Collections.Generic;

namespace Demo.Data.Entities
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> User { get; set; }
    }
}
