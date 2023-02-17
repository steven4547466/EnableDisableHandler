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
            while (Process.GetProcessesByName("YourOnlyMoveIsHUSTLE").Length != 0)
            {
                Thread.Sleep(3000);
            }
            for (int i = 0; i < args.Length; i += 2)
            {
                string p1 = args[i];
                string p2 = args[i + 1];

                Console.WriteLine($"Attempting to {(p1.Contains("zip") ? "disable" : "enable")} {p1.Split('/').Last().Split('.')[0]}");
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
            Process.Start("steam://run/2212330");
        }
    }
}
