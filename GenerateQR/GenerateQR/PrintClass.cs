using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.IO;

namespace GenerateQR
{
    public class PrintClass
    {
        Bitmap _qr;
        public Bitmap QR
        {
            get { return _qr; }
            set { _qr = value; }
        }

        string _qrString;

        public string QrString
        {
            get { return _qrString; }
            set { _qrString = value; }
        }

        private void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;
            Font font = new Font("Cambria", 12);
            float FontHeight = font.GetHeight();
            int startX = 10;
            int startY = 10;
            int offset = 60;
            graphic.DrawString("                             Datetime:" + DateTime.Now.ToString("dd/MM/yy HH:mm:ss"), new Font("Cambria", 9, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY);
            offset = offset + (int)FontHeight;
            graphic.DrawString("===========================", font, new SolidBrush(Color.Black), startX, startY + 9);
            //Image i = Image.FromFile(".\\logo.png");
            Image i = QR;
            Point p = new Point(50, 50);
            graphic.DrawImage(i, startX + 35, startY + 24, i.Width, i.Height);
            offset = offset + 9; //make the spacing consistent
            //graphic.DrawString("CÔNG TY TNHH NU SKIN", new Font("Cambria", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX + 30, startY + offset);
            //offset = offset + (int)FontHeight ; //make the spacing consistent
            //graphic.DrawString("ENTERPRISES VIỆT NAM", new Font("Cambria", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX + 30, startY + offset);
            //offset = offset + 9; //make the spacing consistent
            graphic.DrawString("        ----------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)FontHeight; //make the spacing consistent
            graphic.DrawString("PHIẾU SỐ THỨ TỰ", font, new SolidBrush(Color.Black), startX + 62, startY + offset);
            offset = offset + (int)FontHeight; //make the spacing consistent              
            graphic.DrawString("1234", new Font("Cambria", 40, FontStyle.Bold), new SolidBrush(Color.Black), startX + 55, startY + offset);
            offset = offset + (int)FontHeight + 40; //make the spacing consistent              
            graphic.DrawString("DV: " + "3455", new Font("Cambria", 7, FontStyle.Bold), new SolidBrush(Color.Black), 5, startY + offset + 6);
            offset = offset + (int)FontHeight + 2; //make the spacing consistent   
            graphic.DrawString("Quầy phục vụ: " + "10", new Font("Cambria", 13, FontStyle.Bold), new SolidBrush(Color.Black), 5, startY + offset + 2);
            offset = offset + (int)FontHeight + 10; //make the spacing consistent
            //graphic.DrawString("    Quý khách giữ phiếu cẩn thận,", new Font("Cambria", 11, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            //offset = offset + (int)FontHeight; //make the spacing consistent
            graphic.DrawString("       Vui lòng lấy số lại nếu qua số thứ tự!", new Font("Cambria", 9, FontStyle.Bold), new SolidBrush(Color.Black), 1, startY + offset);
            offset = offset + (int)FontHeight; //make the spacing consistent
            graphic.DrawString("===========================", font, new SolidBrush(Color.Black), startX, startY + offset);
        }

        private void CreateReceiptQr(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;
            Font font = new Font("Cambria", 9);
            float FontHeight = font.GetHeight();
            int startX = 5;
            int startY = 5;
            int offset = 5;
            graphic.DrawString(DateTime.Now.ToString("dd/MM/yy HH:mm:ss"), new Font("Cambria", 9, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY);
            offset = offset + (int)FontHeight;
            graphic.DrawString("--------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + 10);
            offset = offset + (int)FontHeight;

            Image i = _qr;
            Point p = new Point(50, 50);
            graphic.DrawImage(i, startX + offset, startY + 20, i.Width, i.Height);
            offset = offset + (int)FontHeight; //make the spacing consistent              
            graphic.DrawString(_qrString, font, new SolidBrush(Color.Black), startX, startY + i.Height + 10);
        }

        public void StartPrint(string printName)
        {
            //MessageBox.Show("so in :" + so_in +"\r\n"+ "so goi :" + so_goi + "\r\n"+"so quay :" + so_quay + "\r\n");
            try
            {
                PrintDocument _PrintDocument = new PrintDocument();
                _PrintDocument.PrinterSettings.PrinterName = printName;
                if (_PrintDocument.PrinterSettings.IsValid)
                {
                    _PrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceiptQr);
                    _PrintDocument.Print();
                }
                else
                {
                    MessageBox.Show("Máy In Không Tồn Tại!");
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
