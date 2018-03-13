using AutoMapper;
using Demo.API.Models.Exam;
using Demo.API.Models.Subject;
using Demo.API.Models.User;
using Demo.Data.Entities;

namespace Demo.API.Helpers
{
    public static class Mapper
    {
        public static TDestination AutoMap<TSource, TDestination>(TSource source)
            where TDestination : class
            where TSource : class
        {
            var config = new MapperConfiguration(c => c.CreateMap<TSource, TDestination>());
            var mapper = config.CreateMapper();
            return mapper.Map<TDestination>(source);
        }

        public static SubjectModel Map(Subject subject)
        {
            return new SubjectModel
            {
                Id = subject.Id,
                Archived = subject.Archived,
                Name = subject.Name,
                CreatedById = subject.CreatedBy,
                CreatedBy = AutoMap<User, UserModel>(subject.CreatedByNavigation)
            };
        }

        public static ExamModel Map(Exam exam)
        {
            return new ExamModel
            {
                Date = exam.Date,
                Grade = exam.Grade,
                Subject = Map(exam.Subject),
                User = AutoMap<User, UserModel>(exam.User),
                UserId = exam.UserId,
                SubjectId = exam.SubjectId
            };
        }
    }
}
