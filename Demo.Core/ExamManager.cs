using Demo.Common.Helpers;
using Demo.Data;
using Demo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Core
{
    public class ExamManager
    {
        public Exam Add(Exam exam)
        {
            using (var uow = new UnitOfWork())
            {
                exam.Date = DateTime.UtcNow;
                var user = uow.UserRepository.GetById(exam.UserId);
                ValidationHelper.ValidateNotNull(user);

                var subject = uow.SubjectRepository.GetById(exam.SubjectId);
                ValidationHelper.ValidateNotNull(subject);

                var existingExam = uow.ExamRepository.FirstOrDefault(a => a.Date.Date == exam.Date.Date && a.UserId == exam.UserId && a.SubjectId == exam.SubjectId);
                ValidationHelper.ValidateEntityExists(existingExam);

                uow.ExamRepository.Add(exam);
                uow.Save();

                return exam;
            }
        }

        public List<Exam> GetResults(long userId)
        {
            using (var uow = new UnitOfWork())
            {
                var exams = uow.ExamRepository.Find(a => a.UserId == userId, "User,Subject");
                return exams.ToList();
            }
        }

        public List<Exam> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                var exams = uow.ExamRepository.Find(a => true, "User,Subject").OrderByDescending(o => o.Date);
                return exams.ToList();
            }
        }
    }
}
