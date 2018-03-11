using Demo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Data.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>
    {
        public SubjectRepository(DbContext context) : base(context)
        {

        }
    }
}
