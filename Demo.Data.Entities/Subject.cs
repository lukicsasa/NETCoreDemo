using System;
using System.Collections.Generic;

namespace Demo.Data.Entities
{
    public partial class Subject
    {
        public Subject()
        {
            Exam = new HashSet<Exam>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool Archived { get; set; }
        public long CreatedBy { get; set; }

        public User CreatedByNavigation { get; set; }
        public ICollection<Exam> Exam { get; set; }
    }
}
