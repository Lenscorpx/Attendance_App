using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace Attendance_App.UserControls
{
    public partial class uc_barcode : UserControl
    {
        
        public uc_barcode()
        {
            InitializeComponent();
            txt_id_access_level.Focus();
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            try
            {
                var wrt_aztec = new BarcodeWriter();
                wrt_aztec.Format = BarcodeFormat.AZTEC;
                pic_aztec.Image = wrt_aztec.Write(txt_id_access_level.Text);
            }
            catch(Exception exc)
            {
                
            }

            try
            {
                var wrt_codabar = new BarcodeWriter();
                wrt_codabar.Format = BarcodeFormat.CODABAR;
                pic_codabar.Image = wrt_codabar.Write(txt_id_access_level.Text);
            }
            catch (Exception exc)
            {

            }

            try
            {
                var wrt_code_128 = new BarcodeWriter();
                wrt_code_128.Format = BarcodeFormat.CODE_128;
                pic_code_128.Image = wrt_code_128.Write(txt_id_access_level.Text);
            }
            catch (Exception exc)
            {

            }

            try
            {
                var wrt_code_39 = new BarcodeWriter();
                wrt_code_39.Format = BarcodeFormat.CODE_39;
                pic_code_39.Image = wrt_code_39.Write(txt_id_access_level.Text);
            }
            catch (Exception exc)
            {

            }

            try
            {
                var wrt_code_93 = new BarcodeWriter();
                wrt_code_93.Format = BarcodeFormat.CODE_93;
                pic_code_93.Image = wrt_code_93.Write(txt_id_access_level.Text);
            }
            catch (Exception exc)
            {

            }

            //try
            //{
            //    var wrt_upc_A = new BarcodeWriter();
            //    wrt_upc_A.Format = BarcodeFormat.UPC_A;
            //    pic_all1D.Image = wrt_upc_A.Write(txt_id_access_level.Text);
            //}
            //catch (Exception exc)
            //{

            //}


            //try
            //{
            //    var wrt_upc_E = new BarcodeWriter();
            //    wrt_upc_E.Format = BarcodeFormat.UPC_E;
            //    pic_imb.Image = wrt_upc_E.Write(txt_id_access_level.Text);
            //}
            //catch (Exception exc)
            //{

            //}

            //try
            //{
            //    var wrt_upc_ean_extns = new BarcodeWriter();
            //    wrt_upc_ean_extns.Format = BarcodeFormat.UPC_EAN_EXTENSION;
            //    pic_ean_8.Image = wrt_upc_ean_extns.Write(txt_id_access_level.Text);
            //}
            //catch (Exception exc)
            //{

            //}

            try
            {
                var wrt_datamatrix = new BarcodeWriter();
                wrt_datamatrix.Format = BarcodeFormat.DATA_MATRIX;
                pic_datamatrix.Image = wrt_datamatrix.Write(txt_id_access_level.Text);
            }
            catch (Exception exc)
            {

            }

            try
            {
                var wrt_ean13 = new BarcodeWriter();
                wrt_ean13.Format = BarcodeFormat.EAN_13;
                pic_Ean_13.Image = wrt_ean13.Write(txt_id_access_level.Text);
            }
            catch (Exception exc)
            {

            }

            try
            {
                var wrt_qrcode = new BarcodeWriter();
                wrt_qrcode.Format = BarcodeFormat.QR_CODE;
                pic_qrcode.Image = wrt_qrcode.Write(txt_id_access_level.Text);
            }
            catch (Exception exc)
            {

            }

            //try
            //{
            //    var wrt_maxicode = new BarcodeWriter();
            //    wrt_maxicode.Format = BarcodeFormat.MAXICODE;
            //    pic_ITF.Image = wrt_maxicode.Write(txt_id_access_level.Text);
            //}
            //catch (Exception exc)
            //{

            //}   
            try
            {
                var wrt_ean8 = new BarcodeWriter();
                wrt_ean8.Format = BarcodeFormat.EAN_8;
                pic_ean_8.Image = wrt_ean8.Write(txt_id_access_level.Text);
            }
            catch (Exception exc)
            {

            }
            try
            {
                var wrt_all1D = new BarcodeWriter();
                wrt_all1D.Format = BarcodeFormat.All_1D;
                pic_all1D.Image = wrt_all1D.Write(txt_id_access_level.Text);
            }
            catch (Exception exc)
            {

            }
            try
            {
                var wrt_imb = new BarcodeWriter();
                wrt_imb.Format = BarcodeFormat.IMB;
                pic_imb.Image = wrt_imb.Write(txt_id_access_level.Text);
            }
            catch (Exception exc)
            {

            }
            try
            {
                var wrt_itf = new BarcodeWriter();
                wrt_itf.Format = BarcodeFormat.ITF;
                pic_ITF.Image = wrt_itf.Write(txt_id_access_level.Text);
            }
            catch (Exception exc)
            {

            }
        }
        public static void Enregistrer_Barcode(Image image)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.FileName = "RVA-Codebar";// Default file name
            s.DefaultExt = ".png";// Default file extension
            s.Filter = "Image (.png)|*.png"; // Filter files by extension

            // Below are two examples of setting the initial (default) folder - choose one

            // 1. example of setting the default folder to a special folder
            s.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // 2 example of setting the default folder to an absolute path
            //s.InitialDirectory = ("C:\\Temp");

            // setting the RestoreDirectory property to true causes the
            // dialog to restore the current directory before closing
            //s.RestoreDirectory = true;
            // Show save file dialog box
            // Process save file dialog box results
            if (s.ShowDialog() == DialogResult.OK)
            {
                // Save Image
                string filename = s.FileName;
                // the using statement causes the FileStream's dispose method to be
                // called when the object goes out of scope
                using (System.IO.FileStream fstream = new System.IO.FileStream(filename, System.IO.FileMode.Create))
                {
                    image.Save(fstream, System.Drawing.Imaging.ImageFormat.Png);
                    fstream.Close();
                }
            }
        }
        private void btn_enregistrer_code_128_Click(object sender, EventArgs e)
        {
            Enregistrer_Barcode(pic_code_128.Image);
        }

        private void btn_code_39_Click(object sender, EventArgs e)
        {
            Enregistrer_Barcode(pic_code_39.Image);
        }

        private void btn_enregistrer_codabar_Click(object sender, EventArgs e)
        {
            Enregistrer_Barcode(pic_codabar.Image);
        }

        private void btn_enregistrer_ean_8_Click(object sender, EventArgs e)
        {
            Enregistrer_Barcode(pic_ean_8.Image);
        }

        private void btn_enregistrer_code_93_Click(object sender, EventArgs e)
        {
            Enregistrer_Barcode(pic_code_93.Image);
        }

        private void btn_enreg_aztec_Click(object sender, EventArgs e)
        {
            Enregistrer_Barcode(pic_aztec.Image);
        }

        private void btn_all1D_Click(object sender, EventArgs e)
        {
            Enregistrer_Barcode(pic_all1D.Image);
        }

        private void btn_enreg_imb_Click(object sender, EventArgs e)
        {
            Enregistrer_Barcode(pic_imb.Image);
        }

        private void btn_enreg_datamatrix_Click(object sender, EventArgs e)
        {
            Enregistrer_Barcode(pic_datamatrix.Image);
        }

        private void btn_enreg_qrcode_Click(object sender, EventArgs e)
        {
            Enregistrer_Barcode(pic_qrcode.Image);
        }

        private void btn_enreg_ean13_Click(object sender, EventArgs e)
        {
            Enregistrer_Barcode(pic_Ean_13.Image);
        }

        private void btn_enreg_ITF_Click(object sender, EventArgs e)
        {
            Enregistrer_Barcode(pic_ITF.Image);
        }
    }
}
