using Demo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(DbContext context) : base(context)
        {

        }
    }
}
