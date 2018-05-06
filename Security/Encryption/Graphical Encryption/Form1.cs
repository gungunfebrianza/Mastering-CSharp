using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
 
namespace AESEncrypter
{
    public partial class Form1 : Form
    {
        public string base64strRES;
        public Form1()
        {
            InitializeComponent();
            selMode.SelectedIndex = 0;
        }
 
        #region Image to Base64
        public string ImageToBase64(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
 
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
        #endregion
 
        #region Local encryption void
        public string _Encrypt(string plaintext, string password, string IV, string salt, bool ivStart)
        {
            string hash = AESEncryption.Encrypt(plaintext, password, IV, salt);
            string final = "";
            if (ivStart == true)
            {
                final = IV + hash;
            }
            else
            {
                final = hash + IV;
            }
            return final;
        }
        #endregion
 
        #region Local decryption void
        public string _Decrypt(string input, string password, string salt, bool ivStart)
        {
            string IV = "";
            string hash = "";
            string output = "";
            try
            {
                if (ivStart == true)
                {
                    IV = input.Substring(0, 16);
                    hash = input.Substring(16);
                }
                else
                {
                    hash = input.Substring(0, input.Length - 16);
                    IV = input.Replace(hash, "");
                }
 
                output = AESEncryption.Decrypt(hash, password, IV, salt);
            }
            catch (Exception) { MessageBox.Show("Decryption failure. Please check the options you specified."); }
            return output;
        }
        #endregion
 
        private void Encrypt_Click(object sender, EventArgs e)
        {
            //input
            string IV = AESEncryption.GenerateIV();
            string plaintext = txInput1.Text;
            string salt = txSalt1.Text;
            string password = txPass1.Text;
 
            //output
            txOutput1.Text = _Encrypt(plaintext, password, IV, salt, optionStart.Checked);
        }
 
        private void Decrypt_Click(object sender, EventArgs e)
        {
            //input
            string input = txInput2.Text;
            string password = txPass2.Text;
            string salt = txSalt2.Text;
 
            //output
            txOutput2.Text = _Decrypt(input, password, salt, positionStart2.Checked);
        }
 
        private void selFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog od = new OpenFileDialog())
            {
                od.Filter = "JPG|*.jpg|PNG|*.png";
                if (od.ShowDialog() == DialogResult.OK)
                {
                    if (od.FilterIndex == 0)
                    {
                        base64strRES = ImageToBase64(Image.FromFile(od.FileName), ImageFormat.Jpeg);
                    }
                    else if (od.FilterIndex == 1)
                    {
                        base64strRES = ImageToBase64(Image.FromFile(od.FileName), ImageFormat.Png);
                    }
                }
            }
        }
 
        private void graphicCrypt_Click(object sender, EventArgs e)
        {
            if (base64strRES != null)
            {
                if (selMode.SelectedIndex == 0)
                   
                #region Graphical encryption
                {
                    string IV = AESEncryption.GenerateIV();
                    string plaintext = txInput3.Text;
                    string salt = txSalt3.Text;
                    string password = base64strRES;
 
                    txOutput3.Text = _Encrypt(plaintext, password, IV, salt, positionStart3.Checked);
                }
                #endregion
 
                else if (selMode.SelectedIndex == 1)
 
                #region Graphical decryption
                {
                    string input = txInput3.Text;
                    string password = base64strRES;
                    string salt = txSalt3.Text;
 
                    txOutput3.Text = _Decrypt(input, password, salt, positionStart3.Checked);
                }
                #endregion
            }
        }
    }
}
