using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnconDb.DataAccessLayer.Entities;
using AnconDb.DataAccessLayer.Configurations;

namespace AnconDb.DataAccessLayer
{
    public class NoisePowerDistanceDbContext : DbContext
    {
        public NoisePowerDistanceDbContext(string connectionStringName)
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public NoisePowerDistanceDbContext()
            : base("name=NpdTablesDbConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer<NoisePowerDistanceDbContext>(new DropCreateDatabaseAlways<NoisePowerDistanceDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NpdDataRowConfiguration());
        }

        public DbSet<NpdDataRow> NpdDataTable { get; set; }
    }  
}
