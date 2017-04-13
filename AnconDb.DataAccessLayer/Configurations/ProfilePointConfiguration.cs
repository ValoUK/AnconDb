using System.Data.Entity.ModelConfiguration;
using AnconDb.DataAccessLayer.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnconDb.DataAccessLayer.Configurations
{
    public class ProfilePointConfiguration : EntityTypeConfiguration<ProfilePoint>
    {
        public ProfilePointConfiguration()
        {
            Property(pp => pp.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasKey(pp => new { pp.ProfileId, pp.PointNum });

            Property(pp => pp.ProfileId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(pp => pp.PointNum)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired<Profile>(pp => pp.Profile)
                .WithMany(p => p.ProfilePoints)
                .HasForeignKey(pp => pp.ProfileId);
        }
    }
}
