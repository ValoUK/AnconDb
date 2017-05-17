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
            //Profiles
            //using (var uow = new UnitOfWork(new ProfileDbContext()))
            //{
            //    int count = 0;
            //    foreach (var dir in Directory.EnumerateDirectories(@"G:\CORE\PROFILE", "PRD2016*"))
            //    {
            //        //var dir = @"G:\CORE\PROFILE\PRD2016_STN";
            //        Console.WriteLine($"Processing directory {dir}");
            //        foreach (var file in Directory.EnumerateFiles(dir, "*.PRD"))
            //        {
            //            count++;
            //            Console.WriteLine(Path.GetFileName(file));
            //            var pro = new Profile();
            //            var profilePoints = new List<ProfilePoint>();
            //            var prdFileProcessor = new PrdFileProcessor();

            //            try
            //            {
            //                prdFileProcessor.Process(file, count, pro, profilePoints);
            //                uow.Profiles.Add(pro);
            //                uow.ProfilePoints.AddRange(profilePoints);
            //            }
            //            catch (Exception e)
            //            {
            //                if (e.Message.Contains("Error reading file"))
            //                    continue;
            //                Console.WriteLine(e.Message);
            //                Console.WriteLine("Press any key to exit.");
            //                Console.ReadKey();
            //                return;
            //            }
            //        }
            //        Console.WriteLine();
            //    }

            //    try
            //    {
            //        uow.Complete();
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("An error occurred when persisting changes to database.");
            //        Console.WriteLine(e.Message);
            //        Console.WriteLine(e.StackTrace);
            //        Console.WriteLine("Press any key to exit.");
            //        Console.ReadKey();
            //        return;
            //    }
            //}

            //Console.WriteLine("Changes succesfully saved to DB.");
            //Console.WriteLine("Press any key to proceed to Npd data processing.");
            //Console.ReadKey();

            using (var uow = new UnitOfWorkNpd(new NoisePowerDistanceDbContext()))
            {
               
                foreach (var file in Directory.EnumerateFiles(@"G:\CORE\NPD", "NOISEG1*.CSV"))
                {
                    var npdDataTable = new List<NpdDataRow>();
                    var npdFileProc = new NpdFileProcessor();               
                    npdFileProc.Process(file, npdDataTable);
                    uow.NpdDataTable.AddRange(npdDataTable);
                    uow.Complete();
                }

                //try
                //{
                //    uow.Complete();
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine("An error occurred when persisting changes to database.");
                //    Console.WriteLine(e.Message);
                //    Console.WriteLine(e.StackTrace);
                //    Console.WriteLine("Press any key to exit.");
                //    Console.ReadKey();
                //    return;
                //}
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            return;
        }
    }
}
