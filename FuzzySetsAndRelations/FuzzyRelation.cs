using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzySetsAndRelations
{
    public class FuzzyRelation
    {
        private readonly double[][] _relation;

        public FuzzyRelation(double[][] relation)
        {
            _relation = relation;
        }

        private static double[] Min(double[] left, double[] right)
        {
            return left.Select((val, i) => val > right[i] ? right[i] : val).ToArray();
        }

        private static double[] Max(double[] left, double[] right)
        {
            return left.Select((val, i) => val < right[i] ? right[i] : val).ToArray();
        }

        public string IsTrasintive() //using maxmin composition
        {
            for (var i = 0; i < _relation.Length; i++)
            {
                for (var j = 0; j < _relation[0].Length; j++)
                {
                    var buff = Min(_relation[i].Select(val => val).ToArray(), _relation.GetColumn(j)).Max();
                    if (_relation[i][j] < buff)
                        return $"Error at i={i} j={j}.  {_relation[i][j]} <{buff}";
                }
            }
            return "Is Transitive";
        }

        public bool IsIn(FuzzyRelation other)
        {
            for (var i = 0; i < _relation.Length; i++)
            {
                for (var j = 0; j < _relation[i].Length; j++)
                {
                    if (_relation[i][j] > other._relation[i][j])
                        return false;
                }
            }
            return true;
        }

        public FuzzyRelation Invert()
        {
            return new FuzzyRelation(_relation.Select((ar, i) => _relation.GetColumn(i)).ToArray());
        }

        public FuzzyRelation GetStrongPreferenceRelation()
        {
            return this/Invert();
        }

        public double[] GetSetOfNonDominatedAlternatives()
        {
            return GetStrongPreferenceRelation()._relation.Transpose().Select(ar => 1 - ar.Max()).ToArray();
        }

        public NonDomanatedAlternatives GetMostNonDominatedAlternatives()
        {
            var alternatives = GetSetOfNonDominatedAlternatives();
            var maxValue = alternatives.Max();
            var result = new NonDomanatedAlternatives();
            for (var i = 0; i < alternatives.Length; i++)
            {
                if (Math.Abs(alternatives[i] - maxValue) < 1e-10)
                    result.Values.Add((i + 1).ToString(), alternatives[i]);
            }
            return result;
        }

        public static FuzzyRelation operator |(FuzzyRelation left, FuzzyRelation right)
        {
            return new FuzzyRelation(left._relation.Select((ar, i) => Max(ar, right._relation[i])).ToArray());
        }

        public static FuzzyRelation operator &(FuzzyRelation left, FuzzyRelation right)
        {
            return new FuzzyRelation(left._relation.Select((ar, i) => Min(ar, right._relation[i])).ToArray());
        }

        public static FuzzyRelation operator -(FuzzyRelation relation)
        {
            return new FuzzyRelation(relation._relation.Select(ar => ar.Select(val => 1 - val).ToArray()).ToArray());
        }

        public static FuzzyRelation operator /(FuzzyRelation left, FuzzyRelation right)
        {
            return
                new FuzzyRelation(
                    left._relation.Select(
                        (ar, i) =>
                            ar.Select((val, j) => val > right._relation[i][j] ? (val - right._relation[i][j]) : 0)
                                .ToArray()).ToArray());
        }

        public static FuzzyRelation MaxMinComposition(FuzzyRelation first, FuzzyRelation second)
        {
            var firstCount = first._relation.Length;
            var secondCount = second._relation[0].Length;
            var result = new double[firstCount][];
            for (var i = 0; i < firstCount; i++)
            {
                result[i] = new double[secondCount];
                for (var j = 0; j < secondCount; j++)
                {
                    var firstRow = first._relation[i];
                    var secondColumn = second._relation.Select(ar => ar[j]).ToArray();
                    result[i][j] = Min(firstRow, secondColumn).Max();
                }
            }
            return new FuzzyRelation(result);
        }

        public static FuzzyRelation MinMaxComposition(FuzzyRelation first, FuzzyRelation second)
        {
            var firstCount = first._relation.Length;
            var secondCount = second._relation[0].Length;
            var result = new double[firstCount][];
            for (var i = 0; i < firstCount; i++)
            {
                result[i] = new double[secondCount];
                for (var j = 0; j < secondCount; j++)
                {
                    var firstRow = first._relation[i];
                    var secondColumn = second._relation.Select(ar => ar[j]).ToArray();
                    result[i][j] = Max(firstRow, secondColumn).Min();
                }
            }
            return new FuzzyRelation(result);
        }

        public static FuzzyRelation MaxMultComposition(FuzzyRelation first, FuzzyRelation second)
        {
            var firstCount = first._relation.Length;
            var secondCount = second._relation[0].Length;
            var result = new double[firstCount][];
            for (var i = 0; i < firstCount; i++)
            {
                result[i] = new double[secondCount];
                for (var j = 0; j < secondCount; j++)
                {
                    var firstRow = first._relation[i];
                    var secondColumn = second._relation.Select(ar => ar[j]).ToArray();

                    result[i][j] = secondColumn.Select((d, k) => d*firstRow[k]).Max();
                }
            }
            return new FuzzyRelation(result);
        }

        public override string ToString()
        {
            return _relation.Aggregate(new StringBuilder(),
                (builder, val) =>
                    builder.Append(
                        val.Aggregate(new StringBuilder(), (build, d) => build.Append(d).Append('\t')).ToString())
                        .Append('\n')).ToString();
        }

        public class NonDomanatedAlternatives
        {
            public Dictionary<string, double> Values = new Dictionary<string, double>();

            public override string ToString()
            {
                return
                    Values.Aggregate(new StringBuilder(),
                        (builder, pair) =>
                            builder.Append("Variable number:")
                                .Append(pair.Key)
                                .Append('\t')
                                .Append("Value: ")
                                .Append(pair.Value)
                                .Append('\n')).ToString();
            }
        }
    }
}