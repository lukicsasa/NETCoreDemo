using Demo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Data.Repositories
{
    public class ExamRepository : GenericRepository<Exam>
    {
        public ExamRepository(DbContext context) : base(context)
        {

        }
    }
}
