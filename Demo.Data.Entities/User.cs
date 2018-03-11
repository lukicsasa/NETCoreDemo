using System.Collections.Generic;

namespace Demo.Data.Entities
{
    public partial class User
    {
        public User()
        {
            Exam = new HashSet<Exam>();
            Subject = new HashSet<Subject>();
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool Archived { get; set; }
        public long RoleId { get; set; }

        public Role Role { get; set; }
        public ICollection<Exam> Exam { get; set; }
        public ICollection<Subject> Subject { get; set; }
    }
}
