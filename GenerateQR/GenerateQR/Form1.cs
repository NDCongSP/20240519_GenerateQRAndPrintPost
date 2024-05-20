using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateQR
{
    public partial class Form1 : Form
    {
        PrintClass _print = new PrintClass();
        QRGenerateClass _qr = new QRGenerateClass();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string qrString = "P0001|202404/001/NK|13/04/2024|1";
            var qr = _qr.ByteToImage(_qr.GenerateQRCode(qrString));

            pictureBox1.Image = qr;

            _print.QrString = qrString;
            _print.QR = qr;
            _print.StartPrint("XP-80C");
        }


    }
}
