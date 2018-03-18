using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.API.Helpers;
using Demo.API.Models.Exam;
using Demo.Core;
using Demo.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Exam")]
    [ValidateModel]
    public class ExamController : BaseController
    {
        [TokenAuthorize(Roles = "Professor")]
        [HttpPost]
        public ExamModel Add([FromBody]ExamModel examModel)
        {
            var exam = ExamManager.Add(Mapper.AutoMap<ExamModel, Exam>(examModel));
            return Mapper.Map(exam);
        }

        [TokenAuthorize(Roles = "Professor")]
        [HttpGet("All")]
        public List<ExamModel> GetAll()
        {
            var exams = ExamManager.GetAll();
            return exams.Select(s => Mapper.Map(s)).ToList();
        }
    }
}