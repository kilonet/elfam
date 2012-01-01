using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace elfam.web.Utils
{
    public class ImageUtils
    {
        private const int THUMB_SIZE = 200;

        public static Image ResizeImageSquare(string imageFileToResize)
        {
            return ResizeImageSquare(imageFileToResize, THUMB_SIZE);
        }

        public static Image ResizeImage(string imageFileToResize, int size)
        {
            using (Image imgToResize = Image.FromFile(imageFileToResize))
            {
                float scaleFactor = (float)Math.Max(imgToResize.Width, imgToResize.Height) / size;
                int height = (int)(imgToResize.Height / scaleFactor);
                int width = (int)(imgToResize.Width / scaleFactor);


                Bitmap b = new Bitmap(width, height);

                
                Graphics g = Graphics.FromImage(b);
                g.InterpolationMode = InterpolationMode.Default;
                g.DrawImage(imgToResize, 0, 0, width, height);
                g.Dispose();

                return b;
            }
        }

        public static Image ResizeImageSquare(string imageFileToResize, int size)
        {
            using (Image imgToResize = Image.FromFile(imageFileToResize))
            {
                float scaleFactor = (float)Math.Max(imgToResize.Width, imgToResize.Height) / size;
                int height = (int)(imgToResize.Height / scaleFactor);
                int width = (int)(imgToResize.Width / scaleFactor);


                Bitmap b = new Bitmap(size, size);

                int x = (size - width) / 2;
                int y = (size - height) / 2;
                Graphics g = Graphics.FromImage(b);
                g.InterpolationMode = InterpolationMode.Default;
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, size, size);
                g.DrawImage(imgToResize, x, y, width, height);
                g.Dispose();
                    
                return b;
            }
        }

        public static void SaveImageToFile(Image image, string path)
        {
            // Encoder parameter for image quality
            EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, 75L);

            // Jpeg image codec
            ImageCodecInfo jpegCodec = getEncoderInfo("image/jpeg");

            if (jpegCodec == null)
                return;

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            if (!Directory.Exists(Path.GetDirectoryName(path)))
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            image.Save(path, jpegCodec, encoderParams);
        }

        private static ImageCodecInfo getEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }
    }
}
