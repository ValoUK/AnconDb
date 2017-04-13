using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnconDb.DataAccessLayer.Repositories;

namespace AnconDb.DataAccessLayer
{
    public class UnitOfWork : IDisposable
    {
        private readonly ProfileDbContext _context;

        public UnitOfWork(ProfileDbContext context)
        {
            _context = context;
            Profiles = new ProfileRepository(context);
            ProfilePoints = new ProfilePointRepository(context);
        }

        public ProfileRepository Profiles { get; }

        public ProfilePointRepository ProfilePoints { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
