using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnconDb.DataAccessLayer.Entities;

namespace AnconDb
{
    public class PrdFileProcessor
    {
        public void Process(string prdFilePath, int profileId, Profile pro, List<ProfilePoint> profilePoints)
        {
            string name = Path.GetFileNameWithoutExtension(prdFilePath);
            string opType = name.Substring(0, 1);
            if (opType != "A")
                opType = "D";
            pro.Name = name;
            pro.OperationType = opType;

            using (var file = new StreamReader(prdFilePath))
            {
                string line;
                int count = 0;
                int ptNum = 1;
                try
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if (count == 0)
                        {
                            var data = line.Split(',');
                            pro.NpdId = data[0].Trim();
                            pro.NpdAdjustment_dB = Convert.ToDouble(data[1]);
                            count++;
                            continue;
                        }
                        else if (count == 1)
                        {
                            var data = line.Split(',');
                            pro.Weight_kg = Convert.ToDouble(data[0]);
                            pro.NumberOfEngines = Convert.ToInt32(data[1]);
                            pro.EngineType = data[2].Trim();
                            pro.EngineInstallType = data[3].Trim();
                            count++;
                            continue;
                        }
                        else if (count == 2)
                        {
                            if (line.Contains("FEET"))
                                pro.Units = true;
                            else
                                pro.Units = false;
                            count++;
                            continue;
                        }
                        else
                        {
                            //TODO: process the lines that contain year and Airport code
                            if (String.IsNullOrWhiteSpace(line) ||
                                line.Substring(0, 2).Contains(">"))
                            {
                                continue;
                            }
                            var data = line.Split(',');

                            profilePoints.Add(new ProfilePoint
                            {
                                ProfileId = profileId,
                                PointNum = ptNum,
                                Distance = Convert.ToDouble(data[0]),
                                Altitude = Convert.ToDouble(data[1]),
                                Speed = Convert.ToDouble(data[2]),
                                ThrustSet_lbe = Convert.ToDouble(data[3])
                            });

                            count++;
                            ptNum++;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception($"Error reading file {prdFilePath} - profile #{profileId} - point #{ptNum}");
                }
            }

        }
    }
}
