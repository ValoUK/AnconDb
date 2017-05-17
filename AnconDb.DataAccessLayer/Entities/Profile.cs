using System;
using System.Collections.Generic;

namespace AnconDb.DataAccessLayer.Entities
{
    public class Profile : IEntity
    {
        public Profile()
        {
            this.ProfilePoints = new HashSet<ProfilePoint>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string NpdId { get; set; }

        /// <summary>
        /// Boolean representing the Unit system in use
        /// false: SI
        /// true: Imperial
        /// </summary>
        public bool Units { get; set; }

        public int Year { get; set; }

        public string Airport { get; set; }

        public string OperationType  { get; set; }

        public string EngineType { get; set; }

        public string EngineInstallType { get; set; }

        public int NumberOfEngines { get; set; }

        public Nullable<double> Weight_kg { get; set; }

        public Nullable<double> NpdAdjustment_dB { get; set; }

        public virtual ICollection<ProfilePoint> ProfilePoints { get; set; }
    }
}
