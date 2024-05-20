using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;

namespace BlazorApp1
{
    public class QRGenerateClass
    {
        public byte[] GenerateQRCode(string qrString)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrString, QRCodeGenerator.ECCLevel.Q))
            using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
            {
                byte[] qrCodeImage = qrCode.GetGraphic(5);

                return qrCodeImage;
            }

            return null;
        }

        //public Bitmap ByteToImage(byte[] blob)
        //{
        //    MemoryStream mStream = new MemoryStream();
        //    byte[] pData = blob;
        //    mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
        //    Bitmap bm = new Bitmap(mStream, false);
        //    mStream.Dispose();
        //    return bm;
        //}
    }
}
