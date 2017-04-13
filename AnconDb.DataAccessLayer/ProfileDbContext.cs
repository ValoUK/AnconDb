using System.Data.Entity;
using AnconDb.DataAccessLayer.Entities;
using AnconDb.DataAccessLayer.Configurations;

namespace AnconDb.DataAccessLayer
{
    public class ProfileDbContext : DbContext
    {
        public ProfileDbContext(string connectionStringName)
        {
            this.Configuration.LazyLoadingEnabled = true; //TODO: should this really be enabled?
        }

        public ProfileDbContext()
            : base("name=AnconProfilesDbConnection") //DefaultConnection
        {
            this.Configuration.LazyLoadingEnabled = true; //TODO: should this really be enabled?
            Database.SetInitializer<ProfileDbContext>(new DropCreateAlwaysInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProfileConfiguration());
            modelBuilder.Configurations.Add(new ProfilePointConfiguration());
        }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<ProfilePoint> ProfilePoints { get; set; }
    }
}
