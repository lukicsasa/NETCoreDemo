using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.API.Helpers;
using Demo.API.Models.Exam;
using Demo.API.Models.User;
using Demo.Common.Exceptions;
using Demo.Common.Helpers;
using Demo.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers
{
    [ValidateModel]
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("Register")]
        public UserModel Register([FromBody]RegisterModel registerModel)
        {
            var user = UserManager.Register(Mapper.AutoMap<RegisterModel, User>(registerModel));
            return Mapper.AutoMap<User, UserModel>(user);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public object Login([FromBody]LoginModel loginModel)
        {
            var user = UserManager.Login(Mapper.AutoMap<LoginModel, User>(loginModel));
            return new { User = Mapper.AutoMap<User, UserModel>(user), Token = SecurityHelper.CreateLoginToken(user) };
        }

        [TokenAuthorize]
        [HttpGet]
        public UserModel Get(long id)
        {
            var user = UserManager.Get(id);
            return Mapper.AutoMap<User, UserModel>(user);
        }

        [TokenAuthorize]
        [HttpGet("{id}/results")]
        public List<ExamModel> GetResults(long id)
        {
            if (CurrentUser.RoleId == (int)UserRole.Student && CurrentUser.Id != id)
                throw new AuthenticationException("You don't have permissions to access these results!");

            List<Exam> exams = ExamManager.GetResults(id);
            return exams.Select(a => Mapper.Map(a)).ToList();
        }
    }
}