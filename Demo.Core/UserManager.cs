using Demo.Common.Exceptions;
using Demo.Common.Helpers;
using Demo.Data;
using Demo.Data.Entities;
using System.Linq;

namespace Demo.Core
{
    public class UserManager
    {
        public User Register(User user)
        {
            using(var uow = new UnitOfWork())
            {
                var userExisits = uow.UserRepository.Any(a => a.Username.ToLower() == user.Username.Trim().ToLower());
                if (userExisits)
                    throw new ValidationException("Username already exists!");

                user.Password = PasswordHelper.CreateHash(user.Password);
                user.RoleId = (int)UserRole.Student;

                uow.UserRepository.Add(user);
                uow.Save();
                return user;
            }
        }

        public User Login(User login)
        {
            using (var uow = new UnitOfWork())
            {
                var user = uow.UserRepository.FirstOrDefault(a => a.Username.ToLower() == login.Username.Trim().ToLower(), "Role");
                if (user == null) throw new ValidationException("Username doesn't exist!");

                if (!PasswordHelper.ValidatePassword(login.Password, user.Password))
                    throw new ValidationException("Wrong username or password!");

                return user;
            }
        }

        public User Get(long id)
        {
           using(var uow = new UnitOfWork())
            {
                var user = uow.UserRepository.FirstOrDefault(a => a.Id == id, "Role");
                ValidationHelper.ValidateNotNull(user);
                return user;
            }
        }
    }
}
