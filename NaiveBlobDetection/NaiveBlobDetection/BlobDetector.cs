using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveBlobDetection
{
    internal class ElementCoveredEventArgs : EventArgs
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class BlobDetector
    {
        public event EventHandler<ElementCoveredEventArgs> ElementCovered;
        public event EventHandler AllBlobsDetected;

        public void Detect(Matrix<EN_EL> source)
        {
            for (int y=0; y < source.Height; y++)
            {
                for (int x=0; x < source.Width; x++)
                {
                    if (source[x,y] != EN_EL.WHITE)
                    {
                        continue;
                    }
                    else
                    {
                        OnElementCovered(new ElementCoveredEventArgs { X = x, Y = y });
                        //System.Threading.Thread.Sleep(1);
                    }
                }
            }
            OnAllBlobsDetected(new EventArgs());
        }

        protected virtual void OnElementCovered(ElementCoveredEventArgs e)
        {
            EventHandler<ElementCoveredEventArgs> handler = ElementCovered;
            handler?.Invoke(this, e);
        }

        protected virtual void OnAllBlobsDetected(EventArgs e)
        {
            EventHandler handler = AllBlobsDetected;
            handler?.Invoke(this, e);
        }
    }
}
