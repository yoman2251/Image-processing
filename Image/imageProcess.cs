using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Emgu.CV.UI;
using System.Windows.Forms;

namespace Image
{
    class imageProcess
    {       
        public Image<Bgr, Byte> source_frame = null;
        public Image<Bgr, Byte> result_frame = null;
        public Image<Bgr, Byte> flip_frame = null;
        public Image<Bgr, Byte> smoothed_frame = null;
        public Image<Bgr, Byte> facedetect_frame = null;
        public Image<Bgr, Byte> temp_frame;
        public Image<Gray, Byte> grayframe;
        public Image<Gray, Single> img_final;
        private int width;
        private int height;
        private CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt2.xml");

        public void initializeData()
        {
            if (source_frame == null) return;
            width = source_frame.Width;
            height = source_frame.Height;
            temp_frame = new Image<Bgr, Byte>(width, height, new Bgr(0, 0, 0));
            result_frame = new Image<Bgr, Byte>(width, height, new Bgr(0, 0, 0));
            flip_frame = new Image<Bgr, Byte>(width, height, new Bgr(0, 0, 0));
            smoothed_frame = new Image<Bgr, Byte>(width, height, new Bgr(0, 0, 0));
        }
        
        public void gray()
        {
             temp_frame = source_frame.Clone();

             for (int y = 0; y < height; y++)
             {
                 for (int x = 0; x < width; x++)
                 {
                     byte pixelB = temp_frame.Data[y, x, 0];
                     byte pixelG = temp_frame.Data[y, x, 1];
                     byte pixelR = temp_frame.Data[y, x, 2];
                     byte grayPixel = (byte)((pixelB + pixelG + pixelR) / 3);
                     result_frame.Data[y, x, 0] = grayPixel;
                     result_frame.Data[y, x, 1] = grayPixel;
                     result_frame.Data[y, x, 2] = grayPixel;
                 }
             }
        }

        public void binarization()
        {
            Image<Gray, byte> binary_frame = source_frame.Clone().Convert<Gray, byte>();
            result_frame = (binary_frame.ThresholdBinary(new Gray(127), new Gray(255))).Convert<Bgr, byte>();
        }

        public void negative()
        {
            temp_frame = source_frame.Clone();
            for (int y = 0; y < height - 1; y++)
            {
                for (int x = 0; x < width - 1; x++)
                {
                    result_frame.Data[y, x, 0] = (byte)(255 - temp_frame.Data[y, x, 0]);
                    result_frame.Data[y, x, 1] = (byte)(255 - temp_frame.Data[y, x, 1]);
                    result_frame.Data[y, x, 2] = (byte)(255 - temp_frame.Data[y, x, 2]);
                }
            }
        }

        public void relief()
        {
            temp_frame = source_frame.Clone();
            for (int y = 0; y < height - 1; y++)
            {
                for (int x = 0; x < width - 1; x++)
                {
                    byte pixelB1 = temp_frame.Data[y, x, 0];
                    byte pixelG1 = temp_frame.Data[y, x, 1];
                    byte pixelR1 = temp_frame.Data[y, x, 2];
                    byte pixelB2 = temp_frame.Data[y + 1, x + 1, 0];
                    byte pixelG2 = temp_frame.Data[y + 1, x + 1, 1];
                    byte pixelR2 = temp_frame.Data[y + 1, x + 1, 2];
                    byte R = (byte)(Math.Abs(pixelR1 - pixelR2 + 128));
                    byte G = (byte)(Math.Abs(pixelG1 - pixelG2 + 128));
                    byte B = (byte)(Math.Abs(pixelB1 - pixelB2 + 128));
                    if (R > 255)    R = 255;
                    if (R < 0)      R = 0;

                    if (G > 255)    G = 255;
                    if (G < 0)      G = 0;

                    if (B > 255)    B = 255;
                    if (B < 0)      B = 0;

                    result_frame.Data[y, x, 0] = B;
                    result_frame.Data[y, x, 1] = G;
                    result_frame.Data[y, x, 2] = R;
                }
            }
        }

        public void edge()
        {
            temp_frame = source_frame.Clone();
            grayframe = temp_frame.Convert<Gray, byte>();
            img_final = grayframe.Sobel(0, 1, 3).Add(grayframe.Sobel(1, 0, 3)).AbsDiff(new Gray(0.0));
        }

        public void horizontal(Image<Bgr, Byte> frame)
        {
            temp_frame = frame.Clone();
            for (int y = 0; y < height ; y++)
                for (int x = 0; x < width ; x++)
                {
                    flip_frame.Data[y, x, 2] = temp_frame.Data[y,width - x - 1,2];
                    flip_frame.Data[y, x, 1] = temp_frame.Data[y, width - x - 1, 1];
                    flip_frame.Data[y, x, 0] = temp_frame.Data[y, width - x - 1, 0];
                }
        }

        public void vertical(Image<Bgr, Byte> frame)
        {
            temp_frame = frame.Clone();
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    flip_frame.Data[y, x, 2] = temp_frame.Data[height - y - 1, x, 2];
                    flip_frame.Data[y, x, 1] = temp_frame.Data[height - y - 1, x, 1];
                    flip_frame.Data[y, x, 0] = temp_frame.Data[height - y - 1, x, 0];
                }
        }

        public void smoothed()
        {
            temp_frame = source_frame.Clone();
            grayframe = temp_frame.Convert<Gray, byte>();
            grayframe._EqualizeHist();
        }

        public void facedetect()
        {
            temp_frame = source_frame.Clone();
            Image<Gray, byte> face_frame = source_frame.Clone().Convert<Gray, byte>();
            var faces = cascadeClassifier.DetectMultiScale(face_frame, 1.1, 10, Size.Empty);
            foreach (var face in faces)
            {
                temp_frame.Draw(face, new Bgr(Color.Red), 3);
            }
            facedetect_frame = temp_frame;
        }
    }
}
