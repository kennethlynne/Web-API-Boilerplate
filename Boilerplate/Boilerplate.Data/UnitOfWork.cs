using Boilerplate.Data.Configuration;
using Boilerplate.Models;
using System;

namespace Boilerplate.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly BoilerplateDbContext _context;

        public UnitOfWork()
        {
            _context = new BoilerplateDbContext();
        }

        public UnitOfWork(BoilerplateDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
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








        private Repository<Message> _messageRepository;
        public Repository<Message> MessageRepository
        {
            get { return _messageRepository ?? (_messageRepository = new Repository<Message>(_context)); }
        }


    }
}