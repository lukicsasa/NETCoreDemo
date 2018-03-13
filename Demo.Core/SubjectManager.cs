using Demo.Data;
using Demo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core
{
    public class SubjectManager
    {
        public Subject Add(Subject subject, long currentUserId)
        {
            using(var uow = new UnitOfWork())
            {
                subject.CreatedBy = currentUserId;
                uow.SubjectRepository.Add(subject);
                uow.Save();

                return subject;
            }
        }
    }
}
