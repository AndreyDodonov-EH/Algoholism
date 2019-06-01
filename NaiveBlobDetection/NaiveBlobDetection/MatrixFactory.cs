using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveBlobDetection
{
    class MatrixFactory
    {
        private Random rand;
        public MatrixFactory()
        {
            rand = new Random();
        }

        /// <summary>
        ///  [min, max)
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public Matrix<int> GetRandomMatrix(int width, int height, int min, int max)
        {
            Matrix<int> matrix = new Matrix<int>();

            for (int i=0; i< height; i++)
            {
                List<int> row = new List<int>();
                for (int j=0; j< width; j++)
                {
                    row.Add(rand.Next(min, max));
                }

                matrix.AddRow(row);
            }
            return matrix;
        }
    }
}
