using System;
using System.IO;
using AnconDb.DataAccessLayer.Entities;
using System.Collections.Generic;

namespace AnconDb
{
    public class NpdFileProcessor
    {
        public void Process(string npdFilePath, List<NpdDataRow> npdDataTable)
        {            
            using (StreamReader reader = new StreamReader(npdFilePath))
            {
                var fileName = Path.GetFileNameWithoutExtension(npdFilePath);
                int year = 2000;
                int x = 10;
                if (Int32.TryParse(fileName.Substring(fileName.IndexOf('G') + 1), out x))
                {
                    year += x;
                }
                else
                {
                    throw new Exception($"File {fileName} should be renamed NOISEG**.CSV in order to be processed");
                }
                int count = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (count != 0)
                    {
                        var data = line.Trim().Split(',');
                        npdDataTable.Add(new NpdDataRow
                        {
                            NpdId = data[0].Trim(),
                            NoiseMetric = data[1].Trim(),
                            OpMode = data[2].Trim(),
                            PowerSetting = Convert.ToSingle(data[3]),
                            Year = year,
                            Log200_ft = Convert.ToDouble(data[4]),
                            Log400_ft = Convert.ToDouble(data[5]),
                            Log630_ft = Convert.ToDouble(data[6]),
                            Log1000_ft = Convert.ToDouble(data[7]),
                            Log2000_ft = Convert.ToDouble(data[8]),
                            Log4000_ft = Convert.ToDouble(data[9]),
                            Log6300_ft = Convert.ToDouble(data[10]),
                            Log10000_ft = Convert.ToDouble(data[11]),
                            Log16000_ft = Convert.ToDouble(data[12]),
                            Log25000_ft = Convert.ToDouble(data[13])
                        });
                    }
                    count++;
                }
            }
        }
    }
}
