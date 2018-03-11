using System;

namespace Demo.Data.Entities
{
    public partial class Exam
    {
        public long UserId { get; set; }
        public long SubjectId { get; set; }
        public DateTime Date { get; set; }
        public int Grade { get; set; }

        public Subject Subject { get; set; }
        public User User { get; set; }
    }
}
