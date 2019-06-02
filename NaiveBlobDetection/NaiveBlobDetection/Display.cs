using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaiveBlobDetection
{
    public partial class Display : Form
    {
        private MatrixFactory _matrixFactory;
        public Display()
        {
            InitializeComponent();
            _matrixFactory = new MatrixFactory();
            CreateBitmapAtRuntime();
        }

        public void CreateBitmapAtRuntime()
        {
            Bitmap randomBlackWhiteImage = new Bitmap(pictureBoxSource.Width, pictureBoxSource.Height);
            Graphics gfx = Graphics.FromImage(randomBlackWhiteImage);
            //Matrix<int> blackWhiteMatrix = _matrixFactory.GetRandomMatrix(pictureBoxSource.Width, pictureBoxSource.Height, 0, 2); // [0, 2)
            Matrix<int> blackWhiteMatrix = _matrixFactory.GetMatrixFromImage(@"cartoon_0.jpg");

            for (int y = 0; y < blackWhiteMatrix.Height; y++)
            {
                for (int x = 0; x < blackWhiteMatrix.Width; x++)
                {
                    if (blackWhiteMatrix[x,y] == 0)
                        gfx.FillRectangle(Brushes.Black, new Rectangle(x, y, 1, 1));
                    else
                        gfx.FillRectangle(Brushes.White, new Rectangle(x, y,1, 1));
                }
            }
            pictureBoxSource.Image = randomBlackWhiteImage;

        }
    }
}
