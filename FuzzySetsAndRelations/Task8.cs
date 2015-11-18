using System;
using System.IO;

namespace FuzzySetsAndRelations
{
    internal static class Task8
    {
        private static readonly FuzzyRelation A = new FuzzyRelation(new[]
        {
            new[] {0.5, 0.7, 0.6, 0.3, 0.8},
            new[] {0.9, 0.6, 0.4, 0.6, 0.4},
            new[] {0.7, 0.8, 0.7, 0.5, 0.2}
        });

        private static readonly FuzzyRelation B = new FuzzyRelation(new[]
        {
            new[] {0, 0.4, 0.9, 0.4},
            new[] {0.1, 0.8, 0.9, 0.4},
            new[] {0.3, 0.6, 0.9, 0.8},
            new[] {0.5, 0, 0.2, 0.4},
            new[] {0.4, 0.4, 0.1, 0.2}
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
            stream.WriteLine("A:\n" + A);
            stream.WriteLine("B:\n" + B);
            stream.WriteLine("MaxMinComposition :\n" + FuzzyRelation.MaxMinComposition(A, B));
            stream.WriteLine("MinMaxComposition :\n" + FuzzyRelation.MinMaxComposition(A, B));
            stream.WriteLine("MaxMultComposition :\n" + FuzzyRelation.MaxMultComposition(A, B));
        }
    }
}