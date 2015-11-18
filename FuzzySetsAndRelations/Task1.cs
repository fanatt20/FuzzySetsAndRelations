using System;
using System.Collections.Generic;
using System.IO;

namespace FuzzySetsAndRelations
{
    internal static class Task1
    {
        public static FuzzySet A = new FuzzySet(new List<double> { 0.1, 1, 0, 0.2, 0.1, 0.4, 0.6, 0.2, 0.7, 0, 0.3, 0 });

        public static FuzzySet B =
            new FuzzySet(new List<double> { 0.1, 0.8, 0.4, 0.7, 1, 0, 0.1, 0.3, 0.3, 0.2, 0.6, 0.9 });

        public static void WriteToConsole()
        {
            var buf = Console.Out;
            using (var sw = new StreamWriter(Console.OpenStandardOutput()))
            {
                sw.AutoFlush = true;
                Console.SetOut(sw);
                WriteToStream(sw);
            }
            Console.SetOut(buf);
        }

        public static void WriteToStream(StreamWriter stream)
        {
            stream.WriteLine("A\n" + A);
            stream.WriteLine("B\n" + B);
            stream.WriteLine("AUB\n" + (A | B));
            stream.WriteLine("A∩B\n" + (A & B));
            stream.WriteLine("-A\n" + (-A));
            stream.WriteLine("-B\n" + (-B));
            stream.WriteLine("A/B\n" + (A / B));
            stream.WriteLine("A Strong Union B \n" + (A.StrongUnion(B)));
            stream.WriteLine("A Strong Intersection B\n" + (A.StrongIntersection(B)));
            stream.WriteLine("A∩(B/(-A))\n" + (A & (B / (-A))));
        }
    }
}