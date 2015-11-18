using System;
using System.Collections.Generic;
using System.IO;

namespace FuzzySetsAndRelations
{
    internal static class Task2
    {
        private static readonly FuzzySet A =
            new FuzzySet(new List<double> {0.6, 0.4, 0.8, 0.3, 0.9, 0.4, 0.8, 0.5, 0.3, 0.3});

        private static readonly FuzzySet B =
            new FuzzySet(new List<double> {0.5, 0.6, 0.2, 0.6, 0.3, 0.8, 0.7, 0.8, 0.6, 0.7});

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

            stream.WriteLine("a=0.3\n");
            stream.WriteLine("A\n" + A.GetAlphaCut(0.3));
            stream.WriteLine("B\n" + B.GetAlphaCut(0.3));

            stream.WriteLine("a=0.8\n");
            stream.WriteLine("A\n" + A.GetAlphaCut(0.8));
            stream.WriteLine("B\n" + B.GetAlphaCut(0.8));

            stream.WriteLine("a=0.9\n");
            stream.WriteLine("A\n" + A.GetAlphaCut(0.9));
            stream.WriteLine("B\n" + B.GetAlphaCut(0.9));
            stream.WriteLine(new string('#', 20));
            stream.WriteLine("a=0.1\n");
            var AuBa = (A | B).GetAlphaCut(0.1);
            stream.WriteLine("(A U B)a\n" + AuBa);
            var ABa = (A & B).GetAlphaCut(0.1);
            stream.WriteLine("(A ∩ B)a\n" + ABa);
            var AauBa = (A.GetAlphaCut(0.1) | B.GetAlphaCut(0.1));
            stream.WriteLine("Aa U Ba\n" + AauBa);
            var AaBa = (A.GetAlphaCut(0.1) & B.GetAlphaCut(0.1));
            stream.WriteLine("Aa ∩ Ba\n" + AaBa);
            stream.WriteLine("(A ∩ B)a == Aa ∩ Ba : " + (ABa == AaBa));
            stream.WriteLine("(A U B)a == Aa U Ba : " + (AauBa == AuBa));
        }
    }
}