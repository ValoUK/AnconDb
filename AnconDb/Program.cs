using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnconDb.DataAccessLayer;
using AnconDb.DataAccessLayer.Entities;

namespace AnconDb
{
    class Program
    {
        /// <summary>
        /// Programs that populates the AnconProfiles database from files
        /// in G:\CORE\PROFILES
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Console.WriteLine("Creating profile...");
            //var pro = new Profile
            //{
            //    Name = "AB727_04",
            //    NpdId = "3JT8D",
            //    Units = true,
            //    Year = "2013",
            //    OperationType = "A",
            //    EngineType = "JET",
            //    EngineInstallType = "C3",
            //    NumberOfEngines = 3,
            //    Weight_kg = 65320.2d,
            //    NpdAdjustment_dB = -3d,
            //};

            //var pro2 = new Profile
            //{
            //    Name = "AB727_04",
            //    NpdId = "3JT8D",
            //    Units = true,
            //    Year = "2013",
            //    OperationType = "A",
            //    EngineType = "JET",
            //    EngineInstallType = "C3",
            //    NumberOfEngines = 3,
            //    Weight_kg = 65320.2d,
            //    NpdAdjustment_dB = -3d,
            //};

            //var pro_points = new List<ProfilePoint>();
            //pro_points.Add(new ProfilePoint
            //{
            //    ProfileId = 1,
            //    PointNum = 1,
            //    Distance = 100000d,
            //    Altitude = 3800d,
            //    Speed = 132d,
            //    ThrustSet_lbe = 2246.70786d,
            //});

            //pro_points.Add(new ProfilePoint
            //{
            //    ProfileId = 1,
            //    PointNum = 2,
            //    Distance = 40000d,
            //    Altitude = 2069d,
            //    Speed = 132d,
            //    ThrustSet_lbe = 2246.70786d,
            //});

            //pro_points.Add(new ProfilePoint
            //{
            //    ProfileId = 1,
            //    PointNum = 3,
            //    Distance = 10000d,
            //    Altitude = 522d,
            //    Speed = 80d,
            //    ThrustSet_lbe = 4123.707817d,
            //});

            using (var uow = new UnitOfWork(new ProfileDbContext()))
            {
                //    try
                //    {
                //        uow.Profiles.Add(pro);
                //        uow.ProfilePoints.AddRange(pro_points);
                //    }
                //    catch (Exception e)
                //    {
                //        Console.WriteLine(e.StackTrace);
                //        Console.WriteLine("Press any key to exit.");
                //        Console.ReadKey();
                //        return;
                //    }

                //    try
                //    {
                //        uow.Complete();
                //    }
                //    catch (Exception e)
                //    {
                //        Console.WriteLine(e.Message);
                //        Console.WriteLine(e.StackTrace);
                //        Console.WriteLine("Press any key to exit.");
                //        Console.ReadKey();
                //        return;
                //    }

                //    Console.WriteLine("Changes succesfully saved to DB.");
                //    Console.WriteLine("Press any key to exit.");
                //    Console.ReadKey();
                //    return;
                //}

                int count = 0;
                foreach (var dir in Directory.EnumerateDirectories(@"G:\CORE\PROFILE", "PRD2016*"))
                {
                    //var dir = @"G:\CORE\PROFILE\PRD2016_STN";
                    Console.WriteLine($"Processing directory {dir}");
                    foreach (var file in Directory.EnumerateFiles(dir, "*.PRD"))
                    {
                        count++;
                        Console.WriteLine(Path.GetFileName(file));
                        var pro = new Profile();
                        var profilePoints = new List<ProfilePoint>();
                        var prdFileProcessor = new PrdFileProcessor();

                        try
                        {
                            prdFileProcessor.Process(file, count, pro, profilePoints);
                            uow.Profiles.Add(pro);
                            uow.ProfilePoints.AddRange(profilePoints);
                        }
                        catch (Exception e)
                        {
                            if (e.Message.Contains("Error reading file"))
                                continue;
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Press any key to exit.");
                            Console.ReadKey();
                            return;
                        }
                    }
                    Console.WriteLine();
                }

                try
                {
                    uow.Complete();
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred when persisting changes to database.");
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                    return;
                }
            }

            Console.WriteLine("Changes succesfully saved to DB.");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            return;
        }
    }
}
