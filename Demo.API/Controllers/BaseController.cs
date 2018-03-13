using Demo.API.Models;
using Demo.Core;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers
{
    public abstract class BaseController : Controller
    {
        internal UserJwtModel CurrentUser { get; set; }

        private UserManager _userManager;
        internal UserManager UserManager => _userManager ?? (_userManager = new UserManager());

        private SubjectManager _subjectManager;
        internal SubjectManager SubjectManager => _subjectManager ?? (_subjectManager = new SubjectManager());

        private ExamManager _examManager;
        internal ExamManager ExamManager => _examManager ?? (_examManager = new ExamManager());
    }
}
