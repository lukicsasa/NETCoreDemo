using Demo.Data.Entities;
using System;

namespace Demo.API.Models
{
    public class UserJwtModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
