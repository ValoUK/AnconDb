using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnconDb.DataAccessLayer.Entities
{
    public class NpdDataRow : IEntity
    {
        public int Id { get; set; }

        public string NpdId { get; set; }

        public string NoiseMetric { get; set; }

        public string OpMode { get; set; }

        public double PowerSetting { get; set; }

        public string Year { get; set; }

        public double Log200_ft { get; set; }

        public double Log400_ft { get; set; }

        public double Log630_ft { get; set; }

        public double Log1000_ft { get; set; }

        public double Log2000_ft { get; set; }

        public double Log4000_ft { get; set; }

        public double Log6300_ft { get; set; }

        public double Log10000_ft { get; set; }

        public double Log16000_ft { get; set; }

        public double Log25000_ft { get; set; }
    }
}
