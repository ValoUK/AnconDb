using System.Data.Entity.ModelConfiguration;
using AnconDb.DataAccessLayer.Entities;

namespace AnconDb.DataAccessLayer.Configurations
{
    public class ProfileConfiguration : EntityTypeConfiguration<Profile>
    {
        public ProfileConfiguration()
        {
            HasKey(p => p.Id);
        }
    }
}
