using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.API.Helpers;
using Demo.API.Models.Subject;
using Demo.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Subject")]
    public class SubjectController : BaseController
    {
        [TokenAuthorize(Roles = "Professor")]
        [HttpPost]
        public SubjectModel Add([FromBody]SubjectModel subjectModel)
        {
            var subject = SubjectManager.Add(Mapper.AutoMap<SubjectModel, Subject>(subjectModel), CurrentUser.Id);
            return Mapper.Map(subject);
        }

        [TokenAuthorize(Roles = "Professor")]
        [HttpGet("All")]
        public List<SubjectModel> GetAll()
        {
            var subjects = SubjectManager.GetAll();
            return subjects.Select(Mapper.Map).ToList();
        }
    }
}