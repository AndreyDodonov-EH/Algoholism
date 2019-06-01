using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslandAlgorithm
{
    class Matrix<T>
    {
        private List<List<T>> _matrix;
        public Matrix(int size = 0)
        {
            _matrix = new List<List<T>>(size);
        }

        public void AddRow(List<T> row)
        {
            _matrix.Add(row);
        }
    }
}
