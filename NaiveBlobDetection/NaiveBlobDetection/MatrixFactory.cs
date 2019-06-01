using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandAlgorithm
{
    class MatrixFactory
    {
        private Random rand;
        public MatrixFactory()
        {
            rand = new Random();
        }

        public Matrix<int> GetRandomMatrix(int size, int min, int max)
        {
            Matrix<int> matrix = new Matrix<int>(size);

            for (int i=0; i<size; i++)
            {
                List<int> row = new List<int>();
                for (int j=0; j<size; j++)
                {
                    row.Add(rand.Next(min, max));
                }

                matrix.AddRow(row);
            }
            return matrix;
        }
    }
}
