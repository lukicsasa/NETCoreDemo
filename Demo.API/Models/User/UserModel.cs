using Demo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.API.Models.User
{
    public class UserModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public RoleModel Role { get; set; }
        public bool Archived { get; set; }
    }
}
