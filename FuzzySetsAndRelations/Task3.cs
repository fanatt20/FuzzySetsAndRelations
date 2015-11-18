using System;
using System.Collections.Generic;
using System.IO;

namespace FuzzySetsAndRelations
{
    internal static class Task3
    {
        private static readonly FuzzySet A =
            new FuzzySet(new List<double> {0.3, 0.4, 0.4, 0.7, 0.6, 0.1, 0.4, 0.2, 0.2, 0.6});

        private static readonly FuzzySet B =
            new FuzzySet(new List<double> {0.2, 0.3, 0.4, 0.1, 0.7, 0.3, 0.7, 0.8, 0.1, 0.2});

        private static readonly FuzzySet C =
            new FuzzySet(new List<double> {0.6, 0.4, 0, 0.5, 0.7, 0.5, 0.6, 0.8, 0.4, 0.1});

        private static readonly double _lambdaA = 0.6;
        private static readonly double _lambdaB = 0.2;
        private static readonly double _lambdaC = 0.2;

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
            stream.WriteLine("C\n" + C);

            var lst = new List<double>();
            for (var i = 0; i < A.Set.Length; i++)
            {
                var value = A[i]*_lambdaA + B[i]*_lambdaB + C[i]*_lambdaC;
                lst.Add(value < 1 ? value : 1);
            }
            var newFuzzy = new FuzzySet(lst);
            stream.WriteLine("new Fuzzy\n" + newFuzzy);

            var fuzzySumWithAlpha = A.StrongUnion(B).StrongUnion(C).GetAlphaCut(0.4);
            var fuzzyMultWithAlpha = A.StrongIntersection(B).StrongIntersection(C).GetAlphaCut(0.4);
            var fuzzyAlphaUnion = A.GetAlphaCut(0.4) | B.GetAlphaCut(0.4) | C.GetAlphaCut(0.4);
            var fuzzyAlphaIntersection = A.GetAlphaCut(0.4) & B.GetAlphaCut(0.4) & C.GetAlphaCut(0.4);
            stream.WriteLine();
            stream.WriteLine("A Strong Union B Strong Union C\n" + fuzzySumWithAlpha);
            stream.WriteLine("A U B U C\n" + fuzzyAlphaUnion);
            stream.WriteLine("Include: " + fuzzyAlphaUnion.In(fuzzySumWithAlpha));
            stream.WriteLine("(A Strong Intersection B Strong Intersection C)a\n" + fuzzyMultWithAlpha);
            stream.WriteLine("Aa∩Ba∩Ca\n" + fuzzyAlphaIntersection);
            stream.WriteLine("Include: " + fuzzyMultWithAlpha.In(fuzzyAlphaIntersection));
        }
    }
}