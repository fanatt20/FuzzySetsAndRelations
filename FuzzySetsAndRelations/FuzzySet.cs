using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzySetsAndRelations
{
    public class FuzzySet
    {
        public FuzzySet(IEnumerable<double> set)
        {
            Set = set.ToArray();
        }

        public double[] Set { get; }

        public double this[int i] => Set[i];

        protected bool Equals(FuzzySet other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((FuzzySet) obj);
        }

        public override int GetHashCode()
        {
            return (Set != null ? Set.GetHashCode() : 0);
        }

        public FuzzySet GetAlphaCut(double alpha)
        {
            return new FuzzySet(Set.Select(val => val >= alpha ? val : 0));
        }

        public bool In(FuzzySet other)
        {
            return Set.Select((val, i) => other[i] < val).Any();
        }

        public FuzzySet StrongUnion(FuzzySet other)
        {
            return new FuzzySet(Set.Select((val, i) => ((other[i] + val) < 1) ? other[i] + val : 1));
        }

        public FuzzySet StrongIntersection(FuzzySet other)
        {
            return new FuzzySet(Set.Select((v, i) => other.Set[i]*v));
        }

        public static FuzzySet operator |(FuzzySet left, FuzzySet right)
        {
            return new FuzzySet(left.Set.Select((num, i) => num > right[i] ? num : right[i]));
        }

        public static FuzzySet operator -(FuzzySet left)
        {
            return new FuzzySet(left.Set.Select(num => 1 - num).ToArray());
        }

        public static FuzzySet operator &(FuzzySet left, FuzzySet right)
        {
            return new FuzzySet(left.Set.Select((num, i) => num < right[i] ? num : right[i]));
        }

        public static FuzzySet operator *(FuzzySet left, FuzzySet right)
        {
            return new FuzzySet(left.Set.Select((num, i) => num*right[i]));
        }

        public static FuzzySet operator /(FuzzySet left, FuzzySet right)
        {
            return new FuzzySet(left.Set.Select((val, i) => ((val - right[i]) > 0 ? val - right[i] : 0)));
        }

        public override string ToString()
        {
            return Set.Aggregate(new StringBuilder(), (builder, value) => builder.Append(value).Append('\t')).ToString();
        }

        public static bool operator ==(FuzzySet left, FuzzySet right)
        {
            return !left.Set.Where(((d, i) => Math.Abs(d - right[i]) > 1e-5)).Any();
        }

        public static bool operator !=(FuzzySet left, FuzzySet right)
        {
            return !(left == right);
        }
    }
}