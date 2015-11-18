using System;
using System.IO;

namespace FuzzySetsAndRelations
{
    internal static class Task6
    {
        private static readonly FuzzyRelation X = new FuzzyRelation(new[]
        {
            new[] {0.1, 0.2, 0.3, 0.9},
            new[] {0.4, 0.8, 0.5, 0.3},
            new[] {0.4, 0.8, 0.2, 0.9},
            new[] {0.2, 0.2, 0.7, 0.2}
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
            stream.WriteLine(X);
            stream.WriteLine("Is transitive by MaxMin: " +
                             FuzzyRelation.MaxMinComposition(X, X).IsIn(X));
            stream.WriteLine("Is transitive by MaxMult: " +
                             FuzzyRelation.MaxMultComposition(X, X).IsIn(X));
            stream.WriteLine("Is transitive by Minmax: " +
                             FuzzyRelation.MinMaxComposition(X, X).IsIn(X));
        }
    }
}