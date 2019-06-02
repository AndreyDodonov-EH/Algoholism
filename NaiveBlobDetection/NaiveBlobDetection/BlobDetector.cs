using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveBlobDetection
{
    internal class ElementInspectedEventArgs : EventArgs
    {
        public int X { get; set; }
        public int Y { get; set; }
        public EN_EL el_type { get; set; }
    }

    internal enum EN_DIR
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    class BlobDetector
    {
        public event EventHandler<ElementInspectedEventArgs> ElementInspected;
        public event EventHandler AllBlobsDetected;

        public void Detect(Matrix<EN_EL> source)
        {
            DetectOpenSpaces(source);           
        }

        private void DetectOpenSpaces(Matrix<EN_EL> source)
        {
            for(int x = 0; x < source.Width; x++) // upper border
            {
                DetectOpenSpace(x, 0, source, EN_DIR.LEFT);
            }
            for (int y = 1; y < source.Height-1; y++) // right border
            {
                DetectOpenSpace(source.Width-1, y, source, EN_DIR.UP);
            }
            for (int x = source.Width-1; x >= 0; x--) // lower border
            {
                DetectOpenSpace(x, source.Height-1, source, EN_DIR.RIGHT);
            }
            for (int y = source.Height - 1; y > 0; y--) // left border
            {
                DetectOpenSpace(0, y, source, EN_DIR.DOWN);
            }
        }

        private void DetectOpenSpace(int x, int y, Matrix<EN_EL> source, EN_DIR whereFrom)
        {
            while(y < source.Height && EN_EL.WHITE == source[x, y])
            {
                while (x < source.Width && EN_EL.WHITE == source[x, y])
                {
                    source[x, y] = EN_EL.OPEN_SPACE;
                    x++;
                    OnElementInspected(new ElementInspectedEventArgs { X = x, Y = y, el_type = EN_EL.OPEN_SPACE});
                    //System.Threading.Thread.Sleep(5);
                }
                x = 0;
                y++;
            }
        }

        private void DetectBlobs(Matrix<EN_EL> source)
        {
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    if (EN_EL.WHITE != source[x, y])
                    {
                        continue;
                    }
                    else
                    {

                        OnElementInspected(new ElementInspectedEventArgs { X = x, Y = y });
                        //System.Threading.Thread.Sleep(1);
                    }
                }
            }
            OnAllBlobsDetected(new EventArgs());
        }

        protected virtual void OnElementInspected(ElementInspectedEventArgs e)
        {
            EventHandler<ElementInspectedEventArgs> handler = ElementInspected;
            handler?.Invoke(this, e);
        }

        protected virtual void OnAllBlobsDetected(EventArgs e)
        {
            EventHandler handler = AllBlobsDetected;
            handler?.Invoke(this, e);
        }
    }
}
