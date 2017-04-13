using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AnconDb.DataAccessLayer
{
    class DropCreateAlwaysInitializer : DropCreateDatabaseAlways<DbContext>
    {
        protected override void Seed(DbContext context)
        {

        }
    }
}
