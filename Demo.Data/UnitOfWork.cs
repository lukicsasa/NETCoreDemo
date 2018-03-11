using Demo.Data.Entities;
using Demo.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Data
{
    public class UnitOfWork : IDisposable
    {
        private DbContext _context;
        private DbContextOptions<DemoContext> _options;

        public DbContext DataContext => _context ?? (_context = new DemoContext());

        #region Repositories

        private UserRepository _userRepository;
        public UserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(DataContext));

        private ExamRepository _examRepository;
        public ExamRepository ExamRepository => _examRepository ?? (_examRepository = new ExamRepository(DataContext));

        private SubjectRepository _subjectRepository;
        public SubjectRepository SubjectRepository => _subjectRepository ?? (_subjectRepository = new SubjectRepository(DataContext));

        #endregion

        public void Save()
        {
            _context.ChangeTracker.DetectChanges();
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    if (_context != null)
                        _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
