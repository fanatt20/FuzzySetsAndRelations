using System;
using System.IO;

namespace FuzzySetsAndRelations
{
    internal static class Task9
    {
        private static readonly FuzzyRelation X = new FuzzyRelation(new[]
        {
            new[] {0.2, 0.5, 0.3},
            new[] {0.3, 0.3, 0.5},
            new[] {0.2, 0.8, 0.9}
        });

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
            stream.WriteLine("X:\n" + X);
            var r11 = FuzzyRelation.MaxMinComposition(X, X);
            stream.WriteLine("MaxMinComposition:\n" + r11);
            var r12 = FuzzyRelation.MinMaxComposition(X, X);
            stream.WriteLine("MinMaxComposition:\n" + r12);
            var r13 = FuzzyRelation.MaxMultComposition(X, X);
            stream.WriteLine("MaxMultComposition:\n" + r13);
            stream.WriteLine("MaxMultComposition in MinMaxComposition: " + r13.IsIn(r12));
            stream.WriteLine("MinMaxComposition in MaxMinComposition: " + r12.IsIn(r11));
        }
    }
}