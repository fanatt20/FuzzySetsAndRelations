using System;
using System.IO;
using System.Linq;

namespace FuzzySetsAndRelations
{
    internal static class Task10
    {
        public static readonly FuzzyRelation X1 = new FuzzyRelation(new[]
        {
            new[] {1, 0.2, 0.4, 0.1, 0.4},
            new[] {0.8, 1, 0.5, 0.1, 0.4},
            new[] {0.2, 0.7, 1, 0.2, 0.7},
            new[] {0.1, 0.5, 0.2, 1, 0.1},
            new[] {0.4, 0.3, 0.6, 0.6, 1}
        });

        public static readonly FuzzyRelation X2 = new FuzzyRelation(new[]
        {
            new[] {1, 0.4, 0.3, 0.7, 0.4},
            new[] {0.6, 1, 0.9, 0.3, 0.3},
            new[] {0.8, 0.2, 1, 0.2, 0.1},
            new[] {0.4, 0.4, 0.1, 1, 0.2},
            new[] {0.5, 0.3, 0.2, 0.7, 1}
        });

        public static readonly FuzzyRelation X3 = new FuzzyRelation(new[]
        {
            new[] {1, 0.4, 0.2, 0.3, 0.2, 0.5},
            new[] {0.6, 1, 0.1, 0.3, 0.9, 0.6},
            new[] {0.7, 0.1, 1, 0.1, 0.1, 0.9},
            new[] {0.3, 0.9, 0.3, 1, 0.6, 0.2},
            new[] {0.7, 0.2, 0.5, 0.9, 1, 0.3},
            new[] {0.6, 0.3, 0.9, 0.1, 0.7, 1}
        });

        public static readonly FuzzyRelation X4 = new FuzzyRelation(new[]
        {
            new[] {1, 0.8, 0.4, 0.5, 0.6, 0.9},
            new[] {0.1, 1, 0.6, 0.3, 0.2, 0.1},
            new[] {0.4, 0.2, 1, 0.4, 0.8, 0.1},
            new[] {0.7, 0.4, 0.8, 1, 0.4, 0.3},
            new[] {0.3, 0.5, 0.5, 0.6, 1, 0.5},
            new[] {0.8, 0.9, 0.5, 0.4, 0.7, 1}
        });

        public static void WriteToConsole()
        {
            SolveTaskFor(X1, "X1");
            SolveTaskFor(X2, "X2");
            SolveTaskFor(X3, "X3");
            SolveTaskFor(X4, "X4");
            
        }

        public static void WriteToStream(StreamWriter stream)
        {
            SolveTaskForStream(stream,X1, "X1");
            SolveTaskForStream(stream,X2, "X2");
            SolveTaskForStream(stream,X3, "X3");
            SolveTaskForStream(stream,X4, "X4");
        }

        private static void SolveTaskFor(FuzzyRelation relation, string name)
        {
            Console.WriteLine(new string('~', 10)+name+new string('~', 10)+"\n" + relation);

            Console.WriteLine("GetStrongPreferenceRelation:\n" + relation.GetStrongPreferenceRelation());
            Console.WriteLine("GetSetOfNonDominatedAlternatives:\n" +
                              relation.GetSetOfNonDominatedAlternatives()
                                  .Aggregate("", (seed, val) => seed += val + "\t"));
            Console.WriteLine("Most non-dominated alternative: \n" + relation.GetMostNonDominatedAlternatives() + "\n");
        }
        private static void SolveTaskForStream(StreamWriter stream, FuzzyRelation relation, string name)
        {
            stream.WriteLine(new string('~', 10) + name + new string('~', 10) + "\n" + relation);

            stream.WriteLine("GetStrongPreferenceRelation:\n" + relation.GetStrongPreferenceRelation());
            stream.WriteLine("GetSetOfNonDominatedAlternatives:\n" +
                              relation.GetSetOfNonDominatedAlternatives()
                                  .Aggregate("", (seed, val) => seed += val + "\t"));
            stream.WriteLine("Most non-dominated alternative: \n" + relation.GetMostNonDominatedAlternatives() + "\n");
        }
    }
}