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


    class BlobDetector
    {
        public event EventHandler<ElementInspectedEventArgs> ElementInspected;
        public event EventHandler AllBlobsDetected;

        private Matrix<EN_EL> _M;

        public BlobDetector(Matrix<EN_EL> M)
        {
            _M = M;
        }

        public void Detect()
        {
            DetectOpenSpaces();           
        }

        private void DetectOpenSpaces()
        {
            for(int x = 0; x < _M.Width; x++) // upper border
            {
                DetectOpenSpace(x, 0);
            }
            for (int y = 1; y < _M.Height-1; y++) // right border
            {
                DetectOpenSpace(_M.Width-1, y);
            }
            for (int x = _M.Width-1; x >= 0; x--) // lower border
            {
                DetectOpenSpace(x, _M.Height-1);
            }
            for (int y = _M.Height - 1; y > 0; y--) // left border
            {
                DetectOpenSpace(0, y);
            }
        }

        private void DetectOpenSpace(int x0, int y0)
        {
            //if (EN_EL.BLACK == _M[x0, y0])
            //    return;

            //System.Threading.Thread.Sleep(1);
            int x = x0;
            int y = y0;

            if (EN_EL.WHITE == _M[x,y])
            {
                _M[x, y] = EN_EL.OPEN_SPACE;
                OnElementInspected(new ElementInspectedEventArgs { X = x, Y = y, el_type = EN_EL.OPEN_SPACE });
            }

            //x = x0;
            //for (y = y0 + 1; y < _M.Height && EN_EL.WHITE == _M[x, y]; y++)
            //{
            //    _M[x, y] = EN_EL.OPEN_SPACE;
            //    OnElementInspected(new ElementInspectedEventArgs { X = x, Y = y, el_type = EN_EL.OPEN_SPACE });
            //    //DetectOpenSpace(x, y);
            //}
            //for (y = y0 - 1; y >= 0 && EN_EL.WHITE == _M[x, y]; y--)
            //{
            //    _M[x, y] = EN_EL.OPEN_SPACE;
            //    OnElementInspected(new ElementInspectedEventArgs { X = x, Y = y, el_type = EN_EL.OPEN_SPACE });
            //    //DetectOpenSpace(x, y);
            //}

            for (y = y0 + 1, x=x0; y < _M.Height && EN_EL.WHITE == _M[x, y]; y++)
            {
                for (x = x0; x < _M.Width && EN_EL.WHITE == _M[x, y]; x++)
                {
                    _M[x, y] = EN_EL.OPEN_SPACE;
                    OnElementInspected(new ElementInspectedEventArgs { X = x, Y = y, el_type = EN_EL.OPEN_SPACE });
                    //DetectOpenSpace(x, y);
                }
                DetectOpenSpace(x, y);
                for (x = x0 - 1; x >= 0 && EN_EL.WHITE == _M[x, y]; x--)
                {
                    _M[x, y] = EN_EL.OPEN_SPACE;
                    OnElementInspected(new ElementInspectedEventArgs { X = x, Y = y, el_type = EN_EL.OPEN_SPACE });
                    //DetectOpenSpace(x, y);
                }
                DetectOpenSpace(x, y);
                x = x0;
            }
            DetectOpenSpace(x, y);
            for (y = y0 - 1; y >= 0 && EN_EL.WHITE == _M[x, y]; y--)
            {
                for (x = x0; x < _M.Width && EN_EL.WHITE == _M[x, y]; x++)
                {
                    _M[x, y] = EN_EL.OPEN_SPACE;
                    OnElementInspected(new ElementInspectedEventArgs { X = x, Y = y, el_type = EN_EL.OPEN_SPACE });
                    //DetectOpenSpace(x, y);
                }
                DetectOpenSpace(x, y);
                for (x = x0; x >= 0 && EN_EL.WHITE == _M[x, y]; x--)
                {
                    _M[x, y] = EN_EL.OPEN_SPACE;
                    OnElementInspected(new ElementInspectedEventArgs { X = x, Y = y, el_type = EN_EL.OPEN_SPACE });
                    //DetectOpenSpace(x, y);
                }
                DetectOpenSpace(x, y);
                x = x0;
            }
            DetectOpenSpace(x, y);

            y = y0;
            for (x = x0+1; x < _M.Width && EN_EL.WHITE == _M[x, y]; x++)
            {
                _M[x, y] = EN_EL.OPEN_SPACE;
                OnElementInspected(new ElementInspectedEventArgs { X = x, Y = y, el_type = EN_EL.OPEN_SPACE });
                //DetectOpenSpace(x, y);
            }
            DetectOpenSpace(x, y);
            for (x = x0-1; x >= 0 && EN_EL.WHITE == _M[x, y]; x--)
            {
                _M[x, y] = EN_EL.OPEN_SPACE;
                OnElementInspected(new ElementInspectedEventArgs { X = x, Y = y, el_type = EN_EL.OPEN_SPACE });
                //DetectOpenSpace(x, y);
            }
            DetectOpenSpace(x, y);
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
