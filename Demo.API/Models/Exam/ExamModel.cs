using Demo.API.Models.Subject;
using Demo.API.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.API.Models.Exam
{
    public class ExamModel
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public long SubjectId { get; set; }
        public DateTime Date { get; set; }
        [Required]
        [Range(5, 10, ErrorMessage = "Grade must be between 5 and 10")]
        public int Grade { get; set; }
        public SubjectModel Subject { get; set; }
        public UserModel User { get; set; }
    }
}
