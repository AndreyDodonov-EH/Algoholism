using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveBlobDetection
{
    class Matrix<T>
    {
        public int Width => _matrix[0].Count;
        public int Height => _matrix.Count;

        public T this[int x, int y]
        {
            get { return _matrix[y][x]; }
            set { _matrix[y][x] = value; }
        }

        private List<List<T>> _matrix;
        public Matrix()
        {
            _matrix = new List<List<T>>();
        }

        public void AddRow(List<T> row)
        {
            _matrix.Add(row);
        }
    }
}
