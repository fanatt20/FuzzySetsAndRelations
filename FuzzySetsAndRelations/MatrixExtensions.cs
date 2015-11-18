using System;
using System.Linq;

namespace FuzzySetsAndRelations
{
    internal static class MatrixExtensions
    {
        public static double[][] Transpose(this double[][] data)
        {
            var sizeRow = data[0].Length;
            var sizeColumn = data.Length;
            if (data.Any(ar => ar.Length != sizeRow))
                throw new NotSupportedException();
            var result = new double[data[0].Length][];
            for (var i = 0; i < sizeRow; i++)
            {
                result[i] = new double[sizeColumn];
                for (var j = 0; j < sizeColumn; j++)
                {
                    result[i][j] = data[j][i];
                }
            }
            return result;
        }

        public static double[] GetColumn(this double[][] data, int index)
        {
            return data.Select(arr => arr[index]).ToArray();
        }
    }
}