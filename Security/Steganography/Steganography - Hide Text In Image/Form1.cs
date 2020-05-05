using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Steganography;

namespace Steganography___Hide_Text_In_Image
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string imageinputPath;
        string imageoutputPath;
        string message;

        //untuk menyembunyikan pesan
        private void HideMessage(string OutPut)
        {
            try
            {
                message = textBox4.Text;
                Stegano newStegano = new Stegano();
                newStegano.HideMessage(imageinputPath, OutPut, message);
            }
            catch (Exception)
            {
                //tampilkan kotak pesan
                MessageBox.Show("Error Occured While Hide Message..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //untuk menampikan pesan
        private void ExtractMessage(string DecryptedImagePath)
        {
            try
            {
                Stegano newStegano = new Stegano();
                message = newStegano.RetriveMessage(DecryptedImagePath);
                textBox5.Text = message;
            }
            catch (Exception)
            {
                //tampilkan kotak pesan
                MessageBox.Show("Error Occured While Extract Hide Message..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void progressbarloading()
        {

            //progressbar loading effect
            progressBar1.Value = 10;
            progressBar1.Value = 20;
            progressBar1.Value = 30;
            progressBar1.Value = 40;
            progressBar1.Value = 50;
            progressBar1.Value = 60;
            progressBar1.Value = 70;
            progressBar1.Value = 80;
            progressBar1.Value = 90;
            progressBar1.Value = 100;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //button browse
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //textbox1 menyimpan alamat string dari gambar yang dipilih
                textBox1.Text = openFileDialog1.FileName.ToString();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //button convert
            Image img = Image.FromFile(textBox1.Text);

            //gambar yang dipilih dikonversi ekstensinya ke BMP
            img.Save(textBox2.Text, System.Drawing.Imaging.ImageFormat.Bmp);
      
            //progressbarloading effect
            progressbarloading();

            //tampilkan kotak pesan
            MessageBox.Show("Success! Selected Image Has Been Converted To BMP!", "Steganography - Hide Text In Image",MessageBoxButtons.OK , MessageBoxIcon.Information);

            //mengembalikan progressbar loading kesemula
            progressBar1.Value = 0;

            //membersihkan text pada textbox1
            textBox1.Clear(); 

            //membersihkan text pada textbox2
            textBox2.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            //button save to
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //textbox2 menyimpan alamat string dari lokasi penyimpanan gambar
                textBox2.Text = saveFileDialog1.FileName.ToString();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            //button browse image
            //melakukan pengaturan pada properties openfiledialog2
            openFileDialog2.InitialDirectory = "C:/";
            openFileDialog2.Filter = "Bitmaps|*.bmp|All Files|*.*";
            openFileDialog2.FilterIndex = 1;

            //menampilkan openfile dialog
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                //jika terdapat file temp.bmp 
                if (File.Exists("C:\\Temp.bmp"))
                {
                    //maka hapus file
                    File.Delete("C:\\Temp.bmp");
                }

                //kopi filename ke alamat direktori C:\temp.bmp
                File.Copy(openFileDialog2.FileName, "C:\\Temp.bmp");
                
                //ditampilkan di picturebox1
                pictureBox1.Image = Image.FromFile("C:\\Temp.bmp");
                
                //ukuran gambar dipaskan sesuai ukuran picturebox
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                
                //border pada picturebox adalah fixed3d
                pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                
                //imageinputpath adalah gambar yang telah dipilih pada openfiledialog2
                imageinputPath = openFileDialog2.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            //button hide message
            //pengaturan properties pada savefiledialog1
            saveFileDialog1.InitialDirectory = "C:/";
            saveFileDialog1.Filter = "Bitmaps|*.bmp";
            saveFileDialog1.FilterIndex = 1;
           
            // jika textbox4 kosong maka
            if (textBox4.Text != "")
            {
                //jika tidak kosong maka
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //imageoutputpath menyimpan alamat lokasi penyimpanan gambar
                    imageoutputPath = saveFileDialog1.FileName;
                    
                    //sembunyikan pesan
                    HideMessage(imageoutputPath);

                    //progressbarloading effect
                    progressbarloading();

                    //tampilkan kotak pesan
                    MessageBox.Show("Success! Selected Image contain secret Message! ","Steganography - Hide Text In Image", MessageBoxButtons.OK  , MessageBoxIcon.Information  );
                    
                    //membersihkan text
                    textBox4.Clear();

                    //kosongkan gambar
                    pictureBox1.Image = null;

                    //mengembalikan progressbar loading kesemula
                    progressBar1.Value = 0;

                }
            }
                //tampilkan kotak pesan
            else
            {
                MessageBox.Show("There is no message to hide in the image.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                //input focus pada textbox4
                textBox4.Focus();
            }
                     
            
        }

        private void button7_Click(object sender, EventArgs e)
        {

            //button browse
            //pengaturan properties pada openfiledialog1
            openFileDialog2.InitialDirectory = "C:/";
            openFileDialog2.Filter = "Bitmaps|*.bmp|All Files|*.*";
            openFileDialog2.FilterIndex = 0;

            //menampilkan openfiledialog
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {

                //picturebox1 akan menampilkan gambar dari gambar yg telah dipilih
                pictureBox1.Image = Image.FromFile(openFileDialog2.FileName);

                //ukuran gambar disesuaikan dengan ukuran picturebox1
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                //border picturebox1 adalah fixed3d
                pictureBox1.BorderStyle = BorderStyle.Fixed3D;

                //imageoutputpath adalah gambar yang telah dipilih pada openfiledialog2
                imageoutputPath = openFileDialog2.FileName;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {

            //button extract secret message
            //tampilkan pesan rahasia dari gambar yang dipilih
            ExtractMessage(imageoutputPath);
           
            //progressbarloading effect
            progressbarloading();

            //tampilkan kotak pesan
            MessageBox.Show("Extract secret Message! Success!  ", "Steganography - Hide Text In Image", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
            //mengembalikan progressbar loading kesemula
            progressBar1.Value = 0;
 
        }

        private void browseImageToConvertToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //mengeksekusi button browse image to convert
            button1.PerformClick();

        }

        private void saveConvertedImageToToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //mengeksekusi button Save Converted image to
            button3.PerformClick();

        }

        private void browseBMPImageToHideTextToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //mengeksekusi button browse BMP Image to Hide text
            button4.PerformClick();

        }

        private void browseBMPImageToExtractTextToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //mengeksekusi button browse BMP Image to Extract text
            button7.PerformClick();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //keluar dari aplikasi
            Application.Exit();
 
        }

        private void convertSelectedImageToBMPToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //mengeksekusi button Convert
            button2.PerformClick();

        }

        private void hideSecretMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //mengeksekusi button Hide Secret Message
            button5.PerformClick();

        }

        private void extractSecretMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //mengeksekusi button browse Extract Secret Message
            button6.PerformClick();

        }

        private void kaizerFamilyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //about kaizer family
            MessageBox.Show("Kaizer Family \nIs The First Indonesian IT Intelijensi \nSharing And Revealing Knowledge", "Kaizer Family", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void creditToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //thanks and credit : 
            MessageBox.Show("Thanks And Credit For : \nAnu Viswan \nKagari Vonario", "Kaizer Family", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
