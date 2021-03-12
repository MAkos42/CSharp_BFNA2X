using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;

namespace CSharp_feladat
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcDict cd = new ConcDict();

            Console.WriteLine("Mészáros Ákos BFNA2X")

            cd.AddValues(100);

            Console.WriteLine(cd.Count);
            cd.PrintDict();
            Console.WriteLine("\n\n\n\n\n");

            cd.DoubleValues();
            cd.PrintDict();

            Console.WriteLine("Torolni kivant elem kulcsa/indexe:");
            string input = Console.ReadLine();
            try {
                cd.RemoveAt(int.Parse(input));
            }
            catch (FormatException)
            {
                cd.RemoveAt(input);
            }

        }
    }
}
