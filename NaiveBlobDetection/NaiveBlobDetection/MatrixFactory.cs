using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveBlobDetection
{
    internal enum EN_EL : int
    {
        BLACK = 0,
        WHITE = 1,
        OPEN_SPACE = 2,
        BLOB = 3
    }


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

        public Matrix<EN_EL> GetBWMatrixFromImage(string filename)
        {
            Matrix<EN_EL> matrix = new Matrix<EN_EL>();

            Bitmap image = new Bitmap(filename);

            // Loop through the images pixels to reset color.
            for (int y = 0; y < image.Height; y++)
            {
                List<EN_EL> matrixRow = new List<EN_EL>();
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    EN_EL matrixElement = EN_EL.BLACK;
                    if (IsColorConventionallyWhite(pixelColor))
                    {
                        matrixElement = EN_EL.WHITE;
                    }
                    matrixRow.Add(matrixElement);
                }
                matrix.AddRow(matrixRow);
            }

            return matrix;
        }

        private bool IsColorConventionallyWhite(Color color)
        {
            return (color.R > 127 && color.G > 127 && color.B > 127);
        }
    }
}
