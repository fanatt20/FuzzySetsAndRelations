using System;
using System.IO;

namespace FuzzySetsAndRelations
{
    internal static class Task7
    {
        private static readonly FuzzyRelation A = new FuzzyRelation(new[]
        {
            new[] {0.3, 0.8, 0.4, 0.9, 0.1},
            new[] {0.3, 0.5, 0.1, 0.5, 0.4},
            new[] {0.3, 0.8, 0.1, 0.7, 0.1},
            new[] {0.3, 0.1, 0.4, 0, 0.7},
            new[] {0.5, 0, 0.1, 0.9, 0.7}
        });

        private static readonly FuzzyRelation B = new FuzzyRelation(new[]
        {
            new[] {0.5, 0.2, 0.7, 0.1, 0.5},
            new[] {0.7, 0.5, 0, 0.9, 0.8},
            new[] {0.6, 0.7, 0, 0.7, 0.3},
            new[] {0.3, 0, 0.6, 0.9, 0},
            new[] {0.5, 0.2, 0.5, 0.8, 0.6}
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
            stream.WriteLine("A\n" + A);
            stream.WriteLine("B\n" + B);
            stream.WriteLine("AUB\n" + (A | B));
            stream.WriteLine("A∩B\n" + (A & B));
            stream.WriteLine("-A\n" + (-A));
            stream.WriteLine("-B\n" + (-B));
            stream.WriteLine("A/B\n" + (A/B));
            stream.WriteLine("A^-1" + A.Invert());
            stream.WriteLine("B^-1" + B.Invert());
            stream.WriteLine("A xor B" + ((A & (-B)) | ((-A) & B)));
        }
    }
}