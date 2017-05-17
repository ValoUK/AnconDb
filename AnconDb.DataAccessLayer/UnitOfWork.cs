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
        //private readonly NoisePowerDistanceDbContext _npdContext;

        public UnitOfWork(ProfileDbContext context/*, NoisePowerDistanceDbContext npdContext*/)
        {
            _context = context;
            //_npdContext = npdContext;
            Profiles = new ProfileRepository(_context);
            ProfilePoints = new ProfilePointRepository(_context);
            //NpdDataTable = new NpdDataRowRepository(_npdContext);
        }

        public ProfileRepository Profiles { get; }

        public ProfilePointRepository ProfilePoints { get; }

        //public NpdDataRowRepository NpdDataTable { get; }

        public int Complete()
        {
            return _context.SaveChanges() /*+ _npdContext.SaveChanges()*/;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
