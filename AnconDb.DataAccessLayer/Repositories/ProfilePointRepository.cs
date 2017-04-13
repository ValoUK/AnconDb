using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnconDb.DataAccessLayer.Entities;

namespace AnconDb.DataAccessLayer.Repositories
{
    public class ProfilePointRepository : RepositoryBase<ProfilePoint>
    {
        public ProfilePointRepository(ProfileDbContext context) : base(context)
        {

        }
    }
}
