using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Cryptographic_Hash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SHA384 sha384Hash = SHA384.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(textBox1.Text);
                byte[] hashBytes = sha384Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
				textBox2.Text = ComputeHash(textBox1.Text, comboBox1.Text, Encoding.ASCII.GetBytes(textBox3.Text));
            }

        }


		public static string ComputeHash(string plainText, string hash, byte[] salt)
		{
			int minSaltLength = 4, maxSaltLength = 16;

			byte[] saltBytes = null;
			if (salt != null)
			{
				saltBytes = salt;
			}
			else
			{
				Random r = new Random();
				int SaltLength = r.Next(minSaltLength, maxSaltLength);
				saltBytes = new byte[SaltLength];
				RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
				rng.GetNonZeroBytes(saltBytes);
				rng.Dispose();
			}

			byte[] plainData = ASCIIEncoding.UTF8.GetBytes(plainText);
			byte[] plainDataWithSalt = new byte[plainData.Length + saltBytes.Length];

			for (int x = 0; x < plainData.Length; x++)
				plainDataWithSalt[x] = plainData[x];
			for (int n = 0; n < saltBytes.Length; n++)
				plainDataWithSalt[plainData.Length + n] = saltBytes[n];

			byte[] hashValue = null;

			switch (hash)
			{
				case "SHA256":
					SHA256Managed sha = new SHA256Managed();
					hashValue = sha.ComputeHash(plainDataWithSalt);
					sha.Dispose();
					break;
				case "SHA384":
					SHA384Managed sha1 = new SHA384Managed();
					hashValue = sha1.ComputeHash(plainDataWithSalt);
					sha1.Dispose();
					break;
				case "SHA512":
					SHA512Managed sha2 = new SHA512Managed();
					hashValue = sha2.ComputeHash(plainDataWithSalt);
					sha2.Dispose();
					break;
			}

			byte[] result = new byte[hashValue.Length + saltBytes.Length];
			for (int x = 0; x < hashValue.Length; x++)
				result[x] = hashValue[x];
			for (int n = 0; n < saltBytes.Length; n++)
				result[hashValue.Length + n] = saltBytes[n];

			return Convert.ToBase64String(result);
		}

		public static bool Confirm(string plainText, string hashValue, string hash, byte[] salt)
		{
			byte[] hashBytes = Convert.FromBase64String(hashValue);
			int hashSize = 0;

			switch (hash)
			{
				case "SHA256":
					hashSize = 32;
					break;
				case "SHA384":
					hashSize = 48;
					break;
				case "SHA512":
					hashSize = 64;
					break;
			}

			byte[] saltBytes = new byte[hashBytes.Length - hashSize];

			for (int x = 0; x < saltBytes.Length; x++)
				saltBytes[x] = hashBytes[hashSize + x];

			string newHash = ComputeHash(plainText, hash, saltBytes);

			return (hashValue == newHash);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			bool result = Confirm(textBox1.Text, textBox2.Text, comboBox1.Text, Encoding.ASCII.GetBytes(textBox3.Text));
			if (result == true)
			{
				MessageBox.Show("Authentic!", "Cryptographic Hash", MessageBoxButtons.OK, MessageBoxIcon.Information);
			} else
			{
				MessageBox.Show("Not Authentic!", "Cryptographic Hash", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
		}

		private void button3_Click(object sender, EventArgs e)
		{
			textBox1.Clear();
			textBox2.Clear();
			textBox3.Clear();
		}
	}
}
