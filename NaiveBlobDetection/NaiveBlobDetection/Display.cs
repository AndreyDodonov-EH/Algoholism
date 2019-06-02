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
        BlobDetector _blobDetector;
        Matrix<EN_EL> _matrix;

        Dictionary<EN_EL, Brush> _elementToBrushMap = new Dictionary<EN_EL, Brush>()
            {
                {EN_EL.BLACK, Brushes.Black},
                {EN_EL.WHITE, Brushes.White},
                {EN_EL.COVERED, Brushes.GreenYellow}
            };

        Graphics _gfx;

        public Display()
        {
            InitializeComponent();

            _matrixFactory = new MatrixFactory();
            _blobDetector = new BlobDetector();
            _blobDetector.ElementCovered += _blobDetector_ElementCovered;
            _blobDetector.AllBlobsDetected += _blobDetector_AllBlobsDetected;

            _matrix = _matrixFactory.GetBWMatrixFromImage(@"cartoon_1.bmp");

            LoadOriginalPicture();
        }

        private void LoadOriginalPicture()
        {
            Bitmap drawArea = new Bitmap(pictureBoxSource.Width, pictureBoxSource.Height);
            _gfx = Graphics.FromImage(drawArea);

            for (int y = 0; y < _matrix.Height; y++)
            {
                for (int x = 0; x < _matrix.Width; x++)
                {
                    Brush br = _elementToBrushMap[_matrix[x, y]];
                    _gfx.FillRectangle(br, new Rectangle(x, y, 1, 1));
                }
            }
            pictureBoxSource.Image = drawArea;
        }

        private void Display_Shown_1(object sender, EventArgs e)
        {
            Task.Factory.StartNew(delegate ()
            {
                _blobDetector.Detect(_matrix);
            });
        }

        private void _blobDetector_ElementCovered(object sender, ElementCoveredEventArgs e)
        {
            _gfx.FillRectangle(Brushes.Yellow, e.X, e.Y, 1, 1);
            pictureBoxSource.Invalidate();
        }

        private void _blobDetector_AllBlobsDetected(object sender, EventArgs e)
        {
            
        }
    }
}
