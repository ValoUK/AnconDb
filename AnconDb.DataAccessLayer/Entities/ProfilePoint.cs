
namespace AnconDb.DataAccessLayer.Entities
{
    public class ProfilePoint : IEntity
    {
        public int Id { get; set; }

        public int ProfileId { get; set; }

        public int PointNum { get; set; }

        public double Distance { get; set; }

        public double Altitude { get; set; }

        public double Speed { get; set; }

        public double ThrustSet_lbe { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
