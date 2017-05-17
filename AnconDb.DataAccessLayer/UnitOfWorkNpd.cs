using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnconDb.DataAccessLayer.Entities;
using AnconDb.DataAccessLayer.Repositories;

namespace AnconDb.DataAccessLayer
{
    public class UnitOfWorkNpd : IDisposable
    {
        private readonly NoisePowerDistanceDbContext _context;

        public UnitOfWorkNpd(NoisePowerDistanceDbContext context)
        {
            _context = context;
            NpdDataTable = new NpdDataRowRepository(_context);
        }

        public NpdDataRowRepository NpdDataTable { get; } 

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
