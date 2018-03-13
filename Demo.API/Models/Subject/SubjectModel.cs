using Demo.API.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.API.Models.Subject
{
    public class SubjectModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public UserModel CreatedBy { get; set; }
        public long CreatedById { get; set; }
        public bool Archived { get; set; }
    }
}
