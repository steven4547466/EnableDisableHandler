using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace EnableDisableMods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Waiting for Your Only Move Is HUSTLE to close...");
            while (Process.GetProcessesByName("YourOnlyMoveIsHUSTLE").Length != 0)
            {
                Thread.Sleep(1000);
            }

            string exeLocation = args[0];

            for (int i = 1; i < args.Length; i += 3)
            {
                string name = args[i];
                string p1 = args[i + 1];
                string p2 = args[i + 2];

                Console.WriteLine($"Attempting to {(p1.Contains("zip") ? "disable" : "enable")} {name}");
                if (File.Exists(p1))
                {
                    try
                    {
                        File.Move(p1, p2);
                        Console.WriteLine("Success");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed: " + ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Failed: File doesn't exist.");
                }
            }
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
            Process.Start(exeLocation);
            Environment.Exit(0);
        }
    }
}
