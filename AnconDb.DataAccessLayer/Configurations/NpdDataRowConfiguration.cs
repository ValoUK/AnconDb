using System.Data.Entity.ModelConfiguration;
using AnconDb.DataAccessLayer.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnconDb.DataAccessLayer.Configurations
{
    public class NpdDataRowConfiguration : EntityTypeConfiguration<NpdDataRow>
    {
        public NpdDataRowConfiguration()
        {
            Property(n => n.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasKey(n => new { n.NpdId, n.NoiseMetric, n.OpMode, n.PowerSetting });   

        }
    }
}
